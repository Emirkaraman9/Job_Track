using jobTrack.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace jobTrack.Repository
{
    public class YetenekRepository
    {
        public List<Yetenek> GetirByKullaniciId(int kullaniciId)
        {
            List<Yetenek> liste = new List<Yetenek>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                // SQL başlıklarına göre sorgu (KullaniciId sütunu ile filtreleme)
                string query = "SELECT Id, YetenekAdi, Seviye FROM Yetenekler WHERE KullaniciId = @kid";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);

                try
                {
                    conn.Open();
                    // SqlDataReader'ı using içine alarak otomatik kapanmasını sağlıyoruz
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(new Yetenek
                            {
                                Id = (int)dr["Id"],
                                // KRİTİK: NULL kontrolü yaparak programın çökmesini engelliyoruz
                                YetenekAdi = dr["YetenekAdi"]?.ToString() ?? "",
                                Seviye = dr["Seviye"]?.ToString() ?? ""
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesajı yakalıyoruz
                    Console.WriteLine("Yetenek verisi çekilirken hata: " + ex.Message);
                }
            }
            return liste;
        }
    }
}