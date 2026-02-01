using System;
using System.Collections.Generic;
using System.Drawing;
using jobTrack.Models; // Modelleri tanıması için namespace ekledik

namespace jobTrack.Services
{
    public class DashboardService
    {
        /// <summary>
        /// Dashboard için gerekli tüm verileri getirir.
        /// İleride buradaki 'new' tanımlamaları yerine veritabanı sorguları gelecek.
        /// </summary>
        public DashboardViewModel GetDashboardData()
        {
            var data = new DashboardViewModel();

            // 1. İstatistik Kartları Verisi
            data.Stats = new List<StatCardModel>
            {
                new StatCardModel { Title = "Toplam İlan", Value = "12", IndicatorColor = Color.RoyalBlue },
                new StatCardModel { Title = "Toplam Başvuru", Value = "348", IndicatorColor = Color.Orange },
                new StatCardModel { Title = "Yanıt Oranı", Value = "%82", IndicatorColor = Color.SeaGreen },
                new StatCardModel { Title = "Ort. Yanıt", Value = "2.8 Gün", IndicatorColor = Color.Purple }
            };

            // 2. Şirket Puanı Verisi
            data.Rating = new CompanyRatingModel
            {
                AverageScore = "4.6",
                TotalVotes = 348,
                StarDistribution = new List<StarDetail>
                {
                    new StarDetail { StarCount = 5, Percentage = 65, VoteCount = 226 },
                    new StarDetail { StarCount = 4, Percentage = 18, VoteCount = 62 },
                    new StarDetail { StarCount = 3, Percentage = 9, VoteCount = 31 },
                    new StarDetail { StarCount = 2, Percentage = 5, VoteCount = 17 },
                    new StarDetail { StarCount = 1, Percentage = 3, VoteCount = 12 }
                }
            };

            // 3. Mevcut İlanlar Verisi
            data.Listings = new List<JobListingModel>
            {
                new JobListingModel { Id = "#2345", Position = "Senior Developer", Status = "Yayında" },
                new JobListingModel { Id = "#2346", Position = "Data Analyst", Status = "Yayında" },
                new JobListingModel { Id = "#2347", Position = "UI Designer", Status = "Askıda" }
            };

            // 4. Son Başvurular Verisi
            data.RecentApplications = new List<ApplicationModel>
            {
                new ApplicationModel { ApplicantName = "Ahmet Y.", Position = "Veri Analisti", Status = "Beklemede" },
                new ApplicationModel { ApplicantName = "Ayşe K.", Position = "İK Uzmanı", Status = "İnceleniyor" },
                new ApplicationModel { ApplicantName = "Caner E.", Position = "Yazılım Uzm.", Status = "Reddedildi" },
                new ApplicationModel { ApplicantName = "Merve T.", Position = "Grafiker", Status = "Beklemede" }
            };

            return data;
        }
    }
}