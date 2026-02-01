using jobTrack.Models;
using jobTrack.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_basvurularimEkrani : UserControl
    {
        // Simülasyon verisini her zaman en üstte tutmak için static değişken
        private static Basvuru ozelTestBasvurusu = null;

        public UC_basvurularimEkrani()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(20, 25, 25);

            // Simülasyon verisini uygulama ömrü boyunca bir kez başlatıyoruz
            if (ozelTestBasvurusu == null)
            {
                ozelTestBasvurusu = new Basvuru
                {
                    Id = 999,
                    SirketAdi = "Apple Inc.",
                    Pozisyon = "Software Architect",
                    Durum = "Mülakat Onayı",
                    Tarih = DateTime.Now
                };
            }
        }

        private void UC_basvurularimEkrani_Load(object sender, EventArgs e)
        {
            TabloAyarlariniYap();
            ComboBoxDoldur();
            VerileriListele();

            // Olayları temizleyip tekrar bağlayarak mükerrer tetiklenmeyi önlüyoruz
            dgvBasvurular.CellFormatting -= dgvBasvurular_CellFormatting;
            dgvBasvurular.CellFormatting += dgvBasvurular_CellFormatting;

            dgvBasvurular.CellClick -= dgvBasvurular_CellClick;
            dgvBasvurular.CellClick += dgvBasvurular_CellClick;

            dgvBasvurular.CellPainting -= dgvBasvurular_CellPainting;
            dgvBasvurular.CellPainting += dgvBasvurular_CellPainting;
        }

        private void TabloAyarlariniYap()
        {
            dgvBasvurular.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgvBasvurular.ForeColor = Color.White;
            dgvBasvurular.GridColor = Color.FromArgb(50, 50, 50);
            dgvBasvurular.BorderStyle = BorderStyle.None;
            dgvBasvurular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBasvurular.RowHeadersVisible = false;
            dgvBasvurular.AllowUserToAddRows = false;
            dgvBasvurular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBasvurular.EnableHeadersVisualStyles = false;
            dgvBasvurular.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvBasvurular.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBasvurular.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBasvurular.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBasvurular.ColumnHeadersHeight = 45;

            dgvBasvurular.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvBasvurular.DefaultCellStyle.ForeColor = Color.White;
            dgvBasvurular.DefaultCellStyle.SelectionBackColor = Color.FromArgb(88, 88, 88);
            dgvBasvurular.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBasvurular.RowTemplate.Height = 50;

            dgvBasvurular.Columns.Clear();
            dgvBasvurular.AutoGenerateColumns = false;

            dgvBasvurular.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SirketAdi", HeaderText = "Şirket", Name = "SirketAdi", ReadOnly = true });
            dgvBasvurular.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Pozisyon", HeaderText = "Pozisyon", Name = "Pozisyon", ReadOnly = true });
            dgvBasvurular.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Tarih", HeaderText = "Tarih", Name = "Tarih", ReadOnly = true });
            dgvBasvurular.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Durum", HeaderText = "Durum", Name = "Durum", ReadOnly = true });

            // Dinamik İşlem Buton Kolonu
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnDetay";
            btn.HeaderText = "İşlem";
            btn.FlatStyle = FlatStyle.Flat;
            dgvBasvurular.Columns.Add(btn);
        }

        private void ComboBoxDoldur()
        {
            cmbDurumFiltresi.Items.Clear();
            cmbDurumFiltresi.Items.AddRange(new string[] { "Hepsi", "Beklemede", "Kabul Edildi", "Reddedildi", "Mülakat Onayı", "Mülakat" });
            cmbDurumFiltresi.SelectedIndex = 0;
            cmbDurumFiltresi.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void VerileriListele()
        {
            BasvuruRepository repo = new BasvuruRepository();

            try
            {
                List<Basvuru> dbListesi = new List<Basvuru>();
                if (SessionManager.GirisYapanKullanici != null)
                {
                    dbListesi = repo.KullaniciBasvurulariniGetir(SessionManager.GirisYapanKullanici.Id);
                }

                string arama = txtAraBasvuru.Text.Trim().ToLower();
                string durumFiltre = cmbDurumFiltresi.SelectedItem?.ToString() ?? "Hepsi";

                var filtreliListe = dbListesi.Where(b =>
                    (string.IsNullOrEmpty(arama) || b.SirketAdi.ToLower().Contains(arama)) &&
                    (durumFiltre == "Hepsi" || b.Durum == durumFiltre)
                ).ToList();

                // TEST VERİSİNİ LİSTEYE EKLE
                if ((string.IsNullOrEmpty(arama) || ozelTestBasvurusu.SirketAdi.ToLower().Contains(arama)) &&
                    (durumFiltre == "Hepsi" || ozelTestBasvurusu.Durum == durumFiltre))
                {
                    filtreliListe.Insert(0, ozelTestBasvurusu);
                }

                dgvBasvurular.DataSource = null;
                dgvBasvurular.DataSource = new BindingList<Basvuru>(filtreliListe);
                dgvBasvurular.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void dgvBasvurular_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBasvurular.Columns[e.ColumnIndex].Name == "btnDetay")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var satirVerisi = (Basvuru)dgvBasvurular.Rows[e.RowIndex].DataBoundItem;
                string buttonText = "Detay";
                Color buttonColor = Color.FromArgb(70, 70, 70);

                if (satirVerisi != null)
                {
                    if (satirVerisi.Durum == "Mülakat Onayı") { buttonText = "Onayla"; buttonColor = Color.DarkOrange; }
                    else if (satirVerisi.Durum == "Mülakat") { buttonText = "Değerlendir"; buttonColor = Color.DarkCyan; }
                }

                Rectangle buttonArea = e.CellBounds;
                buttonArea.Inflate(-6, -6);

                using (Brush b = new SolidBrush(buttonColor))
                {
                    e.Graphics.FillRectangle(b, buttonArea);
                }

                TextRenderer.DrawText(e.Graphics, buttonText, dgvBasvurular.Font, buttonArea, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                e.Handled = true;
            }
        }

        private void dgvBasvurular_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvBasvurular.Columns[e.ColumnIndex].DataPropertyName == "Durum" && e.Value != null)
            {
                string durum = e.Value.ToString();
                e.CellStyle.Font = new Font(dgvBasvurular.Font, FontStyle.Bold);

                switch (durum)
                {
                    case "Beklemede": e.CellStyle.ForeColor = Color.Yellow; break;
                    case "Kabul Edildi": e.CellStyle.ForeColor = Color.LightGreen; break;
                    case "Reddedildi": e.CellStyle.ForeColor = Color.Red; break;
                    case "Mülakat Onayı": e.CellStyle.ForeColor = Color.Orange; break;
                    case "Mülakat": e.CellStyle.ForeColor = Color.Turquoise; break;
                }
            }
        }

        private void dgvBasvurular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvBasvurular.Columns[e.ColumnIndex].Name == "btnDetay")
            {
                var secili = (Basvuru)dgvBasvurular.Rows[e.RowIndex].DataBoundItem;

                if (secili.Durum == "Mülakat Onayı")
                {
                    var cevap = MessageBox.Show($"{secili.SirketAdi} mülakat davetini onaylıyor musunuz?", "Mülakat Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cevap == DialogResult.Yes)
                    {
                        secili.Durum = "Mülakat";
                        MessageBox.Show("Mülakat onaylandı! 'Değerlendir' butonuna tıklayarak mülakat sonucunu girebilirsiniz.", "Bilgi");
                        dgvBasvurular.Refresh();
                        // İsteğe bağlı: Onaydan hemen sonra değerlendirme ekranına gitmek için:
                        // GitDegerlendirmeEkrani(secili);
                    }
                }
                else if (secili.Durum == "Mülakat")
                {
                    GitDegerlendirmeEkrani(secili);
                }
            }
        }

        /// <summary>
        /// Seçili başvuruyu süreç değerlendirme ekranına taşır.
        /// </summary>
        private void GitDegerlendirmeEkrani(Basvuru basvuru)
        {
            try
            {
                // 1. Yeni kontrolü oluştur
                UC_SurecDegerlendirme ucDegerlendirme = new UC_SurecDegerlendirme(basvuru);
                ucDegerlendirme.Dock = DockStyle.Fill;

                // 2. Ana Formu ve pnlContent'i en garantici yoldan bulalım
                Form anaForm = this.FindForm();
                Control pnlContent = null;

                if (anaForm != null)
                {
                    // Form üzerindeki pnlContent isimli paneli tüm hiyerarşide ara
                    pnlContent = anaForm.Controls.Find("pnlContent", true).FirstOrDefault();
                }

                // 3. Geçiş İşlemi
                if (pnlContent != null)
                {
                    pnlContent.Controls.Clear();
                    pnlContent.Controls.Add(ucDegerlendirme);
                    ucDegerlendirme.BringToFront();
                }
                else
                {
                    // Fallback: Eğer pnlContent ismi farklıysa veya bulunamadıysa Parent zincirini dene
                    Control currentParent = this.Parent;
                    while (currentParent != null && currentParent.Name != "pnlContent")
                    {
                        currentParent = currentParent.Parent;
                    }

                    if (currentParent != null)
                    {
                        currentParent.Controls.Clear();
                        currentParent.Controls.Add(ucDegerlendirme);
                        ucDegerlendirme.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("Hata: İçerik paneli (pnlContent) bulunamadı. Lütfen ana formdaki panel ismini kontrol edin.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekran geçiş hatası: " + ex.Message);
            }
        }

        private void btnAra_Click(object sender, EventArgs e) => VerileriListele();
        private void cmbDurumFiltresi_SelectedIndexChanged(object sender, EventArgs e) => VerileriListele();
    }
}