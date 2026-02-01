using System.Drawing;
using System.Windows.Forms;
using jobTrack.Models;

namespace jobTrack.Helpers
{
    public static class ThemeManager
    {
        public static void ApplyTheme(Control container)
        {
            // Ana konteynerin arka planını boya (Form veya UserControl)
            container.BackColor = ThemeColors.Background;

            foreach (Control ctrl in container.Controls)
            {
                ApplyThemeToControl(ctrl);
            }
        }

        private static void ApplyThemeToControl(Control ctrl)
        {
            // Recursive (İç içe) kontrol
            if (ctrl.HasChildren)
            {
                foreach (Control child in ctrl.Controls)
                {
                    ApplyThemeToControl(child);
                }
            }

            // --- TİPE GÖRE BOYAMA ---

            // 1. LinkLabel
            if (ctrl is LinkLabel lnk)
            {
                lnk.LinkColor = ThemeColors.PrimaryColor;
                lnk.ActiveLinkColor = ThemeColors.SecondaryColor;
                lnk.VisitedLinkColor = ThemeColors.PrimaryColor;
                lnk.LinkBehavior = LinkBehavior.HoverUnderline;
                lnk.BackColor = Color.Transparent;
            }
            // 2. Normal Label (AKILLI KONTRAST AYARI)
            else if (ctrl is Label lbl)
            {
                lbl.BackColor = Color.Transparent;

                // Arka plan rengini kontrol et (Parent rengi)
                Color bgColor = lbl.Parent.BackColor;

                // Eğer parent şeffafsa, onun da parent'ına bak (Bir üst katmana)
                if (bgColor == Color.Transparent && lbl.Parent.Parent != null)
                {
                    bgColor = lbl.Parent.Parent.BackColor;
                }

                // Arka plan parlak mı? (Formül: Parlaklık > 128 ise açıktır)
                if (IsLightColor(bgColor))
                {
                    lbl.ForeColor = ThemeColors.TextDark; // Açık zemine Koyu yazı
                }
                else
                {
                    lbl.ForeColor = ThemeColors.TextMain; // Koyu zemine Kırık Beyaz yazı
                }
            }
            // 3. Butonlar
            else if (ctrl is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = ThemeColors.PrimaryColor;
                btn.ForeColor = ThemeColors.TextMain;
                btn.Cursor = Cursors.Hand;
            }
            // 4. TextBox / DateTimePicker
            else if (ctrl is TextBox || ctrl is DateTimePicker)
            {
                ctrl.BackColor = ThemeColors.InputBackground;
                ctrl.ForeColor = ThemeColors.TextMain;
            }
            // 5. DataGridView
            else if (ctrl is DataGridView dgv)
            {
                dgv.BackgroundColor = ThemeColors.Background;
                dgv.DefaultCellStyle.BackColor = ThemeColors.InputBackground;
                dgv.DefaultCellStyle.ForeColor = ThemeColors.TextMain;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = ThemeColors.Surface; // Header biraz daha açık ton
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = ThemeColors.TextMain;
                dgv.EnableHeadersVisualStyles = false;
                dgv.GridColor = ThemeColors.TextMuted;
            }
            // 6. Paneller
            else if (ctrl is Panel pnl)
            {
                // Eğer panelin kendi rengi özellikle Beyaz ayarlanmışsa dokunma (Kartlar için)
                // Ama sistem rengiyse şeffaf yap
                if (pnl.BackColor == SystemColors.Control || pnl.BackColor == Color.WhiteSmoke)
                {
                    pnl.BackColor = Color.Transparent;
                }
            }
        }

        // Rengin açık mı koyu mu olduğunu anlayan yardımcı metot
        private static bool IsLightColor(Color col)
        {
            // Parlaklık formülü
            int brightness = (int)((col.R * 0.299) + (col.G * 0.587) + (col.B * 0.114));
            return brightness > 128; // 128'den büyükse açık renktir
        }
    }
}