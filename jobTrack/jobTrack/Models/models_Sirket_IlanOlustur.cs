using System;

namespace jobTrack.Models
{
    public class JobPostModel
    {
        public string Title { get; set; }           // İlan Başlığı
        public string WorkType { get; set; }        // Çalışma Şekli
        public string Location { get; set; }        // Konum
        public string Sector { get; set; }          // Sektör
        public DateTime PublishDate { get; set; }   // Yayın Tarihi
        public string ExperienceLevel { get; set; } // Deneyim Düzeyi
        public string SalaryRange { get; set; }     // Maaş Aralığı
        public string Description { get; set; }     // İlan Açıklaması
        public string LogoPath { get; set; }        // Logo Dosya Yolu (Opsiyonel)
    }
}