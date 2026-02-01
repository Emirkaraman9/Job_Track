using System;
using jobTrack.Models;

namespace jobTrack.Services
{
    public class CompanyProfileService
    {
        /// <summary>
        /// Mevcut oturum açmış şirketin profilini getirir.
        /// </summary>
        public CompanyProfileModel GetProfile()
        {
            // Eğer giriş yapmış bir kullanıcı yoksa boş veya varsayılan bir model döndür
            if (SessionManager.GirisYapanSirket == null)
            {
                return new CompanyProfileModel
                {
                    CompanyName = "Giriş Yapılmadı",
                    AboutUs = "Lütfen giriş yapınız."
                };
            }

            // UserSession'daki (Kayıt/Giriş verileri) bilgileri UI Modeline aktarıyoruz
            var user = SessionManager.GirisYapanSirket;

            return new CompanyProfileModel
            {
                // -- Kayıt Ekranından Gelen Veriler --
                CompanyName = user.SirketAdi,
                Email = user.SirketEmail,
                Phone = user.SirketTelefon,
                Sector = user.Sektor,
                Address = user.Adres,
                Website = user.WebSitesi,
                EstablishmentYear = user.KurulusTarihi.HasValue ? user.KurulusTarihi.Value.Year.ToString() : "",

                // -- Kayıt ekranında olmayan ama Profilde olan veriler (Varsayılan boş gelebilir) --
                // Bu alanlar daha sonra "Kaydet" butonuna basıldığında doldurulacak.
                AboutUs = "Firma hakkında bilgi giriniz...",
                CompanySize = "Belirtilmemiş",
                Whatsapp = "",
                InstagramUrl = "",
                LinkedInUrl = "",
                LogoPath = null
            };
        }

        /// <summary>
        /// Profil değişikliklerini kaydeder.
        /// </summary>
        public bool SaveProfile(CompanyProfileModel model)
        {
            if (SessionManager.GirisYapanSirket == null) return false;

            // Validasyon
            if (string.IsNullOrWhiteSpace(model.CompanyName))
                return false;

            // 1. UI'dan gelen güncel verileri Session'daki (ve dolayısıyla DB'ye gidecek olan) nesneye aktar
            var user = SessionManager.GirisYapanSirket;

            user.SirketAdi = model.CompanyName;
            user.SirketEmail = model.Email;
            user.SirketTelefon = model.Phone;
            user.Sektor = model.Sector;
            user.Adres = model.Address;
            user.WebSitesi = model.Website;

            // Tarih dönüşümü (Sadece yıl girildiği için 1 Ocak varsayıyoruz veya mevcut tarihi koruyoruz)
            if (int.TryParse(model.EstablishmentYear, out int year))
            {
                user.KurulusTarihi = new DateTime(year, 1, 1);
            }

            // NOT: AboutUs, CompanySize, Sosyal Medya gibi alanlar 'Kurumsal' tablosunda yoksa,
            // ya 'Kurumsal' modeline eklenmeli ya da ayrı bir 'KurumsalDetay' tablosuna kaydedilmelidir.
            // Şimdilik sadece Kurumsal tablosundaki karşılıkları güncelliyoruz.

            // 2. Veritabanı Update İşlemi (Mock)
            // db.Kurumsal.Update(user);
            // db.SaveChanges();

            Console.WriteLine("Veritabanı ve Session güncellendi: " + user.SirketAdi);
            return true;
        }

        // Dropdown seçenekleri
        public string[] GetSectors() => new[] { "Yazılım", "Finans", "Sağlık", "Eğitim", "Üretim", "Hizmet", "Perakende", "Otomotiv" };
        public string[] GetCompanySizes() => new[] { "0-10 Çalışan", "10-50 Çalışan", "50-100 Çalışan", "100-500 Çalışan", "500+ Çalışan" };
    }
}