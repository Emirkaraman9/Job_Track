using System.Collections.Generic;
using jobTrack.Models; // Modelleri kullanabilmek için

namespace jobTrack.Repository
{
    public interface IBireysel
    {
        // Çok fazla parametre yerine doğrudan modeli gönderiyoruz
        bool Ekle(Bireysel kullanici);

        // Giriş başarılıysa isim-soyad, başarısızsa null döner
        Bireysel GirisYap(string girilenVeri, string sifre);

        // Sadece isimleri değil, tüm kullanıcı nesnelerini dönmek daha esnektir
        List<Bireysel> KullanicilariGetir();
    }
}
