using System;

namespace jobTrack.Models
{
    public class CompanyProfileModel
    {
        // Temel Bilgiler
        public string CompanyName { get; set; }     // Firma İsmi
        public string EstablishmentYear { get; set; } // Kuruluş Yılı
        public string Sector { get; set; }          // Sektör
        public string AboutUs { get; set; }         // Hakkımızda
        public string LogoPath { get; set; }        // Logo Dosya Yolu

        // Detaylar
        public string CompanySize { get; set; }     // Şirket Büyüklüğü
        public string Address { get; set; }         // Adres

        // İletişim
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Whatsapp { get; set; }

        // Sosyal Medya
        public string InstagramUrl { get; set; }
        public string LinkedInUrl { get; set; }
    }
}