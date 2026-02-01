using jobTrack.Helpers;
using jobTrack.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_Navbar : UserControl
    {
        // Sayfa değişim isteğini ana forma (FrmMain) bildirecek olay
        public event Action<string> SayfaDegistirIstegi;

        // Tasarım renkleri
        private Color aktifRenk = Color.FromArgb(0, 150, 136); // Turkuaz vurgu
        private Color pasifRenk = Color.FromArgb(40, 40, 40);  // Koyu gri arka plan

        public UC_Navbar()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            this.Dock = DockStyle.Left; // Navbar genellikle solda sabit durur
        }

        private void UC_Navbar_Load(object sender, EventArgs e)
        {
            MenuYetkileriniAyarla();
        }

        /// <summary>
        /// Giriş yapan kullanıcının tipine göre butonları gösterir veya gizler.
        /// </summary>
        public void MenuYetkileriniAyarla()
        {
            // Eğer Kurumsal bir şirket giriş yaptıysa CV Sihirbazı'nı gizle
            if (SessionManager.GirisYapanSirket != null)
            {
                btnNavCvSihirbazi.Visible = false;
                btnNavBasvurularim.Visible = false;
                // Şirketlere özel butonlar varsa burada aktif edilebilir
            }
            else
            {
                btnNavCvSihirbazi.Visible = true;
                btnNavBasvurularim.Visible = true;
            }
        }

        // --- BUTON TIKLAMA OLAYLARI ---

        private void btnNavAnaSayfa_Click(object sender, EventArgs e)
        {
            ButonVurgula(sender);
            SayfaDegistirIstegi?.Invoke("Anasayfa");
        }

        private void btnNavIlanAra_Click(object sender, EventArgs e)
        {
            ButonVurgula(sender);
            SayfaDegistirIstegi?.Invoke("IlanAra");
        }

        private void btnNavBasvurularim_Click(object sender, EventArgs e)
        {
            ButonVurgula(sender);
            SayfaDegistirIstegi?.Invoke("Basvurularim");
        }

        private void btnNavBildirimler_Click(object sender, EventArgs e)
        {
            ButonVurgula(sender);
            SayfaDegistirIstegi?.Invoke("Bildirimler");
        }

        private void btnNavCvSihirbazi_Click(object sender, EventArgs e)
        {
            ButonVurgula(sender);
            SayfaDegistirIstegi?.Invoke("CVSihirbazi");
        }

        private void btnNavHesap_Click_1(object sender, EventArgs e)
        {
            // Butonu vurgula (Renk değişimi)
            ButonVurgula(sender);

            // Ana forma (FrmMain) "HesapAyarlari" sayfasını açması için sinyal gönder
            SayfaDegistirIstegi?.Invoke("HesapAyarlari");
        }

        private void btnNavCikis_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                // Oturum bilgilerini temizle
                SessionManager.GirisYapanKullanici = null;
                SessionManager.GirisYapanSirket = null;

                SayfaDegistirIstegi?.Invoke("Karsilama");
            }
        }

        // --- UI YARDIMCI METOTLARI ---

        /// <summary>
        /// Tıklanan butonu aktif renge boyar, diğerlerini pasif yapar.
        /// </summary>
        private void ButonVurgula(object tiklananButon)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    if (btn == tiklananButon)
                    {
                        btn.BackColor = aktifRenk;
                        btn.Font = new Font(btn.Font, FontStyle.Bold);
                        btn.FlatAppearance.BorderSize = 1; // Opsiyonel: Vurgu için kenarlık
                    }
                    else
                    {
                        btn.BackColor = pasifRenk;
                        btn.Font = new Font(btn.Font, FontStyle.Regular);
                        btn.FlatAppearance.BorderSize = 0;
                    }
                }
            }
        }
        /// <summary>
        /// Dışarıdan gelen sayfa ismine göre ilgili butonu bulur ve vurgular.
        /// </summary>
        /// <param name="sayfaAdi">Gidilecek sayfanın string adı</param>
        public void AktifButonuIsaretle(string sayfaAdi)
        {
            Button hedefButon = null;

            // Sayfa ismine göre hangi butonun vurgulanacağını seçiyoruz
            switch (sayfaAdi)
            {
                case "Anasayfa":
                    hedefButon = btnNavAnaSayfa;
                    break;
                case "IlanAra":
                    hedefButon = btnNavIlanAra;
                    break;
                case "Basvurularim":
                    hedefButon = btnNavBasvurularim;
                    break;
                case "Bildirimler":
                    hedefButon = btnNavBildirimler;
                    break;
                case "CVSihirbazi":
                    hedefButon = btnNavCvSihirbazi;
                    break;
                case "HesapAyarlari":
                    hedefButon = btnNavHesap;
                    break;
                default:
                    // Eğer eşleşen yoksa (Giriş ekranı vb.) tüm vurguları kaldırabiliriz
                    ButonVurgula(null);
                    return;
            }

            // Bulduğumuz butonu mevcut vurgulama metoduna gönderiyoruz
            if (hedefButon != null)
            {
                ButonVurgula(hedefButon);
            }
        }

        
    }

}