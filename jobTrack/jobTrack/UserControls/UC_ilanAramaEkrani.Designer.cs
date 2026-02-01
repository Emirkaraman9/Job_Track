namespace jobTrack.UserControls
{
    partial class UC_ilanAramaEkrani
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            flpIlanlar = new FlowLayoutPanel();
            label9 = new Label();
            panel2 = new Panel();
            lblYayinlanmaTarihi = new Label();
            lblSektorDetay = new Label();
            lblMaasDetay = new Label();
            lblDeneyimDetay = new Label();
            lblCalismaSekli = new Label();
            btnKaydet = new Button();
            btnBasvur = new Button();
            lblPrefQualTitle = new Label();
            lblMinQualList = new Label();
            lblSirketKonum = new Label();
            lblSirketAd = new Label();
            lblBaslikDetay = new Label();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            btnFiltrele = new Button();
            btnTemizle = new Button();
            label8 = new Label();
            label7 = new Label();
            cmbSektor = new ComboBox();
            cmbYayinlanma = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtKonumFiltre = new TextBox();
            txtMaasMin = new TextBox();
            txtMaasMax = new TextBox();
            cmbDeneyim = new ComboBox();
            chkUzaktan = new CheckBox();
            chkPartTime = new CheckBox();
            chkFullTime = new CheckBox();
            label2 = new Label();
            label1 = new Label();
            btnAraSol = new Button();
            txtAramaSol = new TextBox();
            panel1.SuspendLayout();
            flpIlanlar.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(flpIlanlar);
            panel1.Location = new Point(371, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(435, 963);
            panel1.TabIndex = 0;
            // 
            // flpIlanlar
            // 
            flpIlanlar.AutoScroll = true;
            flpIlanlar.Controls.Add(label9);
            flpIlanlar.Dock = DockStyle.Fill;
            flpIlanlar.FlowDirection = FlowDirection.TopDown;
            flpIlanlar.Location = new Point(0, 0);
            flpIlanlar.Name = "flpIlanlar";
            flpIlanlar.Size = new Size(435, 963);
            flpIlanlar.TabIndex = 0;
            flpIlanlar.WrapContents = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Black;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(20, 50);
            label9.Margin = new Padding(20, 50, 3, 0);
            label9.Name = "label9";
            label9.Size = new Size(134, 20);
            label9.TabIndex = 3;
            label9.Text = "İLAN SONUÇLARI";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(lblYayinlanmaTarihi);
            panel2.Controls.Add(lblSektorDetay);
            panel2.Controls.Add(lblMaasDetay);
            panel2.Controls.Add(lblDeneyimDetay);
            panel2.Controls.Add(lblCalismaSekli);
            panel2.Controls.Add(btnKaydet);
            panel2.Controls.Add(btnBasvur);
            panel2.Controls.Add(lblPrefQualTitle);
            panel2.Controls.Add(lblMinQualList);
            panel2.Controls.Add(lblSirketKonum);
            panel2.Controls.Add(lblSirketAd);
            panel2.Controls.Add(lblBaslikDetay);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(812, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(1090, 963);
            panel2.TabIndex = 1;
            // 
            // lblYayinlanmaTarihi
            // 
            lblYayinlanmaTarihi.AutoSize = true;
            lblYayinlanmaTarihi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblYayinlanmaTarihi.ForeColor = Color.White;
            lblYayinlanmaTarihi.Location = new Point(66, 719);
            lblYayinlanmaTarihi.Name = "lblYayinlanmaTarihi";
            lblYayinlanmaTarihi.Size = new Size(220, 28);
            lblYayinlanmaTarihi.TabIndex = 0;
            lblYayinlanmaTarihi.Text = "İlan Yayınlanma Tarihi";
            // 
            // lblSektorDetay
            // 
            lblSektorDetay.AutoSize = true;
            lblSektorDetay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSektorDetay.ForeColor = Color.White;
            lblSektorDetay.Location = new Point(73, 229);
            lblSektorDetay.Name = "lblSektorDetay";
            lblSektorDetay.Size = new Size(73, 28);
            lblSektorDetay.TabIndex = 1;
            lblSektorDetay.Text = "Sektör";
            // 
            // lblMaasDetay
            // 
            lblMaasDetay.AutoSize = true;
            lblMaasDetay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMaasDetay.ForeColor = Color.White;
            lblMaasDetay.Location = new Point(792, 309);
            lblMaasDetay.Name = "lblMaasDetay";
            lblMaasDetay.Size = new Size(62, 28);
            lblMaasDetay.TabIndex = 2;
            lblMaasDetay.Text = "Maaş";
            // 
            // lblDeneyimDetay
            // 
            lblDeneyimDetay.AutoSize = true;
            lblDeneyimDetay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDeneyimDetay.ForeColor = Color.White;
            lblDeneyimDetay.Location = new Point(406, 309);
            lblDeneyimDetay.Name = "lblDeneyimDetay";
            lblDeneyimDetay.Size = new Size(96, 28);
            lblDeneyimDetay.TabIndex = 3;
            lblDeneyimDetay.Text = "Deneyim";
            // 
            // lblCalismaSekli
            // 
            lblCalismaSekli.AutoSize = true;
            lblCalismaSekli.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCalismaSekli.ForeColor = Color.White;
            lblCalismaSekli.Location = new Point(73, 309);
            lblCalismaSekli.Name = "lblCalismaSekli";
            lblCalismaSekli.Size = new Size(136, 28);
            lblCalismaSekli.TabIndex = 4;
            lblCalismaSekli.Text = "Çalışma Şekli";
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.CornflowerBlue;
            btnKaydet.Location = new Point(655, 785);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(125, 49);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            // 
            // btnBasvur
            // 
            btnBasvur.BackColor = Color.MediumSeaGreen;
            btnBasvur.Location = new Point(836, 785);
            btnBasvur.Name = "btnBasvur";
            btnBasvur.Size = new Size(125, 49);
            btnBasvur.TabIndex = 6;
            btnBasvur.Text = "Başvur";
            btnBasvur.UseVisualStyleBackColor = false;
            btnBasvur.Click += btnBasvur_Click;
            // 
            // lblPrefQualTitle
            // 
            lblPrefQualTitle.AutoSize = true;
            lblPrefQualTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrefQualTitle.ForeColor = Color.White;
            lblPrefQualTitle.Location = new Point(73, 428);
            lblPrefQualTitle.Name = "lblPrefQualTitle";
            lblPrefQualTitle.Size = new Size(191, 23);
            lblPrefQualTitle.TabIndex = 7;
            lblPrefQualTitle.Text = "Tercih Edilen Nitelikler";
            // 
            // lblMinQualList
            // 
            lblMinQualList.AutoSize = true;
            lblMinQualList.ForeColor = Color.White;
            lblMinQualList.Location = new Point(73, 475);
            lblMinQualList.Name = "lblMinQualList";
            lblMinQualList.Size = new Size(0, 20);
            lblMinQualList.TabIndex = 8;
            // 
            // lblSirketKonum
            // 
            lblSirketKonum.AutoSize = true;
            lblSirketKonum.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSirketKonum.ForeColor = Color.White;
            lblSirketKonum.Location = new Point(792, 229);
            lblSirketKonum.Name = "lblSirketKonum";
            lblSirketKonum.Size = new Size(79, 28);
            lblSirketKonum.TabIndex = 9;
            lblSirketKonum.Text = "Konum";
            // 
            // lblSirketAd
            // 
            lblSirketAd.AutoSize = true;
            lblSirketAd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSirketAd.ForeColor = Color.White;
            lblSirketAd.Location = new Point(406, 229);
            lblSirketAd.Name = "lblSirketAd";
            lblSirketAd.Size = new Size(65, 28);
            lblSirketAd.TabIndex = 10;
            lblSirketAd.Text = "Firma";
            // 
            // lblBaslikDetay
            // 
            lblBaslikDetay.AutoSize = true;
            lblBaslikDetay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBaslikDetay.ForeColor = Color.White;
            lblBaslikDetay.Location = new Point(73, 152);
            lblBaslikDetay.Name = "lblBaslikDetay";
            lblBaslikDetay.Size = new Size(138, 28);
            lblBaslikDetay.TabIndex = 11;
            lblBaslikDetay.Text = "İLAN BAŞLIĞI";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.Location = new Point(84, 50);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 74);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(btnFiltrele);
            panel3.Controls.Add(btnTemizle);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(cmbSektor);
            panel3.Controls.Add(cmbYayinlanma);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtKonumFiltre);
            panel3.Controls.Add(txtMaasMin);
            panel3.Controls.Add(txtMaasMax);
            panel3.Controls.Add(cmbDeneyim);
            panel3.Controls.Add(chkUzaktan);
            panel3.Controls.Add(chkPartTime);
            panel3.Controls.Add(chkFullTime);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnAraSol);
            panel3.Controls.Add(txtAramaSol);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(0, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(365, 963);
            panel3.TabIndex = 2;
            // 
            // btnFiltrele
            // 
            btnFiltrele.Location = new Point(179, 836);
            btnFiltrele.Name = "btnFiltrele";
            btnFiltrele.Size = new Size(94, 29);
            btnFiltrele.TabIndex = 0;
            btnFiltrele.Text = "Filtrele";
            btnFiltrele.Click += btnFiltrele_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(21, 836);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(94, 29);
            btnTemizle.TabIndex = 1;
            btnTemizle.Text = "Temizle";
            btnTemizle.Click += btnTemizle_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(144, 756);
            label8.Name = "label8";
            label8.Size = new Size(15, 20);
            label8.TabIndex = 2;
            label8.Text = "-";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(21, 727);
            label7.Name = "label7";
            label7.Size = new Size(96, 20);
            label7.TabIndex = 3;
            label7.Text = "Maaş Aralığı";
            // 
            // cmbSektor
            // 
            cmbSektor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSektor.Items.AddRange(new object[] { "Teknoloji", "Yazılım", "Finans", "Sağlık" });
            cmbSektor.Location = new Point(21, 639);
            cmbSektor.Name = "cmbSektor";
            cmbSektor.Size = new Size(163, 28);
            cmbSektor.TabIndex = 4;
            // 
            // cmbYayinlanma
            // 
            cmbYayinlanma.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYayinlanma.Items.AddRange(new object[] { "Son 24 Saat", "Son 1 Hafta", "Son 1 Ay" });
            cmbYayinlanma.Location = new Point(21, 547);
            cmbYayinlanma.Name = "cmbYayinlanma";
            cmbYayinlanma.Size = new Size(163, 28);
            cmbYayinlanma.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(21, 616);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 6;
            label6.Text = "Sektör";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(21, 524);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 7;
            label5.Text = "Yayınlandığı Tarih";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(21, 428);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 8;
            label4.Text = "Deneyim Düzeyi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(21, 271);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 9;
            label3.Text = "Çalışma Şekli";
            // 
            // txtKonumFiltre
            // 
            txtKonumFiltre.Location = new Point(21, 200);
            txtKonumFiltre.Name = "txtKonumFiltre";
            txtKonumFiltre.Size = new Size(163, 27);
            txtKonumFiltre.TabIndex = 10;
            // 
            // txtMaasMin
            // 
            txtMaasMin.Location = new Point(21, 760);
            txtMaasMin.Name = "txtMaasMin";
            txtMaasMin.Size = new Size(100, 27);
            txtMaasMin.TabIndex = 11;
            // 
            // txtMaasMax
            // 
            txtMaasMax.Location = new Point(179, 760);
            txtMaasMax.Name = "txtMaasMax";
            txtMaasMax.Size = new Size(100, 27);
            txtMaasMax.TabIndex = 12;
            // 
            // cmbDeneyim
            // 
            cmbDeneyim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDeneyim.Items.AddRange(new object[] { "0-2 Yıl", "3-5 Yıl", "5-10 Yıl", "10+ Yıl" });
            cmbDeneyim.Location = new Point(21, 451);
            cmbDeneyim.Name = "cmbDeneyim";
            cmbDeneyim.Size = new Size(163, 28);
            cmbDeneyim.TabIndex = 13;
            // 
            // chkUzaktan
            // 
            chkUzaktan.AutoSize = true;
            chkUzaktan.ForeColor = Color.White;
            chkUzaktan.Location = new Point(21, 369);
            chkUzaktan.Name = "chkUzaktan";
            chkUzaktan.Size = new Size(84, 24);
            chkUzaktan.TabIndex = 14;
            chkUzaktan.Text = "Uzaktan";
            // 
            // chkPartTime
            // 
            chkPartTime.AutoSize = true;
            chkPartTime.ForeColor = Color.White;
            chkPartTime.Location = new Point(21, 339);
            chkPartTime.Name = "chkPartTime";
            chkPartTime.Size = new Size(103, 24);
            chkPartTime.TabIndex = 15;
            chkPartTime.Text = "Part - Time";
            // 
            // chkFullTime
            // 
            chkFullTime.AutoSize = true;
            chkFullTime.ForeColor = Color.White;
            chkFullTime.Location = new Point(21, 309);
            chkFullTime.Name = "chkFullTime";
            chkFullTime.Size = new Size(101, 24);
            chkFullTime.TabIndex = 16;
            chkFullTime.Text = "Full - Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 177);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 17;
            label2.Text = "Konum";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 118);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 18;
            label1.Text = "FİLTRELER";
            // 
            // btnAraSol
            // 
            btnAraSol.ForeColor = Color.White;
            btnAraSol.Location = new Point(207, 41);
            btnAraSol.Name = "btnAraSol";
            btnAraSol.Size = new Size(72, 29);
            btnAraSol.TabIndex = 19;
            btnAraSol.Text = "Ara";
            btnAraSol.Click += txtAramaSol_TextChanged;
            // 
            // txtAramaSol
            // 
            txtAramaSol.Location = new Point(21, 43);
            txtAramaSol.Name = "txtAramaSol";
            txtAramaSol.Size = new Size(163, 27);
            txtAramaSol.TabIndex = 20;
            // 
            // UC_ilanAramaEkrani
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_ilanAramaEkrani";
            Size = new Size(1902, 1033);
            panel1.ResumeLayout(false);
            flpIlanlar.ResumeLayout(false);
            flpIlanlar.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtMaasMin;
        private TextBox txtMaasMax;
        private ComboBox cmbDeneyim;
        private CheckBox chkUzaktan;
        private CheckBox chkPartTime;
        private CheckBox chkFullTime;
        private Label label2;
        private Label label1;
        private Button btnAraSol;
        private TextBox txtAramaSol;
        private ComboBox cmbSektor;
        private ComboBox cmbYayinlanma;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtKonumFiltre;
        private Label label7;
        private Label label8;
        private FlowLayoutPanel flpIlanlar;
        private Label label9;
        private Label lblBaslikDetay;
        private PictureBox pictureBox2;
        private Label lblPrefQualList;
        private Label lblMinQualList;
        private Label lblSirketKonum;
        private Label lblSirketAd;
        private Button btnKaydet;
        private Button btnBasvur;
        private Button btnFiltrele;
        private Button btnTemizle;
        private Label lblCalismaSekli;
        private Label lblPrefQualTitle;
        private Label lblSektorDetay;
        private Label lblMaasDetay;
        private Label lblDeneyimDetay;
        private Label lblYayinlanmaTarihi;
    }
}