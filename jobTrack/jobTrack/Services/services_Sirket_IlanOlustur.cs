using System;
using System.Collections.Generic;
using jobTrack.Models;

namespace jobTrack.Services
{
    public class JobPostService
    {
        // --- Dropdown Verileri ---

        public string[] GetWorkTypes()
        {
            return new string[] { "Tam Zamanlı (Full-Time)", "Yarı Zamanlı (Part-Time)", "Uzaktan (Remote)", "Hibrit" };
        }

        public string[] GetSectors()
        {
            return new string[] { "Bilişim / Yazılım", "Finans", "Sağlık", "E-Ticaret", "Eğitim", "Üretim", "Hizmet" };
        }

        public string[] GetExperienceLevels()
        {
            return new string[] { "Junior (0-2 Yıl)", "Mid-Level (2-5 Yıl)", "Senior (5+ Yıl)", "Lead / Manager", "Executive" };
        }

        // --- İşlemler ---

        /// <summary>
        /// İlanı veritabanına kaydeder.
        /// </summary>
        public bool SaveJobPost(JobPostModel model)
        {
            // Validasyon (Örnek)
            if (string.IsNullOrWhiteSpace(model.Title) || string.IsNullOrWhiteSpace(model.Description))
            {
                return false;
            }

            // Burada veritabanı INSERT işlemi yapılacak
            // Database.Insert(model)...

            Console.WriteLine($"İlan Kaydedildi: {model.Title} - {model.WorkType}");
            return true;
        }
    }
}