using System;

namespace jobTrack.Models
{
    public class ProcessEvaluationModel
    {
        
        public int BasvuruId { get; set; }        // Hangi başvuruya ait olduğu (SQL için şart)
        public string CompanyName { get; set; }   // Şirket Adı
        public string Position { get; set; }      // Pozisyon
        public string Description { get; set; }   // İlan Açıklaması
        public string Location { get; set; }      // Lokasyon
        public string Status { get; set; }        // Durum (Mülakat vs.)
        public DateTime Date { get; set; }        // Başvuru Tarihi
        public string LogoPath { get; set; }      // Logo Yolu

        // --- KULLANICININ GİRECEĞİ VERİLER (INPUT) ---
        public int UserRating { get; set; }       // Verilen Yıldız (1-5)
        public string UserComment { get; set; }   // Yorum
        public string ProofFilePath { get; set; } // Görsel Kanıt Yolu
        public bool IsAnonymous { get; set; }     // İsim Gizli mi?
    }
}