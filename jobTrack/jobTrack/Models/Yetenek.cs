using System;

namespace jobTrack.Models
{
    public class Yetenek
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string YetenekAdi { get; set; }
        public string Seviye { get; set; } // Başlangıç, Orta, İleri vb.

        // UI tarafında (örneğin bir ListBox'ta) güzel görünmesi için:
        public string YetenekDetay => $"{YetenekAdi} ({Seviye})";
    }

    public class Sertifika
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string SertifikaAdi { get; set; }
        public string AlindigiKurum { get; set; }

        // SQL'de "yes" (boş olabilir) olduğu için DateTime? (Nullable) yaptık
        public DateTime? AlindigiTarih { get; set; }

        // CV'de güzel görünmesi için yardımcı bir özellik
        public string SertifikaOzeti => $"{SertifikaAdi} - {AlindigiKurum}";
    }
}
