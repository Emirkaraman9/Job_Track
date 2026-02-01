using Microsoft.Data.SqlClient;
using jobTrack.Models;
using System;
using System.Collections.Generic;

namespace jobTrack.Repository
{
    public class IlanRepository
    {
        // 1. DÜZELTME: Bağlantı dizesini her yerde değiştirmemek için merkezi DatabaseHelper'ı kullanıyoruz.
        private string ConnectionString => DatabaseHelper.ConnectionString;

        public List<Ilan> IlanlariGetir()
        {
            List<Ilan> liste = new List<Ilan>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT Id, Baslik, Sirket, Konum, Sektor, CalismaSekli, Deneyim, Maas, Nitelikler, Snippet, YayinlanmaTarihi FROM Ilanlar ORDER BY YayinlanmaTarihi DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(new Ilan
                            {
                                Id = (int)dr["Id"],
                                Baslik = dr["Baslik"]?.ToString() ?? "",
                                Sirket = dr["Sirket"]?.ToString() ?? "Belirtilmemiş",
                                Konum = dr["Konum"]?.ToString() ?? "Belirtilmemiş",
                                Sektor = dr["Sektor"]?.ToString() ?? "",
                                CalismaSekli = dr["CalismaSekli"]?.ToString() ?? "",
                                Deneyim = dr["Deneyim"]?.ToString() ?? "",
                                Maas = dr["Maas"] != DBNull.Value ? Convert.ToDecimal(dr["Maas"]) : 0,
                                Nitelikler = dr["Nitelikler"]?.ToString() ?? "",
                                Snippet = dr["Snippet"]?.ToString() ?? "",
                                // 2. DÜZELTME: Tarih alanı veritabanında boş (null) ise hata almamak için kontrol:
                                YayinlanmaTarihi = dr["YayinlanmaTarihi"] != DBNull.Value ? (DateTime)dr["YayinlanmaTarihi"] : DateTime.Now
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("İlan Getirme Hatası: " + ex.Message);
                }
            }
            return liste;
        }

        public bool BasvuruYap(int kullaniciId, int ilanId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                // 3. DÜZELTME: SQL tablonda sütun adı 'KullaniciId' olduğu için 'BireyselId' kısımları güncellendi.
                string checkQuery = "SELECT COUNT(*) FROM Basvurular WHERE KullaniciId=@bid AND IlanId=@iid";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@bid", kullaniciId);
                checkCmd.Parameters.AddWithValue("@iid", ilanId);

                try
                {
                    conn.Open();
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        return false;
                    }

                    // 4. DÜZELTME: INSERT sorgusunda sütun adları veritabanıyla (KullaniciId) eşlendi.
                    string query = "INSERT INTO Basvurular (KullaniciId, IlanId, BasvuruTarihi, Durum) " +
                                   "VALUES (@bid, @iid, GETDATE(), 'Beklemede')";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bid", kullaniciId);
                    cmd.Parameters.AddWithValue("@iid", ilanId);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Başvuru Hatası: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
