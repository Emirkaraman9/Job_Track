using jobTrack.Helpers;
using jobTrack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_CvOnIzlemeEkrani : UserControl
    {
        BindingList<Egitim> _egitimler;
        BindingList<IsDeneyimi> _isler;
        BindingList<Yetenek> _yetenekler;
        BindingList<Sertifika> _sertifikalar;

        string _adSoyad, _unvan, _email, _telefon;
        public UC_CvOnIzlemeEkrani(BindingList<Egitim> egitimler, BindingList<IsDeneyimi> isler,
             BindingList<Yetenek> yetenekler, BindingList<Sertifika> sertifikalar,
             string ad, string unvan, string email, string tel) // Parametreler eklendi
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);

            _egitimler = egitimler;
            _isler = isler;
            _yetenekler = yetenekler;
            _sertifikalar = sertifikalar;

            // EKLENECEK KISIM:
            _adSoyad = ad;
            _unvan = unvan;
            _email = email;
            _telefon = tel;

            ppvCvOnizleme.Zoom = 0.6;

        }



        private void btnPdfKaydet_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Dosyası|*.pdf";
                sfd.FileName = "Ozgecmis.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Güvenli Yazıcı Bulma: İsminde "PDF" geçen ilk yazıcıyı seç
                    string pdfPrinter = PrinterSettings.InstalledPrinters.Cast<string>().FirstOrDefault(p => p.ToUpper().Contains("PDF"));


                    if (string.IsNullOrEmpty(pdfPrinter))
                    {
                        MessageBox.Show("Sistemde PDF yazıcısı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    printDocument1.PrinterSettings.PrinterName = pdfPrinter;
                    printDocument1.PrinterSettings.PrintToFile = true;
                    printDocument1.PrinterSettings.PrintFileName = sfd.FileName;
                    printDocument1.Print();

                    MessageBox.Show("CV'niz başarıyla kaydedildi.");
                }
            }
        }

        private void btnYakinlastir_Click(object sender, EventArgs e)
        {
            if (ppvCvOnizleme.Zoom < 3.0)
            {
                ppvCvOnizleme.Zoom += 0.2; // Her tıkta %20 büyüt
            }
        }

        private void btnUzaklastir_Click(object sender, EventArgs e)
        {
            if (ppvCvOnizleme.Zoom > 0.4)
            {
                ppvCvOnizleme.Zoom -= 0.2; // Her tıkta %20 küçült
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // --- RENKLER VE FONTLAR ---
            Color maviSeritRengi = Color.FromArgb(235, 245, 255);
            Color baslikMavi = Color.SteelBlue;

            Font isimFont = new Font("Segoe UI", 24, FontStyle.Bold);
            Font unvanFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font altBaslikFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font kucukGriFont = new Font("Segoe UI", 9, FontStyle.Regular);

            // --- SOL SÜTUN (Profil ve Yetenekler) ---
            int solX = 50;
            g.DrawEllipse(Pens.LightGray, solX + 20, 50, 150, 150);
            g.DrawString(_adSoyad.ToUpper(), isimFont, Brushes.Black, solX, 220);
            g.DrawString(_unvan.ToUpper(), unvanFont, Brushes.Black, solX, 265);

            int iletisimY = 310;
            g.DrawString("?  " + _email, kucukGriFont, Brushes.Black, solX, iletisimY + 25);
            g.DrawString("?  " + _telefon, kucukGriFont, Brushes.Black, solX, iletisimY + 50);

            int yetenekY = 430;
            g.DrawString("İLGİLİ BECERİLER", altBaslikFont, Brushes.Black, solX, yetenekY);
            yetenekY += 30;
            foreach (var yetenek in _yetenekler)
            {
                g.DrawString("• " + yetenek.YetenekAdi, normalFont, Brushes.Black, solX + 10, yetenekY);
                yetenekY += 25;
            }

            // --- SAĞ SÜTUN (İş, Eğitim, Sertifikalar) ---
            int sagX = 350;
            int sagY = 50;

            // 1. İŞ DENEYİMİ
            BolumBasligiCiz(g, "İŞ DENEYİMİ", maviSeritRengi, baslikMavi, sagX, sagY);
            sagY += 45;
            foreach (var isD in _isler)
            {
                // Pozisyon Başlığı
                g.DrawString(isD.Pozisyon, altBaslikFont, Brushes.Black, sagX, sagY);
                sagY += 22;

                // Şirket ve Tarih Bilgisi (Güvenli Kontrol)
                string baslangic = isD.BaslamaTarihi.Year.ToString();
                string bitis = isD.DevamEdiyor ? "Güncel" : (isD.AyrilmaTarihi?.Year.ToString() ?? "-");

                string satirBilgisi = $"• {isD.SirketAdi} | {baslangic} - {bitis}";

                g.DrawString(satirBilgisi, normalFont, Brushes.DimGray, sagX + 10, sagY);
                sagY += 45;
            }

            // 2. EĞİTİM GEÇMİŞİ (Hata burada düzeldi: 'e' yerine 'egitim' kullanıldı)
            sagY += 10;
            BolumBasligiCiz(g, "EĞİTİM GEÇMİŞİ", maviSeritRengi, baslikMavi, sagX, sagY);
            sagY += 45;
            foreach (var egitim in _egitimler)
            {
                // 1. Bölüm Adı (Kalın ve Siyah)
                g.DrawString(egitim.Bolum, altBaslikFont, Brushes.Black, sagX, sagY);
                sagY += 20;

                // 2. Okul Adı (Gri ve Normal)
                g.DrawString(egitim.OkulAdi, normalFont, Brushes.DimGray, sagX, sagY);
                sagY += 20;

                // 3. Tarih Hesaplama (GÜVENLİ KONTROL)
                // Mezuniyet tarihi boşsa veya devam ediyorsa "Devam Ediyor" yaz, aksi halde yılı yaz.
                string bitisYili = egitim.DevamEdiyor ? "Devam Ediyor" :
                                   (egitim.MezuniyetTarihi.HasValue ? egitim.MezuniyetTarihi.Value.Year.ToString() : "-");

                string tarihAraligi = $"{egitim.BaslangicTarihi.Year} - {bitisYili}";

                g.DrawString(tarihAraligi, kucukGriFont, Brushes.Gray, sagX, sagY);

                // Bir sonraki eğitim bilgisi için boşluk bırak
                sagY += 45;
            }

            // 3. SERTİFİKALAR
            sagY += 10;
            BolumBasligiCiz(g, "SERTİFİKALAR", maviSeritRengi, baslikMavi, sagX, sagY);
            sagY += 45;
            foreach (var sertifika in _sertifikalar)
            {
                g.DrawString("?", normalFont, Brushes.SteelBlue, sagX, sagY);
                g.DrawString($"{sertifika.SertifikaAdi} {(sertifika.AlindigiTarih?.Year.ToString() ?? "")}",
             normalFont, Brushes.Black, sagX + 25, sagY);
            }
        }

        // YARDIMCI METOT: Şeritli Başlık Çizimi
        private void BolumBasligiCiz(Graphics g, string metin, Color arkaPlan, Color yaziRengi, int x, int y)
        {
            g.FillRectangle(new SolidBrush(arkaPlan), x, y, 450, 30); // Şerit genişliği: 450
            g.DrawString(metin, new Font("Segoe UI", 11, FontStyle.Bold), new SolidBrush(yaziRengi), x + 10, y + 5);
        }
    }
}
