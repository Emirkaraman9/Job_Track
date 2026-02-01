namespace jobTrack.UserControls
{
    partial class UC_Navbar
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
            btnNavAnaSayfa = new Button();
            btnNavIlanAra = new Button();
            btnNavBasvurularim = new Button();
            btnNavBildirimler = new Button();
            btnNavCvSihirbazi = new Button();
            btnNavHesap = new Button();
            btnNavCikis = new Button();
            SuspendLayout();
            // 
            // btnNavAnaSayfa
            // 
            btnNavAnaSayfa.FlatAppearance.BorderSize = 0;
            btnNavAnaSayfa.FlatStyle = FlatStyle.Flat;
            btnNavAnaSayfa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavAnaSayfa.ForeColor = Color.White;
            btnNavAnaSayfa.Location = new Point(10, 25);
            btnNavAnaSayfa.Margin = new Padding(3, 4, 3, 4);
            btnNavAnaSayfa.Name = "btnNavAnaSayfa";
            btnNavAnaSayfa.Size = new Size(130, 56);
            btnNavAnaSayfa.TabIndex = 0;
            btnNavAnaSayfa.Text = "Ana Sayfa";
            btnNavAnaSayfa.Click += btnNavAnaSayfa_Click;
            // 
            // btnNavIlanAra
            // 
            btnNavIlanAra.FlatAppearance.BorderSize = 0;
            btnNavIlanAra.FlatStyle = FlatStyle.Flat;
            btnNavIlanAra.Font = new Font("Segoe UI", 10F);
            btnNavIlanAra.ForeColor = Color.White;
            btnNavIlanAra.Location = new Point(145, 25);
            btnNavIlanAra.Margin = new Padding(3, 4, 3, 4);
            btnNavIlanAra.Name = "btnNavIlanAra";
            btnNavIlanAra.Size = new Size(130, 56);
            btnNavIlanAra.TabIndex = 1;
            btnNavIlanAra.Text = "İlan Ara";
            btnNavIlanAra.Click += btnNavIlanAra_Click;
            // 
            // btnNavBasvurularim
            // 
            btnNavBasvurularim.FlatAppearance.BorderSize = 0;
            btnNavBasvurularim.FlatStyle = FlatStyle.Flat;
            btnNavBasvurularim.Font = new Font("Segoe UI", 10F);
            btnNavBasvurularim.ForeColor = Color.White;
            btnNavBasvurularim.Location = new Point(280, 25);
            btnNavBasvurularim.Margin = new Padding(3, 4, 3, 4);
            btnNavBasvurularim.Name = "btnNavBasvurularim";
            btnNavBasvurularim.Size = new Size(130, 56);
            btnNavBasvurularim.TabIndex = 2;
            btnNavBasvurularim.Text = "Başvurularım";
            btnNavBasvurularim.Click += btnNavBasvurularim_Click;
            // 
            // btnNavBildirimler
            // 
            btnNavBildirimler.FlatAppearance.BorderSize = 0;
            btnNavBildirimler.FlatStyle = FlatStyle.Flat;
            btnNavBildirimler.Font = new Font("Segoe UI", 10F);
            btnNavBildirimler.ForeColor = Color.White;
            btnNavBildirimler.Location = new Point(415, 25);
            btnNavBildirimler.Margin = new Padding(3, 4, 3, 4);
            btnNavBildirimler.Name = "btnNavBildirimler";
            btnNavBildirimler.Size = new Size(130, 56);
            btnNavBildirimler.TabIndex = 3;
            btnNavBildirimler.Text = "Bildirimler";
            btnNavBildirimler.Click += btnNavBildirimler_Click;
            // 
            // btnNavCvSihirbazi
            // 
            btnNavCvSihirbazi.FlatAppearance.BorderSize = 0;
            btnNavCvSihirbazi.FlatStyle = FlatStyle.Flat;
            btnNavCvSihirbazi.Font = new Font("Segoe UI", 10F);
            btnNavCvSihirbazi.ForeColor = Color.White;
            btnNavCvSihirbazi.Location = new Point(550, 25);
            btnNavCvSihirbazi.Margin = new Padding(3, 4, 3, 4);
            btnNavCvSihirbazi.Name = "btnNavCvSihirbazi";
            btnNavCvSihirbazi.Size = new Size(130, 56);
            btnNavCvSihirbazi.TabIndex = 4;
            btnNavCvSihirbazi.Text = "CV Sihirbazı";
            btnNavCvSihirbazi.Click += btnNavCvSihirbazi_Click;
            // 
            // btnNavHesap
            // 
            btnNavHesap.FlatAppearance.BorderSize = 0;
            btnNavHesap.FlatStyle = FlatStyle.Flat;
            btnNavHesap.Font = new Font("Segoe UI", 10F);
            btnNavHesap.ForeColor = Color.White;
            btnNavHesap.Location = new Point(685, 25);
            btnNavHesap.Margin = new Padding(3, 4, 3, 4);
            btnNavHesap.Name = "btnNavHesap";
            btnNavHesap.Size = new Size(130, 56);
            btnNavHesap.TabIndex = 5;
            btnNavHesap.Text = "Hesabım";
            btnNavHesap.Click += btnNavHesap_Click_1;
            // 
            // btnNavCikis
            // 
            btnNavCikis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNavCikis.FlatAppearance.BorderColor = Color.Red;
            btnNavCikis.FlatStyle = FlatStyle.Flat;
            btnNavCikis.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNavCikis.ForeColor = Color.Tomato;
            btnNavCikis.Location = new Point(1140, 25);
            btnNavCikis.Margin = new Padding(3, 4, 3, 4);
            btnNavCikis.Name = "btnNavCikis";
            btnNavCikis.Size = new Size(100, 56);
            btnNavCikis.TabIndex = 6;
            btnNavCikis.Text = "ÇIKIŞ";
            btnNavCikis.Click += btnNavCikis_Click;
            // 
            // UC_Navbar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(btnNavCikis);
            Controls.Add(btnNavHesap);
            Controls.Add(btnNavCvSihirbazi);
            Controls.Add(btnNavBildirimler);
            Controls.Add(btnNavBasvurularim);
            Controls.Add(btnNavIlanAra);
            Controls.Add(btnNavAnaSayfa);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_Navbar";
            Size = new Size(1264, 106);
            Load += UC_Navbar_Load;
            ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnNavAnaSayfa;
        public System.Windows.Forms.Button btnNavIlanAra;
        public System.Windows.Forms.Button btnNavBasvurularim; // Tanım eklendi
        public System.Windows.Forms.Button btnNavBildirimler;
        public System.Windows.Forms.Button btnNavCvSihirbazi;
        public System.Windows.Forms.Button btnNavHesap;
        public System.Windows.Forms.Button btnNavCikis;
    }
}