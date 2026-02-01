using System.Windows.Forms;

namespace jobTrack.UserControls
{
    partial class UC_basvurularimEkrani
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            label2 = new Label();
            dgvBasvurular = new DataGridView();
            colOkul = new DataGridViewTextBoxColumn();
            colBolum = new DataGridViewTextBoxColumn();
            colDerece = new DataGridViewTextBoxColumn();
            colDevamEdiyor = new DataGridViewTextBoxColumn();
            txtAraBasvuru = new TextBox();
            btnAraBasvuru = new Button();
            label1 = new Label();
            cmbDurumFiltresi = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvBasvurular).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(20, 25, 25);
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(160, 292);
            label2.Name = "label2";
            label2.Size = new Size(196, 35);
            label2.TabIndex = 1;
            label2.Text = "BAŞVURULARIM";
            // 
            // dgvBasvurular
            // 
            dgvBasvurular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBasvurular.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvBasvurular.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.DarkGray;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvBasvurular.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvBasvurular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBasvurular.Columns.AddRange(new DataGridViewColumn[] { colOkul, colBolum, colDerece, colDevamEdiyor });
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle13.ForeColor = Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvBasvurular.DefaultCellStyle = dataGridViewCellStyle13;
            dgvBasvurular.EnableHeadersVisualStyles = false;
            dgvBasvurular.Location = new Point(160, 353);
            dgvBasvurular.Name = "dgvBasvurular";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle14.ForeColor = Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dgvBasvurular.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dgvBasvurular.RowHeadersWidth = 51;
            dgvBasvurular.RowTemplate.Height = 30;
            dgvBasvurular.Size = new Size(917, 220);
            dgvBasvurular.TabIndex = 29;
            // 
            // colOkul
            // 
            colOkul.DataPropertyName = "SirketAdi";
            dataGridViewCellStyle9.ForeColor = Color.Black;
            colOkul.DefaultCellStyle = dataGridViewCellStyle9;
            colOkul.HeaderText = "Şirket Adı";
            colOkul.MinimumWidth = 6;
            colOkul.Name = "colOkul";
            // 
            // colBolum
            // 
            colBolum.DataPropertyName = "Pozisyon";
            dataGridViewCellStyle10.ForeColor = Color.Black;
            colBolum.DefaultCellStyle = dataGridViewCellStyle10;
            colBolum.HeaderText = "Pozisyon";
            colBolum.MinimumWidth = 6;
            colBolum.Name = "colBolum";
            // 
            // colDerece
            // 
            colDerece.DataPropertyName = "Tarih";
            dataGridViewCellStyle11.ForeColor = Color.Black;
            colDerece.DefaultCellStyle = dataGridViewCellStyle11;
            colDerece.HeaderText = "Başvuru Tarihi";
            colDerece.MinimumWidth = 6;
            colDerece.Name = "colDerece";
            // 
            // colDevamEdiyor
            // 
            colDevamEdiyor.DataPropertyName = "Durum";
            dataGridViewCellStyle12.ForeColor = Color.Black;
            colDevamEdiyor.DefaultCellStyle = dataGridViewCellStyle12;
            colDevamEdiyor.HeaderText = "Durum";
            colDevamEdiyor.MinimumWidth = 6;
            colDevamEdiyor.Name = "colDevamEdiyor";
            // 
            // txtAraBasvuru
            // 
            txtAraBasvuru.ForeColor = Color.Black;
            txtAraBasvuru.Location = new Point(160, 133);
            txtAraBasvuru.Name = "txtAraBasvuru";
            txtAraBasvuru.Size = new Size(150, 27);
            txtAraBasvuru.TabIndex = 0;
            // 
            // btnAraBasvuru
            // 
            btnAraBasvuru.Location = new Point(333, 131);
            btnAraBasvuru.Name = "btnAraBasvuru";
            btnAraBasvuru.Size = new Size(94, 29);
            btnAraBasvuru.TabIndex = 1;
            btnAraBasvuru.Text = "Ara";
            btnAraBasvuru.UseVisualStyleBackColor = true;
            btnAraBasvuru.Click += btnAra_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(20, 25, 25);
            label1.ForeColor = Color.White;
            label1.Location = new Point(565, 135);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 2;
            label1.Text = "Durum Filtresi";
            // 
            // cmbDurumFiltresi
            // 
            cmbDurumFiltresi.FormattingEnabled = true;
            cmbDurumFiltresi.Location = new Point(686, 131);
            cmbDurumFiltresi.Name = "cmbDurumFiltresi";
            cmbDurumFiltresi.Size = new Size(162, 28);
            cmbDurumFiltresi.TabIndex = 3;
            cmbDurumFiltresi.SelectedIndexChanged += cmbDurumFiltresi_SelectedIndexChanged;
            // 
            // UC_basvurularimEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 25, 25);
            Controls.Add(label1);
            Controls.Add(cmbDurumFiltresi);
            Controls.Add(dgvBasvurular);
            Controls.Add(label2);
            Controls.Add(txtAraBasvuru);
            Controls.Add(btnAraBasvuru);
            Name = "UC_basvurularimEkrani";
            Size = new Size(1902, 1033);
            Load += UC_basvurularimEkrani_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBasvurular).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private DataGridView dgvBasvurular;
        private TextBox txtAraBasvuru;
        private Button btnAraBasvuru;
        private Label label1;
        private ComboBox cmbDurumFiltresi;
        private DataGridViewTextBoxColumn colOkul;
        private DataGridViewTextBoxColumn colBolum;
        private DataGridViewTextBoxColumn colDerece;
        private DataGridViewTextBoxColumn colDevamEdiyor;
    }
}
