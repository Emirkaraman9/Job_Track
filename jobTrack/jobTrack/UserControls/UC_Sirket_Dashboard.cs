using jobTrack.Helpers;
using jobTrack.Models;   // Modelleri kullan
using jobTrack.Services; // Servisi kullan
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_Sirket_Dashboard : UserControl
    {
        // Servis sınıfını tanımlıyoruz
        private readonly DashboardService _service;

        public UC_Sirket_Dashboard()
        {
            InitializeComponent();

            // Servisi başlatıyoruz
            _service = new DashboardService();

            // Verileri servisten çekiyoruz (Backend ile iletişim)
            var dashboardData = _service.GetDashboardData();

            // Gelen veriyi kullanarak tasarımı çiziyoruz
            TasarimiOlustur(dashboardData);
        }

        private void InitializeComponent()
        {
            this.Name = "UC_Sirket_Dashboard";
            this.Size = new Size(1100, 800);
            this.BackColor = Color.WhiteSmoke;
            this.AutoScroll = true;
            // Çift tamponlama (titreşimi önlemek için)
            this.DoubleBuffered = true;
        }

        private void TasarimiOlustur(DashboardViewModel data)
        {
            // --- 1. ANA KAPLAYICI ---
            Panel mainPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(30) };
            this.Controls.Add(mainPanel);

            // --- 2. ANA DÜZEN (Başlık + İçerik) ---
            TableLayoutPanel tlpAna = new TableLayoutPanel();
            tlpAna.Dock = DockStyle.Fill;
            tlpAna.ColumnCount = 1;
            tlpAna.RowCount = 2;
            tlpAna.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tlpAna.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainPanel.Controls.Add(tlpAna);

            // Başlık
            Label lblBaslik = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 48),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            tlpAna.Controls.Add(lblBaslik, 0, 0);

            // --- 3. İÇERİK GRID (2x2) ---
            TableLayoutPanel tlpIcerik = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Margin = new Padding(0, 10, 0, 0)
            };
            tlpIcerik.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpIcerik.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpIcerik.RowStyles.Add(new RowStyle(SizeType.Absolute, 320F)); // Üst Bölüm Yüksekliği
            tlpIcerik.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Alt Bölüm
            tlpAna.Controls.Add(tlpIcerik, 0, 1);

            // =========================================================
            // SOL ÜST: İSTATİSTİK KARTLARI
            // =========================================================
            Panel pnlStatsContainer = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 0, 15, 15) };
            tlpIcerik.Controls.Add(pnlStatsContainer, 0, 0);

            TableLayoutPanel tlpStats = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 2
            };
            // Satır/Sütun ayarları
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Alt Başlık
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlStatsContainer.Controls.Add(tlpStats);

            Label lblStatBaslik = new Label { Text = "Şirket İstatistikleri", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.DimGray, Dock = DockStyle.Fill, TextAlign = ContentAlignment.BottomLeft };
            tlpStats.Controls.Add(lblStatBaslik, 0, 0);
            tlpStats.SetColumnSpan(lblStatBaslik, 2);

            // Kartları Dinamik Olarak Ekle (Modeldeki sıraya göre)
            if (data.Stats.Count >= 4)
            {
                tlpStats.Controls.Add(KartOlustur(data.Stats[0]), 0, 1);
                tlpStats.Controls.Add(KartOlustur(data.Stats[1]), 1, 1);
                tlpStats.Controls.Add(KartOlustur(data.Stats[2]), 0, 2);
                tlpStats.Controls.Add(KartOlustur(data.Stats[3]), 1, 2);
            }

            // =========================================================
            // SAĞ ÜST: ŞİRKET PUANI
            // =========================================================
            Panel pnlPuanContainer = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15, 0, 0, 15) };
            tlpIcerik.Controls.Add(pnlPuanContainer, 1, 0);

            Panel pnlPuanKutu = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            pnlPuanKutu.Paint += BorderCiz;
            pnlPuanContainer.Controls.Add(pnlPuanKutu);

            TableLayoutPanel tlpPuanMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(25), RowCount = 2, ColumnCount = 1 };
            tlpPuanMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlpPuanMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlPuanKutu.Controls.Add(tlpPuanMain);

            tlpPuanMain.Controls.Add(new Label { Text = "Şirket Puanı", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.DimGray, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 0);

            TableLayoutPanel tlpDetay = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            tlpDetay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpDetay.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlpPuanMain.Controls.Add(tlpDetay, 0, 1);

            // Sol Puan Özeti
            Panel pnlSolPuan = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 15, 0, 0) };
            pnlSolPuan.Controls.Add(new Label { Text = $"{data.Rating.TotalVotes} Değerlendirme", Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, Dock = DockStyle.Top, TextAlign = ContentAlignment.TopCenter, Height = 30 });
            pnlSolPuan.Controls.Add(new Label { Text = "Toplam", Font = new Font("Segoe UI", 16), ForeColor = Color.Gray, Dock = DockStyle.Top, TextAlign = ContentAlignment.TopCenter, Height = 35 });
            pnlSolPuan.Controls.Add(new Label { Text = data.Rating.AverageScore, Font = new Font("Segoe UI", 48, FontStyle.Bold), ForeColor = Color.FromArgb(50, 50, 50), Dock = DockStyle.Top, TextAlign = ContentAlignment.BottomCenter, Height = 100 });
            tlpDetay.Controls.Add(pnlSolPuan, 0, 0);

            // Sağ Barlar (Modelden döngü ile)
            TableLayoutPanel tlpBarlar = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10, 10, 0, 10), RowCount = 5, ColumnCount = 1 };
            for (int i = 0; i < 5; i++) tlpBarlar.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            int row = 0;
            // Modeldeki yıldız dağılımını dönüyoruz
            foreach (var star in data.Rating.StarDistribution)
            {
                tlpBarlar.Controls.Add(OzelPuanSatiri(star.StarCount, star.Percentage, star.VoteCount), 0, row);
                row++;
            }
            tlpDetay.Controls.Add(tlpBarlar, 1, 0);

            // =========================================================
            // ALT KISIM: TABLOLAR
            // =========================================================

            // Tablo 1: İlanlar
            Panel pnlSolAlt = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 20, 15, 0) };
            tlpIcerik.Controls.Add(pnlSolAlt, 0, 1);
            pnlSolAlt.Controls.Add(TabloOlustur("Mevcut İlanlar", data.Listings));

            // Tablo 2: Başvurular
            Panel pnlSagAlt = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15, 20, 0, 0) };
            tlpIcerik.Controls.Add(pnlSagAlt, 1, 1);
            pnlSagAlt.Controls.Add(TabloOlustur("Son Gelen Başvurular", data.RecentApplications));
        }

        // --- YARDIMCI METODLAR ---

        // StatCardModel alan yeni kart fonksiyonu
        private Panel KartOlustur(StatCardModel model)
        {
            Panel pOuter = new Panel { Dock = DockStyle.Fill, Padding = new Padding(5) };
            Panel pInner = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            pInner.Paint += BorderCiz;

            Panel pSerit = new Panel { Dock = DockStyle.Left, Width = 6, BackColor = model.IndicatorColor };
            pInner.Controls.Add(pSerit);

            Label lDeger = new Label { Text = model.Value, Font = new Font("Segoe UI", 22, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(15, 0, 0, 0) };
            pInner.Controls.Add(lDeger);

            Label lBaslik = new Label { Text = model.Title, Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, Dock = DockStyle.Bottom, Height = 35, TextAlign = ContentAlignment.TopLeft, Padding = new Padding(15, 5, 0, 0) };
            pInner.Controls.Add(lBaslik);

            lDeger.BringToFront();
            pOuter.Controls.Add(pInner);
            return pOuter;
        }

        // Generic veri listesi alan tablo fonksiyonu
        private Control TabloOlustur(string baslik, object veriListesi)
        {
            TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label lbl = new Label { Text = baslik, Font = new Font("Segoe UI", 12, FontStyle.Bold), Dock = DockStyle.Fill, TextAlign = ContentAlignment.BottomLeft };
            tlp.Controls.Add(lbl, 0, 0);

            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgv.EnableHeadersVisualStyles = false;

            // Gelen listeye göre sütunları ve satırları ekle
            if (veriListesi is List<JobListingModel> listings)
            {
                dgv.Columns.Add("No", "İlan No");
                dgv.Columns.Add("Pozisyon", "Pozisyon");
                dgv.Columns.Add("Durum", "Durum");

                foreach (var item in listings)
                {
                    dgv.Rows.Add(item.Id, item.Position, item.Status);
                }
            }
            else if (veriListesi is List<ApplicationModel> apps)
            {
                dgv.Columns.Add("Isim", "Aday");
                dgv.Columns.Add("Pozisyon", "Pozisyon");
                dgv.Columns.Add("Durum", "Durum");

                foreach (var item in apps)
                {
                    dgv.Rows.Add(item.ApplicantName, item.Position, item.Status);
                }

                // Durum sütununu renklendir
                dgv.CellFormatting += (s, e) =>
                {
                    if (dgv.Columns[e.ColumnIndex].Name == "Durum" && e.Value != null)
                    {
                        string d = e.Value.ToString();
                        e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        if (d == "Beklemede") e.CellStyle.ForeColor = Color.Orange;
                        else if (d == "İnceleniyor") e.CellStyle.ForeColor = Color.RoyalBlue;
                        else if (d == "Reddedildi") e.CellStyle.ForeColor = Color.IndianRed;
                    }
                };
            }

            tlp.Controls.Add(dgv, 0, 1);
            return tlp;
        }

        // --- GRAFİK & ÇİZİM FONKSİYONLARI ---
        private Panel OzelPuanSatiri(int yildizNo, int yuzde, int kisiSayisi)
        {
            Panel p = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };

            p.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                int w = p.Width;
                int h = p.Height;

                // Sol Taraf (Yıldız)
                string textStar = yildizNo.ToString();
                Font fStar = new Font("Segoe UI", 10, FontStyle.Bold);
                Brush bText = new SolidBrush(Color.FromArgb(80, 80, 80));
                string icon = "★";
                Font fIcon = new Font("Segoe UI", 12);
                Brush bIcon = new SolidBrush(Color.Orange);

                g.DrawString(textStar, fStar, bText, 0, h / 2 - 8);
                g.DrawString(icon, fIcon, bIcon, 15, h / 2 - 10);

                // Orta (Progress Bar)
                int barX = 45;
                int rightTextSpace = 80;
                int barWidth = w - barX - rightTextSpace;
                int barHeight = 10;
                int barY = h / 2 - barHeight / 2;

                if (barWidth > 0)
                {
                    // Arka Plan
                    Rectangle rectBg = new Rectangle(barX, barY, barWidth, barHeight);
                    using (GraphicsPath pathBg = RoundedRect(rectBg, 4))
                    using (SolidBrush brushBg = new SolidBrush(Color.FromArgb(230, 230, 230)))
                    {
                        g.FillPath(brushBg, pathBg);
                    }

                    // Dolu Kısım
                    int fillW = (int)(barWidth * (yuzde / 100.0f));
                    if (fillW > 4)
                    {
                        Rectangle rectFill = new Rectangle(barX, barY, fillW, barHeight);
                        using (GraphicsPath pathFill = RoundedRect(rectFill, 4))
                        using (SolidBrush brushFill = new SolidBrush(Color.Orange))
                        {
                            g.FillPath(brushFill, pathFill);
                        }
                    }
                }

                // Sağ (Metin)
                string statText = $"%{yuzde} ({kisiSayisi})";
                Font fStat = new Font("Segoe UI", 9, FontStyle.Regular);
                Brush bStat = new SolidBrush(Color.Gray);
                SizeF textSize = g.MeasureString(statText, fStat);
                float textX = w - textSize.Width - 5;
                g.DrawString(statText, fStat, bStat, textX, h / 2 - 8);
            };

            p.Resize += (s, e) => p.Invalidate();
            return p;
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0) { path.AddRectangle(bounds); return path; }

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void BorderCiz(object sender, PaintEventArgs e) =>
            ControlPaint.DrawBorder(e.Graphics, ((Control)sender).ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
    }
}