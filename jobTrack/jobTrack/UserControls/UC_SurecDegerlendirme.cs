using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using jobTrack.Models;
using jobTrack.Services;

namespace jobTrack.UserControls
{
    /// <summary>
    /// 1200x800 boyutunda, ekranın üst kısmına daha yakın konumlanan modern süreç değerlendirme ekranı.
    /// İçerik bir "Kart" yapısı içindedir ve dikey taşma yapmaması için optimize edilmiştir.
    /// </summary>
    public partial class UC_SurecDegerlendirme : UserControl
    {
        // Renk Paleti
        private readonly Color clrBg = Color.FromArgb(15, 20, 25);     // Dış arka plan (Koyu Lacivert/Siyah)
        private readonly Color clrCardBg = Color.FromArgb(25, 30, 35); // Kart arka planı
        private readonly Color clrText = Color.White;
        private readonly Color clrAccent = Color.Turquoise;
        private readonly Color clrPanelBg = Color.FromArgb(40, 45, 50);
        private readonly Color clrBorder = Color.FromArgb(60, 65, 70);

        private ProcessEvaluationModel _model;
        private readonly EvaluationService _evaluationService;
        private Label[] starLabels = new Label[5];

        public UC_SurecDegerlendirme(Basvuru basvuru)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = clrBg;
            this.AutoScroll = true; // Konteyner küçülürse kaydırma çubuğu çıksın

            this._evaluationService = new EvaluationService();

            _model = new ProcessEvaluationModel
            {
                BasvuruId = basvuru.Id,
                CompanyName = basvuru.SirketAdi,
                Position = basvuru.Pozisyon,
                Status = basvuru.Durum,
                Date = basvuru.Tarih,
                Location = "Belirtilmedi",
                Description = $"{basvuru.SirketAdi} firması bünyesindeki {basvuru.Pozisyon} pozisyonu mülakat süreci.",
                UserRating = 0,
                UserComment = "",
                IsAnonymous = false
            };

            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            this.Controls.Clear();

            // --- MERKEZLEME KATMANI (TableLayoutPanel 3x3) ---
            TableLayoutPanel centeringLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3,
                BackColor = Color.Transparent
            };

            // Kenar boşluklarını dinamik ayarla (% - Sabit - %)
            centeringLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            centeringLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1200f)); // Hedef Genişlik
            centeringLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            // Dikey konumlandırma: Üst boşluk %30, Alt boşluk %70 (Yukarı taşındı)
            centeringLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30f));
            centeringLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 800f)); // Hedef Yükseklik
            centeringLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 70f));

            // --- ANA KART PANELİ ---
            Panel pnlCard = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = clrCardBg,
                Padding = new Padding(20),
                BorderStyle = BorderStyle.None
            };

            // Üst Navigasyon
            Panel pnlNav = new Panel { Dock = DockStyle.Top, Height = 45 };
            Button btnBack = new Button
            {
                Text = "← Geri Dön",
                FlatStyle = FlatStyle.Flat,
                ForeColor = clrAccent,
                Width = 200,
                Dock = DockStyle.Left,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold)
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => SayfayiKapatVeListeyeDon();
            pnlNav.Controls.Add(btnBack);

            // İçerik Izgarası (Sol Bilgi - Sağ Giriş)
            TableLayoutPanel mainContentGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 15, 0, 0)
            };
            mainContentGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
            mainContentGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));

            Panel pnlLeft = CreateStyledContainer();
            AddLeftContent(pnlLeft);

            Panel pnlRight = CreateStyledContainer();
            AddRightContent(pnlRight);

            mainContentGrid.Controls.Add(pnlLeft, 0, 0);
            mainContentGrid.Controls.Add(pnlRight, 1, 0);

            // Panelleri birleştir
            pnlCard.Controls.Add(mainContentGrid);
            pnlCard.Controls.Add(pnlNav);

            // Kartı merkeze ekle
            centeringLayout.Controls.Add(pnlCard, 1, 1);
            this.Controls.Add(centeringLayout);
        }

        private void AddLeftContent(Panel parent)
        {
            TableLayoutPanel leftLayout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45f));  // Durum
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150f)); // Firma/Pozisyon Kutuları
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));  // Detay Metni

            Label lblStatus = new Label
            {
                Text = $"● {_model.Status.ToUpper()} | {_model.Date:dd.MM.yyyy}",
                Dock = DockStyle.Fill,
                ForeColor = clrAccent,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Panel pnlInfoBoxes = new Panel { Dock = DockStyle.Fill };
            pnlInfoBoxes.Controls.Add(CreateDataBlock($"POZİSYON\n{_model.Position}", DockStyle.Bottom, 65));
            pnlInfoBoxes.Controls.Add(new Panel { Dock = DockStyle.Bottom, Height = 10 });
            pnlInfoBoxes.Controls.Add(CreateDataBlock($"FİRMA\n{_model.CompanyName}", DockStyle.Top, 65));

            Label lblDetails = new Label
            {
                Text = $"SÜREÇ DETAYLARI VE NOTLAR:\n\nSayın Serkan Demirtaş,\r\nApple mülakat sürecine katılımınız için teşekkür ederiz. Gerçekleştirilen teknik ve yetkinlik görüşmeleri kapsamında; sistem mimarisi tasarımı, yüksek erişilebilirlik ve ölçeklenebilir yazılım yapıları, tasarım desenleri ve mimari karar alma süreçlerindeki yaklaşımınız detaylı olarak değerlendirilmiştir. Ekiplerimiz, teknik liderlik bakış açınızın ve karmaşık sistemleri sadeleştirerek yapılandırma becerinizin Software Architect pozisyonu ile güçlü bir uyum gösterdiğini belirtmiştir. Pozisyon özelindeki değerlendirme süreci devam etmekte olup, sonraki adımlar ve nihai geri bildirim tarafınıza ayrıca iletilecektir.\n\nLokasyon: Apple Park, Cupertino, Kaliforniya, ABD",
                Dock = DockStyle.Fill,
                ForeColor = clrText,
                Font = new Font("Segoe UI", 10f),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(30, 35, 40),
                Margin = new Padding(0, 15, 0, 0)
            };

            leftLayout.Controls.Add(lblStatus, 0, 0);
            leftLayout.Controls.Add(pnlInfoBoxes, 0, 1);
            leftLayout.Controls.Add(lblDetails, 0, 2);

            parent.Controls.Add(leftLayout);
        }

        private void AddRightContent(Panel parent)
        {
            TableLayoutPanel rightLayout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 5 };
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70f));  // Yıldız Puanlama
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35f));  // Yorum Başlığı
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f)); // Metin Kutusu
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70f));  // Kanıt Yükle Butonu
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70f));  // İşlem Butonları

            // 1. Yıldızlar
            FlowLayoutPanel pnlStars = new FlowLayoutPanel { Dock = DockStyle.Fill, Margin = new Padding(0), WrapContents = false };
            Label lblStarTitle = new Label { Text = "Süreci Puanla:", ForeColor = clrText, AutoSize = true, Font = new Font("Segoe UI", 12f, FontStyle.Bold), Margin = new Padding(0, 20, 10, 0) };
            pnlStars.Controls.Add(lblStarTitle);

            for (int i = 0; i < 5; i++)
            {
                int ratingValue = i + 1;
                starLabels[i] = new Label { Text = "★", ForeColor = Color.Gray, Font = new Font("Segoe UI", 30f), AutoSize = true, Cursor = Cursors.Hand };
                starLabels[i].Click += (s, e) => { _model.UserRating = ratingValue; UpdateStars(); };
                pnlStars.Controls.Add(starLabels[i]);
            }

            // 2. Yorum Başlığı
            Label lblTitle = new Label { Text = "Deneyim ve Önerileriniz", Dock = DockStyle.Fill, ForeColor = clrText, Font = new Font("Segoe UI", 10.5f, FontStyle.Bold), TextAlign = ContentAlignment.BottomLeft };

            // 3. Yorum Kutusu
            TextBox txtComment = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                BackColor = clrPanelBg,
                ForeColor = clrText,
                Font = new Font("Segoe UI", 12f),
                Text = _model.UserComment,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 5, 0, 5)
            };
            txtComment.TextChanged += (s, e) => _model.UserComment = txtComment.Text;

            // 4. Kanıt Yükleme
            Button btnUpload = new Button
            {
                Text = "📷 Süreçle İlgili Görsel / Kanıt Yükleyiniz",
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                ForeColor = clrText,
                BackColor = Color.FromArgb(50, 55, 60),
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 10, 0, 10)
            };
            btnUpload.FlatAppearance.BorderColor = clrBorder;
            btnUpload.Click += (s, e) => {
                using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Resim Dosyaları|*.jpg;*.png" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK) { _model.ProofFilePath = ofd.FileName; btnUpload.Text = "✅ Görsel Başarıyla Eklendi"; btnUpload.ForeColor = Color.LightGreen; }
                }
            };

            // 5. Alt İşlem Butonları
            TableLayoutPanel bottomActions = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, Margin = new Padding(0) };
            bottomActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
            bottomActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));
            bottomActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35f));

            CheckBox chkAnon = new CheckBox { Text = "İsmimi Gizle (Anonim Değerlendir)", ForeColor = clrText, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9.5f), Checked = _model.IsAnonymous };
            chkAnon.CheckedChanged += (s, e) => _model.IsAnonymous = chkAnon.Checked;

            Button btnClear = CreateButton("FORMU TEMİZLE", Color.Crimson);
            btnClear.Click += (s, e) => {
                _model.UserRating = 0; _model.UserComment = ""; UpdateStars(); txtComment.Text = "";
                btnUpload.Text = "📷 Süreçle İlgili Görsel / Kanıt Yükleyiniz"; btnUpload.ForeColor = clrText;
            };

            Button btnSubmit = CreateButton("DEĞERLENDİRMEYİ YAYINLA", Color.SeaGreen);
            btnSubmit.Click += (s, e) => {
                if (_model.UserRating > 0)
                {
                    if (_evaluationService.SaveEvaluation(_model))
                    {
                        MessageBox.Show("Değerlendirmeniz başarıyla sisteme kaydedildi ve yayınlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SayfayiKapatVeListeyeDon();
                    }
                }
                else MessageBox.Show("Lütfen yıldızlara tıklayarak süreci puanlayın.");
            };

            bottomActions.Controls.Add(chkAnon, 0, 0);
            bottomActions.Controls.Add(btnClear, 1, 0);
            bottomActions.Controls.Add(btnSubmit, 2, 0);

            rightLayout.Controls.Add(pnlStars, 0, 0);
            rightLayout.Controls.Add(lblTitle, 0, 1);
            rightLayout.Controls.Add(txtComment, 0, 2);
            rightLayout.Controls.Add(btnUpload, 0, 3);
            rightLayout.Controls.Add(bottomActions, 0, 4);

            parent.Controls.Add(rightLayout);
        }

        private void SayfayiKapatVeListeyeDon()
        {
            if (this.FindForm() is FrmMain mainForm)
            {
                mainForm.SayfaGetir(new UC_basvurularimEkrani());
            }
        }

        private Panel CreateStyledContainer() => new Panel { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None, Padding = new Padding(10), Margin = new Padding(10), BackColor = Color.FromArgb(35, 40, 45) };

        private Label CreateDataBlock(string text, DockStyle dock, int height) => new Label
        {
            Text = text,
            Dock = dock,
            Height = height,
            ForeColor = clrText,
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 11f, FontStyle.Bold),
            BackColor = Color.FromArgb(45, 50, 55)
        };

        private Button CreateButton(string text, Color bg) => new Button
        {
            Text = text,
            BackColor = bg,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10f, FontStyle.Bold),
            Cursor = Cursors.Hand,
            Margin = new Padding(5),
            Dock = DockStyle.Fill
        };

        private void UpdateStars() { for (int i = 0; i < 5; i++) starLabels[i].ForeColor = (i < _model.UserRating) ? Color.Gold : Color.Gray; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "UC_SurecDegerlendirme";
            // Kontrolün kendi boyutu 1200x800'dür
            this.Size = new Size(1200, 800);
            this.ResumeLayout(false);
        }
    }
}