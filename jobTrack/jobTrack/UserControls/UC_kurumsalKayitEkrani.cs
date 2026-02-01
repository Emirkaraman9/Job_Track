using jobTrack.Helpers;
using jobTrack.Models;
using jobTrack.Repository;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_kurumsalKayitEkrani : UserControl
    {
        public event Action<string> SayfaDegistirIstegi;

        public UC_kurumsalKayitEkrani()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void hakkımızda_button_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Hakkimizda");

        private void geri_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Karsilama");

        private void kullanicigir_button_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Hesap");

        private void Kayitol_Button_Click(object sender, EventArgs e)
        {
            // 1. ADIM: BOŞ ALAN KONTROLÜ
            if (string.IsNullOrWhiteSpace(txtSirketAdi.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen şirket adı, email ve şifre alanlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ADIM: EMAIL FORMAT KONTROLÜ
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Geçerli bir kurumsal e-posta adresi giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. ADIM: ŞİFRE EŞLEŞME KONTROLÜ
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Girdiğiniz şifreler birbiriyle uyuşmuyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. ADIM: MODELİ PAKETLEME
            Kurumsal yeniSirket = new Kurumsal
            {
                SirketAdi = txtSirketAdi.Text.Trim(),
                YetkiliAd = txtYetkiliAd.Text.Trim(),
                YetkiliSoyad = txtYetkiliSoyad.Text.Trim(),
                SirketEmail = txtEmail.Text.Trim(),
                Sifre = txtSifre.Text,
                SirketTelefon = txtTelefon.Text.Trim(),
                Sektor = txtSektor.Text.Trim(),
                KurulusTarihi = dtpKurulus.Value
            };

            // 5. ADIM: VERİTABANINA KAYIT
            KurumsalRepository repo = new KurumsalRepository();
            try
            {
                bool basarili = repo.Ekle(yeniSirket);

                if (basarili)
                {
                    MessageBox.Show("Şirket kaydınız başarıyla oluşturuldu. Giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SayfaDegistirIstegi?.Invoke("Hesap"); // Login ekranına yönlendir
                }
                else
                {
                    MessageBox.Show("Kayıt oluşturulamadı. Bu e-posta adresi sistemde zaten kayıtlı olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_kullaniciGirisEkrani kullaniciGiris = new UC_kullaniciGirisEkrani();
            kullaniciGiris.Tag = this.Tag;
            this.Hide();
            kullaniciGiris.Show();
        }
    }
}