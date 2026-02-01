namespace jobTrack.Models
{
    public class Bireysel
    {
        // Veritabanı işlemleri için bir ID mutlaka olmalı
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Email { get; set; }
        public string Okul { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
    }
}
