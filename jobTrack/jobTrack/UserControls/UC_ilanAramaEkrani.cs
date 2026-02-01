using jobTrack.Helpers;
using jobTrack.Models;
using jobTrack.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_ilanAramaEkrani : UserControl
    {
        private Ilan seciliIlan;
        private List<Ilan> tumIlanlar = new List<Ilan>();
        private IlanRepository ilanRepo = new IlanRepository();

        public UC_ilanAramaEkrani()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            this.Load += UC_ilanAramaEkrani_Load;
        }

        private void UC_ilanAramaEkrani_Load(object sender, EventArgs e)
        {
            ComboBoxlariDoldur();
            flpIlanlar.FlowDirection = FlowDirection.TopDown;
            flpIlanlar.WrapContents = false;
            flpIlanlar.AutoScroll = true;

            VerileriYukle();
        }

        private void VerileriYukle()
        {
            try
            {
                // SQL'den gerçek verileri çekiyoruz
                tumIlanlar = ilanRepo.IlanlariGetir();
                UygulaFiltreleme();
            }
            catch (Exception ex)
            {
                MessageBox.Show("İlanlar yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void ComboBoxlariDoldur()
        {
            cmbSektor.Items.Clear();
            cmbSektor.Items.AddRange(new string[] { "Teknoloji", "Yazılım", "Finans", "Sağlık", "Eğitim" });

            cmbDeneyim.Items.Clear();
            cmbDeneyim.Items.AddRange(new string[] { "0-2", "3-5", "5-10", "10+" });

            cmbYayinlanma.Items.Clear();
            cmbYayinlanma.Items.AddRange(new string[] { "Son 24 Saat", "Son 1 Hafta", "Son 1 Ay" });
        }

        private void UygulaFiltreleme()
        {
            string anahtar = txtAramaSol.Text.Trim().ToLower();
            string konumF = txtKonumFiltre.Text.Trim().ToLower();
            string sektorF = cmbSektor.SelectedItem?.ToString();
            string deneyimF = cmbDeneyim.SelectedItem?.ToString();

            bool ftSecili = chkFullTime.Checked;
            bool ptSecili = chkPartTime.Checked;
            bool uzSecili = chkUzaktan.Checked;

            decimal.TryParse(txtMaasMin.Text, out decimal min);
            decimal.TryParse(txtMaasMax.Text, out decimal max);

            var filtrelenmis = tumIlanlar.Where(ilan =>
            {
                bool kelimeUygun = string.IsNullOrEmpty(anahtar) ||
                                  ilan.Baslik.ToLower().Contains(anahtar) ||
                                  ilan.Sirket.ToLower().Contains(anahtar);

                bool konumUygun = string.IsNullOrEmpty(konumF) || ilan.Konum.ToLower().Contains(konumF);
                bool sektorUygun = string.IsNullOrEmpty(sektorF) || ilan.Sektor == sektorF;
                bool deneyimUygun = string.IsNullOrEmpty(deneyimF) || ilan.Deneyim == deneyimF;

                bool calismaUygun = true;
                if (ftSecili || ptSecili || uzSecili)
                {
                    calismaUygun = (ftSecili && ilan.CalismaSekli == "Full - Time") ||
                                   (ptSecili && ilan.CalismaSekli == "Part - Time") ||
                                   (uzSecili && ilan.CalismaSekli == "Uzaktan");
                }

                decimal maxSinir = (max <= 0) ? decimal.MaxValue : max;
                bool maasUygun = ilan.Maas >= min && ilan.Maas <= maxSinir;

                return kelimeUygun && konumUygun && sektorUygun && calismaUygun && deneyimUygun && maasUygun;
            }).ToList();

            IlanlariListele(filtrelenmis);
        }

        private void IlanlariListele(List<Ilan> liste)
        {
            flpIlanlar.Controls.Clear();
            flpIlanlar.Controls.Add(label9); // Başlığı koru

            foreach (var ilan in liste)
            {
                Panel pnl = new Panel
                {
                    Width = flpIlanlar.Width - 40,
                    Height = 110,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Cursor = Cursors.Hand,
                    BackColor = Color.FromArgb(30, 30, 30)
                };

                Label lblBaslik = new Label
                {
                    Text = ilan.Baslik,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(15, 15),
                    Size = new Size(pnl.Width - 20, 25),
                    AutoEllipsis = true
                };

                Label lblSirket = new Label
                {
                    Text = $"{ilan.Sirket} • {ilan.Konum}",
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.DarkGray,
                    Location = new Point(15, 45),
                    Size = new Size(pnl.Width - 20, 20)
                };

                Label lblSnippet = new Label
                {
                    Text = ilan.Snippet,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.Gray,
                    Location = new Point(15, 70),
                    Size = new Size(pnl.Width - 20, 20)
                };

                // Tıklama Olayları
                Action selectAction = () =>
                {
                    foreach (Control c in flpIlanlar.Controls) if (c is Panel) c.BackColor = Color.FromArgb(30, 30, 30);
                    pnl.BackColor = Color.FromArgb(60, 60, 60);
                    IlanDetayGoster(ilan);
                };

                pnl.Click += (s, e) => selectAction();
                lblBaslik.Click += (s, e) => selectAction();
                lblSirket.Click += (s, e) => selectAction();

                pnl.Controls.Add(lblBaslik);
                pnl.Controls.Add(lblSirket);
                pnl.Controls.Add(lblSnippet);
                flpIlanlar.Controls.Add(pnl);
            }
        }

        private void IlanDetayGoster(Ilan ilan)
        {
            seciliIlan = ilan;
            lblBaslikDetay.Text = ilan.Baslik;
            lblSirketAd.Text = "Şirket: " + ilan.Sirket;
            lblSirketKonum.Text = "Konum: " + ilan.Konum;
            lblMinQualList.Text = ilan.Nitelikler;
            lblMaasDetay.Text = "Maaş: " + (ilan.Maas?.ToString("C2") ?? "Belirtilmemiş");
            lblCalismaSekli.Text = "Çalışma: " + ilan.CalismaSekli;
            lblDeneyimDetay.Text = "Deneyim: " + ilan.Deneyim;
            lblSektorDetay.Text = "Sektör: " + ilan.Sektor;
            lblYayinlanmaTarihi.Text = "Tarih: " + (ilan.YayinlanmaTarihi?.ToString("dd.MM.yyyy") ?? "Belirtilmemiş");
        }

        private void btnFiltrele_Click(object sender, EventArgs e) => UygulaFiltreleme();

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAramaSol.Clear();
            txtKonumFiltre.Clear();
            txtMaasMin.Clear();
            txtMaasMax.Clear();
            cmbSektor.SelectedIndex = -1;
            cmbDeneyim.SelectedIndex = -1;
            cmbYayinlanma.SelectedIndex = -1;
            UygulaFiltreleme();
        }

        private void txtAramaSol_TextChanged(object sender, EventArgs e) => UygulaFiltreleme();

        private void btnBasvur_Click(object sender, EventArgs e)
        {
            if (seciliIlan == null)
            {
                MessageBox.Show("Lütfen önce bir ilan seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionManager.GirisYapanKullanici == null)
            {
                MessageBox.Show("Başvuru yapabilmek için bireysel kullanıcı girişi yapmalısınız!");
                return;
            }

            try
            {
                BasvuruRepository basvuruRepo = new BasvuruRepository();
                bool basarili = basvuruRepo.BasvuruYap(SessionManager.GirisYapanKullanici.Id, seciliIlan.Id);

                if (basarili)
                    MessageBox.Show($"{seciliIlan.Sirket} ilanına başvurunuz başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Bu ilana daha önce başvurmuş olabilirsiniz.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başvuru sırasında bir hata oluştu: " + ex.Message);
            }
        }
    }
}