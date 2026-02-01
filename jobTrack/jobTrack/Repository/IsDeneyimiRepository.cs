using jobTrack.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace jobTrack.Repository
{
    public class IsDeneyimiRepository
    {
        public List<IsDeneyimi> GetirByKullaniciId(int kullaniciId)
        {
            List<IsDeneyimi> liste = new List<IsDeneyimi>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                // SQL'deki IsTanimi (nvarchar MAX) sütununu da sorguya ekledik
                string query = "SELECT Id, SirketAdi, Pozisyon, IsTanimi, BaslamaTarihi, AyrilmaTarihi, DevamEdiyor " +
                               "FROM IsDeneyimleri WHERE KullaniciId = @kid ORDER BY BaslamaTarihi DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        liste.Add(new IsDeneyimi
                        {
                            Id = (int)dr["Id"],
                            SirketAdi = dr["SirketAdi"]?.ToString() ?? "",
                            Pozisyon = dr["Pozisyon"]?.ToString() ?? "",

                            // 1. DÜZELTME: SQL'deki IsTanimi verisini C# tarafına çekiyoruz
                            IsTanimi = dr["IsTanimi"]?.ToString() ?? "",

                            // 2. DÜZELTME: Başlama tarihi null gelirse hata vermemesi için kontrol
                            BaslamaTarihi = dr["BaslamaTarihi"] != DBNull.Value ? (DateTime)dr["BaslamaTarihi"] : DateTime.MinValue,

                            // Ayrılma tarihi zaten null olabilir (DateTime? olarak tanımlamıştık)
                            AyrilmaTarihi = dr["AyrilmaTarihi"] as DateTime?,

                            // 3. DÜZELTME: SQL'deki bit alanı null ise false olarak kabul ediyoruz
                            DevamEdiyor = dr["DevamEdiyor"] != DBNull.Value && (bool)dr["DevamEdiyor"]
                        });
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda konsola yazdırarak nerede sorun olduğunu görebiliriz
                    Console.WriteLine("İş Deneyimi Veri Çekme Hatası: " + ex.Message);
                }
            }
            return liste;
        }
    }
}
