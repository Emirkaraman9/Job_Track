namespace jobTrack
{
    partial class FrmMain
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
            uC_Navbar1 = new jobTrack.UserControls.UC_Navbar();
            pnlContent = new Panel();
            SuspendLayout();
            // 
            // uC_Navbar1
            // 
            uC_Navbar1.BackColor = Color.FromArgb(40, 40, 40);
            uC_Navbar1.Dock = DockStyle.Top;
            uC_Navbar1.Location = new Point(0, 0);
            uC_Navbar1.Margin = new Padding(3, 5, 3, 5);
            uC_Navbar1.Name = "uC_Navbar1";
            uC_Navbar1.Size = new Size(1902, 100);
            uC_Navbar1.TabIndex = 0;

            // 
            // pnlContent
            // 
            pnlContent.Location = new Point(0, 100);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1920, 1080);
            pnlContent.TabIndex = 1;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(pnlContent);
            Controls.Add(uC_Navbar1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "jobTrack - Kariyer Platformu";
            Load += FrmMain_Load;
            ResumeLayout(false);
        }

        #endregion

        // Değişkenlerin Tanımlanması (Declaration)
        public jobTrack.UserControls.UC_Navbar uC_Navbar1;
        private System.Windows.Forms.Panel pnlContent;
    }
}