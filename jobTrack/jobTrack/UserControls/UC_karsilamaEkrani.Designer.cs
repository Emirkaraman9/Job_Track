using System.Windows.Forms;

namespace jobTrack.UserControls
{
    partial class UC_karsilamaEkrani
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
            kurumsal_button = new Button();
            bireysel_button = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // kurumsal_button
            // 
            kurumsal_button.Location = new Point(152, 255);
            kurumsal_button.Name = "kurumsal_button";
            kurumsal_button.Size = new Size(225, 76);
            kurumsal_button.TabIndex = 0;
            kurumsal_button.Text = "Kurumsal Kayıt Ol";
            kurumsal_button.UseVisualStyleBackColor = true;
            kurumsal_button.Click += kurumsal_button_Click;
            // 
            // bireysel_button
            // 
            bireysel_button.Location = new Point(152, 366);
            bireysel_button.Name = "bireysel_button";
            bireysel_button.Size = new Size(225, 76);
            bireysel_button.TabIndex = 1;
            bireysel_button.Text = "Bireysel Kayıt Ol";
            bireysel_button.UseVisualStyleBackColor = true;
            bireysel_button.Click += bireysel_button_Click;
            // 
            // button3
            // 
            button3.Location = new Point(152, 478);
            button3.Name = "button3";
            button3.Size = new Size(225, 76);
            button3.TabIndex = 2;
            button3.Text = "HESABINA GİRİŞ YAP";
            button3.UseVisualStyleBackColor = true;
            button3.Click += kullanicigir_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(122, 134);
            label1.Name = "label1";
            label1.Size = new Size(491, 41);
            label1.TabIndex = 3;
            label1.Text = "\"Şirket ve adayı ortak bir gerçeklikte";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(122, 193);
            label2.Name = "label2";
            label2.Size = new Size(292, 41);
            label2.TabIndex = 4;
            label2.Text = "buluşturan platform\"";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(76, 48);
            label3.Name = "label3";
            label3.Size = new Size(128, 41);
            label3.TabIndex = 5;
            label3.Text = "jobTrack";
            // 
            // button4
            // 
            button4.Location = new Point(436, 41);
            button4.Name = "button4";
            button4.Size = new Size(159, 65);
            button4.TabIndex = 6;
            button4.Text = "Menü";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(647, 41);
            button5.Name = "button5";
            button5.Size = new Size(159, 65);
            button5.TabIndex = 7;
            button5.Text = "Hakkımızda";
            button5.UseVisualStyleBackColor = true;
            button5.Click += hakkımızda_button_Click;
            // 
            // button6
            // 
            button6.Location = new Point(843, 41);
            button6.Name = "button6";
            button6.Size = new Size(159, 65);
            button6.TabIndex = 8;
            button6.Text = "@job_track";
            button6.UseVisualStyleBackColor = true;
            // 
            // UC_karsilamaEkrani
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(bireysel_button);
            Controls.Add(kurumsal_button);
            Name = "UC_karsilamaEkrani";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button kurumsal_button;
        private Button bireysel_button;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
