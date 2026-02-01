using jobTrack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace jobTrack.Repository
{
    // HATA BURADAYDI: Metodu sarmalayacak bir sınıf (class) ekledik
    public class EgitimRepository
    {
        public List<Egitim> GetirByKullaniciId(int kullaniciId)
        {
            List<Egitim> liste = new List<Egitim>();

            // DatabaseHelper sınıfının ve GetConnection metodunun tanımlı olduğundan emin ol
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string query = "SELECT * FROM Egitimler WHERE KullaniciId = @kid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        liste.Add(new Egitim
                        {
                            Id = (int)dr["Id"],
                            // Veritabanı başlıklarınla (OkulAdi, Bolum, Derece) tam uyumlu
                            OkulAdi = dr["OkulAdi"]?.ToString() ?? "",
                            Bolum = dr["Bolum"]?.ToString() ?? "",
                            Derece = dr["Derece"]?.ToString() ?? "",

                            // Tarih ve Bit alanları için güvenli dönüşüm
                            BaslangicTarihi = dr["BaslangicTarihi"] != DBNull.Value ? Convert.ToDateTime(dr["BaslangicTarihi"]) : DateTime.MinValue,

                            // NULL gelebilen tarih alanı için:
                            MezuniyetTarihi = dr["MezuniyetTarihi"] != DBNull.Value ? Convert.ToDateTime(dr["MezuniyetTarihi"]) : (DateTime?)null,

                            // SQL bit (0/1) -> C# bool (false/true)
                            DevamEdiyor = dr["DevamEdiyor"] != DBNull.Value && Convert.ToBoolean(dr["DevamEdiyor"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda hata mesajını görebilmek için:
                    Console.WriteLine("Veritabanı hatası: " + ex.Message);
                }
            }
            return liste;
        }
    }
}