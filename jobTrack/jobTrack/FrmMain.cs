using jobTrack.Helpers;
using jobTrack.Models;
using jobTrack.Repository;
using jobTrack.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jobTrack
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            // Navbar'dan gelen sayfa değişim isteklerini karşıla
            uC_Navbar1.SayfaDegistirIstegi += SayfaGoster;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Uygulama açılışında karşılama ekranını yükle
            SayfaGoster("Karsilama");
        }

        /// <summary>
        /// Hazır oluşturulmuş (instance alınmış) bir sayfayı ana panelde gösterir.
        /// Bu metot NavigationHelper tarafından da kullanılır.
        /// </summary>
        public void SayfaGetir(UserControl uc)
        {
            if (uc == null) return;

            // Panel temizliği ve yerleşim ayarları
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;

            // UserControl içerisinden sayfa değiştirme isteği gelirse (Navbar dışı navigasyon) yakala
            try
            {
                dynamic dynamicPage = uc;
                // Mevcut event aboneliklerini temizleyip (varsa) yeniden bağlayarak mükerrerliği önler
                dynamicPage.SayfaDegistirIstegi += new Action<string>(SayfaGoster);
            }
            catch { /* Sayfada SayfaDegistirIstegi eventi yoksa sessizce devam et */ }

            pnlContent.Controls.Add(uc);
            uc.BringToFront();
            uc.Focus();
        }

        /// <summary>
        /// Sayfa ismine (string) göre yeni bir nesne oluşturup ekrana basar.
        /// </summary>
        public void SayfaGoster(string sayfaAdi)
        {
            UserControl yeniSayfa = null;

            switch (sayfaAdi)
            {
                case "Karsilama":
                    yeniSayfa = new UC_karsilamaEkrani();
                    uC_Navbar1.Visible = false;
                    break;

                case "Hakkimizda":
                    yeniSayfa = new UC_hakkimizda();
                    uC_Navbar1.Visible = false;
                    break;

                case "BireyselKayit":
                    yeniSayfa = new UC_bireyselKayitEkrani();
                    uC_Navbar1.Visible = false;
                    break;

                case "KurumsalKayit":
                    yeniSayfa = new UC_kurumsalKayitEkrani();
                    uC_Navbar1.Visible = false;
                    break;

                case "Hesap":
                    yeniSayfa = new UC_kullaniciGirisEkrani();
                    uC_Navbar1.Visible = false;
                    break;

                case "SirketDashboard":
                    Form_SirketMain sirketForm = new Form_SirketMain();
                    sirketForm.FormClosed += (s, args) =>
                    {
                        this.Show();
                        SayfaGoster("Karsilama");
                    };
                    sirketForm.Show();
                    this.Hide();
                    return;

                case "Anasayfa":
                    yeniSayfa = new UC_anasayfa();
                    uC_Navbar1.Visible = true;
                    break;

                case "IlanAra":
                    yeniSayfa = new UC_ilanAramaEkrani();
                    uC_Navbar1.Visible = true;
                    break;

                case "Bildirimler":
                    yeniSayfa = new UC_bildirimler();
                    uC_Navbar1.Visible = true;
                    break;

                case "CVSihirbazi":
                    yeniSayfa = new UC_CvSihirbaziEkrani();
                    uC_Navbar1.Visible = true;
                    break;

                case "CvOnizleme":
                    if (SessionManager.GirisYapanKullanici != null)
                    {
                        try
                        {
                            int kId = SessionManager.GirisYapanKullanici.Id;
                            var egitimler = new BindingList<Egitim>(new EgitimRepository().GetirByKullaniciId(kId));
                            var isler = new BindingList<IsDeneyimi>(new IsDeneyimiRepository().GetirByKullaniciId(kId));
                            var yetenekler = new BindingList<Yetenek>(new YetenekRepository().GetirByKullaniciId(kId));
                            var sertifikalar = new BindingList<Sertifika>(new SertifikaRepository().GetirByKullaniciId(kId));

                            string adSoyad = SessionManager.GirisYapanKullanici.Ad + " " + SessionManager.GirisYapanKullanici.Soyad;
                            string email = SessionManager.GirisYapanKullanici.Email;
                            string tel = SessionManager.GirisYapanKullanici.Telefon;
                            string unvan = "Yazılım Geliştirici";

                            yeniSayfa = new UC_CvOnIzlemeEkrani(egitimler, isler, yetenekler, sertifikalar, adSoyad, unvan, email, tel);
                            uC_Navbar1.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Önizleme yüklenirken hata: " + ex.Message);
                            yeniSayfa = new UC_anasayfa();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Önizleme için giriş yapmalısınız.");
                        yeniSayfa = new UC_kullaniciGirisEkrani();
                    }
                    break;

                case "Basvurularim":
                    yeniSayfa = new UC_basvurularimEkrani();
                    uC_Navbar1.Visible = true;
                    break;

                case "HesapAyarlari":
                    yeniSayfa = new UC_HesapAyarlari();
                    uC_Navbar1.Visible = true;
                    break;
            }

            if (yeniSayfa != null)
            {
                // Sayfayı ekrana basmak için merkezi metodu kullanıyoruz
                SayfaGetir(yeniSayfa);

                // Navbar güncellemelerini yap
                uC_Navbar1.MenuYetkileriniAyarla();
                uC_Navbar1.AktifButonuIsaretle(sayfaAdi);
            }
        }
    }
}