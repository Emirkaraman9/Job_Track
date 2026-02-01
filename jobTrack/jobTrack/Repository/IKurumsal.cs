using System.Collections.Generic;
using jobTrack.Models; // Modelleri kullanabilmek için

namespace jobTrack.Repository
{
    public interface IKurumsal
    {
        // Karmaşık parametre listesi yerine nesne kullanımı
        bool Ekle(Kurumsal sirket);

        // Giriş başarılıysa şirket adını, başarısızsa null döner
        Kurumsal GirisYap(string email, string sifre);

        // Sadece isimleri değil, tüm şirket bilgilerini dönmek daha esnektir
        List<Kurumsal> SirketleriListele();
    }
}