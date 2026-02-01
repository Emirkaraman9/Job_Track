using Microsoft.Data.SqlClient;
using jobTrack.Models;
using System;
using System.Collections.Generic;

namespace jobTrack.Repository
{
    public class CvRepository
    {
        // Artık merkezi DatabaseHelper.ConnectionString kullanılıyor.

        public bool CvKaydet(int kullaniciId, List<Egitim> egitimler, List<IsDeneyimi> deneyimler, List<Yetenek> yetenekler, List<Sertifika> sertifikalar)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction tr = conn.BeginTransaction(); // Bağlantı açıkken transaction başlar

                try
                {
                    // 1. ADIM: ESKİ VERİLERİ TEMİZLE (Sütun adlarını KullaniciId, tablo adlarını çoğul yaptık)
                    string deleteQuery = @"DELETE FROM Egitimler WHERE KullaniciId = @kid;
                                 DELETE FROM IsDeneyimleri WHERE KullaniciId = @kid;
                                 DELETE FROM Yetenekler WHERE KullaniciId = @kid;
                                 DELETE FROM Sertifikalar WHERE KullaniciId = @kid;";

                    using (SqlCommand delCmd = new SqlCommand(deleteQuery, conn, tr))
                    {
                        delCmd.Parameters.AddWithValue("@kid", kullaniciId);
                        delCmd.ExecuteNonQuery();
                    }

                    // 2. ADIM: EĞİTİMLERİ KAYDET (Tablo: Egitimler, Sütun: KullaniciId)
                    foreach (var e in egitimler)
                    {
                        string q = "INSERT INTO Egitimler (KullaniciId, OkulAdi, Bolum, Derece, BaslangicTarihi, MezuniyetTarihi, DevamEdiyor) VALUES (@kid, @okul, @bolum, @derece, @btar, @mtar, @devam)";
                        using (SqlCommand cmd = new SqlCommand(q, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@kid", kullaniciId);
                            cmd.Parameters.AddWithValue("@okul", e.OkulAdi);
                            cmd.Parameters.AddWithValue("@bolum", e.Bolum);
                            cmd.Parameters.AddWithValue("@derece", e.Derece ?? "Belirtilmedi");
                            cmd.Parameters.AddWithValue("@btar", e.BaslangicTarihi);
                            cmd.Parameters.AddWithValue("@mtar", e.DevamEdiyor || !e.MezuniyetTarihi.HasValue ? DBNull.Value : (object)e.MezuniyetTarihi.Value);
                            cmd.Parameters.AddWithValue("@devam", e.DevamEdiyor);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 3. ADIM: İŞ DENEYİMLERİNİ KAYDET (Tablo: IsDeneyimleri)
                    foreach (var i in deneyimler)
                    {
                        string q = "INSERT INTO IsDeneyimleri (KullaniciId, SirketAdi, Pozisyon, IsTanimi, BaslamaTarihi, AyrilmaTarihi, DevamEdiyor) VALUES (@kid, @sirket, @poz, @tanim, @btar, @atar, @devam)";
                        using (SqlCommand cmd = new SqlCommand(q, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@kid", kullaniciId);
                            cmd.Parameters.AddWithValue("@sirket", i.SirketAdi);
                            cmd.Parameters.AddWithValue("@poz", i.Pozisyon);
                            cmd.Parameters.AddWithValue("@tanim", i.IsTanimi ?? "");
                            cmd.Parameters.AddWithValue("@btar", i.BaslamaTarihi);
                            cmd.Parameters.AddWithValue("@atar", i.DevamEdiyor || !i.AyrilmaTarihi.HasValue ? DBNull.Value : (object)i.AyrilmaTarihi.Value);
                            cmd.Parameters.AddWithValue("@devam", i.DevamEdiyor);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 4. ADIM: YETENEKLERİ KAYDET (Tablo: Yetenekler)
                    foreach (var y in yetenekler)
                    {
                        string q = "INSERT INTO Yetenekler (KullaniciId, YetenekAdi, Seviye) VALUES (@kid, @yad, @sev)";
                        using (SqlCommand cmd = new SqlCommand(q, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@kid", kullaniciId);
                            cmd.Parameters.AddWithValue("@yad", y.YetenekAdi);
                            cmd.Parameters.AddWithValue("@sev", y.Seviye ?? "Belirtilmedi");
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 5. ADIM: SERTİFİKALARI KAYDET (Tablo: Sertifikalar)
                    foreach (var s in sertifikalar)
                    {
                        string q = "INSERT INTO Sertifikalar (KullaniciId, SertifikaAdi, AlindigiKurum, AlindigiTarih) VALUES (@kid, @sad, @kurum, @tarih)";
                        using (SqlCommand cmd = new SqlCommand(q, conn, tr))
                        {
                            cmd.Parameters.AddWithValue("@kid", kullaniciId);
                            cmd.Parameters.AddWithValue("@sad", s.SertifikaAdi);
                            cmd.Parameters.AddWithValue("@kurum", s.AlindigiKurum ?? "");
                            cmd.Parameters.AddWithValue("@tarih", s.AlindigiTarih ?? (object)DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    // Gerçek hatayı görmek için mutlaka burayı kullan:
                    System.Windows.Forms.MessageBox.Show("Veritabanı Hatası: " + ex.Message);
                    return false;
                }
            }
        }

        // 1. EĞİTİMLERİ GETİR
        public List<Egitim> GetirEgitimler(int kullaniciId)
        {
            List<Egitim> liste = new List<Egitim>();
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string query = "SELECT * FROM Egitimler WHERE KullaniciId = @kid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        liste.Add(new Egitim
                        {
                            OkulAdi = dr["OkulAdi"].ToString(),
                            Bolum = dr["Bolum"].ToString(),
                            Derece = dr["Derece"].ToString(),
                            BaslangicTarihi = Convert.ToDateTime(dr["BaslangicTarihi"]),
                            // Null kontrolü: Mezuniyet tarihi boş olabilir
                            MezuniyetTarihi = dr["MezuniyetTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["MezuniyetTarihi"]),
                            DevamEdiyor = Convert.ToBoolean(dr["DevamEdiyor"])
                        });
                    }
                }
            }
            return liste;
        }

        // 2. İŞ DENEYİMLERİNİ GETİR
        public List<IsDeneyimi> GetirIsDeneyimleri(int kullaniciId)
        {
            List<IsDeneyimi> liste = new List<IsDeneyimi>();
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string query = "SELECT * FROM IsDeneyimleri WHERE KullaniciId = @kid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        liste.Add(new IsDeneyimi
                        {
                            SirketAdi = dr["SirketAdi"].ToString(),
                            Pozisyon = dr["Pozisyon"].ToString(),
                            IsTanimi = dr["IsTanimi"].ToString(),
                            BaslamaTarihi = Convert.ToDateTime(dr["BaslamaTarihi"]),
                            AyrilmaTarihi = dr["AyrilmaTarihi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["AyrilmaTarihi"]),
                            DevamEdiyor = Convert.ToBoolean(dr["DevamEdiyor"])
                        });
                    }
                }
            }
            return liste;
        }

        // 3. YETENEKLERİ GETİR
        public List<Yetenek> GetirYetenekler(int kullaniciId)
        {
            List<Yetenek> liste = new List<Yetenek>();
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string query = "SELECT * FROM Yetenekler WHERE KullaniciId = @kid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        liste.Add(new Yetenek
                        {
                            YetenekAdi = dr["YetenekAdi"].ToString(),
                            Seviye = dr["Seviye"].ToString()
                        });
                    }
                }
            }
            return liste;
        }

        // 4. SERTİFİKALARI GETİR
        public List<Sertifika> GetirSertifikalar(int kullaniciId)
        {
            List<Sertifika> liste = new List<Sertifika>();
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string query = "SELECT * FROM Sertifikalar WHERE KullaniciId = @kid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        liste.Add(new Sertifika
                        {
                            SertifikaAdi = dr["SertifikaAdi"].ToString(),
                            AlindigiKurum = dr["AlindigiKurum"].ToString(),
                            AlindigiTarih = dr["AlindigiTarih"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["AlindigiTarih"])
                        });
                    }
                }
            }
            return liste;
        }
    }
}