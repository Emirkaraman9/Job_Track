using jobTrack.Helpers;
using jobTrack.Models;   // Modeller
using jobTrack.Services; // Servisler
using System;
using System.Drawing;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_Sirket_IlanOlustur : UserControl
    {
        private readonly JobPostService _service;

        // Form Elemanları (Veriyi okumak için sınıf seviyesinde tanımlı)
        private TextBox txtBaslik;
        private ComboBox cmbCalisma;
        private TextBox txtKonum;
        private ComboBox cmbSektor;
        private DateTimePicker dtpTarih;
        private ComboBox cmbDeneyim;
        private TextBox txtMaas;
        private RichTextBox rtbAciklama;
        private Label lblKarakter;
        private PictureBox pbLogo;
        private string _selectedLogoPath; // Seçilen logonun yolu

        public UC_Sirket_IlanOlustur()
        {
            InitializeComponent();
            _service = new JobPostService(); // Servisi başlat
            TasarimiOlustur();
        }

        private void InitializeComponent()
        {
            this.Name = "UC_Sirket_IlanOlustur";
            this.Size = new Size(1100, 900);
            this.BackColor = Color.WhiteSmoke;
            this.AutoScroll = true;
        }

        private void TasarimiOlustur()
        {
            // --- ANA LAYOUT (TableLayoutPanel) ---
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Top;
            mainLayout.AutoSize = true;
            mainLayout.ColumnCount = 1;
            mainLayout.Padding = new Padding(30);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.Controls.Add(mainLayout);

            // 1. SATIR: SAYFA BAŞLIĞI VE LOGO
            Panel pnlHeader = new Panel { Height = 100, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 20) };
            Label lblSayfaBaslik = new Label { Text = "Yeni İlan Oluştur", Font = new Font("Segoe UI", 24, FontStyle.Bold), ForeColor = Color.FromArgb(45, 45, 48), AutoSize = true, Location = new Point(0, 10) };
            pnlHeader.Controls.Add(lblSayfaBaslik);

            // Logo
            pbLogo = new PictureBox
            {
                Size = new Size(120, 80),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                Location = new Point(pnlHeader.Width - 120, 10),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            pbLogo.Click += LogoYukle_Click;
            Label lblLogoText = new Label { Text = "Logo Yükle\n(Tıkla)", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, ForeColor = Color.Gray };
            lblLogoText.Click += LogoYukle_Click;
            pbLogo.Controls.Add(lblLogoText);
            pnlHeader.Controls.Add(pbLogo);
            mainLayout.Controls.Add(pnlHeader, 0, 0);

            // 2. SATIR: FORM ALANLARI (2 Sütunlu Grid)
            TableLayoutPanel formGrid = new TableLayoutPanel();
            formGrid.Dock = DockStyle.Fill;
            formGrid.AutoSize = true;
            formGrid.ColumnCount = 2;
            formGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            formGrid.RowCount = 8; // Satır sayısı arttı
            mainLayout.Controls.Add(formGrid, 0, 1);

            // -- İlan Başlığı --
            formGrid.Controls.Add(CreateLabel("İlan Başlığı"), 0, 0);
            txtBaslik = CreateTextBox("Örn: Senior Software Developer");
            formGrid.Controls.Add(txtBaslik, 0, 1);
            formGrid.SetColumnSpan(txtBaslik, 2);

            // -- Çalışma Şekli & Konum --
            formGrid.Controls.Add(CreateLabel("Çalışma Şekli"), 0, 2);
            formGrid.Controls.Add(CreateLabel("Konum"), 1, 2);

            cmbCalisma = CreateComboBox(_service.GetWorkTypes()); // Servisten çekiyoruz
            formGrid.Controls.Add(cmbCalisma, 0, 3);

            txtKonum = CreateTextBox("Örn: İstanbul, Maslak");
            formGrid.Controls.Add(txtKonum, 1, 3);

            // -- Sektör & Tarih --
            formGrid.Controls.Add(CreateLabel("Sektör"), 0, 4);
            formGrid.Controls.Add(CreateLabel("Yayınlanma Tarihi"), 1, 4);

            cmbSektor = CreateComboBox(_service.GetSectors()); // Servisten çekiyoruz
            formGrid.Controls.Add(cmbSektor, 0, 5);

            dtpTarih = new DateTimePicker { Font = new Font("Segoe UI", 11), Format = DateTimePickerFormat.Short, Dock = DockStyle.Top, Height = 35 };
            formGrid.Controls.Add(dtpTarih, 1, 5);

            // -- Deneyim & Maaş --
            formGrid.Controls.Add(CreateLabel("Deneyim Düzeyi"), 0, 6);
            formGrid.Controls.Add(CreateLabel("Maaş Aralığı (Opsiyonel)"), 1, 6);

            cmbDeneyim = CreateComboBox(_service.GetExperienceLevels()); // Servisten çekiyoruz
            formGrid.Controls.Add(cmbDeneyim, 0, 7);

            txtMaas = CreateTextBox("Örn: 40.000 - 60.000 TL");
            formGrid.Controls.Add(txtMaas, 1, 7);

            // 3. SATIR: AÇIKLAMA ALANI
            Panel pnlAciklama = new Panel { Dock = DockStyle.Fill, AutoSize = true, Padding = new Padding(0, 20, 0, 0) };
            Label lblAciklamaBaslik = CreateLabel("İlan Açıklaması");
            lblAciklamaBaslik.Dock = DockStyle.Top;

            Panel pnlEditor = new Panel { Dock = DockStyle.Top, Height = 250, BackColor = Color.White };
            pnlEditor.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, pnlEditor.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);

            rtbAciklama = new RichTextBox { BorderStyle = BorderStyle.None, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 11), Margin = new Padding(10) };
            pnlEditor.Padding = new Padding(10);
            pnlEditor.Controls.Add(rtbAciklama);

            lblKarakter = new Label { Text = "0/2000", Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, AutoSize = true, Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleRight };
            rtbAciklama.TextChanged += (s, e) => lblKarakter.Text = $"{rtbAciklama.Text.Length}/2000";

            pnlAciklama.Controls.Add(lblKarakter);
            pnlAciklama.Controls.Add(pnlEditor);
            pnlAciklama.Controls.Add(lblAciklamaBaslik);
            mainLayout.Controls.Add(pnlAciklama, 0, 2);

            // 4. SATIR: BUTONLAR
            FlowLayoutPanel flpButonlar = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft, AutoSize = true, Padding = new Padding(0, 20, 0, 0) };

            Button btnYayinla = CreateButton("YAYINLA", Color.SeaGreen);
            btnYayinla.Click += BtnYayinla_Click; // Click Olayı Eklendi

            Button btnTaslak = CreateButton("TASLAK OLUŞTUR", Color.Gray);
            Button btnVazgec = CreateButton("SİL / VAZGEÇ", Color.IndianRed);

            flpButonlar.Controls.Add(btnYayinla);
            flpButonlar.Controls.Add(btnTaslak);
            flpButonlar.Controls.Add(btnVazgec);
            mainLayout.Controls.Add(flpButonlar, 0, 3);
        }

        // --- OLAY YÖNETİCİLERİ ---

        private void BtnYayinla_Click(object sender, EventArgs e)
        {
            // Modeli Oluştur
            var ilanModel = new JobPostModel
            {
                Title = txtBaslik.Text,
                WorkType = cmbCalisma.SelectedItem?.ToString(),
                Location = txtKonum.Text,
                Sector = cmbSektor.SelectedItem?.ToString(),
                PublishDate = dtpTarih.Value,
                ExperienceLevel = cmbDeneyim.SelectedItem?.ToString(),
                SalaryRange = txtMaas.Text,
                Description = rtbAciklama.Text,
                LogoPath = _selectedLogoPath
            };

            // Servise Gönder
            bool basarili = _service.SaveJobPost(ilanModel);

            if (basarili)
            {
                MessageBox.Show("İlan başarıyla yayınlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Burada sayfayı temizleyebilir veya yönlendirme yapabilirsiniz
            }
            else
            {
                MessageBox.Show("Lütfen zorunlu alanları (Başlık ve Açıklama) doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LogoYukle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Şirket Logosu Seç";
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _selectedLogoPath = ofd.FileName;
                        pbLogo.Image = Image.FromFile(_selectedLogoPath);
                        pbLogo.Controls.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        // --- YARDIMCI METODLAR ---

        private Label CreateLabel(string text)
        {
            return new Label { Text = text, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DimGray, AutoSize = true, Margin = new Padding(0, 10, 0, 5) };
        }

        private TextBox CreateTextBox(string placeholder)
        {
            return new TextBox { PlaceholderText = placeholder, Font = new Font("Segoe UI", 11), Dock = DockStyle.Top, Height = 35 };
        }

        private ComboBox CreateComboBox(string[] items)
        {
            ComboBox cmb = new ComboBox { Font = new Font("Segoe UI", 11), Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList, Height = 35 };
            cmb.Items.AddRange(items);
            if (items.Length > 0) cmb.SelectedIndex = 0;
            return cmb;
        }

        private Button CreateButton(string text, Color bg)
        {
            return new Button
            {
                Text = text,
                BackColor = bg,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Size = new Size(160, 45),
                Cursor = Cursors.Hand,
                Margin = new Padding(10, 0, 0, 0)
            };
        }
    }
}