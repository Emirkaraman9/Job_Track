using System.Drawing;

namespace jobTrack.Models
{
    public static class ThemeColors
    {
        // --- 1. Renk Paleti ---
        public static Color PrimaryColor = Color.FromArgb(0, 150, 136);     // Turkuaz
        public static Color SecondaryColor = Color.FromArgb(0, 120, 100);   // Koyu Turkuaz

        // Zemin Renkleri
        public static Color Background = Color.FromArgb(20, 25, 30);        // En arka plan (Koyu)
        public static Color Surface = Color.FromArgb(32, 35, 40);           // Kartlar/Kutular için bir ton açık
        public static Color InputBackground = Color.FromArgb(45, 45, 48);   // Inputlar

        // --- 2. Yazı Renkleri (Yumuşatıldı) ---
        // Gözü almasın diye tam White yerine 235,235,235 tonunu kullanıyoruz
        public static Color TextMain = Color.FromArgb(235, 235, 235);       // Kırık Beyaz (Yumuşak)
        public static Color TextDark = Color.FromArgb(30, 30, 30);          // Açık zemin üstüne koyu yazı için
        public static Color TextSecondary = Color.Silver;                   // Yardımcı yazılar
        public static Color TextMuted = Color.Gray;                         // Pasif yazılar
    }
}