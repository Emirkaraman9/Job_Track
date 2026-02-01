using System;

namespace jobTrack.Models
{
    public class IsDeneyimi
    {
        public int Id { get; set; }

        // SQL tablonla tam uyum için KullaniciId ismini öneririm
        public int KullaniciId { get; set; }

        public string SirketAdi { get; set; } = string.Empty;
        public string Pozisyon { get; set; } = string.Empty;
        public string IsTanimi { get; set; } = string.Empty;
        public DateTime BaslamaTarihi { get; set; }
        public DateTime? AyrilmaTarihi { get; set; }
        public bool DevamEdiyor { get; set; }

        // Bu özellik CV Önizleme ekranında harika duracaktır
        public string TarihAraligi
        {
            get
            {
                // "MM/yyyy" yerine resume standartlarında "MMM yyyy" (Oca 2024) de kullanılabilir
                string bas = BaslamaTarihi.ToString("MM.yyyy");

                // Mantık doğru: Devam ediyorsa veya bitiş tarihi girilmemişse "Devam Ediyor" yaz
                string bit = (DevamEdiyor || !AyrilmaTarihi.HasValue)
                             ? "Devam Ediyor"
                             : AyrilmaTarihi.Value.ToString("MM.yyyy");

                return $"{bas} - {bit}";
            }
        }
    }

    public class Ilan
    {
        public int Id { get; set; }
        public string Baslik { get; set; } // SQL'de "no" (boş olamaz) olduğu için normal string
        public string Sirket { get; set; }
        public string Konum { get; set; }
        public string Sektor { get; set; }
        public string CalismaSekli { get; set; }
        public string Deneyim { get; set; }

        // KRİTİK DÜZELTME 1: SQL'de "Maas" null olabilir (yes). 
        // Bu yüzden decimal? (Nullable) kullanmalıyız.
        public decimal? Maas { get; set; }

        public string Nitelikler { get; set; }
        public string Snippet { get; set; }

        // KRİTİK DÜZELTME 2: SQL'de "YayinlanmaTarihi" null olabilir.
        // Varsayılan değer ataman güzel, ancak DB'den okurken sorun yaşamamak için DateTime? yapmalıyız.
        public DateTime? YayinlanmaTarihi { get; set; } = DateTime.Now;
    }

    public class Basvuru
    {
        // 1. Veritabanında Fiziksel Olarak Var Olanlar
        public int Id { get; set; }
        public int BireyselId { get; set; }
        public int IlanId { get; set; }
        public DateTime Tarih { get; set; }
        public string Durum { get; set; }

        // 2. Veritabanında Yok Ama Ekran İçin Gerekenler (JOIN ile dolacak)
        public string SirketAdi { get; set; }
        public string Pozisyon { get; set; }

        public string Lokasyon { get; set; }      // İlanın konumu
        public string Aciklama { get; set; }      // İlanın nitelikleri/açıklaması
        public string LogoPath { get; set; }      // Şirket logosu
        public bool DegerlendirildiMi { get; set; } // Süreç değerlendirme durumu
    }
}
