using System;

namespace jobTrack.Models
{
    public class ApplicationDetailModel
    {
        public string Id { get; set; }              // Örn: #3424
        public string ApplicantName { get; set; }   // Mert Yalçın
        public string Position { get; set; }        // Bilgisayar Mühendisi
        public string AppliedDate { get; set; }     // 19/12/2025
        public string Status { get; set; }          // Beklemede
        public string StatusDescription { get; set; } // Başvuru Durum Açıklaması

        // Profil Detayları
        public string EducationInfo { get; set; }   // Ankara Üniversitesi...
        public string ExperienceInfo { get; set; }  // Teknova Yazılım A.Ş...

        // Linkler
        public string LinkedInUrl { get; set; }
        public string MediumUrl { get; set; }
        public string CvUrl { get; set; }

        // Mülakat Durumu
        public bool IsInterviewCompleted { get; set; } // Mülakat tamamlandı mı?
        public DateTime? InterviewDate { get; set; } // Planlanan Tarih
        public string InterviewType { get; set; }    // Online / Yüz Yüze
        public string InterviewLink { get; set; }    // Toplantı Linki veya Adres

        public string UniqueVerificationCode { get; set; }
    }
}