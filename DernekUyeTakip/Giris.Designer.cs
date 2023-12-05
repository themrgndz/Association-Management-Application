namespace DernekUyeTakip
{
    partial class Giris
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnUyeGiris = new System.Windows.Forms.Button();
            this.BtnYoneticiGiris = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 63);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(254, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Üye Takip Programı";
            // 
            // BtnUyeGiris
            // 
            this.BtnUyeGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnUyeGiris.Location = new System.Drawing.Point(136, 19);
            this.BtnUyeGiris.Name = "BtnUyeGiris";
            this.BtnUyeGiris.Size = new System.Drawing.Size(150, 75);
            this.BtnUyeGiris.TabIndex = 5;
            this.BtnUyeGiris.Text = "Üye Giriş";
            this.BtnUyeGiris.UseVisualStyleBackColor = true;
            this.BtnUyeGiris.Click += new System.EventHandler(this.BtnUyeGiris_Click);
            this.BtnUyeGiris.MouseEnter += new System.EventHandler(this.BtnUyeGiris_MouseEnter);
            this.BtnUyeGiris.MouseLeave += new System.EventHandler(this.BtnUyeGiris_MouseLeave);
            // 
            // BtnYoneticiGiris
            // 
            this.BtnYoneticiGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnYoneticiGiris.Location = new System.Drawing.Point(111, 19);
            this.BtnYoneticiGiris.Name = "BtnYoneticiGiris";
            this.BtnYoneticiGiris.Size = new System.Drawing.Size(150, 75);
            this.BtnYoneticiGiris.TabIndex = 4;
            this.BtnYoneticiGiris.Text = "Yönetici Giriş";
            this.BtnYoneticiGiris.UseVisualStyleBackColor = true;
            this.BtnYoneticiGiris.Click += new System.EventHandler(this.BtnYoneticiGiris_Click);
            this.BtnYoneticiGiris.MouseEnter += new System.EventHandler(this.BtnYoneticiGiris_MouseEnter);
            this.BtnYoneticiGiris.MouseLeave += new System.EventHandler(this.BtnYoneticiGiris_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnYoneticiGiris);
            this.panel3.Location = new System.Drawing.Point(12, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 119);
            this.panel3.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BtnUyeGiris);
            this.panel5.Location = new System.Drawing.Point(418, 96);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(397, 119);
            this.panel5.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Kestirme";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(826, 243);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Giris_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnUyeGiris;
        private System.Windows.Forms.Button BtnYoneticiGiris;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button1;
    }
}