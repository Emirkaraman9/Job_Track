using jobTrack.Helpers;
using jobTrack.Models;      // Model kullanımı için
using jobTrack.Repository;  // Repository kullanımı için
using System;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_bireyselKayitEkrani : UserControl
    {
        public event Action<string> SayfaDegistirIstegi;

        public UC_bireyselKayitEkrani()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void geri_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Karsilama");

        private void Kayıtol_Button_Click(object sender, EventArgs e)
        {
            // 1. EKSİK: Şifre Kontrolü (Veritabanına gitmeden önce yapılmalı)
            if (txtSifre.Text != txtSifreTekrar.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. EKSİK: Boş Alan Kontrolü
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun!");
                return;
            }

            BireyselRepository repo = new BireyselRepository();

            // 3. GEREKSİZ: 10 tane parametre yerine Model paketlemek
            Bireysel yeniKullanici = new Bireysel
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                Email = txtEmail.Text,
                Okul = txtOkul.Text,
                Sifre = txtSifre.Text
            };

            try
            {
                // Ekle metodu bool dönecek şekilde güncellenmeli
                bool basarili = repo.Ekle(yeniKullanici);

                if (basarili)
                {
                    MessageBox.Show("Kayıt Başarılı! Giriş ekranına yönlendiriliyorsunuz.");
                    SayfaDegistirIstegi?.Invoke("Hesap");
                }
                else
                {
                    MessageBox.Show("Kayıt sırasında bir hata oluştu. Kullanıcı adı veya Email alınmış olabilir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem Hatası: " + ex.Message);
            }
        }

        private void kullanıcıgir_button_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Hesap");

        private void button5_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Hakkimizda");

    }
}