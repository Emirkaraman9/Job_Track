using System;

namespace jobTrack.Models
{
    // Başvuru listesindeki her bir satırı temsil eden model
    public class ApplicationRecordModel
    {
        public string Id { get; set; }            // İlan/Başvuru No (Örn: #3424)
        public string ApplicantName { get; set; } // Aday Adı Soyadı
        public string Position { get; set; }      // Başvurulan Pozisyon
        public string ApplicationDate { get; set; } // Başvuru Tarihi
        public string Status { get; set; }        // Durum (Beklemede, Mülakat, vb.)
    }
}