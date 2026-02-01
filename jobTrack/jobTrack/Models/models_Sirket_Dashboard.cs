using System;
using System.Collections.Generic;
using System.Drawing; // Renkler için gerekli (System.Drawing.Common referansı ekli olmalı)

namespace jobTrack.Models
{
    // --- İstatistik Kartları İçin Model ---
    public class StatCardModel
    {
        public string Title { get; set; }           // Kart Başlığı (Örn: Toplam Başvuru)
        public string Value { get; set; }           // Değer (Örn: 348)
        public Color IndicatorColor { get; set; }   // Sol şerit rengi
    }

    // --- Şirket Puanı Detayları İçin Model ---
    public class CompanyRatingModel
    {
        public string AverageScore { get; set; }    // Örn: "4.6"
        public int TotalVotes { get; set; }         // Örn: 348
        public List<StarDetail> StarDistribution { get; set; } // Yıldız dağılım listesi
    }

    // Yıldız dağılımı alt sınıfı
    public class StarDetail
    {
        public int StarCount { get; set; }  // 5, 4, 3...
        public int Percentage { get; set; } // %65
        public int VoteCount { get; set; }  // (226)
    }

    // --- Mevcut İlanlar Tablosu İçin Model ---
    public class JobListingModel
    {
        public string Id { get; set; }          // İlan No (#2345)
        public string Position { get; set; }    // Pozisyon
        public string Status { get; set; }      // Durum (Yayında/Askıda)
    }

    // --- Başvurular Tablosu İçin Model ---
    public class ApplicationModel
    {
        public string ApplicantName { get; set; } // Aday İsmi
        public string Position { get; set; }      // Başvurulan Pozisyon
        public string Status { get; set; }        // Durum (Beklemede, İnceleniyor...)
    }

    // --- TÜM SAYFAYI TAŞIYAN ANA MODEL (VIEWMODEL) ---
    public class DashboardViewModel
    {
        public List<StatCardModel> Stats { get; set; }
        public CompanyRatingModel Rating { get; set; }
        public List<JobListingModel> Listings { get; set; }
        public List<ApplicationModel> RecentApplications { get; set; }

        public DashboardViewModel()
        {
            Stats = new List<StatCardModel>();
            Listings = new List<JobListingModel>();
            RecentApplications = new List<ApplicationModel>();
        }
    }
}