using System;
using System.Data.SqlClient;
using jobTrack.Helpers;
using jobTrack.Models;
using jobTrack.Repository;

namespace jobTrack.Services
{
    public class EvaluationRepository
    {
        public bool DegerlendirmeEkle(ProcessEvaluationModel model)
        {
            // Basit ID kontrolü
            if (model.BasvuruId == 0) return false;

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                // SQL Sorgusu: Değerlendirme tablosuna kayıt atar
                string query = @"
                    INSERT INTO SurecDegerlendirmeleri 
                    (BasvuruId, Puan, Yorum, KanitDosyaYolu, IsimGizliMi, OlusturmaTarihi) 
                    VALUES 
                    (@BasvuruId, @Puan, @Yorum, @Dosya, @Gizli, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Parametreler
                cmd.Parameters.AddWithValue("@BasvuruId", model.BasvuruId);
                cmd.Parameters.AddWithValue("@Puan", model.UserRating);

                // Yorum boşsa NULL kaydet
                if (string.IsNullOrEmpty(model.UserComment) || model.UserComment == "Deneyimlerinizi buraya yazın...")
                    cmd.Parameters.AddWithValue("@Yorum", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Yorum", model.UserComment);

                // Dosya yoksa NULL kaydet
                if (string.IsNullOrEmpty(model.ProofFilePath))
                    cmd.Parameters.AddWithValue("@Dosya", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Dosya", model.ProofFilePath);

                cmd.Parameters.AddWithValue("@Gizli", model.IsAnonymous);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Kayıt başarılıysa true döner
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Repository Hatası: " + ex.Message);
                    return false;
                }
            }
        }
    }
}