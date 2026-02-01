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
    public partial class UC_bildirimler : UserControl
    {
        public event Action<string> SayfaDegistirIstegi;
        public UC_bildirimler()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("Anasayfa");
        }

        // 2. İLAN ARA BUTONU
        private void btnIlanAra_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("IlanAra");
        }

        // 3. CV SİHİRBAZI BUTONU
        private void btnCvSihirbazi_Click(object sender, EventArgs e)
        {
            SayfaDegistirIstegi?.Invoke("CVSihirbazi");
        }
    }
}
