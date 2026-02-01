using jobTrack.Helpers;
using jobTrack.Models;
using jobTrack.Repository;
using System;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_kullaniciGirisEkrani : UserControl
    {
        public event Action<string> SayfaDegistirIstegi;

        public UC_kullaniciGirisEkrani()
        {
            InitializeComponent();
            // Şifre kutusunda karakterleri gizlemek için (Tasarım tarafında da yapılabilir)
            ThemeManager.ApplyTheme(this);
            txtSifre.PasswordChar = '•';
        }

        private void geri_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Karsilama");

        private void hakkımızda_button_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Hakkimizda");

        private void kayıt_ol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => SayfaDegistirIstegi?.Invoke("BireyselKayit");

        private void girisyap_button_Click(object sender, EventArgs e)
        {
            string girilenVeri = txtKullaniciVeyaEmail.Text.Trim();
            string girilenSifre = txtSifre.Text;

            // 1. Boş Alan Kontrolü
            if (string.IsNullOrEmpty(girilenVeri) || string.IsNullOrEmpty(girilenSifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BireyselRepository repoBireysel = new BireyselRepository();
            KurumsalRepository repoKurumsal = new KurumsalRepository();

            // Önceki oturum bilgilerini temizle
            SessionManager.GirisYapanKullanici = null;
            SessionManager.GirisYapanSirket = null;

            // 2. BİREYSEL GİRİŞİ DENE
            Bireysel kullanici = repoBireysel.GirisYap(girilenVeri, girilenSifre);

            if (kullanici != null)
            {
                // Giriş başarılı (Bireysel)
                SessionManager.GirisYapanKullanici = kullanici; // Tüm nesneyi ID dahil kaydettik

                MessageBox.Show($"Hoşgeldin, {kullanici.Ad} {kullanici.Soyad}!", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SayfaDegistirIstegi?.Invoke("Anasayfa");
            }
            else
            {
                // 3. KURUMSAL GİRİŞİ DENE (Bireysel bulunamadıysa)
                Kurumsal sirket = repoKurumsal.GirisYap(girilenVeri, girilenSifre);

                if (sirket != null)
                {
                    // Giriş başarılı (Kurumsal)
                    SessionManager.GirisYapanSirket = sirket; // Şirket bilgilerini kaydettik

                    MessageBox.Show($"{sirket.SirketAdi} yetkilisi olarak giriş yapıldı.", "Kurumsal Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SayfaDegistirIstegi?.Invoke("SirketDashboard");
                }
                else
                {
                    // Her iki tabloda da kullanıcı bulunamadı
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSifre.Clear();
                    txtSifre.Focus();
                }
            }
        }
    }
}