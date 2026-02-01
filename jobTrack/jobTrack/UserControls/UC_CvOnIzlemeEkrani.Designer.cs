using System.Windows.Forms;

namespace jobTrack.UserControls
{
    partial class UC_CvOnIzlemeEkrani
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_CvOnIzlemeEkrani));
            pnlSidebar = new Panel();
            label4 = new Label();
            btnUzaklastir = new Button();
            label3 = new Label();
            btnPdfKaydet = new Button();
            label2 = new Label();
            btnYakinlastir = new Button();
            label1 = new Label();
            btnYazdir = new Button();
            panel2 = new Panel();
            ppvCvOnizleme = new PrintPreviewControl();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            pnlSidebar.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.Black;
            pnlSidebar.BackgroundImageLayout = ImageLayout.Center;
            pnlSidebar.Controls.Add(label4);
            pnlSidebar.Controls.Add(btnUzaklastir);
            pnlSidebar.Controls.Add(label3);
            pnlSidebar.Controls.Add(btnPdfKaydet);
            pnlSidebar.Controls.Add(label2);
            pnlSidebar.Controls.Add(btnYakinlastir);
            pnlSidebar.Controls.Add(label1);
            pnlSidebar.Controls.Add(btnYazdir);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(120, 1033);
            pnlSidebar.TabIndex = 0;
            pnlSidebar.Paint += pnlSidebar_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(17, 808);
            label4.Name = "label4";
            label4.Size = new Size(83, 23);
            label4.TabIndex = 3;
            label4.Text = "Uzaklaştır";
            // 
            // btnUzaklastir
            // 
            btnUzaklastir.BackgroundImage = (Image)resources.GetObject("btnUzaklastir.BackgroundImage");
            btnUzaklastir.BackgroundImageLayout = ImageLayout.Zoom;
            btnUzaklastir.FlatAppearance.BorderSize = 0;
            btnUzaklastir.FlatStyle = FlatStyle.Flat;
            btnUzaklastir.ForeColor = Color.White;
            btnUzaklastir.Location = new Point(20, 739);
            btnUzaklastir.Name = "btnUzaklastir";
            btnUzaklastir.Size = new Size(73, 66);
            btnUzaklastir.TabIndex = 3;
            btnUzaklastir.UseVisualStyleBackColor = true;
            btnUzaklastir.Click += btnUzaklastir_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(20, 651);
            label3.Name = "label3";
            label3.Size = new Size(85, 23);
            label3.TabIndex = 2;
            label3.Text = "Yakınlaştır";
            // 
            // btnPdfKaydet
            // 
            btnPdfKaydet.BackgroundImage = (Image)resources.GetObject("btnPdfKaydet.BackgroundImage");
            btnPdfKaydet.BackgroundImageLayout = ImageLayout.Zoom;
            btnPdfKaydet.FlatAppearance.BorderSize = 0;
            btnPdfKaydet.FlatStyle = FlatStyle.Flat;
            btnPdfKaydet.ForeColor = Color.White;
            btnPdfKaydet.Location = new Point(23, 217);
            btnPdfKaydet.Name = "btnPdfKaydet";
            btnPdfKaydet.Size = new Size(73, 66);
            btnPdfKaydet.TabIndex = 0;
            btnPdfKaydet.UseVisualStyleBackColor = true;
            btnPdfKaydet.Click += btnPdfKaydet_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(32, 470);
            label2.Name = "label2";
            label2.Size = new Size(55, 23);
            label2.TabIndex = 1;
            label2.Text = "Yazdır";
            // 
            // btnYakinlastir
            // 
            btnYakinlastir.BackgroundImage = (Image)resources.GetObject("btnYakinlastir.BackgroundImage");
            btnYakinlastir.BackgroundImageLayout = ImageLayout.Zoom;
            btnYakinlastir.FlatAppearance.BorderSize = 0;
            btnYakinlastir.FlatStyle = FlatStyle.Flat;
            btnYakinlastir.ForeColor = Color.White;
            btnYakinlastir.Location = new Point(23, 582);
            btnYakinlastir.Name = "btnYakinlastir";
            btnYakinlastir.Size = new Size(73, 66);
            btnYakinlastir.TabIndex = 2;
            btnYakinlastir.UseVisualStyleBackColor = true;
            btnYakinlastir.Click += btnYakinlastir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 286);
            label1.Name = "label1";
            label1.Size = new Size(97, 23);
            label1.TabIndex = 0;
            label1.Text = "PDF Kaydet";
            // 
            // btnYazdir
            // 
            btnYazdir.BackgroundImage = (Image)resources.GetObject("btnYazdir.BackgroundImage");
            btnYazdir.BackgroundImageLayout = ImageLayout.Zoom;
            btnYazdir.FlatAppearance.BorderSize = 0;
            btnYazdir.FlatStyle = FlatStyle.Flat;
            btnYazdir.ForeColor = Color.White;
            btnYazdir.Location = new Point(23, 401);
            btnYazdir.Name = "btnYazdir";
            btnYazdir.Size = new Size(73, 66);
            btnYazdir.TabIndex = 1;
            btnYazdir.UseVisualStyleBackColor = true;
            btnYazdir.Click += btnYazdir_Click;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(ppvCvOnizleme);
            panel2.Location = new Point(120, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1782, 1033);
            panel2.TabIndex = 1;
            // 
            // ppvCvOnizleme
            // 
            ppvCvOnizleme.AutoZoom = false;
            ppvCvOnizleme.BackColor = Color.Gray;
            ppvCvOnizleme.Document = printDocument1;
            ppvCvOnizleme.Font = new Font("Segoe UI", 9F);
            ppvCvOnizleme.Location = new Point(0, -8);
            ppvCvOnizleme.Name = "ppvCvOnizleme";
            ppvCvOnizleme.Size = new Size(1782, 948);
            ppvCvOnizleme.TabIndex = 0;
            ppvCvOnizleme.Zoom = 0.65012831479897348D;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // UC_CvOnIzlemeEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(pnlSidebar);
            ForeColor = Color.White;
            Name = "UC_CvOnIzlemeEkrani";
            Size = new Size(1902, 1033);
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel panel2;
        private Button btnPdfKaydet;
        private Button btnUzaklastir;
        private Button btnYakinlastir;
        private Button btnYazdir;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private PrintPreviewControl ppvCvOnizleme;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
