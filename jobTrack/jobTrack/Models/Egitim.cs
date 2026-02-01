using System;

namespace jobTrack.Models
{
    public class Egitim
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; } // Hangi kullanıcıya ait olduğunu belirtir
        public string OkulAdi { get; set; }
        public string Bolum { get; set; }
        public string Derece { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? MezuniyetTarihi { get; set; } // Nullable yapıldı
        public bool DevamEdiyor { get; set; }

        public string TarihAraligi
        {
            get
            {
                string baslangic = BaslangicTarihi.ToString("MM.yyyy");
                string bitis = DevamEdiyor || !MezuniyetTarihi.HasValue
                    ? "Devam Ediyor"
                    : MezuniyetTarihi.Value.ToString("MM.yyyy");
                return $"{baslangic} - {bitis}";
            }
        }
    }
}