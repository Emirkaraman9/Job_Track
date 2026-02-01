using System.Windows.Forms;

namespace jobTrack.UserControls
{
    partial class UC_CvSihirbaziEkrani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            panel4 = new Panel();
            txtYetenekAdi = new TextBox();
            dgvSertifikalar = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            dgvYetenekler = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            cmbYetenekSeviyesi = new ComboBox();
            btnSertifikaSil = new Button();
            btnSertifikaGuncelle = new Button();
            btnSertifikaEkle = new Button();
            dtpSertifikaTarih = new DateTimePicker();
            lblSertifikaTarihi = new Label();
            txtSertifikaKurum = new TextBox();
            lblSertifikaKurum = new Label();
            txtSertifikaAdi = new TextBox();
            lblSertifikaAdi = new Label();
            label11 = new Label();
            btnYetenekSil = new Button();
            btnYetenekGuncelle = new Button();
            btnYetenekEkle = new Button();
            lblYetenekSeviyesi = new Label();
            lblYetenekAdi = new Label();
            txtIsTanimi = new RichTextBox();
            lblIsAyrilma = new Label();
            dgvIsDeneyimi = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            btnIsDeneyimiSil = new Button();
            btnIsDeneyimiGuncelle = new Button();
            btnIsDeneyimiEkle = new Button();
            chkIsDevamEdiyor = new CheckBox();
            lblIsBaslama = new Label();
            dtpIsBaslama = new DateTimePicker();
            dtpIsAyrilma = new DateTimePicker();
            txtPozisyon = new TextBox();
            txtSirketAdi = new TextBox();
            lblIsTanimi = new Label();
            lblPozisyon = new Label();
            lblSirketAdi = new Label();
            lblEgitimMezuniyet = new Label();
            dgvEgitim = new DataGridView();
            colOkul = new DataGridViewTextBoxColumn();
            colBolum = new DataGridViewTextBoxColumn();
            colDerece = new DataGridViewTextBoxColumn();
            colTarih = new DataGridViewTextBoxColumn();
            colDevamEdiyor = new DataGridViewTextBoxColumn();
            btnEgitimSil = new Button();
            btnEgitimGuncelle = new Button();
            btnEgitimEkle = new Button();
            chkDevamEdiyor = new CheckBox();
            lblEgitimBaslangic = new Label();
            dtpBaslangic = new DateTimePicker();
            dtpMezuniyet = new DateTimePicker();
            cmbDerece = new ComboBox();
            txtBolum = new TextBox();
            txtOkulAdi = new TextBox();
            lblDerece = new Label();
            lblBolum = new Label();
            lblOkulAdi = new Label();
            btnKaydet = new Button();
            button13 = new Button();
            tabControl1 = new TabControl();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSertifikalar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvYetenekler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvIsDeneyimi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEgitim).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(27, 27, 34);
            panel4.Controls.Add(txtYetenekAdi);
            panel4.Controls.Add(dgvSertifikalar);
            panel4.Controls.Add(dgvYetenekler);
            panel4.Controls.Add(cmbYetenekSeviyesi);
            panel4.Controls.Add(btnSertifikaSil);
            panel4.Controls.Add(btnSertifikaGuncelle);
            panel4.Controls.Add(btnSertifikaEkle);
            panel4.Controls.Add(dtpSertifikaTarih);
            panel4.Controls.Add(lblSertifikaTarihi);
            panel4.Controls.Add(txtSertifikaKurum);
            panel4.Controls.Add(lblSertifikaKurum);
            panel4.Controls.Add(txtSertifikaAdi);
            panel4.Controls.Add(lblSertifikaAdi);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(btnYetenekSil);
            panel4.Controls.Add(btnYetenekGuncelle);
            panel4.Controls.Add(btnYetenekEkle);
            panel4.Controls.Add(lblYetenekSeviyesi);
            panel4.Controls.Add(lblYetenekAdi);
            panel4.Controls.Add(txtIsTanimi);
            panel4.Controls.Add(lblIsAyrilma);
            panel4.Controls.Add(dgvIsDeneyimi);
            panel4.Controls.Add(btnIsDeneyimiSil);
            panel4.Controls.Add(btnIsDeneyimiGuncelle);
            panel4.Controls.Add(btnIsDeneyimiEkle);
            panel4.Controls.Add(chkIsDevamEdiyor);
            panel4.Controls.Add(lblIsBaslama);
            panel4.Controls.Add(dtpIsBaslama);
            panel4.Controls.Add(dtpIsAyrilma);
            panel4.Controls.Add(txtPozisyon);
            panel4.Controls.Add(txtSirketAdi);
            panel4.Controls.Add(lblIsTanimi);
            panel4.Controls.Add(lblPozisyon);
            panel4.Controls.Add(lblSirketAdi);
            panel4.Controls.Add(lblEgitimMezuniyet);
            panel4.Controls.Add(dgvEgitim);
            panel4.Controls.Add(btnEgitimSil);
            panel4.Controls.Add(btnEgitimGuncelle);
            panel4.Controls.Add(btnEgitimEkle);
            panel4.Controls.Add(chkDevamEdiyor);
            panel4.Controls.Add(lblEgitimBaslangic);
            panel4.Controls.Add(dtpBaslangic);
            panel4.Controls.Add(dtpMezuniyet);
            panel4.Controls.Add(cmbDerece);
            panel4.Controls.Add(txtBolum);
            panel4.Controls.Add(txtOkulAdi);
            panel4.Controls.Add(lblDerece);
            panel4.Controls.Add(lblBolum);
            panel4.Controls.Add(lblOkulAdi);
            panel4.Controls.Add(btnKaydet);
            panel4.Controls.Add(button13);
            panel4.Dock = DockStyle.Fill;
            panel4.ForeColor = Color.White;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1902, 1033);
            panel4.TabIndex = 1;
            // 
            // txtYetenekAdi
            // 
            txtYetenekAdi.BackColor = Color.White;
            txtYetenekAdi.BorderStyle = BorderStyle.FixedSingle;
            txtYetenekAdi.Location = new Point(213, 561);
            txtYetenekAdi.Name = "txtYetenekAdi";
            txtYetenekAdi.Size = new Size(170, 27);
            txtYetenekAdi.TabIndex = 86;
            // 
            // dgvSertifikalar
            // 
            dgvSertifikalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSertifikalar.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvSertifikalar.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSertifikalar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSertifikalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSertifikalar.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, Column1 });
            dgvSertifikalar.EnableHeadersVisualStyles = false;
            dgvSertifikalar.Location = new Point(777, 789);
            dgvSertifikalar.Name = "dgvSertifikalar";
            dgvSertifikalar.RowHeadersWidth = 51;
            dgvSertifikalar.RowTemplate.Height = 30;
            dgvSertifikalar.Size = new Size(689, 95);
            dgvSertifikalar.TabIndex = 85;
            dgvSertifikalar.CellClick += dgvSertifikalar_CellClick;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "SertifikaAdi";
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn7.HeaderText = "Sertifika Adı";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "AlindigiKurum";
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn8.HeaderText = "Alındığı Kurum";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // Column1
            // 
            Column1.DataPropertyName = "AlindigiTarih";
            dataGridViewCellStyle4.ForeColor = Color.Black;
            Column1.DefaultCellStyle = dataGridViewCellStyle4;
            Column1.HeaderText = "Alındığı Tarih";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // dgvYetenekler
            // 
            dgvYetenekler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvYetenekler.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvYetenekler.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.DarkGray;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvYetenekler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvYetenekler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvYetenekler.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn6 });
            dgvYetenekler.EnableHeadersVisualStyles = false;
            dgvYetenekler.Location = new Point(73, 789);
            dgvYetenekler.Name = "dgvYetenekler";
            dgvYetenekler.RowHeadersWidth = 51;
            dgvYetenekler.RowTemplate.Height = 30;
            dgvYetenekler.Size = new Size(468, 102);
            dgvYetenekler.TabIndex = 84;
            dgvYetenekler.CellClick += dgvYetenekler_CellClick;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "YetenekAdi";
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn3.HeaderText = "Yetenek Adı";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Seviye";
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn6.HeaderText = "Seviye";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // cmbYetenekSeviyesi
            // 
            cmbYetenekSeviyesi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYetenekSeviyesi.FormattingEnabled = true;
            cmbYetenekSeviyesi.Items.AddRange(new object[] { "Başlangıç", "Temel / Orta", "İleri", "Uzman" });
            cmbYetenekSeviyesi.Location = new Point(213, 608);
            cmbYetenekSeviyesi.Name = "cmbYetenekSeviyesi";
            cmbYetenekSeviyesi.Size = new Size(170, 28);
            cmbYetenekSeviyesi.TabIndex = 67;
            // 
            // btnSertifikaSil
            // 
            btnSertifikaSil.BackColor = Color.IndianRed;
            btnSertifikaSil.ForeColor = Color.Black;
            btnSertifikaSil.Location = new Point(1343, 694);
            btnSertifikaSil.Name = "btnSertifikaSil";
            btnSertifikaSil.Size = new Size(123, 36);
            btnSertifikaSil.TabIndex = 78;
            btnSertifikaSil.Text = "SİL";
            btnSertifikaSil.UseVisualStyleBackColor = false;
            btnSertifikaSil.Click += btnSertifikaSil_Click;
            // 
            // btnSertifikaGuncelle
            // 
            btnSertifikaGuncelle.BackColor = Color.DarkKhaki;
            btnSertifikaGuncelle.ForeColor = Color.Black;
            btnSertifikaGuncelle.Location = new Point(1029, 694);
            btnSertifikaGuncelle.Name = "btnSertifikaGuncelle";
            btnSertifikaGuncelle.Size = new Size(123, 36);
            btnSertifikaGuncelle.TabIndex = 77;
            btnSertifikaGuncelle.Text = "GÜNCELLE";
            btnSertifikaGuncelle.UseVisualStyleBackColor = false;
            btnSertifikaGuncelle.Click += btnSertifikaGuncelle_Click;
            // 
            // btnSertifikaEkle
            // 
            btnSertifikaEkle.BackColor = Color.FromArgb(192, 255, 192);
            btnSertifikaEkle.ForeColor = Color.Black;
            btnSertifikaEkle.Location = new Point(777, 694);
            btnSertifikaEkle.Name = "btnSertifikaEkle";
            btnSertifikaEkle.Size = new Size(123, 36);
            btnSertifikaEkle.TabIndex = 76;
            btnSertifikaEkle.Text = "EKLE";
            btnSertifikaEkle.UseVisualStyleBackColor = false;
            btnSertifikaEkle.Click += btnSertifikaEkle_Click;
            // 
            // dtpSertifikaTarih
            // 
            dtpSertifikaTarih.Format = DateTimePickerFormat.Short;
            dtpSertifikaTarih.Location = new Point(1363, 561);
            dtpSertifikaTarih.Name = "dtpSertifikaTarih";
            dtpSertifikaTarih.Size = new Size(150, 27);
            dtpSertifikaTarih.TabIndex = 75;
            dtpSertifikaTarih.Value = new DateTime(2026, 1, 8, 0, 0, 0, 0);
            // 
            // lblSertifikaTarihi
            // 
            lblSertifikaTarihi.AutoSize = true;
            lblSertifikaTarihi.Font = new Font("Segoe UI", 10F);
            lblSertifikaTarihi.Location = new Point(1232, 561);
            lblSertifikaTarihi.Name = "lblSertifikaTarihi";
            lblSertifikaTarihi.Size = new Size(108, 23);
            lblSertifikaTarihi.TabIndex = 82;
            lblSertifikaTarihi.Text = "Alındığı Tarih";
            // 
            // txtSertifikaKurum
            // 
            txtSertifikaKurum.BackColor = Color.White;
            txtSertifikaKurum.BorderStyle = BorderStyle.FixedSingle;
            txtSertifikaKurum.Location = new Point(929, 608);
            txtSertifikaKurum.Name = "txtSertifikaKurum";
            txtSertifikaKurum.Size = new Size(170, 27);
            txtSertifikaKurum.TabIndex = 74;
            // 
            // lblSertifikaKurum
            // 
            lblSertifikaKurum.AutoSize = true;
            lblSertifikaKurum.Font = new Font("Segoe UI", 10F);
            lblSertifikaKurum.Location = new Point(790, 613);
            lblSertifikaKurum.Name = "lblSertifikaKurum";
            lblSertifikaKurum.Size = new Size(123, 23);
            lblSertifikaKurum.TabIndex = 81;
            lblSertifikaKurum.Text = "Alındığı Kurum";
            // 
            // txtSertifikaAdi
            // 
            txtSertifikaAdi.BackColor = Color.White;
            txtSertifikaAdi.BorderStyle = BorderStyle.FixedSingle;
            txtSertifikaAdi.Location = new Point(929, 561);
            txtSertifikaAdi.Name = "txtSertifikaAdi";
            txtSertifikaAdi.Size = new Size(170, 27);
            txtSertifikaAdi.TabIndex = 73;
            // 
            // lblSertifikaAdi
            // 
            lblSertifikaAdi.AutoSize = true;
            lblSertifikaAdi.Font = new Font("Segoe UI", 10F);
            lblSertifikaAdi.Location = new Point(813, 561);
            lblSertifikaAdi.Name = "lblSertifikaAdi";
            lblSertifikaAdi.Size = new Size(100, 23);
            lblSertifikaAdi.TabIndex = 80;
            lblSertifikaAdi.Text = "Sertifika Adı";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label11.Location = new Point(26, 819);
            label11.Name = "label11";
            label11.Size = new Size(0, 15);
            label11.TabIndex = 79;
            // 
            // btnYetenekSil
            // 
            btnYetenekSil.BackColor = Color.IndianRed;
            btnYetenekSil.ForeColor = Color.Black;
            btnYetenekSil.Location = new Point(418, 694);
            btnYetenekSil.Name = "btnYetenekSil";
            btnYetenekSil.Size = new Size(123, 36);
            btnYetenekSil.TabIndex = 72;
            btnYetenekSil.Text = "SİL";
            btnYetenekSil.UseVisualStyleBackColor = false;
            btnYetenekSil.Click += btnYetenekSil_Click;
            // 
            // btnYetenekGuncelle
            // 
            btnYetenekGuncelle.BackColor = Color.DarkKhaki;
            btnYetenekGuncelle.ForeColor = Color.Black;
            btnYetenekGuncelle.Location = new Point(249, 694);
            btnYetenekGuncelle.Name = "btnYetenekGuncelle";
            btnYetenekGuncelle.Size = new Size(123, 36);
            btnYetenekGuncelle.TabIndex = 69;
            btnYetenekGuncelle.Text = "GÜNCELLE";
            btnYetenekGuncelle.UseVisualStyleBackColor = false;
            btnYetenekGuncelle.Click += btnYetenekGuncelle_Click;
            // 
            // btnYetenekEkle
            // 
            btnYetenekEkle.BackColor = Color.FromArgb(192, 255, 192);
            btnYetenekEkle.ForeColor = Color.Black;
            btnYetenekEkle.Location = new Point(73, 694);
            btnYetenekEkle.Name = "btnYetenekEkle";
            btnYetenekEkle.Size = new Size(123, 36);
            btnYetenekEkle.TabIndex = 68;
            btnYetenekEkle.Text = "EKLE";
            btnYetenekEkle.UseVisualStyleBackColor = false;
            btnYetenekEkle.Click += btnYetenekEkle_Click;
            // 
            // lblYetenekSeviyesi
            // 
            lblYetenekSeviyesi.AutoSize = true;
            lblYetenekSeviyesi.Font = new Font("Segoe UI", 10F);
            lblYetenekSeviyesi.Location = new Point(139, 613);
            lblYetenekSeviyesi.Name = "lblYetenekSeviyesi";
            lblYetenekSeviyesi.Size = new Size(57, 23);
            lblYetenekSeviyesi.TabIndex = 70;
            lblYetenekSeviyesi.Text = "Seviye";
            // 
            // lblYetenekAdi
            // 
            lblYetenekAdi.AutoSize = true;
            lblYetenekAdi.Font = new Font("Segoe UI", 10F);
            lblYetenekAdi.Location = new Point(97, 561);
            lblYetenekAdi.Name = "lblYetenekAdi";
            lblYetenekAdi.Size = new Size(99, 23);
            lblYetenekAdi.TabIndex = 71;
            lblYetenekAdi.Text = "Yetenek Adı";
            // 
            // txtIsTanimi
            // 
            txtIsTanimi.BorderStyle = BorderStyle.FixedSingle;
            txtIsTanimi.Location = new Point(1104, 125);
            txtIsTanimi.Name = "txtIsTanimi";
            txtIsTanimi.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtIsTanimi.Size = new Size(170, 52);
            txtIsTanimi.TabIndex = 33;
            txtIsTanimi.Text = "";
            // 
            // lblIsAyrilma
            // 
            lblIsAyrilma.AutoSize = true;
            lblIsAyrilma.Font = new Font("Segoe UI", 10F);
            lblIsAyrilma.Location = new Point(1446, 85);
            lblIsAyrilma.Name = "lblIsAyrilma";
            lblIsAyrilma.Size = new Size(67, 23);
            lblIsAyrilma.TabIndex = 45;
            lblIsAyrilma.Text = "Ayrılma";
            // 
            // dgvIsDeneyimi
            // 
            dgvIsDeneyimi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIsDeneyimi.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvIsDeneyimi.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.DarkGray;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvIsDeneyimi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvIsDeneyimi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIsDeneyimi.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvIsDeneyimi.EnableHeadersVisualStyles = false;
            dgvIsDeneyimi.Location = new Point(998, 310);
            dgvIsDeneyimi.Name = "dgvIsDeneyimi";
            dgvIsDeneyimi.RowHeadersWidth = 51;
            dgvIsDeneyimi.RowTemplate.Height = 30;
            dgvIsDeneyimi.Size = new Size(689, 134);
            dgvIsDeneyimi.TabIndex = 43;
            dgvIsDeneyimi.CellClick += dgvIsDeneyimi_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "SirketAdi";
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewTextBoxColumn1.HeaderText = "Şirket Adı";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Pozisyon";
            dataGridViewCellStyle10.ForeColor = Color.Black;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewTextBoxColumn2.HeaderText = "Pozisyon";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "TarihAraligi";
            dataGridViewCellStyle11.ForeColor = Color.Black;
            dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewTextBoxColumn4.HeaderText = "Başlama - Ayrılma";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "DevamEdiyor";
            dataGridViewCellStyle12.ForeColor = Color.Black;
            dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewTextBoxColumn5.HeaderText = "Devam";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // btnIsDeneyimiSil
            // 
            btnIsDeneyimiSil.BackColor = Color.IndianRed;
            btnIsDeneyimiSil.ForeColor = Color.Black;
            btnIsDeneyimiSil.Location = new Point(1564, 215);
            btnIsDeneyimiSil.Name = "btnIsDeneyimiSil";
            btnIsDeneyimiSil.Size = new Size(123, 36);
            btnIsDeneyimiSil.TabIndex = 42;
            btnIsDeneyimiSil.Text = "SİL";
            btnIsDeneyimiSil.UseVisualStyleBackColor = false;
            btnIsDeneyimiSil.Click += btnIsDeneyimiSil_Click;
            // 
            // btnIsDeneyimiGuncelle
            // 
            btnIsDeneyimiGuncelle.BackColor = Color.DarkKhaki;
            btnIsDeneyimiGuncelle.ForeColor = Color.Black;
            btnIsDeneyimiGuncelle.Location = new Point(1288, 215);
            btnIsDeneyimiGuncelle.Name = "btnIsDeneyimiGuncelle";
            btnIsDeneyimiGuncelle.Size = new Size(123, 36);
            btnIsDeneyimiGuncelle.TabIndex = 41;
            btnIsDeneyimiGuncelle.Text = "GÜNCELLE";
            btnIsDeneyimiGuncelle.UseVisualStyleBackColor = false;
            btnIsDeneyimiGuncelle.Click += btnIsDeneyimiGuncelle_Click;
            // 
            // btnIsDeneyimiEkle
            // 
            btnIsDeneyimiEkle.BackColor = Color.FromArgb(192, 255, 192);
            btnIsDeneyimiEkle.ForeColor = Color.Black;
            btnIsDeneyimiEkle.Location = new Point(989, 215);
            btnIsDeneyimiEkle.Name = "btnIsDeneyimiEkle";
            btnIsDeneyimiEkle.Size = new Size(123, 36);
            btnIsDeneyimiEkle.TabIndex = 40;
            btnIsDeneyimiEkle.Text = "EKLE";
            btnIsDeneyimiEkle.UseVisualStyleBackColor = false;
            btnIsDeneyimiEkle.Click += btnIsDeneyimiEkle_Click;
            // 
            // chkIsDevamEdiyor
            // 
            chkIsDevamEdiyor.AutoSize = true;
            chkIsDevamEdiyor.Font = new Font("Segoe UI", 10F);
            chkIsDevamEdiyor.Location = new Point(1525, 135);
            chkIsDevamEdiyor.Name = "chkIsDevamEdiyor";
            chkIsDevamEdiyor.Size = new Size(162, 27);
            chkIsDevamEdiyor.TabIndex = 39;
            chkIsDevamEdiyor.Text = "Devam Ediyorum";
            chkIsDevamEdiyor.UseVisualStyleBackColor = true;
            chkIsDevamEdiyor.Click += chkIsDevamEdiyor_CheckedChanged;
            // 
            // lblIsBaslama
            // 
            lblIsBaslama.AutoSize = true;
            lblIsBaslama.Font = new Font("Segoe UI", 10F);
            lblIsBaslama.Location = new Point(1440, 38);
            lblIsBaslama.Name = "lblIsBaslama";
            lblIsBaslama.Size = new Size(73, 23);
            lblIsBaslama.TabIndex = 44;
            lblIsBaslama.Text = "Başlama";
            // 
            // dtpIsBaslama
            // 
            dtpIsBaslama.Format = DateTimePickerFormat.Short;
            dtpIsBaslama.Location = new Point(1537, 34);
            dtpIsBaslama.Name = "dtpIsBaslama";
            dtpIsBaslama.Size = new Size(150, 27);
            dtpIsBaslama.TabIndex = 35;
            dtpIsBaslama.Value = new DateTime(2026, 1, 8, 0, 0, 0, 0);
            // 
            // dtpIsAyrilma
            // 
            dtpIsAyrilma.Format = DateTimePickerFormat.Short;
            dtpIsAyrilma.Location = new Point(1537, 81);
            dtpIsAyrilma.Name = "dtpIsAyrilma";
            dtpIsAyrilma.Size = new Size(150, 27);
            dtpIsAyrilma.TabIndex = 37;
            dtpIsAyrilma.Value = new DateTime(2026, 1, 8, 0, 0, 0, 0);
            // 
            // txtPozisyon
            // 
            txtPozisyon.BackColor = Color.White;
            txtPozisyon.BorderStyle = BorderStyle.FixedSingle;
            txtPozisyon.Location = new Point(1104, 77);
            txtPozisyon.Name = "txtPozisyon";
            txtPozisyon.Size = new Size(170, 27);
            txtPozisyon.TabIndex = 32;
            // 
            // txtSirketAdi
            // 
            txtSirketAdi.BackColor = Color.White;
            txtSirketAdi.BorderStyle = BorderStyle.FixedSingle;
            txtSirketAdi.Location = new Point(1104, 34);
            txtSirketAdi.Name = "txtSirketAdi";
            txtSirketAdi.Size = new Size(170, 27);
            txtSirketAdi.TabIndex = 31;
            // 
            // lblIsTanimi
            // 
            lblIsTanimi.AutoSize = true;
            lblIsTanimi.Font = new Font("Segoe UI", 10F);
            lblIsTanimi.Location = new Point(1004, 139);
            lblIsTanimi.Name = "lblIsTanimi";
            lblIsTanimi.Size = new Size(76, 23);
            lblIsTanimi.TabIndex = 34;
            lblIsTanimi.Text = "İş Tanımı";
            // 
            // lblPozisyon
            // 
            lblPozisyon.AutoSize = true;
            lblPozisyon.Font = new Font("Segoe UI", 10F);
            lblPozisyon.Location = new Point(1004, 81);
            lblPozisyon.Name = "lblPozisyon";
            lblPozisyon.Size = new Size(76, 23);
            lblPozisyon.TabIndex = 36;
            lblPozisyon.Text = "Pozisyon";
            // 
            // lblSirketAdi
            // 
            lblSirketAdi.AutoSize = true;
            lblSirketAdi.Font = new Font("Segoe UI", 10F);
            lblSirketAdi.Location = new Point(998, 34);
            lblSirketAdi.Name = "lblSirketAdi";
            lblSirketAdi.Size = new Size(82, 23);
            lblSirketAdi.TabIndex = 38;
            lblSirketAdi.Text = "Şirket Adı";
            // 
            // lblEgitimMezuniyet
            // 
            lblEgitimMezuniyet.AutoSize = true;
            lblEgitimMezuniyet.Font = new Font("Segoe UI", 10F);
            lblEgitimMezuniyet.Location = new Point(510, 74);
            lblEgitimMezuniyet.Name = "lblEgitimMezuniyet";
            lblEgitimMezuniyet.Size = new Size(89, 23);
            lblEgitimMezuniyet.TabIndex = 30;
            lblEgitimMezuniyet.Text = "Mezuniyet";
            // 
            // dgvEgitim
            // 
            dgvEgitim.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEgitim.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvEgitim.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = Color.DarkGray;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle13.ForeColor = Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            dgvEgitim.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dgvEgitim.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEgitim.Columns.AddRange(new DataGridViewColumn[] { colOkul, colBolum, colDerece, colTarih, colDevamEdiyor });
            dgvEgitim.EnableHeadersVisualStyles = false;
            dgvEgitim.Location = new Point(97, 310);
            dgvEgitim.Name = "dgvEgitim";
            dgvEgitim.RowHeadersWidth = 51;
            dgvEgitim.RowTemplate.Height = 30;
            dgvEgitim.Size = new Size(674, 134);
            dgvEgitim.TabIndex = 28;
            dgvEgitim.CellClick += dgvEgitim_CellClick;
            // 
            // colOkul
            // 
            colOkul.DataPropertyName = "OkulAdi";
            dataGridViewCellStyle14.ForeColor = Color.Black;
            colOkul.DefaultCellStyle = dataGridViewCellStyle14;
            colOkul.HeaderText = "Okul Adı";
            colOkul.MinimumWidth = 6;
            colOkul.Name = "colOkul";
            // 
            // colBolum
            // 
            colBolum.DataPropertyName = "Bolum";
            dataGridViewCellStyle15.ForeColor = Color.Black;
            colBolum.DefaultCellStyle = dataGridViewCellStyle15;
            colBolum.HeaderText = "Bölüm";
            colBolum.MinimumWidth = 6;
            colBolum.Name = "colBolum";
            // 
            // colDerece
            // 
            colDerece.DataPropertyName = "Derece";
            dataGridViewCellStyle16.ForeColor = Color.Black;
            colDerece.DefaultCellStyle = dataGridViewCellStyle16;
            colDerece.HeaderText = "Derece";
            colDerece.MinimumWidth = 6;
            colDerece.Name = "colDerece";
            // 
            // colTarih
            // 
            colTarih.DataPropertyName = "TarihAraligi";
            dataGridViewCellStyle17.ForeColor = Color.Black;
            colTarih.DefaultCellStyle = dataGridViewCellStyle17;
            colTarih.HeaderText = "Başlangıç - Mezuniyet";
            colTarih.MinimumWidth = 6;
            colTarih.Name = "colTarih";
            // 
            // colDevamEdiyor
            // 
            colDevamEdiyor.DataPropertyName = "DevamEdiyor";
            dataGridViewCellStyle18.ForeColor = Color.Black;
            colDevamEdiyor.DefaultCellStyle = dataGridViewCellStyle18;
            colDevamEdiyor.HeaderText = "Devam";
            colDevamEdiyor.MinimumWidth = 6;
            colDevamEdiyor.Name = "colDevamEdiyor";
            // 
            // btnEgitimSil
            // 
            btnEgitimSil.BackColor = Color.IndianRed;
            btnEgitimSil.ForeColor = Color.Black;
            btnEgitimSil.Location = new Point(648, 215);
            btnEgitimSil.Name = "btnEgitimSil";
            btnEgitimSil.Size = new Size(123, 36);
            btnEgitimSil.TabIndex = 27;
            btnEgitimSil.Text = "SİL";
            btnEgitimSil.UseVisualStyleBackColor = false;
            btnEgitimSil.Click += btnEgitimSil_Click;
            // 
            // btnEgitimGuncelle
            // 
            btnEgitimGuncelle.BackColor = Color.DarkKhaki;
            btnEgitimGuncelle.ForeColor = Color.Black;
            btnEgitimGuncelle.Location = new Point(388, 215);
            btnEgitimGuncelle.Name = "btnEgitimGuncelle";
            btnEgitimGuncelle.Size = new Size(123, 36);
            btnEgitimGuncelle.TabIndex = 26;
            btnEgitimGuncelle.Text = "GÜNCELLE";
            btnEgitimGuncelle.UseVisualStyleBackColor = false;
            btnEgitimGuncelle.Click += btnEgitimGuncelle_Click;
            // 
            // btnEgitimEkle
            // 
            btnEgitimEkle.BackColor = Color.FromArgb(192, 255, 192);
            btnEgitimEkle.ForeColor = Color.Black;
            btnEgitimEkle.Location = new Point(97, 215);
            btnEgitimEkle.Name = "btnEgitimEkle";
            btnEgitimEkle.Size = new Size(123, 36);
            btnEgitimEkle.TabIndex = 25;
            btnEgitimEkle.Text = "EKLE";
            btnEgitimEkle.UseVisualStyleBackColor = false;
            btnEgitimEkle.Click += btnEgitimEkle_Click;
            // 
            // chkDevamEdiyor
            // 
            chkDevamEdiyor.AutoSize = true;
            chkDevamEdiyor.Font = new Font("Segoe UI", 10F);
            chkDevamEdiyor.Location = new Point(609, 124);
            chkDevamEdiyor.Name = "chkDevamEdiyor";
            chkDevamEdiyor.Size = new Size(162, 27);
            chkDevamEdiyor.TabIndex = 24;
            chkDevamEdiyor.Text = "Devam Ediyorum";
            chkDevamEdiyor.UseVisualStyleBackColor = true;
            chkDevamEdiyor.Click += chkDevamEdiyor_CheckedChanged;
            // 
            // lblEgitimBaslangic
            // 
            lblEgitimBaslangic.AutoSize = true;
            lblEgitimBaslangic.Font = new Font("Segoe UI", 10F);
            lblEgitimBaslangic.Location = new Point(518, 34);
            lblEgitimBaslangic.Name = "lblEgitimBaslangic";
            lblEgitimBaslangic.Size = new Size(81, 23);
            lblEgitimBaslangic.TabIndex = 29;
            lblEgitimBaslangic.Text = "Başlangıç";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Format = DateTimePickerFormat.Short;
            dtpBaslangic.Location = new Point(621, 30);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(150, 27);
            dtpBaslangic.TabIndex = 20;
            dtpBaslangic.Value = new DateTime(2026, 1, 8, 0, 0, 0, 0);
            // 
            // dtpMezuniyet
            // 
            dtpMezuniyet.Format = DateTimePickerFormat.Short;
            dtpMezuniyet.Location = new Point(621, 74);
            dtpMezuniyet.Name = "dtpMezuniyet";
            dtpMezuniyet.Size = new Size(150, 27);
            dtpMezuniyet.TabIndex = 22;
            dtpMezuniyet.Value = new DateTime(2026, 1, 8, 0, 0, 0, 0);
            // 
            // cmbDerece
            // 
            cmbDerece.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDerece.FormattingEnabled = true;
            cmbDerece.Items.AddRange(new object[] { "Lise", "Önlisans", "Lisans", "Yüksek Lisans", "Doktora" });
            cmbDerece.Location = new Point(202, 124);
            cmbDerece.Name = "cmbDerece";
            cmbDerece.Size = new Size(170, 28);
            cmbDerece.TabIndex = 18;
            // 
            // txtBolum
            // 
            txtBolum.BackColor = Color.White;
            txtBolum.BorderStyle = BorderStyle.FixedSingle;
            txtBolum.Location = new Point(202, 74);
            txtBolum.Name = "txtBolum";
            txtBolum.Size = new Size(170, 27);
            txtBolum.TabIndex = 17;
            // 
            // txtOkulAdi
            // 
            txtOkulAdi.BackColor = Color.White;
            txtOkulAdi.BorderStyle = BorderStyle.FixedSingle;
            txtOkulAdi.Location = new Point(202, 30);
            txtOkulAdi.Name = "txtOkulAdi";
            txtOkulAdi.Size = new Size(170, 27);
            txtOkulAdi.TabIndex = 16;
            // 
            // lblDerece
            // 
            lblDerece.AutoSize = true;
            lblDerece.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDerece.Location = new Point(109, 129);
            lblDerece.Name = "lblDerece";
            lblDerece.Size = new Size(63, 23);
            lblDerece.TabIndex = 19;
            lblDerece.Text = "Derece";
            // 
            // lblBolum
            // 
            lblBolum.AutoSize = true;
            lblBolum.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBolum.Location = new Point(113, 74);
            lblBolum.Name = "lblBolum";
            lblBolum.Size = new Size(59, 23);
            lblBolum.TabIndex = 21;
            lblBolum.Text = "Bölüm";
            // 
            // lblOkulAdi
            // 
            lblOkulAdi.AutoSize = true;
            lblOkulAdi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulAdi.Location = new Point(97, 30);
            lblOkulAdi.Name = "lblOkulAdi";
            lblOkulAdi.Size = new Size(75, 23);
            lblOkulAdi.TabIndex = 23;
            lblOkulAdi.Text = "Okul Adı";
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKaydet.BackColor = Color.FromArgb(87, 177, 68);
            btnKaydet.Location = new Point(1714, 755);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(123, 36);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "KAYDET";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // button13
            // 
            button13.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button13.BackColor = Color.FromArgb(167, 37, 37);
            button13.Location = new Point(1537, 755);
            button13.Name = "button13";
            button13.Size = new Size(123, 36);
            button13.TabIndex = 0;
            button13.Text = "İPTAL";
            button13.UseVisualStyleBackColor = false;
            button13.Click += btnIptal_Click;
            // 
            // tabControl1
            // 
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new Size(100, 40);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1902, 1033);
            tabControl1.TabIndex = 0;
            // 
            // UC_CvSihirbaziEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(panel4);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ForeColor = Color.White;
            Name = "UC_CvSihirbaziEkrani";
            Size = new Size(1902, 1033);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSertifikalar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvYetenekler).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvIsDeneyimi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEgitim).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel4;
        private Button btnKaydet;
        private Button button13;
        private TabControl tabControl1;
        private RichTextBox txtIsTanimi;
        private Label lblIsAyrilma;
        private DataGridView dgvIsDeneyimi;
        private Button btnIsDeneyimiSil;
        private Button btnIsDeneyimiGuncelle;
        private Button btnIsDeneyimiEkle;
        private CheckBox chkIsDevamEdiyor;
        private Label lblIsBaslama;
        private DateTimePicker dtpIsBaslama;
        private DateTimePicker dtpIsAyrilma;
        private TextBox txtPozisyon;
        private TextBox txtSirketAdi;
        private Label lblIsTanimi;
        private Label lblPozisyon;
        private Label lblSirketAdi;
        private Label lblEgitimMezuniyet;
        private DataGridView dgvEgitim;
        private Button btnEgitimSil;
        private Button btnEgitimGuncelle;
        private Button btnEgitimEkle;
        private CheckBox chkDevamEdiyor;
        private Label lblEgitimBaslangic;
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpMezuniyet;
        private ComboBox cmbDerece;
        private TextBox txtBolum;
        private TextBox txtOkulAdi;
        private Label lblDerece;
        private Label lblBolum;
        private Label lblOkulAdi;
        private DataGridView dgvSertifikalar;
        private DataGridView dgvYetenekler;
        private ComboBox cmbYetenekSeviyesi;
        private Button btnSertifikaSil;
        private Button btnSertifikaGuncelle;
        private Button btnSertifikaEkle;
        private DateTimePicker dtpSertifikaTarih;
        private Label lblSertifikaTarihi;
        private TextBox txtSertifikaKurum;
        private Label lblSertifikaKurum;
        private TextBox txtSertifikaAdi;
        private Label lblSertifikaAdi;
        private Label label11;
        private Button btnYetenekSil;
        private Button btnYetenekGuncelle;
        private Button btnYetenekEkle;
        private Label lblYetenekSeviyesi;
        private Label lblYetenekAdi;
        private TextBox txtYetenekAdi;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn colOkul;
        private DataGridViewTextBoxColumn colBolum;
        private DataGridViewTextBoxColumn colDerece;
        private DataGridViewTextBoxColumn colTarih;
        private DataGridViewTextBoxColumn colDevamEdiyor;
    }
}
