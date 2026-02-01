using jobTrack.Helpers;
using jobTrack.Models;
using jobTrack.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // ToList() kullanımı için
using System.Text;
using System.Windows.Forms;

namespace jobTrack.UserControls
{
    public partial class UC_CvSihirbaziEkrani : UserControl
    {
        // Ana Form ile haberleşmek için olay (Event)
        public event Action<string> SayfaDegistirIstegi;

        // Tablolarla (DataGridView) senkronize çalışan listeler
        BindingList<Egitim> egitimListesi = new BindingList<Egitim>();
        BindingList<IsDeneyimi> isDeneyimiListesi = new BindingList<IsDeneyimi>();
        BindingList<Yetenek> yetenekListesi = new BindingList<Yetenek>();
        BindingList<Sertifika> sertifikaListesi = new BindingList<Sertifika>();

        // Güncelleme işlemi sırasında hangi satırın seçili olduğunu tutan geçici nesneler
        Egitim guncellenecekEgitim;
        IsDeneyimi guncellenecekIs;
        Yetenek guncellenecekYetenek;
        Sertifika guncellenecekSertifika;

        public UC_CvSihirbaziEkrani()
        {
            InitializeComponent();
            ThemeManager.ApplyTheme(this);
            TabloAyarlariniYap();
            this.Dock = DockStyle.Fill;
            this.Load += UC_CvSihirbaziEkrani_Load;
        }

        private void TabloAyarlariniYap()
        {
            // Tabloların kolonlarını otomatik oluşturmasını engelliyoruz (Tasarım tarafında elle eklediysen)
            dgvEgitim.AutoGenerateColumns = dgvIsDeneyimi.AutoGenerateColumns =
            dgvYetenekler.AutoGenerateColumns = dgvSertifikalar.AutoGenerateColumns = false;

            // Listeleri tablolara bağlıyoruz
            dgvEgitim.DataSource = egitimListesi;
            dgvIsDeneyimi.DataSource = isDeneyimiListesi;
            dgvYetenekler.DataSource = yetenekListesi;
            dgvSertifikalar.DataSource = sertifikaListesi;
        }

        private void UC_CvSihirbaziEkrani_Load(object sender, EventArgs e)
        {
            // Giriş yapan kullanıcı yoksa işlem yapma
            if (SessionManager.GirisYapanKullanici == null) return;

            int kullaniciId = SessionManager.GirisYapanKullanici.Id;
            CvRepository repo = new CvRepository();

            try
            {
                // 1. Eğitimleri yükle ve listeyi tazele
                var gelenEgitimler = repo.GetirEgitimler(kullaniciId);
                egitimListesi = new BindingList<Egitim>(gelenEgitimler);
                dgvEgitim.DataSource = egitimListesi;

                // 2. İş deneyimlerini yükle
                var gelenIsler = repo.GetirIsDeneyimleri(kullaniciId);
                isDeneyimiListesi = new BindingList<IsDeneyimi>(gelenIsler);
                dgvIsDeneyimi.DataSource = isDeneyimiListesi;

                // 3. Yetenekleri yükle
                var gelenYetenekler = repo.GetirYetenekler(kullaniciId);
                yetenekListesi = new BindingList<Yetenek>(gelenYetenekler);
                dgvYetenekler.DataSource = yetenekListesi;

                // 4. Sertifikaları yükle
                var gelenSertifikalar = repo.GetirSertifikalar(kullaniciId);
                sertifikaListesi = new BindingList<Sertifika>(gelenSertifikalar);
                dgvSertifikalar.DataSource = sertifikaListesi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        // --- NAVİGASYON BUTONLARI ---
        private void btnAnasayfa_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Anasayfa");
        private void btnBildirimler_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("Bildirimler");
        private void btnIlanAra_Click(object sender, EventArgs e) => SayfaDegistirIstegi?.Invoke("IlanAra");

        // --- EĞİTİM İŞLEMLERİ ---
        private void btnEgitimEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOkulAdi.Text))
            {
                MessageBox.Show("Lütfen okul adını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkDevamEdiyor.Checked && dtpMezuniyet.Value < dtpBaslangic.Value)
            {
                MessageBox.Show("Mezuniyet tarihi başlangıçtan önce olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            egitimListesi.Add(new Egitim()
            {
                OkulAdi = txtOkulAdi.Text,
                Bolum = txtBolum.Text,
                Derece = cmbDerece.SelectedItem?.ToString() ?? "Belirtilmedi",
                BaslangicTarihi = dtpBaslangic.Value,
                MezuniyetTarihi = chkDevamEdiyor.Checked ? null : (DateTime?)dtpMezuniyet.Value,
                DevamEdiyor = chkDevamEdiyor.Checked
            });

            TemizleEgitimFormu();
        }

        private void btnEgitimGuncelle_Click(object sender, EventArgs e)
        {
            if (guncellenecekEgitim != null)
            {
                guncellenecekEgitim.OkulAdi = txtOkulAdi.Text;
                guncellenecekEgitim.Bolum = txtBolum.Text;
                guncellenecekEgitim.Derece = cmbDerece.SelectedItem?.ToString();
                guncellenecekEgitim.BaslangicTarihi = dtpBaslangic.Value;
                guncellenecekEgitim.MezuniyetTarihi = chkDevamEdiyor.Checked ? null : (DateTime?)dtpMezuniyet.Value;
                guncellenecekEgitim.DevamEdiyor = chkDevamEdiyor.Checked;

                egitimListesi.ResetBindings(); // Tabloyu tazele
                guncellenecekEgitim = null;
                TemizleEgitimFormu();
                MessageBox.Show("Eğitim bilgisi güncellendi.");
            }
            else
            {
                MessageBox.Show("Hata: Güncellenecek bir satır seçilmemiş!");
            }
        }

        private void btnEgitimSil_Click(object sender, EventArgs e)
        {
            if (dgvEgitim.CurrentRow != null && SilmeOnayiAl())
                egitimListesi.Remove((Egitim)dgvEgitim.CurrentRow.DataBoundItem);
        }

        // --- İŞ DENEYİMİ İŞLEMLERİ ---
        private void btnIsDeneyimiEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSirketAdi.Text)) return;

            isDeneyimiListesi.Add(new IsDeneyimi()
            {
                SirketAdi = txtSirketAdi.Text,
                Pozisyon = txtPozisyon.Text,
                IsTanimi = txtIsTanimi.Text,
                BaslamaTarihi = dtpIsBaslama.Value,
                AyrilmaTarihi = chkIsDevamEdiyor.Checked ? null : (DateTime?)dtpIsAyrilma.Value,
                DevamEdiyor = chkIsDevamEdiyor.Checked
            });
            TemizleIsFormu();
        }

        private void btnIsDeneyimiGuncelle_Click(object sender, EventArgs e)
        {
            if (guncellenecekIs != null)
            {
                guncellenecekIs.SirketAdi = txtSirketAdi.Text;
                guncellenecekIs.Pozisyon = txtPozisyon.Text;
                guncellenecekIs.IsTanimi = txtIsTanimi.Text;
                guncellenecekIs.BaslamaTarihi = dtpIsBaslama.Value;
                guncellenecekIs.AyrilmaTarihi = chkIsDevamEdiyor.Checked ? null : (DateTime?)dtpIsAyrilma.Value;
                guncellenecekIs.DevamEdiyor = chkIsDevamEdiyor.Checked;

                isDeneyimiListesi.ResetBindings();
                guncellenecekIs = null;
                TemizleIsFormu();
                MessageBox.Show("İş deneyimi bilgisi güncellendi.");
            }
            else
            {
                MessageBox.Show("Hata: Güncellenecek bir satır seçilmemiş!");
            }
        }

        private void btnIsDeneyimiSil_Click(object sender, EventArgs e)
        {
            if (dgvIsDeneyimi.CurrentRow != null && SilmeOnayiAl())
                isDeneyimiListesi.Remove((IsDeneyimi)dgvIsDeneyimi.CurrentRow.DataBoundItem);
        }

        // --- YETENEK VE SERTİFİKA İŞLEMLERİ ---
        private void btnYetenekEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYetenekAdi.Text)) return;
            yetenekListesi.Add(new Yetenek { YetenekAdi = txtYetenekAdi.Text, Seviye = cmbYetenekSeviyesi.SelectedItem?.ToString() });
            txtYetenekAdi.Clear();
        }

        private void btnYetenekGuncelle_Click(object sender, EventArgs e)
        {
            if (guncellenecekYetenek != null)
            {
                guncellenecekYetenek.YetenekAdi = txtYetenekAdi.Text;
                guncellenecekYetenek.Seviye = cmbYetenekSeviyesi.SelectedItem?.ToString();

                yetenekListesi.ResetBindings(); // Tabloyu görsel olarak tazeler
                guncellenecekYetenek = null;
                txtYetenekAdi.Clear();
                MessageBox.Show("Yetenek güncellendi.");
            }
            else
            {
                MessageBox.Show("Hata: Güncellenecek bir satır seçilmemiş!");
            }
        }

        private void btnYetenekSil_Click(object sender, EventArgs e)
        {
            if (dgvYetenekler.CurrentRow != null && SilmeOnayiAl())
                yetenekListesi.Remove((Yetenek)dgvYetenekler.CurrentRow.DataBoundItem);
        }

        private void btnSertifikaEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSertifikaAdi.Text)) return;
            sertifikaListesi.Add(new Sertifika { SertifikaAdi = txtSertifikaAdi.Text, AlindigiKurum = txtSertifikaKurum.Text, AlindigiTarih = dtpSertifikaTarih.Value });
            txtSertifikaAdi.Clear(); txtSertifikaKurum.Clear();
        }

        private void btnSertifikaGuncelle_Click(object sender, EventArgs e)
        {
            if (guncellenecekSertifika != null)
            {
                guncellenecekSertifika.SertifikaAdi = txtSertifikaAdi.Text;
                guncellenecekSertifika.AlindigiKurum = txtSertifikaKurum.Text;
                guncellenecekSertifika.AlindigiTarih = dtpSertifikaTarih.Value;

                sertifikaListesi.ResetBindings();
                guncellenecekSertifika = null;
                txtSertifikaAdi.Clear(); txtSertifikaKurum.Clear();
                MessageBox.Show("Sertifika güncellendi.");
            }
            else
            {
                MessageBox.Show("Hata: Güncellenecek bir satır seçilmemiş!");
            }
        }

        private void btnSertifikaSil_Click(object sender, EventArgs e)
        {
            if (dgvSertifikalar.CurrentRow != null && SilmeOnayiAl())
                sertifikaListesi.Remove((Sertifika)dgvSertifikalar.CurrentRow.DataBoundItem);
        }

        // --- VERİTABANINA KAYDET (SON ADIM) ---
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // SessionManager üzerinden giriş yapan kullanıcı kontrolü
            if (SessionManager.GirisYapanKullanici == null)
            {
                MessageBox.Show("Kayıt yapabilmek için giriş yapmalısınız!", "Uyarı");
                return;
            }

            if (egitimListesi.Count == 0 && isDeneyimiListesi.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir eğitim veya iş deneyimi ekleyin.", "Bilgi");
                return;
            }

            CvRepository cvRepo = new CvRepository();
            bool basarili = cvRepo.CvKaydet(
                SessionManager.GirisYapanKullanici.Id,
                egitimListesi.ToList(),
                isDeneyimiListesi.ToList(),
                yetenekListesi.ToList(),
                sertifikaListesi.ToList()
            );

            if (basarili)
            {
                MessageBox.Show("Özgeçmiş bilgileriniz başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Kayıt başarılıysa Önizleme sayfasına yönlendir
                SayfaDegistirIstegi?.Invoke("CvOnizleme");
            }
            else
            {
                MessageBox.Show("Kaydedilirken bir hata oluştu. Lütfen bağlantınızı kontrol edin.", "Hata");
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            // Kullanıcıya onay soralım (Opsiyonel)
            DialogResult sonuc = MessageBox.Show("Giriş yapılan veriler temizlenecek. Emin misiniz?", "İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                FormuTamamenSifirla();

                SayfaDegistirIstegi?.Invoke("Anasayfa");
            }
        }

        // --- YARDIMCI METOTLAR (TEMİZLEME VE ONAY) ---
        private bool SilmeOnayiAl() => MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

        private void TemizleEgitimFormu()
        {
            txtOkulAdi.Clear(); txtBolum.Clear(); cmbDerece.SelectedIndex = -1;
            dtpBaslangic.Value = dtpMezuniyet.Value = DateTime.Now; chkDevamEdiyor.Checked = false;
        }

        private void TemizleIsFormu()
        {
            txtSirketAdi.Clear(); txtPozisyon.Clear(); txtIsTanimi.Clear();
            dtpIsBaslama.Value = dtpIsAyrilma.Value = DateTime.Now; chkIsDevamEdiyor.Checked = false;
        }

        private void FormuTamamenSifirla()
        {
            // 1. Tüm form temizleme metotlarını çağır
            TemizleEgitimFormu();
            TemizleIsFormu();

            // 2. Yetenek ve Sertifika alanlarını temizle
            txtYetenekAdi.Clear();
            cmbYetenekSeviyesi.SelectedIndex = -1;
            txtSertifikaAdi.Clear();
            txtSertifikaKurum.Clear();
            dtpSertifikaTarih.Value = DateTime.Now;

            // 3. KRİTİK: Güncelleme nesnelerini sıfırla
            // Bu işlem yapılmazsa, iptalden sonra yeni kayıt eklemek istersen eski kaydı güncelleyebilir!
            guncellenecekEgitim = null;
            guncellenecekIs = null;
            guncellenecekYetenek = null;
            guncellenecekSertifika = null;

            // 4. (Opsiyonel) Varsa "Güncelle" butonlarını pasif, "Ekle" butonlarını aktif yapabilirsin
        }

        private void chkDevamEdiyor_CheckedChanged(object sender, EventArgs e) => dtpMezuniyet.Enabled = !chkDevamEdiyor.Checked;
        private void chkIsDevamEdiyor_CheckedChanged(object sender, EventArgs e) => dtpIsAyrilma.Enabled = !chkIsDevamEdiyor.Checked;

        // Tablodan seçim yapıldığında kutuları dolduran olaylar
        private void dgvEgitim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // DataBoundItem'ı 'as' ile çekerek boş satırda hata almasını engelliyoruz
                var secilenNesne = dgvEgitim.Rows[e.RowIndex].DataBoundItem as Egitim;

                // Eğer tıklanan satır boş değilse (null değilse) işlemleri yap
                if (secilenNesne != null)
                {
                    guncellenecekEgitim = secilenNesne;
                    txtOkulAdi.Text = guncellenecekEgitim.OkulAdi;
                    txtBolum.Text = guncellenecekEgitim.Bolum;
                    cmbDerece.SelectedItem = guncellenecekEgitim.Derece;
                    dtpBaslangic.Value = guncellenecekEgitim.BaslangicTarihi;
                    if (guncellenecekEgitim.MezuniyetTarihi.HasValue) dtpMezuniyet.Value = guncellenecekEgitim.MezuniyetTarihi.Value;
                    chkDevamEdiyor.Checked = guncellenecekEgitim.DevamEdiyor;
                }
            }
        }

        private void dgvIsDeneyimi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // DataBoundItem'ı 'as' operatörü ile güvenli bir şekilde alıyoruz
                var secilenIs = dgvIsDeneyimi.Rows[e.RowIndex].DataBoundItem as IsDeneyimi;

                // Eğer seçilen satır boş değilse (null değilse) işlemleri yap
                if (secilenIs != null)
                {
                    guncellenecekIs = secilenIs;
                    txtSirketAdi.Text = guncellenecekIs.SirketAdi;
                    txtPozisyon.Text = guncellenecekIs.Pozisyon;
                    txtIsTanimi.Text = guncellenecekIs.IsTanimi;
                    dtpIsBaslama.Value = guncellenecekIs.BaslamaTarihi;

                    if (guncellenecekIs.AyrilmaTarihi.HasValue)
                        dtpIsAyrilma.Value = guncellenecekIs.AyrilmaTarihi.Value;

                    chkIsDevamEdiyor.Checked = guncellenecekIs.DevamEdiyor;
                }
            }
        }

        private void dgvYetenekler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlık satırına tıklanmadığından emin oluyoruz
            if (e.RowIndex >= 0)
            {
                // 'as' kullanarak nesneyi güvenli bir şekilde çekiyoruz
                var secilenYetenek = dgvYetenekler.Rows[e.RowIndex].DataBoundItem as Yetenek;

                // Eğer tıklanan satır boş değilse işlemleri yap
                if (secilenYetenek != null)
                {
                    guncellenecekYetenek = secilenYetenek;

                    // Kutucukları nesnedeki verilerle doldur
                    txtYetenekAdi.Text = guncellenecekYetenek.YetenekAdi;

                    // ComboBox'ta ilgili seviyeyi seç
                    cmbYetenekSeviyesi.SelectedItem = guncellenecekYetenek.Seviye;
                }
            }
        }

        private void dgvSertifikalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 'as' operatörü ile nesneyi güvenli bir şekilde alıyoruz
                var secilenSertifika = dgvSertifikalar.Rows[e.RowIndex].DataBoundItem as Sertifika;

                // Eğer seçilen satır boş değilse (null değilse) işlemleri yap
                if (secilenSertifika != null)
                {
                    guncellenecekSertifika = secilenSertifika;

                    // Kutucukları doldur
                    txtSertifikaAdi.Text = guncellenecekSertifika.SertifikaAdi;
                    txtSertifikaKurum.Text = guncellenecekSertifika.AlindigiKurum;

                    // Tarih seçili gelmesi için
                    if (guncellenecekSertifika.AlindigiTarih.HasValue)
                        dtpSertifikaTarih.Value = guncellenecekSertifika.AlindigiTarih.Value;
                }
            }
        }
    }
}
