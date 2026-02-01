using System.Windows.Forms;

namespace jobTrack.UserControls
{
    partial class UC_bireyselKayitEkrani
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
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            txtTelefon = new TextBox();
            txtOkul = new TextBox();
            txtSifre = new TextBox();
            txtSifreTekrar = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            btnKayitOl = new Button();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            checkBox1 = new CheckBox();
            label16 = new Label();
            label17 = new Label();
            button2 = new Button();
            comboBox1 = new ComboBox();
            geri = new Button();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtKullaniciAdi = new TextBox();
            dtpDogumTarihi = new DateTimePicker();
            SuspendLayout();
            // 
            // button6
            // 
            button6.Location = new Point(913, 41);
            button6.Name = "button6";
            button6.Size = new Size(159, 65);
            button6.TabIndex = 15;
            button6.Text = "Hesap";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(721, 41);
            button5.Name = "button5";
            button5.Size = new Size(159, 65);
            button5.TabIndex = 14;
            button5.Text = "Hakkımızda";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(522, 41);
            button4.Name = "button4";
            button4.Size = new Size(159, 65);
            button4.TabIndex = 13;
            button4.Text = "Menü";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(65, 46);
            label3.Name = "label3";
            label3.Size = new Size(128, 41);
            label3.TabIndex = 12;
            label3.Text = "jobTrack";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(380, 138);
            label1.Name = "label1";
            label1.Size = new Size(191, 41);
            label1.TabIndex = 16;
            label1.Text = "Bireysel Kayıt";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 179);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 18;
            label2.Text = "Ad:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtEmail.Location = new Point(458, 281);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(221, 47);
            txtEmail.TabIndex = 21;
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtTelefon.Location = new Point(458, 363);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(221, 47);
            txtTelefon.TabIndex = 23;
            // 
            // txtOkul
            // 
            txtOkul.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtOkul.Location = new Point(120, 446);
            txtOkul.Name = "txtOkul";
            txtOkul.Size = new Size(221, 47);
            txtOkul.TabIndex = 24;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSifre.Location = new Point(120, 532);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(221, 47);
            txtSifre.TabIndex = 26;
            // 
            // txtSifreTekrar
            // 
            txtSifreTekrar.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSifreTekrar.Location = new Point(458, 532);
            txtSifreTekrar.Name = "txtSifreTekrar";
            txtSifreTekrar.Size = new Size(221, 47);
            txtSifreTekrar.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(458, 179);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 28;
            label4.Text = "Soyad:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(120, 258);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 29;
            label5.Text = "Kullanıcı adı:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(458, 258);
            label6.Name = "label6";
            label6.Size = new Size(63, 20);
            label6.TabIndex = 30;
            label6.Text = "E-posta:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(120, 340);
            label7.Name = "label7";
            label7.Size = new Size(101, 20);
            label7.TabIndex = 31;
            label7.Text = "Doğum Tarihi:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(458, 340);
            label8.Name = "label8";
            label8.Size = new Size(128, 20);
            label8.TabIndex = 32;
            label8.Text = "Telefon Numarası:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(120, 423);
            label9.Name = "label9";
            label9.Size = new Size(195, 20);
            label9.TabIndex = 33;
            label9.Text = "Mevcut/Mezun Olunan Okul:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(458, 423);
            label10.Name = "label10";
            label10.Size = new Size(105, 20);
            label10.TabIndex = 34;
            label10.Text = "Bölüm/Derece";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(120, 509);
            label11.Name = "label11";
            label11.Size = new Size(42, 20);
            label11.TabIndex = 36;
            label11.Text = "Şifre:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(458, 509);
            label12.Name = "label12";
            label12.Size = new Size(90, 20);
            label12.TabIndex = 37;
            label12.Text = "Şifre(tekrar):";
            // 
            // btnKayitOl
            // 
            btnKayitOl.Location = new Point(495, 608);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.Size = new Size(159, 65);
            btnKayitOl.TabIndex = 38;
            btnKayitOl.Text = "Kayıt Ol";
            btnKayitOl.UseVisualStyleBackColor = true;
            btnKayitOl.Click += Kayıtol_Button_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(139, 598);
            label13.Name = "label13";
            label13.Size = new Size(101, 20);
            label13.TabIndex = 39;
            label13.Text = "Tüm metinleri";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(139, 618);
            label14.Name = "label14";
            label14.Size = new Size(135, 20);
            label14.TabIndex = 40;
            label14.Text = "inceledim, okudum";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(139, 638);
            label15.Name = "label15";
            label15.Size = new Size(91, 20);
            label15.TabIndex = 41;
            label15.Text = "onaylıyorum";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            checkBox1.Location = new Point(280, 621);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 42;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label16.Location = new Point(721, 332);
            label16.Name = "label16";
            label16.Size = new Size(379, 31);
            label16.TabIndex = 43;
            label16.Text = "\"Şirket ve adayı ortak bir gerçeklikte";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label17.Location = new Point(721, 363);
            label17.Name = "label17";
            label17.Size = new Size(227, 31);
            label17.TabIndex = 44;
            label17.Text = "buluşturan platform\"";
            // 
            // button2
            // 
            button2.Location = new Point(761, 444);
            button2.Name = "button2";
            button2.Size = new Size(311, 65);
            button2.TabIndex = 45;
            button2.Text = "Mevcut Hesabına GİRİŞ YAP";
            button2.UseVisualStyleBackColor = true;
            button2.Click += kullanıcıgir_button_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Lisans", "Yüksek Lisans", "Doktora" });
            comboBox1.Location = new Point(460, 446);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 49);
            comboBox1.TabIndex = 46;
            // 
            // geri
            // 
            geri.Location = new Point(929, 614);
            geri.Name = "geri";
            geri.Size = new Size(122, 52);
            geri.TabIndex = 81;
            geri.Text = "Geri Dön";
            geri.UseVisualStyleBackColor = true;
            geri.Click += geri_Click;
            // 
            // txtAd
            // 
            txtAd.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtAd.Location = new Point(120, 208);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(221, 47);
            txtAd.TabIndex = 82;
            // 
            // txtSoyad
            // 
            txtSoyad.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSoyad.Location = new Point(458, 208);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(221, 47);
            txtSoyad.TabIndex = 83;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtKullaniciAdi.Location = new Point(120, 281);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(221, 47);
            txtKullaniciAdi.TabIndex = 84;
            // 
            // dtpDogumTarihi
            // 
            dtpDogumTarihi.Location = new Point(120, 378);
            dtpDogumTarihi.Name = "dtpDogumTarihi";
            dtpDogumTarihi.Size = new Size(221, 27);
            dtpDogumTarihi.TabIndex = 85;
            // 
            // UC_bireyselKayitEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dtpDogumTarihi);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            Controls.Add(geri);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(checkBox1);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(btnKayitOl);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtSifreTekrar);
            Controls.Add(txtSifre);
            Controls.Add(txtOkul);
            Controls.Add(txtTelefon);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label3);
            Name = "UC_bireyselKayitEkrani";
            Size = new Size(1902, 1033);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button6;
        private Button button5;
        private Button button4;
        private Label label3;
        private Label label1;

        public TextBox Ad { get; private set; }

        private TextBox textBox1;
        private Label label2;

        public TextBox K { get; private set; }

        private TextBox textBox3;
        private TextBox txtEmail;
        private TextBox txtTelefon;
        private TextBox txtOkul;
        private TextBox txtSifre;
        private TextBox txtSifreTekrar;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;

        public TextBox Soyad { get; private set; }

        private TextBox textBox2;
        private Label label11;
        private Label label12;
        private Button btnKayitOl;
        private Label label13;
        private Label label14;
        private Label label15;
        private CheckBox checkBox1;
        private Label label16;
        private Label label17;
        private Button button2;
        private ComboBox comboBox1;
        private Button geri;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtKullaniciAdi;
        private DateTimePicker dtpDogumTarihi;
    }
}
