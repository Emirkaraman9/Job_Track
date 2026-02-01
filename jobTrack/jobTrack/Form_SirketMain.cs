using jobTrack.Helpers;
using jobTrack.UserControls;
using jobTrack.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace jobTrack
{
    public partial class Form_SirketMain : Form
    {
        private Panel pnlMenu;
        private Panel pnlContent;

        public Form_SirketMain()
        {
            // Form Ayarları
            this.Text = "jobTrack Kurumsal Yönetim Paneli";
            this.Size = new Size(1280, 800);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Eğer kullanıcı pencereyi 'X' butonundan kapatırsa ve çıkış yapmamışsa 
            // tüm uygulamayı kapat. Ancak 'Çıkış Yap' butonuna basılmışsa Session null olacağı için
            // sadece bu form kapanacak ve FrmMain tekrar görünecektir.
            this.FormClosing += (s, e) => {
                if (SessionManager.GirisYapanSirket != null)
                {
                    Application.Exit();
                }
            };

            ArayuzuKur();

            // İlk açılışta Dashboard UserControl'ünü getir
            SayfaGetir(new UC_Sirket_Dashboard());
        }

        private void ArayuzuKur()
        {
            // 1. Sol Menü Paneli (Navbar)
            pnlMenu = new Panel();
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Width = 250;
            pnlMenu.BackColor = Color.FromArgb(32, 33, 36);
            this.Controls.Add(pnlMenu);

            // 2. İçerik Paneli (Sayfaların yükleneceği alan)
            pnlContent = new Panel();
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Color.WhiteSmoke;
            this.Controls.Add(pnlContent);
            pnlContent.BringToFront();

            // --- MENÜ BUTONLARI ---

            // ÇIKIŞ BUTONU: Session'ı temizler ve formu kapatır.
            // FrmMain bu formun kapandığını anlayıp kendini tekrar gösterecektir.
            Button btnCikis = ButonOlustur("Çıkış Yap", (s, e) => CikisYap());
            btnCikis.Dock = DockStyle.Bottom;
            btnCikis.BackColor = Color.FromArgb(40, 0, 0);
            pnlMenu.Controls.Add(btnCikis);

            // Menü Öğeleri
            MenuButonuEkle("Firma Profili", (s, e) => SayfaGetir(new UC_Sirket_Profil()));
            MenuButonuEkle("Başvurular", (s, e) => SayfaGetir(new UC_Sirket_Basvurular()));
            MenuButonuEkle("İlan Oluştur", (s, e) => SayfaGetir(new UC_Sirket_IlanOlustur()));
            MenuButonuEkle("Dashboard", (s, e) => SayfaGetir(new UC_Sirket_Dashboard()));

            // Üst Kısım Logo
            Label lblLogo = new Label();
            lblLogo.Text = "jobTrack";
            lblLogo.ForeColor = Color.White;
            lblLogo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Height = 100;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            pnlMenu.Controls.Add(lblLogo);
        }

        private void CikisYap()
        {
            DialogResult sonuc = MessageBox.Show("Oturumu kapatıp giriş ekranına dönmek istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                // 1. ÖNEMLİ: Önce oturum verisini temizliyoruz.
                // Bu sayede FormClosing olayındaki Application.Exit tetiklenmez.
                SessionManager.GirisYapanSirket = null;
                SessionManager.GirisYapanKullanici = null;

                // 2. Formu kapatıyoruz.
                // FrmMain.cs içindeki sirketForm.FormClosed olayı tetiklenecek, 
                // FrmMain kendini .Show() yapacak ve 'Karsilama' ekranına dönecektir.
                this.Close();
            }
        }

        private void MenuButonuEkle(string text, EventHandler olay)
        {
            Button btn = ButonOlustur(text, olay);
            btn.Dock = DockStyle.Top;
            pnlMenu.Controls.Add(btn);
        }

        private Button ButonOlustur(string text, EventHandler olay)
        {
            Button btn = new Button();
            btn.Text = "  " + text;
            btn.Height = 55;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.LightGray;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Font = new Font("Segoe UI", 11);
            btn.Cursor = Cursors.Hand;

            if (olay != null) btn.Click += olay;

            // Görsel Efektler
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(50, 50, 60);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;

            return btn;
        }

        public void SayfaGetir(UserControl sayfa)
        {
            if (sayfa == null) return;
            pnlContent.Controls.Clear();
            sayfa.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(sayfa);
            sayfa.BringToFront();
        }
    }
}