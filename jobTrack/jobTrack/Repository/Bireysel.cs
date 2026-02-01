using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using jobTrack.Models;

namespace jobTrack.Repository
{
    public class BireyselRepository : IBireysel
    {
        // 1. KAYIT EKLEME: Telefon sütunu eklendi
        public bool Ekle(Bireysel kullanici)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    string query = "INSERT INTO BireyselKullanicilar (Ad, Soyad, KullaniciAdi, Email, Okul, Sifre, Telefon) " +
                                   "VALUES (@ad, @soyad, @kadi, @email, @okul, @sifre, @tel)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ad", kullanici.Ad);
                        cmd.Parameters.AddWithValue("@soyad", kullanici.Soyad);
                        cmd.Parameters.AddWithValue("@kadi", kullanici.KullaniciAdi ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", kullanici.Email);
                        cmd.Parameters.AddWithValue("@okul", kullanici.Okul ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@sifre", kullanici.Sifre);
                        cmd.Parameters.AddWithValue("@tel", kullanici.Telefon ?? (object)DBNull.Value);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kayıt Hatası: " + ex.Message);
                return false;
            }
        }

        // 2. GİRİŞ YAP: SELECT kısmına tüm gerekli sütunlar eklendi
        public Bireysel GirisYap(string girilenVeri, string sifre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    // HATA DÜZELTME: SELECT kısmına Telefon, Okul ve KullaniciAdi eklendi
                    string query = "SELECT Id, Ad, Soyad, Email, Telefon, Okul, KullaniciAdi FROM BireyselKullanicilar " +
                                   "WHERE (KullaniciAdi=@veri OR Email=@veri) AND Sifre=@sifre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@veri", girilenVeri);
                        cmd.Parameters.AddWithValue("@sifre", sifre);

                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                return new Bireysel
                                {
                                    Id = (int)dr["Id"],
                                    Ad = dr["Ad"].ToString(),
                                    Soyad = dr["Soyad"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    // NULL kontrolü ile güvenli okuma
                                    Telefon = dr["Telefon"]?.ToString() ?? "",
                                    Okul = dr["Okul"]?.ToString() ?? "",
                                    KullaniciAdi = dr["KullaniciAdi"]?.ToString() ?? ""
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Giriş Hatası: " + ex.Message);
            }
            return null;
        }

        // 3. LİSTELEME: Tüm bilgiler çekilecek şekilde güncellendi
        public List<Bireysel> KullanicilariGetir()
        {
            List<Bireysel> liste = new List<Bireysel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    string query = "SELECT * FROM BireyselKullanicilar";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                liste.Add(new Bireysel
                                {
                                    Id = (int)reader["Id"],
                                    Ad = reader["Ad"].ToString(),
                                    Soyad = reader["Soyad"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Telefon = reader["Telefon"]?.ToString() ?? "",
                                    Okul = reader["Okul"]?.ToString() ?? ""
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Listeleme Hatası: " + ex.Message);
            }
            return liste;
        }
    }
}