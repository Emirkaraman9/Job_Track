using jobTrack.Helpers;
using jobTrack.Models;   // Modelleri kullan
using jobTrack.Services; // Servisi kullan
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_Sirket_Basvurular : UserControl
    {
        // Servis sınıfı
        private readonly ApplicationService _service;

        // DataGridView ve Veri Listesi (Filtreleme için bellekte tutuyoruz)
        private DataGridView dgv;
        private List<ApplicationRecordModel> _basvuruListesi;

        public UC_Sirket_Basvurular()
        {
            InitializeComponent();

            // Servisi başlat ve verileri çek
            _service = new ApplicationService();
            _basvuruListesi = _service.GetAllApplications();

            // Tasarımı oluştur
            TasarimiOlustur();
        }

        private void InitializeComponent()
        {
            this.Name = "UC_Sirket_Basvurular";
            this.Size = new Size(1100, 800);
            this.BackColor = Color.WhiteSmoke;
        }

        private void TasarimiOlustur()
        {
            // --- 1. ANA KAPLAYICI ---
            Panel main = new Panel { Dock = DockStyle.Fill, Padding = new Padding(30) };
            this.Controls.Add(main);

            // --- 2. BAŞLIK ---
            Label lblBaslik = new Label
            {
                Text = "Başvuru Listesi",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Dock = DockStyle.Top,
                Height = 60
            };
            main.Controls.Add(lblBaslik);

            // --- 3. FİLTRE ALANI ---
            Panel pnlFiltreContainer = new Panel { Dock = DockStyle.Top, Height = 80, Padding = new Padding(0, 20, 0, 10) };
            main.Controls.Add(pnlFiltreContainer);

            Panel pnlFiltreBox = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            pnlFiltreBox.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, pnlFiltreBox.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
            pnlFiltreContainer.Controls.Add(pnlFiltreBox);

            TableLayoutPanel tlpFiltre = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(10) };
            tlpFiltre.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpFiltre.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlFiltreBox.Controls.Add(tlpFiltre);

            // Sol Taraf: Arama
            FlowLayoutPanel flpArama = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
            TextBox txtAra = new TextBox { PlaceholderText = "Aday Adı veya Pozisyon Ara...", Font = new Font("Segoe UI", 11), Size = new Size(250, 30), Margin = new Padding(0, 5, 10, 0) };
            Button btnAra = new Button { Text = "Ara", BackColor = Color.SteelBlue, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(80, 32), Cursor = Cursors.Hand, Font = new Font("Segoe UI", 10, FontStyle.Bold), Margin = new Padding(0, 4, 0, 0) };
            flpArama.Controls.Add(txtAra);
            flpArama.Controls.Add(btnAra);
            tlpFiltre.Controls.Add(flpArama, 0, 0);

            // Sağ Taraf: Dropdownlar
            FlowLayoutPanel flpFiltreler = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft, AutoSize = true };

            // Durum Filtresi
            ComboBox cmbDurum = new ComboBox { Text = "Tümü", Font = new Font("Segoe UI", 10), Size = new Size(160, 30), DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(10, 5, 0, 0) };
            cmbDurum.Items.AddRange(new string[] { "Tümü", "Beklemede", "Mülakat", "Reddedildi", "Kabul" });
            cmbDurum.SelectedIndex = 0;

            // Filtreleme Olayı
            cmbDurum.SelectedIndexChanged += (s, e) => {
                GridiDoldur(cmbDurum.SelectedItem.ToString());
            };

            // İlan Filtresi (Görsel)
            ComboBox cmbIlan = new ComboBox { Text = "İlan: Tümü", Font = new Font("Segoe UI", 10), Size = new Size(160, 30), DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(0, 5, 0, 0) };
            cmbIlan.Items.AddRange(new string[] { "Tümü", "#3424 - PC Müh.", "#3425 - İK" });

            flpFiltreler.Controls.Add(cmbDurum);
            flpFiltreler.Controls.Add(cmbIlan);
            tlpFiltre.Controls.Add(flpFiltreler, 1, 0);

            // --- 4. LİSTE (GRID) ---
            Panel pnlGridContainer = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 10, 0, 0) };
            main.Controls.Add(pnlGridContainer);

            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.RowTemplate.Height = 50;
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgv.DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.EnableHeadersVisualStyles = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.WhiteSmoke;

            dgv.Columns.Add("No", "İlan No");
            dgv.Columns.Add("AdSoyad", "Aday Adı Soyadı");
            dgv.Columns.Add("Pozisyon", "Başvurulan Pozisyon");
            dgv.Columns.Add("Tarih", "Başvuru Tarihi");
            dgv.Columns.Add("Durum", "Durum");

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
            {
                Name = "Islem",
                HeaderText = "İşlem",
                Text = "Detay",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            btnCol.DefaultCellStyle.ForeColor = Color.SteelBlue;
            btnCol.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.Columns.Add(btnCol);

            // Renklendirme
            dgv.CellFormatting += (s, e) => {
                if (dgv.Columns[e.ColumnIndex].Name == "Durum" && e.Value != null)
                {
                    string d = e.Value.ToString();
                    e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    if (d == "Beklemede") e.CellStyle.ForeColor = Color.Orange;
                    else if (d == "Mülakat") e.CellStyle.ForeColor = Color.RoyalBlue;
                    else if (d == "Reddedildi") e.CellStyle.ForeColor = Color.IndianRed;
                    else if (d == "Kabul") e.CellStyle.ForeColor = Color.SeaGreen;
                }
            };

            // Sayfa Geçişi
            dgv.CellClick += (s, e) => {
                if (e.ColumnIndex == dgv.Columns["Islem"].Index && e.RowIndex >= 0)
                {
                    // Seçilen satırdan ID'yi al
                    string basvuruId = dgv.Rows[e.RowIndex].Cells["No"].Value.ToString();

                    Panel parent = this.Parent as Panel;
                    if (parent != null)
                    {
                        parent.Controls.Clear();
                        // Detay sayfasına yönlendir (ID parametresi ile)
                        UC_Sirket_BasvuruDetay detay = new UC_Sirket_BasvuruDetay(basvuruId);
                        detay.Dock = DockStyle.Fill;
                        parent.Controls.Add(detay);
                    }
                }
            };

            pnlGridContainer.Controls.Add(dgv);
            pnlGridContainer.BringToFront();
            pnlFiltreContainer.SendToBack();

            // İlk Açılış: Tümü
            GridiDoldur("Tümü");
        }

        // --- FİLTRELEME FONKSİYONU ---
        private void GridiDoldur(string durumFiltresi)
        {
            if (dgv == null || _basvuruListesi == null) return;

            dgv.Rows.Clear(); // Tabloyu temizle

            foreach (var kayit in _basvuruListesi)
            {
                // Eğer "Tümü" seçiliyse HEPSİNİ ekle, değilse duruma göre filtrele
                if (durumFiltresi == "Tümü" || kayit.Status == durumFiltresi)
                {
                    dgv.Rows.Add(kayit.Id, kayit.ApplicantName, kayit.Position, kayit.ApplicationDate, kayit.Status);
                }
            }
        }
    }
}