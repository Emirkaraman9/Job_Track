using System.Windows.Forms;

namespace jobTrack.UserControls
{
    partial class UC_kullaniciGirisEkrani
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
            label17 = new Label();
            label16 = new Label();
            label1 = new Label();
            txtKullaniciVeyaEmail = new TextBox();
            txtSifre = new TextBox();
            label2 = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            button1 = new Button();
            label6 = new Label();
            geri = new Button();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // button6
            // 
            button6.Location = new Point(893, 44);
            button6.Name = "button6";
            button6.Size = new Size(159, 65);
            button6.TabIndex = 54;
            button6.Text = "@job_track";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(701, 44);
            button5.Name = "button5";
            button5.Size = new Size(159, 65);
            button5.TabIndex = 53;
            button5.Text = "Hakkımızda";
            button5.UseVisualStyleBackColor = true;
            button5.Click += hakkımızda_button_Click;
            // 
            // button4
            // 
            button4.Location = new Point(502, 44);
            button4.Name = "button4";
            button4.Size = new Size(159, 65);
            button4.TabIndex = 52;
            button4.Text = "Menü";
            button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(55, 49);
            label3.Name = "label3";
            label3.Size = new Size(128, 41);
            label3.TabIndex = 51;
            label3.Text = "jobTrack";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 22.2F);
            label17.Location = new Point(231, 196);
            label17.Name = "label17";
            label17.Size = new Size(365, 50);
            label17.TabIndex = 79;
            label17.Text = "buluşturan platform\"";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 22.2F);
            label16.Location = new Point(231, 146);
            label16.Name = "label16";
            label16.Size = new Size(608, 50);
            label16.TabIndex = 78;
            label16.Text = "\"Şirket ve adayı ortak bir gerçeklikte";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(314, 271);
            label1.Name = "label1";
            label1.Size = new Size(274, 31);
            label1.TabIndex = 80;
            label1.Text = "Kullanıcı adı veya E-posta";
            // 
            // txtKullaniciVeyaEmail
            // 
            txtKullaniciVeyaEmail.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtKullaniciVeyaEmail.Location = new Point(314, 305);
            txtKullaniciVeyaEmail.Name = "txtKullaniciVeyaEmail";
            txtKullaniciVeyaEmail.Size = new Size(411, 47);
            txtKullaniciVeyaEmail.TabIndex = 81;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSifre.Location = new Point(314, 411);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(411, 47);
            txtSifre.TabIndex = 83;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(314, 377);
            label2.Name = "label2";
            label2.Size = new Size(59, 31);
            label2.TabIndex = 82;
            label2.Text = "Şifre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(314, 461);
            label4.Name = "label4";
            label4.Size = new Size(101, 25);
            label4.TabIndex = 84;
            label4.Text = "Beni Hatırla";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(421, 468);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(18, 17);
            checkBox1.TabIndex = 85;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(421, 527);
            button1.Name = "button1";
            button1.Size = new Size(203, 55);
            button1.TabIndex = 87;
            button1.Text = "Giriş Yap";
            button1.UseVisualStyleBackColor = true;
            button1.Click += girisyap_button_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.Location = new Point(376, 585);
            label6.Name = "label6";
            label6.Size = new Size(154, 25);
            label6.TabIndex = 88;
            label6.Text = "Hesabın yok mu ?";
            // 
            // geri
            // 
            geri.Location = new Point(977, 654);
            geri.Name = "geri";
            geri.Size = new Size(109, 37);
            geri.TabIndex = 89;
            geri.Text = "Geri Dön";
            geri.UseVisualStyleBackColor = true;
            geri.Click += geri_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.LinkVisited = true;
            linkLabel1.Location = new Point(608, 465);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(117, 20);
            linkLabel1.TabIndex = 90;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Şifremi Unuttum";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(536, 587);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(142, 23);
            linkLabel2.TabIndex = 91;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "HEMEN KAYIT OL";
            linkLabel2.LinkClicked += kayıt_ol_LinkClicked;
            // 
            // UC_kullaniciGirisEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(geri);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(txtSifre);
            Controls.Add(label2);
            Controls.Add(txtKullaniciVeyaEmail);
            Controls.Add(label1);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label3);
            Name = "UC_kullaniciGirisEkrani";
            Size = new Size(1902, 1033);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button6;
        private Button button5;
        private Button button4;
        private Label label3;
        private Label label17;
        private Label label16;
        private Label label1;
        private TextBox txtKullaniciVeyaEmail;
        private TextBox txtSifre;
        private Label label2;
        private Label label4;
        private CheckBox checkBox1;
        private Button button1;
        private Label label6;
        private Button geri;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}
