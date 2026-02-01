using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using jobTrack.Models;

namespace jobTrack.Repository
{
    public class KurumsalRepository : IKurumsal
    {
        // 1. KAYIT EKLEME: Sütun isimleri SQL şemana göre düzeltildi.
        public bool Ekle(Kurumsal sirket)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    // SQL Şemasına göre SirketEmail ve SirketTelefon olarak güncellendi
                    string query = @"INSERT INTO KurumsalKullanicilar 
                                   (SirketAdi, YetkiliAd, YetkiliSoyad, SirketEmail, KurulusTarihi, SirketTelefon, Sifre, Sektor, Adres, WebSitesi) 
                                   VALUES (@sirket, @yad, @ysoyad, @email, @ktrh, @tel, @sifre, @sektor, @adres, @web)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sirket", sirket.SirketAdi);
                        cmd.Parameters.AddWithValue("@yad", sirket.YetkiliAd ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ysoyad", sirket.YetkiliSoyad ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", sirket.SirketEmail);
                        cmd.Parameters.AddWithValue("@ktrh", sirket.KurulusTarihi ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@tel", sirket.SirketTelefon ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@sifre", sirket.Sifre);
                        cmd.Parameters.AddWithValue("@sektor", sirket.Sektor ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@adres", sirket.Adres ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@web", sirket.WebSitesi ?? (object)DBNull.Value);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kurumsal Kayıt Hatası: " + ex.Message);
                return false;
            }
        }

        // 2. GİRİŞ YAP: dr["Email"] gibi hatalı okumalar düzeltildi.
        public Kurumsal GirisYap(string email, string sifre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    // Şemadaki 'SirketEmail' başlığına göre sorguluyoruz
                    string query = "SELECT * FROM KurumsalKullanicilar WHERE SirketEmail=@email AND Sifre=@sifre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@sifre", sifre);

                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                return new Kurumsal
                                {
                                    Id = (int)dr["Id"],
                                    SirketAdi = dr["SirketAdi"].ToString(),
                                    // Null güvenli okuma:
                                    YetkiliAd = dr["YetkiliAd"]?.ToString() ?? "",
                                    YetkiliSoyad = dr["YetkiliSoyad"]?.ToString() ?? "",
                                    SirketEmail = dr["SirketEmail"].ToString(),
                                    SirketTelefon = dr["SirketTelefon"]?.ToString() ?? "",
                                    Sektor = dr["Sektor"]?.ToString() ?? "",
                                    Adres = dr["Adres"]?.ToString() ?? "",
                                    WebSitesi = dr["WebSitesi"]?.ToString() ?? "",
                                    KurulusTarihi = dr["KurulusTarihi"] as DateTime?
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kurumsal Giriş Hatası: " + ex.Message);
            }
            return null;
        }

        // 3. LİSTELEME: Şirket listesini SQL başlıklarıyla dolduruyoruz.
        public List<Kurumsal> SirketleriListele()
        {
            List<Kurumsal> sirketListesi = new List<Kurumsal>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    string query = "SELECT * FROM KurumsalKullanicilar";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sirketListesi.Add(new Kurumsal
                                {
                                    Id = (int)reader["Id"],
                                    SirketAdi = reader["SirketAdi"].ToString(),
                                    SirketEmail = reader["SirketEmail"].ToString(),
                                    Sektor = reader["Sektor"]?.ToString() ?? "",
                                    WebSitesi = reader["WebSitesi"]?.ToString() ?? "",
                                    Adres = reader["Adres"]?.ToString() ?? ""
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Şirket Listeleme Hatası: " + ex.Message);
            }
            return sirketListesi;
        }
    }
}