using jobTrack.Helpers;
using jobTrack.Models;
using jobTrack.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_Sirket_BasvuruDetay : UserControl
    {
        private readonly ApplicationDetailService _service;
        private ApplicationDetailModel _model;

        // Overlay Panelleri
        private Panel _pnlPlanlamaOverlay;
        private Panel _pnlDogrulamaOverlay;
        private CheckBox _chkMulakatTamam;

        // Renkler
        private Color _bgColor = Color.White;
        private Color _borderColor = Color.FromArgb(200, 200, 200);
        private Color _textDark = Color.FromArgb(40, 40, 40);
        private Color _accentColor = Color.SteelBlue;

        public UC_Sirket_BasvuruDetay(string id)
        {
            InitializeComponent();
            _service = new ApplicationDetailService();
            string hedefId = string.IsNullOrEmpty(id) ? "#3424" : id;
            _model = _service.GetApplicationDetail(hedefId);

            TasarimiOlustur();
            OverlayPanelleriOlustur();
        }

        public UC_Sirket_BasvuruDetay() : this("#3424") { }

        private void InitializeComponent()
        {
            this.Name = "UC_Sirket_BasvuruDetay";
            this.Size = new Size(1100, 750);
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 9);
            this.Resize += (s, e) => { Ortala(_pnlPlanlamaOverlay); Ortala(_pnlDogrulamaOverlay); };
        }

        private void TasarimiOlustur()
        {
            this.Controls.Clear();

            // 1. ÜST HEADER
            TableLayoutPanel tlpHeader = new TableLayoutPanel { Dock = DockStyle.Top, Height = 60, ColumnCount = 3, BackColor = Color.White, Padding = new Padding(10, 0, 10, 0) };
            tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));

            Label lblGeri = new Label { Text = "🡠 Geri", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = _accentColor, AutoSize = false, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Cursor = Cursors.Hand };
            lblGeri.Click += (s, e) =>
            {
                // 1. Bu UserControl'ün içinde bulunduğu Ana Formu buluyoruz
                Form_SirketMain anaForm = this.FindForm() as Form_SirketMain;

                if (anaForm != null)
                {
                    // 2. Ana formun public yaptığımız metodunu kullanarak sayfayı değiştiriyoruz
                    anaForm.SayfaGetir(new UC_Sirket_Basvurular());
                }
            };
            Label lblBaslik = new Label { Text = $"Başvuru Detayı: {_model.ApplicantName}", Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = _textDark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };

            tlpHeader.Controls.Add(lblGeri, 0, 0);
            tlpHeader.Controls.Add(lblBaslik, 1, 0);
            this.Controls.Add(new Panel { Dock = DockStyle.Top, Height = 1, BackColor = Color.LightGray });
            this.Controls.Add(tlpHeader);

            // 2. ANA TABLO
            TableLayoutPanel tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Padding = new Padding(10), BackColor = Color.WhiteSmoke };
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            this.Controls.Add(tlpMain);

            // =================================================================
            // SOL PANEL (AŞAĞI KAYDIRILDI)
            // =================================================================
            TableLayoutPanel tlpSol = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 5,
                // GÜNCELLEME: Üst boşluk 30'dan 60'a çıkarıldı.
                Margin = new Padding(0, 60, 10, 0)
            };
            tlpSol.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tlpSol.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tlpSol.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSol.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSol.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));

            tlpSol.Controls.Add(ProfilKartiOlustur(), 0, 0);
            tlpSol.Controls.Add(SosyalButonlar(), 0, 1);
            tlpSol.Controls.Add(BilgiKutusu("🎓 Eğitim Bilgileri", _model.EducationInfo), 0, 2);
            tlpSol.Controls.Add(BilgiKutusu("💼 Deneyim", _model.ExperienceInfo), 0, 3);
            tlpSol.Controls.Add(MulakatKutusu(), 0, 4);
            tlpMain.Controls.Add(tlpSol, 0, 0);

            // =================================================================
            // SAĞ PANEL (AŞAĞI KAYDIRILDI)
            // =================================================================
            // GÜNCELLEME: Üst boşluk 30'dan 60'a çıkarıldı (Sol ile aynı hiza).
            Panel pnlSagWrapper = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 60, 0, 0) };
            pnlSagWrapper.Paint += BorderCiz;
            Panel pnlSagContent = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };
            pnlSagWrapper.Controls.Add(pnlSagContent);
            tlpMain.Controls.Add(pnlSagWrapper, 1, 0);

            // Alt Butonlar
            TableLayoutPanel tlpButtons = new TableLayoutPanel { Dock = DockStyle.Bottom, Height = 45, ColumnCount = 3, Margin = new Padding(0) };
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpButtons.Controls.Add(RenkliButon("Vazgeç", Color.IndianRed), 0, 0);
            tlpButtons.Controls.Add(RenkliButon("Taslak", Color.Orange), 1, 0);
            Button btnKaydet = RenkliButon("Kaydet", Color.SeaGreen);
            btnKaydet.Click += (s, e) => { _service.SaveFinalDecision(_model); MessageBox.Show("Kaydedildi."); };
            tlpButtons.Controls.Add(btnKaydet, 2, 0);
            pnlSagContent.Controls.Add(tlpButtons);

            // Durum (AŞAĞI ALINDI)
            Panel pnlDurum = new Panel { Dock = DockStyle.Top, Height = 90 }; // Yükseklik arttırıldı
            Label lblDurum = new Label { Text = "Başvuru Durumu:", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.Gray, AutoSize = true, Location = new Point(0, 15) };
            ComboBox cmbDurum = new ComboBox { Text = _model.Status, Font = new Font("Segoe UI", 11), DropDownStyle = ComboBoxStyle.DropDownList, Width = 220, Location = new Point(0, 45), BackColor = Color.WhiteSmoke };
            cmbDurum.Items.AddRange(new string[] { "Beklemede", "İnceleniyor", "Mülakat", "Reddedildi", "Kabul" });
            pnlDurum.Controls.Add(lblDurum); pnlDurum.Controls.Add(cmbDurum);
            pnlSagContent.Controls.Add(pnlDurum);

            // Açıklama
            Panel pnlAciklama = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 5, 0, 15) };
            Label lblAciklama = new Label { Text = "Başvuru Durum Açıklaması:", Dock = DockStyle.Top, Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.Gray, Height = 25 };
            Panel pnlRtbBorder = new Panel { Dock = DockStyle.Fill, Padding = new Padding(1), BackColor = _borderColor };
            RichTextBox rtb = new RichTextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.None, BackColor = Color.WhiteSmoke, Text = _model.StatusDescription, Font = new Font("Segoe UI", 10), Padding = new Padding(10) };
            pnlRtbBorder.Controls.Add(rtb);
            pnlAciklama.Controls.Add(pnlRtbBorder);
            pnlAciklama.Controls.Add(lblAciklama);
            pnlSagContent.Controls.Add(pnlAciklama);

            tlpButtons.SendToBack(); pnlDurum.SendToBack(); pnlAciklama.BringToFront();
        }

        // ============================================================================
        // POP-UP PANELLERİ (GÜNCELLENDİ: DAHA BÜYÜK VE FERAH)
        // ============================================================================
        private void OverlayPanelleriOlustur()
        {
            // 1. PLANLAMA PANELİ (Boyut Büyütüldü)
            _pnlPlanlamaOverlay = new Panel { Size = new Size(450, 480), BackColor = Color.White, Visible = false, BorderStyle = BorderStyle.FixedSingle };
            _pnlPlanlamaOverlay.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, _pnlPlanlamaOverlay.ClientRectangle, _accentColor, 2, ButtonBorderStyle.Solid, _accentColor, 2, ButtonBorderStyle.Solid, _accentColor, 2, ButtonBorderStyle.Solid, _accentColor, 2, ButtonBorderStyle.Solid);

            Label lblPlanBaslik = new Label { Text = "Mülakat Planla", Dock = DockStyle.Top, Height = 50, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = _accentColor, TextAlign = ContentAlignment.MiddleCenter };

            Panel pnlIcerik = new Panel { Dock = DockStyle.Fill, Padding = new Padding(30) }; // Padding artırıldı

            Label lblTarih = new Label { Text = "Tarih:", Dock = DockStyle.Top, Height = 25, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            DateTimePicker dtpTarih = new DateTimePicker { Dock = DockStyle.Top, Format = DateTimePickerFormat.Short, Font = new Font("Segoe UI", 11) };

            Label lblSaat = new Label { Text = "Saat:", Dock = DockStyle.Top, Height = 25, Font = new Font("Segoe UI", 10, FontStyle.Bold), Margin = new Padding(0, 15, 0, 0) };
            DateTimePicker dtpSaat = new DateTimePicker { Dock = DockStyle.Top, Format = DateTimePickerFormat.Time, ShowUpDown = true, Font = new Font("Segoe UI", 11) };

            Label lblTip = new Label { Text = "Mülakat Tipi:", Dock = DockStyle.Top, Height = 25, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            ComboBox cmbTip = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 11) };
            cmbTip.Items.AddRange(new string[] { "Online (Google Meet/Zoom)", "Yüz Yüze (Ofis)", "Telefon" });
            cmbTip.SelectedIndex = 0;

            Label lblLink = new Label { Text = "Link / Adres:", Dock = DockStyle.Top, Height = 25, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            TextBox txtLink = new TextBox { Dock = DockStyle.Top, Height = 35, Font = new Font("Segoe UI", 11) };

            Button btnKaydet = RenkliButon("Planı Kaydet", Color.SeaGreen);
            btnKaydet.Dock = DockStyle.Bottom;
            btnKaydet.Height = 45;
            btnKaydet.Click += (s, e) => {
                _service.SaveInterviewPlan(_model);
                _pnlPlanlamaOverlay.Visible = false;
                MessageBox.Show("Mülakat planlandı.");
            };

            Button btnIptal = RenkliButon("Vazgeç", Color.IndianRed);
            btnIptal.Dock = DockStyle.Bottom;
            btnIptal.Height = 45;
            btnIptal.Click += (s, e) => _pnlPlanlamaOverlay.Visible = false;

            // Kontroller (Tersten Ekleme - Dock Top)
            // Spacer yükseklikleri 10'dan 20'ye çıkarıldı.
            pnlIcerik.Controls.Add(txtLink); pnlIcerik.Controls.Add(lblLink);
            pnlIcerik.Controls.Add(new Panel { Height = 20, Dock = DockStyle.Top });
            pnlIcerik.Controls.Add(cmbTip); pnlIcerik.Controls.Add(lblTip);
            pnlIcerik.Controls.Add(new Panel { Height = 20, Dock = DockStyle.Top });
            pnlIcerik.Controls.Add(dtpSaat); pnlIcerik.Controls.Add(lblSaat);
            pnlIcerik.Controls.Add(new Panel { Height = 20, Dock = DockStyle.Top });
            pnlIcerik.Controls.Add(dtpTarih); pnlIcerik.Controls.Add(lblTarih);

            _pnlPlanlamaOverlay.Controls.Add(pnlIcerik);
            _pnlPlanlamaOverlay.Controls.Add(btnKaydet);
            _pnlPlanlamaOverlay.Controls.Add(btnIptal);
            _pnlPlanlamaOverlay.Controls.Add(lblPlanBaslik);
            this.Controls.Add(_pnlPlanlamaOverlay);
            _pnlPlanlamaOverlay.BringToFront();


            // 2. DOĞRULAMA PANELİ (Boyut Büyütüldü)
            _pnlDogrulamaOverlay = new Panel { Size = new Size(450, 250), BackColor = Color.White, Visible = false, BorderStyle = BorderStyle.FixedSingle };
            _pnlDogrulamaOverlay.Paint += (s, e) => ControlPaint.DrawBorder(e.Graphics, _pnlDogrulamaOverlay.ClientRectangle, Color.Orange, 2, ButtonBorderStyle.Solid, Color.Orange, 2, ButtonBorderStyle.Solid, Color.Orange, 2, ButtonBorderStyle.Solid, Color.Orange, 2, ButtonBorderStyle.Solid);

            Label lblDogruBaslik = new Label { Text = "Güvenli Mülakat Doğrulama", Dock = DockStyle.Top, Height = 50, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.Orange, TextAlign = ContentAlignment.MiddleCenter };

            Label lblInfo = new Label { Text = "Adaydan gelen benzersiz hash kodunu giriniz:", Dock = DockStyle.Top, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 10) };

            // Hash için daha geniş TextBox
            TextBox txtKod = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Consolas", 14, FontStyle.Bold), // Kodlar için Consolas fontu daha iyidir
                MaxLength = 20, // Hash uzun olabilir
                PlaceholderText = "XXXX-XXXX"
            };

            Panel pnlKodWrapper = new Panel { Dock = DockStyle.Top, Height = 50, Padding = new Padding(60, 5, 60, 5) }; // Genişletildi
            pnlKodWrapper.Controls.Add(txtKod);

            Button btnOnayla = RenkliButon("Doğrula ve Tamamla", Color.Orange);
            btnOnayla.ForeColor = Color.White;
            btnOnayla.Dock = DockStyle.Bottom; btnOnayla.Height = 45;
            btnOnayla.Click += (s, e) => {
                // Servisteki yeni Verify metodunu kullanıyoruz
                if (_service.VerifyCandidateCode(txtKod.Text, _model.UniqueVerificationCode))
                {
                    _model.IsInterviewCompleted = true;
                    if (_chkMulakatTamam != null) { _chkMulakatTamam.Checked = true; _chkMulakatTamam.Enabled = false; }
                    _pnlDogrulamaOverlay.Visible = false;
                    MessageBox.Show("Hash Doğrulandı! Mülakat başarıyla tamamlandı.", "İşlem Başarılı");
                }
                else
                {
                    MessageBox.Show("Hatalı Hash Kodu! Lütfen kontrol ediniz.", "Güvenlik Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKod.Clear();
                }
            };

            Button btnVazgec2 = RenkliButon("Vazgeç", Color.Gray);
            btnVazgec2.Dock = DockStyle.Bottom; btnVazgec2.Height = 45;
            btnVazgec2.Click += (s, e) => { _pnlDogrulamaOverlay.Visible = false; if (_chkMulakatTamam != null) _chkMulakatTamam.Checked = false; };

            _pnlDogrulamaOverlay.Controls.Add(pnlKodWrapper);
            _pnlDogrulamaOverlay.Controls.Add(lblInfo);
            _pnlDogrulamaOverlay.Controls.Add(btnOnayla);
            _pnlDogrulamaOverlay.Controls.Add(btnVazgec2);
            _pnlDogrulamaOverlay.Controls.Add(lblDogruBaslik);

            this.Controls.Add(_pnlDogrulamaOverlay);
            _pnlDogrulamaOverlay.BringToFront();
        }

        private void Ortala(Panel p)
        {
            if (p != null) { p.Location = new Point((this.Width - p.Width) / 2, (this.Height - p.Height) / 2); p.BringToFront(); }
        }

        // --- YARDIMCILAR (AYNI) ---
        private Panel ProfilKartiOlustur()
        {
            Panel p = PanelKutu();
            TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(5) };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F)); tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            Label lblFoto = new Label { Text = "Fotoğraf", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, BackColor = Color.Gainsboro, ForeColor = Color.Gray, Margin = new Padding(0, 0, 5, 0) };
            tlp.Controls.Add(lblFoto, 0, 0);
            Panel pnlInfo = new Panel { Dock = DockStyle.Fill };
            Label lblId = new Label { Text = _model.Id, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = _accentColor, Dock = DockStyle.Top, Height = 25 };
            Label lblIsim = new Label { Text = _model.ApplicantName, Font = new Font("Segoe UI", 11, FontStyle.Bold), Dock = DockStyle.Top, Height = 25, AutoEllipsis = true };
            Label lblPoz = new Label { Text = _model.Position, Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, Dock = DockStyle.Top, Height = 20, AutoEllipsis = true };
            Label lblTarih = new Label { Text = _model.AppliedDate, Font = new Font("Segoe UI", 9), ForeColor = Color.Gray, Dock = DockStyle.Top, Height = 20 };
            Button btnCv = OutlineButon("📄 CV Görüntüle", Color.DimGray); btnCv.Dock = DockStyle.Bottom; btnCv.Height = 30;
            pnlInfo.Controls.Add(lblTarih); pnlInfo.Controls.Add(lblPoz); pnlInfo.Controls.Add(lblIsim); pnlInfo.Controls.Add(lblId); pnlInfo.Controls.Add(btnCv);
            tlp.Controls.Add(pnlInfo, 1, 0); p.Controls.Add(tlp); return p;
        }
        private TableLayoutPanel SosyalButonlar()
        {
            TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, Margin = new Padding(0, 5, 0, 5) };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F)); tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F)); tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlp.Controls.Add(OutlineButon("Profil", Color.Gray), 0, 0); tlp.Controls.Add(OutlineButon("LinkedIn", Color.FromArgb(0, 119, 181)), 1, 0); tlp.Controls.Add(OutlineButon("Medium", Color.Black), 2, 0); return tlp;
        }
        private Panel BilgiKutusu(string baslik, string icerik)
        {
            Panel p = PanelKutu(); p.Margin = new Padding(0, 5, 0, 5); p.Padding = new Padding(10);
            Label lblBaslik = new Label { Text = baslik, Dock = DockStyle.Top, Font = new Font("Segoe UI", 9, FontStyle.Bold), ForeColor = _accentColor, Height = 20 };
            Label lblIcerik = new Label { Text = icerik, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9), ForeColor = _textDark, TextAlign = ContentAlignment.TopLeft, AutoEllipsis = true };
            p.Controls.Add(lblIcerik); p.Controls.Add(lblBaslik); return p;
        }
        private Panel MulakatKutusu()
        {
            Panel p = PanelKutu(); p.Margin = new Padding(0, 5, 0, 0);
            TableLayoutPanel tlp = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(5) };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            Button btnPlanla = new Button { Text = "📅 Mülakat Planla", BackColor = Color.FromArgb(50, 50, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Fill, Margin = new Padding(2) };
            btnPlanla.Click += (s, e) => { Ortala(_pnlPlanlamaOverlay); _pnlPlanlamaOverlay.Visible = true; };
            _chkMulakatTamam = new CheckBox { Text = "Mülakat Tamamlandı", Font = new Font("Segoe UI", 9, FontStyle.Bold), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
            _chkMulakatTamam.Checked = _model.IsInterviewCompleted;
            _chkMulakatTamam.Click += (s, e) => { if (_chkMulakatTamam.Checked && !_model.IsInterviewCompleted) { _chkMulakatTamam.Checked = false; Ortala(_pnlDogrulamaOverlay); _pnlDogrulamaOverlay.Visible = true; } };
            tlp.Controls.Add(btnPlanla, 0, 0); tlp.Controls.Add(_chkMulakatTamam, 1, 0); p.Controls.Add(tlp); return p;
        }
        private Panel PanelKutu() { Panel p = new Panel { Dock = DockStyle.Fill, BackColor = Color.White }; p.Paint += BorderCiz; return p; }
        private void BorderCiz(object sender, PaintEventArgs e) { ControlPaint.DrawBorder(e.Graphics, ((Control)sender).ClientRectangle, _borderColor, ButtonBorderStyle.Solid); }
        private Button OutlineButon(string text, Color c) { Button btn = new Button { Text = text, BackColor = Color.White, ForeColor = c, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Fill, Margin = new Padding(2), Font = new Font("Segoe UI", 8, FontStyle.Bold) }; btn.FlatAppearance.BorderColor = Color.LightGray; return btn; }
        private Button RenkliButon(string text, Color bg) { Button btn = new Button { Text = text, BackColor = bg, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Dock = DockStyle.Fill, Margin = new Padding(3), Font = new Font("Segoe UI", 9, FontStyle.Bold), Cursor = Cursors.Hand }; btn.FlatAppearance.BorderSize = 0; return btn; }
    }
}