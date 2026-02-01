using Microsoft.Data.SqlClient;
using jobTrack.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace jobTrack.Repository
{
    public class BasvuruRepository
    {
        // ARTIK BURADA YEREL _connectionString YOK, DatabaseHelper KULLANIYORUZ.

        public List<Basvuru> KullaniciBasvurulariniGetir(int bireyselId)
        {
            List<Basvuru> liste = new List<Basvuru>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                // SQL JOIN: Başvurular tablosu ile Ilanlar tablosunu birleştiriyoruz 
                // i.Sirket ve i.Baslik alanlarını Basvuru modelindeki SirketAdi ve Pozisyon ile eşleştiriyoruz.
                string query = @"SELECT b.Id, i.Sirket, i.Baslik, b.BasvuruTarihi, b.Durum 
                                 FROM Basvurular b 
                                 INNER JOIN Ilanlar i ON b.IlanId = i.Id 
                                 WHERE b.KullaniciId = @bid";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bid", bireyselId);

                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(new Basvuru
                            {
                                Id = (int)dr["Id"],
                                SirketAdi = dr["Sirket"].ToString(),
                                Pozisyon = dr["Baslik"].ToString(),
                                Tarih = (DateTime)dr["BasvuruTarihi"],
                                Durum = dr["Durum"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda boş liste döner veya loglama yapılabilir
                    Console.WriteLine("Başvuru Listeleme Hatası: " + ex.Message);
                }
            }
            return liste;
        }
        public bool BasvuruYap(int bireyselId, int ilanId)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                // Mükerrer başvuru kontrolü: Aynı kullanıcı aynı ilana tekrar başvurmasın
                string checkQuery = "SELECT COUNT(*) FROM Basvurular WHERE KullaniciId=@bid AND IlanId=@iid";
                SqlCommand cmdCheck = new SqlCommand(checkQuery, conn);
                cmdCheck.Parameters.AddWithValue("@bid", bireyselId);
                cmdCheck.Parameters.AddWithValue("@iid", ilanId);

                try
                {
                    conn.Open();
                    int mevcutBasvuru = (int)cmdCheck.ExecuteScalar();
                    if (mevcutBasvuru > 0) return false; // Zaten başvurmuşsa işlemi durdur

                    // Başvuru kaydetme
                    string query = "INSERT INTO Basvurular (KullaniciId, IlanId, BasvuruTarihi, Durum) VALUES (@bid, @iid, GETDATE(), 'Beklemede')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bid", bireyselId);
                    cmd.Parameters.AddWithValue("@iid", ilanId);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Başvuru Yapma Hatası: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
