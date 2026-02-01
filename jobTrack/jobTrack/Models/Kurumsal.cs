using System;

namespace jobTrack.Models
{
    public class Kurumsal
    {
        public int Id { get; set; } // Birincil Anahtar (Primary Key)
        public string SirketAdi { get; set; }
        public string YetkiliAd { get; set; }
        public string YetkiliSoyad { get; set; }
        public string SirketEmail { get; set; }
        public string SirketTelefon { get; set; }
        public string Sifre { get; set; }
        public string Sektor { get; set; }
        public string Adres { get; set; } // Yeni eklendi
        public string WebSitesi { get; set; } // Yeni eklendi
        public DateTime? KurulusTarihi { get; set; }
    }
}
