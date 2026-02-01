using jobTrack.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_anasayfa : UserControl
    {
        public event Action<string> SayfaDegistirIstegi;

        public string gelenKullaniciAdi = "";

        public UC_anasayfa()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            // Artık dışarıdan değişken beklemek yerine oturumdan çekiyoruz
            if (SessionManager.BireyselMi)
            {
                label1.Text = "Merhaba " + SessionManager.GirisYapanKullanici.Ad.ToUpper();
            }
        }
        private void btnIlanAra_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("IlanAra");
        }

        private void bildirmler_button_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("Bildirimler");
        }

        private void btnCvSihirbazi_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("CVSihirbazi");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("CvOnizleme");
        }
    }
}