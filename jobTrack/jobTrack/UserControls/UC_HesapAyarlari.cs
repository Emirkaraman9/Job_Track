using jobTrack.Helpers;
using jobTrack.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_HesapAyarlari : UserControl
    {
        public event Action<string> SayfaDegistirIstegi;

        public UC_HesapAyarlari()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            TasarimiOlusturResponsive();
            VerileriYukle();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            BackColor = Color.FromArgb(20, 25, 30);
            Name = "UC_HesapAyarlari";
            Size = new Size(1100, 750); // Yüksekliği biraz daha artırdık
            ResumeLayout(false);
        }

        private void TasarimiOlusturResponsive()
        {
            // --- ANA DÜZEN ---
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.ColumnCount = 2;
            mainLayout.RowCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            mainLayout.Padding = new Padding(25);
            this.Controls.Add(mainLayout);

            // =================================================================
            // 1. SOL PANEL: KİŞİSEL BİLGİLER
            // =================================================================
            Panel pnlSol = new Panel();
            pnlSol.Dock = DockStyle.Fill;
            pnlSol.AutoScroll = true;
            pnlSol.Padding = new Padding(0, 0, 20, 0);
            mainLayout.Controls.Add(pnlSol, 0, 0);

            // Başlık
            Label lblBaslik = new Label { Text = "Kişisel Bilgiler", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.White, AutoSize = true, Location = new Point(0, 0) };
            pnlSol.Controls.Add(lblBaslik);

            // Profil Alanı
            Panel pnlProfil = new Panel { Location = new Point(0, 50), Size = new Size(600, 140), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlSol.Controls.Add(pnlProfil);

            PictureBox pbProfil = new PictureBox
            {
                Size = new Size(110, 110),
                Location = new Point(0, 10),
                BackColor = Color.FromArgb(40, 45, 55),
                BorderStyle = BorderStyle.None,
                SizeMode = PictureBoxSizeMode.CenterImage
            };
            Label lblFotoYazi = new Label { Text = "Profil\nFotoğrafı", ForeColor = Color.Gray, AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, BackColor = Color.Transparent };
            pbProfil.Controls.Add(lblFotoYazi);
            pnlProfil.Controls.Add(pbProfil);

            Button btnCvYukle = new Button { Text = "CV YÜKLE (.pdf)", Size = new Size(180, 40), Location = new Point(130, 45), FlatStyle = FlatStyle.Flat, ForeColor = Color.White, Cursor = Cursors.Hand };
            btnCvYukle.FlatAppearance.BorderColor = Color.FromArgb(0, 150, 136);
            pnlProfil.Controls.Add(btnCvYukle);

            // Form Alanları Izgarası
            TableLayoutPanel formGrid = new TableLayoutPanel();
            formGrid.Location = new Point(0, 200);
            formGrid.Width = pnlSol.Width - 40;
            formGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            formGrid.ColumnCount = 2;
            formGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formGrid.RowCount = 4;
            formGrid.AutoSize = true; // İçeriğe göre genişlemesini sağla
            for (int i = 0; i < 4; i++) formGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));

            pnlSol.Controls.Add(formGrid);

            EkleInputToGrid(formGrid, "Ad:", "txtAd", 0, 0);
            EkleInputToGrid(formGrid, "Soyad:", "txtSoyad", 1, 0);
            EkleInputToGrid(formGrid, "Kullanıcı Adı:", "txtKullaniciAdi", 0, 1);
            EkleInputToGrid(formGrid, "E-posta:", "txtEmail", 1, 1);
            EkleInputToGrid(formGrid, "Doğum Tarihi:", "dtpDogumTarihi", 0, 2, isDate: true);
            EkleInputToGrid(formGrid, "Telefon Numarası:", "txtTelefon", 1, 2);
            EkleInputToGrid(formGrid, "Mevcut/Mezun Okul:", "txtOkul", 0, 3);
            EkleInputToGrid(formGrid, "Bölüm/Derece:", "txtBolum", 1, 3);

            // Konum Alanı
            Panel pnlKonum = new Panel { Location = new Point(0, 560), Height = 80, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, Width = pnlSol.Width - 40 };
            Label lblKonum = new Label { Text = "Konum:", ForeColor = Color.Gray, Location = new Point(0, 5), AutoSize = true };
            TextBox txtKonum = new TextBox { Name = "txtKonum", Location = new Point(0, 30), Height = 35, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, BackColor = Color.FromArgb(30, 35, 40), ForeColor = Color.White, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10) };
            pnlKonum.Controls.Add(lblKonum);
            pnlKonum.Controls.Add(txtKonum);
            pnlSol.Controls.Add(pnlKonum);

            // Alt Butonlar
            Panel pnlButonlar = new Panel { Location = new Point(0, 650), Height = 80, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            Button btnVazgec = new Button { Text = "Vazgeç", Size = new Size(120, 45), Location = new Point(0, 0), FlatStyle = FlatStyle.Flat, ForeColor = Color.White, BackColor = Color.FromArgb(60, 60, 60) };
            Button btnKaydet = new Button { Text = "Değişiklikleri Kaydet", Size = new Size(220, 45), Location = new Point(135, 0), FlatStyle = FlatStyle.Flat, ForeColor = Color.White, BackColor = Color.FromArgb(0, 150, 136) };

            btnVazgec.Click += (s, e) => SayfaDegistirIstegi?.Invoke("Anasayfa");
            btnKaydet.Click += BtnKaydet_Click;

            pnlButonlar.Controls.Add(btnVazgec);
            pnlButonlar.Controls.Add(btnKaydet);
            pnlSol.Controls.Add(pnlButonlar);


            // =================================================================
            // 2. SAĞ PANEL: AYARLAR MENÜSÜ
            // =================================================================
            Panel pnlSag = new Panel();
            pnlSag.Dock = DockStyle.Fill;
            pnlSag.Padding = new Padding(30, 0, 0, 0);
            mainLayout.Controls.Add(pnlSag, 1, 0);

            Label lblAyarlarBaslik = new Label { Text = "Ayarlar", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Top, Height = 60 };
            pnlSag.Controls.Add(lblAyarlarBaslik);

            FlowLayoutPanel flowMenu = new FlowLayoutPanel();
            flowMenu.Dock = DockStyle.Fill;
            flowMenu.FlowDirection = FlowDirection.TopDown;
            flowMenu.WrapContents = false;
            flowMenu.AutoScroll = true;
            pnlSag.Controls.Add(flowMenu);

            EkleMenuButonuResponsive(flowMenu, "👤  Hesap Tercihleri");
            EkleMenuButonuResponsive(flowMenu, "🛡️  Oturum Açma ve Güvenlik");
            EkleMenuButonuResponsive(flowMenu, "👁️  Görünürlük");
            EkleMenuButonuResponsive(flowMenu, "🔔  Bildirimler");

            flowMenu.Controls.Add(new Panel { Height = 25, Width = 10 });

            string[] linkler = { "Yardım Merkezi", "Kullanıcı Anlaşması", "Gizlilik Politikası", "Erişilebilirlik" };
            foreach (var link in linkler)
            {
                Label lblLink = new Label { Text = link, ForeColor = Color.Silver, Font = new Font("Segoe UI", 9), Margin = new Padding(10, 8, 0, 8), AutoSize = true, Cursor = Cursors.Hand };
                flowMenu.Controls.Add(lblLink);
            }

            flowMenu.Controls.Add(new Panel { Height = 35, Width = 10 });

            Button btnCikis = new Button { Text = "Oturumu Kapat", Height = 50, Width = 280, FlatStyle = FlatStyle.Flat, ForeColor = Color.Tomato, BackColor = Color.FromArgb(40, 30, 30), Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            btnCikis.FlatAppearance.BorderColor = Color.Tomato;
            btnCikis.Click += (s, e) =>
            {
                SessionManager.SignOut();
                SayfaDegistirIstegi?.Invoke("Karsilama");
            };
            flowMenu.Controls.Add(btnCikis);
        }

        private void EkleInputToGrid(TableLayoutPanel grid, string baslik, string name, int col, int row, bool isDate = false)
        {
            Panel pnlItem = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 0, 20, 0) };

            Label lbl = new Label { Text = baslik, ForeColor = Color.Gray, Dock = DockStyle.Top, Height = 22, AutoSize = false, TextAlign = ContentAlignment.BottomLeft, Font = new Font("Segoe UI", 9) };

            Control ctrl;
            if (isDate) ctrl = new DateTimePicker { Format = DateTimePickerFormat.Short, Height = 32 };
            else ctrl = new TextBox { BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 11) };

            ctrl.Name = name;
            ctrl.Dock = DockStyle.Top;
            ctrl.BackColor = Color.FromArgb(30, 35, 40);
            ctrl.ForeColor = Color.White;

            pnlItem.Controls.Add(ctrl);
            pnlItem.Controls.Add(lbl);

            grid.Controls.Add(pnlItem, col, row);
        }

        private void EkleMenuButonuResponsive(FlowLayoutPanel flow, string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Height = 55;
            btn.Width = 300;
            btn.Padding = new Padding(15, 0, 0, 0);
            btn.Margin = new Padding(0, 0, 0, 12);
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(30, 35, 40);
            btn.FlatAppearance.BorderColor = Color.FromArgb(50, 55, 60);
            btn.Cursor = Cursors.Hand;
            flow.Controls.Add(btn);
        }

        private void VerileriYukle()
        {
            if (SessionManager.GirisYapanKullanici != null)
            {
                var k = SessionManager.GirisYapanKullanici;
                SetData("txtAd", k.Ad);
                SetData("txtSoyad", k.Soyad);
                SetData("txtKullaniciAdi", k.KullaniciAdi);
                SetData("txtEmail", k.Email);
                SetData("txtTelefon", k.Telefon);

                // DateTime Picker kontrolü için modelde DogumTarihi olmalı
                // if (k.DogumTarihi != null) SetData("dtpDogumTarihi", k.DogumTarihi);

                // Diğer alanlar (Okul, Bölüm, Konum) modelinizde varsa buraya ekleyin:
                // SetData("txtOkul", k.Okul);
                // SetData("txtBolum", k.Bolum);
                // SetData("txtKonum", k.Konum);
            }
        }

        private void SetData(string name, object value)
        {
            if (value == null) return;

            Control[] ctrls = this.Controls.Find(name, true);
            if (ctrls.Length > 0)
            {
                if (ctrls[0] is DateTimePicker dtp && value is DateTime dateValue)
                {
                    dtp.Value = dateValue;
                }
                else
                {
                    ctrls[0].Text = value.ToString();
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bilgileriniz başarıyla güncellendi!", "jobTrack", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}