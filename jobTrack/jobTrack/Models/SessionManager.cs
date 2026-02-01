using jobTrack.Models;

public static class SessionManager
{
    // Giriş yapan kullanıcının tüm bilgisini burada tutabiliriz
    public static Bireysel GirisYapanKullanici { get; set; }
    public static Kurumsal GirisYapanSirket { get; set; }

    // Yardımcı özellik: Giriş yapan kişi bireysel mi?
    public static bool BireyselMi => GirisYapanKullanici != null;

    public static void SignOut()
    {
        GirisYapanKullanici = null;
        GirisYapanSirket = null;
    }
}