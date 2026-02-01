using jobTrack.Helpers;
using System;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_karsilamaEkrani : UserControl
    {
        // Ana formun (FrmMain) duyması gereken olay (sinyal)
        public event Action<string> SayfaDegistirIstegi;

        public UC_karsilamaEkrani()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void kurumsal_button_Click(object sender, EventArgs e)
        {
            // Ana forma "Kurumsal Kayıt sayfasına git" diyoruz
            SayfaDegistirIstegi?.Invoke("KurumsalKayit");
        }

        private void bireysel_button_Click(object sender, EventArgs e)
        {
            // Ana forma "Bireysel Kayıt sayfasına git" diyoruz
            SayfaDegistirIstegi?.Invoke("BireyselKayit");
        }

        private void kullanicigir_button_Click(object sender, EventArgs e)
        {
            // Giriş ekranına git (FrmMain'deki case ismine dikkat et: "Hesap")
            SayfaDegistirIstegi?.Invoke("Hesap");
        }

        private void hakkımızda_button_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("Hakkimizda");
        }
    }
}