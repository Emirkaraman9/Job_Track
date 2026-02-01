using System;
using System.Collections.Generic;
using jobTrack.Models;

namespace jobTrack.Services
{
    public class ApplicationService
    {
        /// <summary>
        /// Tüm başvuru listesini getirir.
        /// (İleride burası veritabanından sorgu yapacak)
        /// </summary>
        public List<ApplicationRecordModel> GetAllApplications()
        {
            return new List<ApplicationRecordModel>
            {
                new ApplicationRecordModel { Id = "#3424", ApplicantName = "Mert Yalçın", Position = "Bilgisayar Mühendisi", ApplicationDate = "19.12.2025", Status = "Beklemede" },
                new ApplicationRecordModel { Id = "#3424", ApplicantName = "Deniz Aydın", Position = "Yazılım Mühendisi", ApplicationDate = "18.12.2025", Status = "Mülakat" },
                new ApplicationRecordModel { Id = "#3425", ApplicantName = "Ayşe Can", Position = "İnsan Kaynakları Uzm.", ApplicationDate = "17.12.2025", Status = "Reddedildi" },
                new ApplicationRecordModel { Id = "#3426", ApplicantName = "Mehmet Yılmaz", Position = "Veri Analisti", ApplicationDate = "16.12.2025", Status = "Kabul" },
                new ApplicationRecordModel { Id = "#3427", ApplicantName = "Selin Demir", Position = "Proje Yöneticisi", ApplicationDate = "15.12.2025", Status = "Beklemede" }
            };
        }
    }
}