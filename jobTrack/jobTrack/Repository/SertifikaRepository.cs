using jobTrack.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace jobTrack.Repository
{
    public class SertifikaRepository
    {
        public List<Sertifika> GetirByKullaniciId(int kullaniciId)
        {
            List<Sertifika> liste = new List<Sertifika>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                // Verimlilik için tüm sütunları tek tek yazmak iyidir
                string query = "SELECT Id, SertifikaAdi, AlindigiKurum, AlindigiTarih FROM Sertifikalar WHERE KullaniciId = @kid";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kid", kullaniciId);

                try
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            liste.Add(new Sertifika
                            {
                                Id = (int)dr["Id"],
                                // NULL gelme ihtimaline karşı güvenli okuma:
                                SertifikaAdi = dr["SertifikaAdi"]?.ToString() ?? "",
                                AlindigiKurum = dr["AlindigiKurum"]?.ToString() ?? "",

                                // KRİTİK DÜZELTME: Tarih kolonu NULL ise hata vermesini engelliyoruz
                                AlindigiTarih = dr["AlindigiTarih"] != DBNull.Value
                                                ? (DateTime)dr["AlindigiTarih"]
                                                : (DateTime?)null
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Sertifika verileri çekilemedi: " + ex.Message);
                }
            }
            return liste;
        }
    }
}