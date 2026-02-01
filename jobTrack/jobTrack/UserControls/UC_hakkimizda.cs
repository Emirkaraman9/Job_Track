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
    public partial class UC_hakkimizda : UserControl
    {
        public event Action<string> SayfaDegistirIstegi;
        public UC_hakkimizda()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            // Ana forma "Karsilama" sayfasına dönmek istediğini bildiriyoruz
            SayfaDegistirIstegi?.Invoke("Karsilama");
        }
    }
}
