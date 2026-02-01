using jobTrack.Helpers;
using jobTrack.Models;   // Modeller
using jobTrack.Services; // Servisler
using System;
using System.Drawing;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_Sirket_Profil : UserControl
    {
        private readonly CompanyProfileService _service;

        // Form Elemanları
        private PictureBox pbLogo;
        private TextBox txtYil;
        private TextBox txtFirmaIsmi;
        private ComboBox cmbSektor;
        private RichTextBox rtbHakkimizda;
        private Label lblKarakterSayac;
        private ComboBox cmbBuyukluk;
        private RichTextBox rtbAdres;
        private TextBox txtTelefon;
        private TextBox txtEmail;
        private TextBox txtWeb;
        private TextBox txtWhatsapp;
        private TextBox txtInstagram;
        private TextBox txtLinkedin;

        private string _currentLogoPath;

        public UC_Sirket_Profil()
        {
            InitializeComponent();

            // 2. Özel Arka Plan Rengini Koru
            // ThemeManager arka planı koyu yapmış olabilir, bu form özel (Açık renk) olduğu için geri alıyoruz.
            this.BackColor = Color.WhiteSmoke;

            _service = new CompanyProfileService();
            TasarimiOlustur();
            VerileriYukle();
        }

        private void InitializeComponent()
        {
            this.Name = "UC_Sirket_Profil";
            this.Size = new Size(1200, 1100);
            this.BackColor = Color.WhiteSmoke;
            this.AutoScroll = true;
            this.Dock = DockStyle.Fill;
        }

        private void TasarimiOlustur()
        {
            // --- 1. ANA KAPLAYICI ---
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Top;
            mainPanel.AutoSize = true;
            mainPanel.Padding = new Padding(40);
            this.Controls.Add(mainPanel);

            // =========================================================
            // NESNELERİ HAZIRLIYORUZ (HENÜZ EKLEMİYORUZ)
            // =========================================================

            // A) Başlık
            Label lblBaslik = new Label();
            lblBaslik.Text = "Firma Profili";
            lblBaslik.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            lblBaslik.ForeColor = Color.FromArgb(45, 45, 48);
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Height = 60;

            // B) Boşluk
            Panel pnlSpacer = new Panel { Height = 20, Dock = DockStyle.Top };

            // C) Orta Kısım (Grid)
            TableLayoutPanel tlpAna = new TableLayoutPanel();
            tlpAna.Dock = DockStyle.Top;
            tlpAna.AutoSize = true;
            tlpAna.ColumnCount = 2;
            tlpAna.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpAna.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpAna.RowCount = 1;
            tlpAna.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // --- SOL SÜTUN ---
            Panel pnlSol = new Panel { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(0, 0, 30, 0) };
            tlpAna.Controls.Add(pnlSol, 0, 0);

            TableLayoutPanel tlpSol = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1 };
            tlpSol.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlSol.Controls.Add(tlpSol);

            // Logo ve Yıl
            TableLayoutPanel tlpUst = new TableLayoutPanel { Height = 140, Dock = DockStyle.Top, ColumnCount = 2, Margin = new Padding(0, 0, 0, 15) };
            tlpUst.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tlpUst.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            Panel pnlLogo = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 0, 10, 0) };
            pnlLogo.Controls.Add(EtiketOlustur("Firma Logosu"));
            pbLogo = new PictureBox { Size = new Size(150, 100), Dock = DockStyle.Bottom, BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Cursor = Cursors.Hand, SizeMode = PictureBoxSizeMode.Zoom };
            pbLogo.Click += PbLogo_Click;
            Label lblYukle = new Label { Text = "YÜKLE", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Gray, Font = new Font("Segoe UI", 8, FontStyle.Bold) };
            lblYukle.Click += PbLogo_Click;
            pbLogo.Controls.Add(lblYukle);
            pnlLogo.Controls.Add(pbLogo);
            tlpUst.Controls.Add(pnlLogo, 0, 0);

            Panel pnlYil = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10, 0, 0, 0) };
            Panel pnlYilIc = new Panel { Height = 60, Dock = DockStyle.Top, Margin = new Padding(0, 20, 0, 0) };
            pnlYilIc.Controls.Add(EtiketOlustur("Kuruluş Yılı"));
            txtYil = new TextBox { Dock = DockStyle.Bottom, Height = 35, Width = 120, Font = new Font("Segoe UI", 11), TextAlign = HorizontalAlignment.Center };
            pnlYilIc.Controls.Add(txtYil);
            pnlYil.Controls.Add(pnlYilIc);
            tlpUst.Controls.Add(pnlYil, 1, 0);

            tlpSol.Controls.Add(tlpUst);

            txtFirmaIsmi = new TextBox();
            tlpSol.Controls.Add(FormGrupOlustur("Firma İsmi", txtFirmaIsmi));

            cmbSektor = new ComboBox();
            cmbSektor.Items.AddRange(_service.GetSectors());
            tlpSol.Controls.Add(FormGrupOlustur("Sektör", cmbSektor));

            Panel pnlHakkimizda = new Panel { Height = 280, Dock = DockStyle.Top, Margin = new Padding(0, 10, 0, 0) };
            Panel pnlSayacContainer = new Panel { Height = 25, Dock = DockStyle.Bottom };
            lblKarakterSayac = new Label { Text = "0/2000", ForeColor = Color.Gray, AutoSize = true, Dock = DockStyle.Right, TextAlign = ContentAlignment.MiddleRight, Padding = new Padding(0, 5, 0, 0) };
            pnlSayacContainer.Controls.Add(lblKarakterSayac);
            pnlHakkimizda.Controls.Add(pnlSayacContainer);
            Label lblHak = EtiketOlustur("Hakkımızda");
            pnlHakkimizda.Controls.Add(lblHak);
            Panel pnlHakSpacer = new Panel { Height = 5, Dock = DockStyle.Top };
            pnlHakkimizda.Controls.Add(pnlHakSpacer);
            rtbHakkimizda = new RichTextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            pnlHakkimizda.Controls.Add(rtbHakkimizda);
            pnlSayacContainer.SendToBack();
            lblHak.BringToFront();
            pnlHakSpacer.BringToFront();
            rtbHakkimizda.BringToFront();
            tlpSol.Controls.Add(pnlHakkimizda);
            rtbHakkimizda.TextChanged += (s, e) => lblKarakterSayac.Text = rtbHakkimizda.Text.Length + "/2000";

            // --- SAĞ SÜTUN ---
            Panel pnlSag = new Panel { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(30, 0, 0, 0) };
            tlpAna.Controls.Add(pnlSag, 1, 0);
            TableLayoutPanel tlpSag = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1 };
            tlpSag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlSag.Controls.Add(tlpSag);

            cmbBuyukluk = new ComboBox();
            cmbBuyukluk.Items.AddRange(_service.GetCompanySizes());
            tlpSag.Controls.Add(FormGrupOlustur("Şirket Büyüklüğü", cmbBuyukluk));

            Panel pnlAdres = new Panel { Height = 110, Dock = DockStyle.Top, Margin = new Padding(0, 0, 0, 15) };
            pnlAdres.Controls.Add(EtiketOlustur("Konum / Adres:"));
            rtbAdres = new RichTextBox { Dock = DockStyle.Bottom, Height = 80, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            pnlAdres.Controls.Add(rtbAdres);
            tlpSag.Controls.Add(pnlAdres);

            Label lblIletisim = new Label { Text = "İletişim Bilgileri", Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Underline), ForeColor = Color.SteelBlue, AutoSize = true, Margin = new Padding(0, 20, 0, 10) };
            tlpSag.Controls.Add(lblIletisim);

            txtTelefon = new TextBox();
            tlpSag.Controls.Add(FormGrupOlustur("Telefon", txtTelefon));
            txtEmail = new TextBox();
            tlpSag.Controls.Add(FormGrupOlustur("E-posta", txtEmail));
            txtWeb = new TextBox();
            tlpSag.Controls.Add(FormGrupOlustur("Web Sitesi", txtWeb));
            txtWhatsapp = new TextBox();
            tlpSag.Controls.Add(FormGrupOlustur("WhatsApp İş Hattı", txtWhatsapp));

            Label lblSosyal = new Label { Text = "Sosyal Medya Bağlantıları", Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Underline), ForeColor = Color.Purple, AutoSize = true, Margin = new Padding(0, 20, 0, 5) };
            tlpSag.Controls.Add(lblSosyal);

            txtInstagram = new TextBox { ForeColor = Color.Purple };
            tlpSag.Controls.Add(FormGrupOlustur("Instagram Profil Linki", txtInstagram));
            txtLinkedin = new TextBox { ForeColor = Color.RoyalBlue };
            tlpSag.Controls.Add(FormGrupOlustur("LinkedIn Profil Linki", txtLinkedin));

            // D) Butonlar
            FlowLayoutPanel flpBtn = new FlowLayoutPanel();
            flpBtn.FlowDirection = FlowDirection.RightToLeft;
            flpBtn.Dock = DockStyle.Top;
            flpBtn.Height = 80;
            flpBtn.Padding = new Padding(0, 20, 0, 0);

            Button btnKaydet = new Button { Text = "Kaydet", BackColor = Color.SeaGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(150, 45), Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(10, 0, 0, 0) };
            btnKaydet.Click += BtnKaydet_Click;

            Button btnVazgec = new Button { Text = "Vazgeç", BackColor = Color.IndianRed, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(150, 45), Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand, Margin = new Padding(10, 0, 0, 0) };

            flpBtn.Controls.Add(btnKaydet);
            flpBtn.Controls.Add(btnVazgec);

            // =========================================================
            // DÜZELTME: EKLEME SIRASI (AŞAĞIDAN YUKARIYA)
            // =========================================================
            // Dock.Top kullanıldığında;
            // - İLK eklenen kontrol EN ALTTA görünür.
            // - EN SON eklenen kontrol EN ÜSTTE görünür.

            // 1. En altta BUTONLAR olsun
            mainPanel.Controls.Add(flpBtn);

            // 2. Onun üzerinde FORM (Grid) olsun
            mainPanel.Controls.Add(tlpAna);

            // 3. Onun üzerinde BOŞLUK olsun
            mainPanel.Controls.Add(pnlSpacer);

            // 4. En üstte BAŞLIK olsun (En son ekliyoruz)
            mainPanel.Controls.Add(lblBaslik);
        }

        private void VerileriYukle()
        {
            var profil = _service.GetProfile();
            if (profil == null) return;

            txtFirmaIsmi.Text = profil.CompanyName;
            txtYil.Text = profil.EstablishmentYear;
            cmbSektor.SelectedItem = profil.Sector;
            rtbHakkimizda.Text = profil.AboutUs;
            cmbBuyukluk.SelectedItem = profil.CompanySize;
            rtbAdres.Text = profil.Address;
            txtTelefon.Text = profil.Phone;
            txtEmail.Text = profil.Email;
            txtWeb.Text = profil.Website;
            txtWhatsapp.Text = profil.Whatsapp;
            txtInstagram.Text = profil.InstagramUrl;
            txtLinkedin.Text = profil.LinkedInUrl;

            _currentLogoPath = profil.LogoPath;
            if (!string.IsNullOrEmpty(_currentLogoPath))
            {
                try
                {
                    pbLogo.Image = Image.FromFile(_currentLogoPath);
                    foreach (Control c in pbLogo.Controls) if (c is Label) c.Visible = false;
                }
                catch { }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            var model = new CompanyProfileModel
            {
                CompanyName = txtFirmaIsmi.Text,
                EstablishmentYear = txtYil.Text,
                Sector = cmbSektor.SelectedItem?.ToString(),
                AboutUs = rtbHakkimizda.Text,
                CompanySize = cmbBuyukluk.SelectedItem?.ToString(),
                Address = rtbAdres.Text,
                Phone = txtTelefon.Text,
                Email = txtEmail.Text,
                Website = txtWeb.Text,
                Whatsapp = txtWhatsapp.Text,
                InstagramUrl = txtInstagram.Text,
                LinkedInUrl = txtLinkedin.Text,
                LogoPath = _currentLogoPath
            };

            bool sonuc = _service.SaveProfile(model);
            if (sonuc)
                MessageBox.Show("Profil başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lütfen firma ismini giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PbLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _currentLogoPath = ofd.FileName;
                    pbLogo.Image = Image.FromFile(_currentLogoPath);
                    foreach (Control c in pbLogo.Controls) if (c is Label) c.Visible = false;
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private Label EtiketOlustur(string text)
        {
            // Yazı rengini koyu gri yaparak açık arka planda okunmasını sağla
            return new Label { Text = text, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64), AutoSize = true, Dock = DockStyle.Top, Padding = new Padding(0, 0, 0, 5) };
        }

        private Panel FormGrupOlustur(string baslik, Control c)
        {
            Panel p = new Panel { Height = 65, Dock = DockStyle.Top, Margin = new Padding(0, 0, 0, 15) };
            p.Controls.Add(EtiketOlustur(baslik));
            c.Dock = DockStyle.Fill;
            c.Font = new Font("Segoe UI", 10);
            if (c is ComboBox cmb) cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            p.Controls.Add(c);
            p.Controls.SetChildIndex(c, 0);
            return p;
        }
    }
}