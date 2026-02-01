using System.Windows.Forms;

namespace jobTrack.UserControls
{
    partial class UC_kurumsalKayitEkrani
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
            comboBox1 = new ComboBox();
            button2 = new Button();
            label17 = new Label();
            label16 = new Label();
            checkBox1 = new CheckBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            Kayitol_Button = new Button();
            label12 = new Label();
            label11 = new Label();
            txtYetkiliAd = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtSifreTekrar = new TextBox();
            txtSifre = new TextBox();
            txtSektor = new TextBox();
            txtTelefon = new TextBox();
            txtEmail = new TextBox();
            txtYetkiliSoyad = new TextBox();
            label2 = new Label();
            txtSirketAdi = new TextBox();
            label1 = new Label();
            button6 = new Button();
            hakkımızda_button = new Button();
            button4 = new Button();
            label3 = new Label();
            geri = new Button();
            dtpKurulus = new DateTimePicker();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "0 - 50", "51 - 100", "101 - 200", "201 - 300", "301- 400", "401 - 500", "501 - 600", "601 - 700", "701 - 800", "801 - 900", "901 - 1000", "1001 - 2000", "2001 - 3000", "3001 - 4000", "4001 - 5000", "5001 - 6000", "6001 - 7000", "7001 - 8000", "8001 - 9000", "9001 - 10000", "10000+" });
            comboBox1.Location = new Point(424, 450);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 36);
            comboBox1.TabIndex = 79;
            // 
            // button2
            // 
            button2.Location = new Point(727, 438);
            button2.Name = "button2";
            button2.Size = new Size(311, 65);
            button2.TabIndex = 78;
            button2.Text = "Mevcut Hesabına GİRİŞ YAP";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label17.Location = new Point(687, 357);
            label17.Name = "label17";
            label17.Size = new Size(227, 31);
            label17.TabIndex = 77;
            label17.Text = "buluşturan platform\"";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label16.Location = new Point(687, 326);
            label16.Name = "label16";
            label16.Size = new Size(379, 31);
            label16.TabIndex = 76;
            label16.Text = "\"Şirket ve adayı ortak bir gerçeklikte";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            checkBox1.Location = new Point(246, 615);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 75;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(105, 632);
            label15.Name = "label15";
            label15.Size = new Size(91, 20);
            label15.TabIndex = 74;
            label15.Text = "onaylıyorum";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(105, 612);
            label14.Name = "label14";
            label14.Size = new Size(135, 20);
            label14.TabIndex = 73;
            label14.Text = "inceledim, okudum";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(105, 592);
            label13.Name = "label13";
            label13.Size = new Size(101, 20);
            label13.TabIndex = 72;
            label13.Text = "Tüm metinleri";
            // 
            // Kayitol_Button
            // 
            Kayitol_Button.Location = new Point(461, 602);
            Kayitol_Button.Name = "Kayitol_Button";
            Kayitol_Button.Size = new Size(159, 65);
            Kayitol_Button.TabIndex = 71;
            Kayitol_Button.Text = "Kayıt Ol";
            Kayitol_Button.UseVisualStyleBackColor = true;
            Kayitol_Button.Click += Kayitol_Button_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(424, 503);
            label12.Name = "label12";
            label12.Size = new Size(90, 20);
            label12.TabIndex = 70;
            label12.Text = "Şifre(tekrar):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(86, 503);
            label11.Name = "label11";
            label11.Size = new Size(42, 20);
            label11.TabIndex = 69;
            label11.Text = "Şifre:";
            // 
            // txtYetkiliAd
            // 
            txtYetkiliAd.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtYetkiliAd.Location = new Point(424, 196);
            txtYetkiliAd.Name = "txtYetkiliAd";
            txtYetkiliAd.Size = new Size(221, 47);
            txtYetkiliAd.TabIndex = 68;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(424, 417);
            label10.Name = "label10";
            label10.Size = new Size(97, 20);
            label10.TabIndex = 67;
            label10.Text = "Çalışan Sayısı";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(86, 417);
            label9.Name = "label9";
            label9.Size = new Size(51, 20);
            label9.TabIndex = 66;
            label9.Text = "Sektör";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(424, 334);
            label8.Name = "label8";
            label8.Size = new Size(128, 20);
            label8.TabIndex = 65;
            label8.Text = "Telefon Numarası:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(86, 334);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 64;
            label7.Text = "Kuruluş Tarihi:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(424, 252);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 63;
            label6.Text = "E-posta:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(86, 252);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 62;
            label5.Text = "Yetkili Soyadı";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(424, 173);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 61;
            label4.Text = "Yetkili İsim:";
            // 
            // txtSifreTekrar
            // 
            txtSifreTekrar.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSifreTekrar.Location = new Point(424, 526);
            txtSifreTekrar.Name = "txtSifreTekrar";
            txtSifreTekrar.Size = new Size(221, 47);
            txtSifreTekrar.TabIndex = 60;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSifre.Location = new Point(86, 526);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(221, 47);
            txtSifre.TabIndex = 59;
            // 
            // txtSektor
            // 
            txtSektor.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSektor.Location = new Point(86, 440);
            txtSektor.Name = "txtSektor";
            txtSektor.Size = new Size(221, 47);
            txtSektor.TabIndex = 58;
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtTelefon.Location = new Point(424, 357);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(221, 47);
            txtTelefon.TabIndex = 57;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtEmail.Location = new Point(424, 275);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(221, 47);
            txtEmail.TabIndex = 55;
            // 
            // txtYetkiliSoyad
            // 
            txtYetkiliSoyad.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtYetkiliSoyad.Location = new Point(86, 275);
            txtYetkiliSoyad.Name = "txtYetkiliSoyad";
            txtYetkiliSoyad.Size = new Size(221, 47);
            txtYetkiliSoyad.TabIndex = 54;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(86, 173);
            label2.Name = "label2";
            label2.Size = new Size(153, 20);
            label2.TabIndex = 53;
            label2.Text = "Kurumsal Şirketin Adı:";
            // 
            // txtSirketAdi
            // 
            txtSirketAdi.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSirketAdi.Location = new Point(86, 196);
            txtSirketAdi.Name = "txtSirketAdi";
            txtSirketAdi.Size = new Size(221, 47);
            txtSirketAdi.TabIndex = 52;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(338, 121);
            label1.Name = "label1";
            label1.Size = new Size(212, 41);
            label1.TabIndex = 51;
            label1.Text = "Kurumsal Kayıt";
            // 
            // button6
            // 
            button6.Location = new Point(879, 35);
            button6.Name = "button6";
            button6.Size = new Size(159, 65);
            button6.TabIndex = 50;
            button6.Text = "Hesap";
            button6.UseVisualStyleBackColor = true;
            // 
            // hakkımızda_button
            // 
            hakkımızda_button.Location = new Point(687, 35);
            hakkımızda_button.Name = "hakkımızda_button";
            hakkımızda_button.Size = new Size(159, 65);
            hakkımızda_button.TabIndex = 49;
            hakkımızda_button.Text = "Hakkımızda";
            hakkımızda_button.UseVisualStyleBackColor = true;
            hakkımızda_button.Click += hakkımızda_button_Click;
            // 
            // button4
            // 
            button4.Location = new Point(488, 35);
            button4.Name = "button4";
            button4.Size = new Size(159, 65);
            button4.TabIndex = 48;
            button4.Text = "Menü";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(57, 40);
            label3.Name = "label3";
            label3.Size = new Size(128, 41);
            label3.TabIndex = 47;
            label3.Text = "jobTrack";
            // 
            // geri
            // 
            geri.Location = new Point(833, 612);
            geri.Name = "geri";
            geri.Size = new Size(122, 52);
            geri.TabIndex = 80;
            geri.Text = "Geri Dön";
            geri.UseVisualStyleBackColor = true;
            geri.Click += geri_Click;
            // 
            // dtpKurulus
            // 
            dtpKurulus.Location = new Point(86, 372);
            dtpKurulus.Name = "dtpKurulus";
            dtpKurulus.Size = new Size(221, 27);
            dtpKurulus.TabIndex = 81;
            // 
            // UC_kurumsalKayitEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dtpKurulus);
            Controls.Add(geri);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(checkBox1);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(Kayitol_Button);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtYetkiliAd);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtSifreTekrar);
            Controls.Add(txtSifre);
            Controls.Add(txtSektor);
            Controls.Add(txtTelefon);
            Controls.Add(txtEmail);
            Controls.Add(txtYetkiliSoyad);
            Controls.Add(label2);
            Controls.Add(txtSirketAdi);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(hakkımızda_button);
            Controls.Add(button4);
            Controls.Add(label3);
            Name = "UC_kurumsalKayitEkrani";
            Size = new Size(1920, 1080);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button button2;
        private Label label17;
        private Label label16;
        private CheckBox checkBox1;
        private Label label15;
        private Label label14;
        private Label label13;
        private Button Kayitol_Button;
        private Label label12;
        private Label label11;
        private TextBox txtYetkiliAd;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtSifreTekrar;
        private TextBox txtSifre;
        private TextBox txtSektor;
        private TextBox txtTelefon;
        private TextBox txtEmail;
        private TextBox txtYetkiliSoyad;
        private Label label2;
        private TextBox txtSirketAdi;
        private Label label1;
        private Button button6;
        private Button hakkımızda_button;
        private Button button4;
        private Label label3;
        private Button geri;
        private DateTimePicker dtpKurulus;
    }
}
