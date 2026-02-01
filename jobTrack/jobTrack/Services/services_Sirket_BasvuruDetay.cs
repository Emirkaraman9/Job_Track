using System;
using jobTrack.Models;

namespace jobTrack.Services
{
    public class ApplicationDetailService
    {
        public ApplicationDetailModel GetApplicationDetail(string id)
        {
            return new ApplicationDetailModel
            {
                Id = string.IsNullOrEmpty(id) ? "#3424" : id,
                ApplicantName = "Mert Yalçın",
                Position = "Bilgisayar Mühendisi",
                AppliedDate = "19/12/2025",
                Status = "Beklemede",
                EducationInfo = "Ankara Üniversitesi – Bilgisayar Mühendisliği\n2018 – 2022",
                ExperienceInfo = "Teknova Yazılım A.Ş. – Junior Developer\n2023 – 2024",
                LinkedInUrl = "linkedin.com/in/mertyalcin",
                MediumUrl = "medium.com/@mertyalcin",
                CvUrl = "cv.pdf",
                IsInterviewCompleted = false,

                // YENİ: Adaya gönderilen benzersiz hash kodu (Simülasyon)
                UniqueVerificationCode = "A7F2-9X3B"
            };
        }

        public void SaveInterviewPlan(ApplicationDetailModel model)
        {
            // DB Kayıt simülasyonu
        }

        // YENİ: Hash Doğrulama
        public bool VerifyCandidateCode(string inputCode, string actualHash)
        {
            // Büyük/küçük harf duyarlılığını kaldırarak kontrol et
            return inputCode.Trim().ToUpper() == actualHash.ToUpper();
        }

        public void SaveFinalDecision(ApplicationDetailModel model) { }
        public void SaveDraft(ApplicationDetailModel model) { }

        public void InitiateInterviewVerification(string id)
        {
            // Adaya Hash kodunu mail atma simülasyonu
            MessageBox.Show($"Sistem Mesajı:\nAdaya gönderilen doğrulama kodu: A7F2-9X3B\n(Test için bu kodu kullanınız)");
        }
    }
}