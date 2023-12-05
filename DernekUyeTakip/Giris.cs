using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DernekUyeTakip
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void BtnUyeGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            UyeGirisPaneli uyeGirisPaneli = new UyeGirisPaneli();
            uyeGirisPaneli.Show();
        }

        private void BtnYoneticiGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            YoneticiGirisPaneli yoneticiGirisPaneli = new YoneticiGirisPaneli();
            yoneticiGirisPaneli.Show();
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Sil bunu
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            YoneticiPaneli yp = new YoneticiPaneli();
            yp.Show();  
        }

        private void BtnYoneticiGiris_MouseEnter(object sender, EventArgs e)
        {
            BtnYoneticiGiris.BackColor = Color.FromArgb(90,0,0);
            BtnYoneticiGiris.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void BtnYoneticiGiris_MouseLeave(object sender, EventArgs e)
        {
            BtnYoneticiGiris.BackColor = Color.FromArgb(255, 255, 255);
            BtnYoneticiGiris.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void BtnUyeGiris_MouseEnter(object sender, EventArgs e)
        {
            BtnUyeGiris.BackColor = Color.FromArgb(0, 90, 0);
            BtnUyeGiris.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void BtnUyeGiris_MouseLeave(object sender, EventArgs e)
        {
            BtnUyeGiris.BackColor = Color.FromArgb(255, 255, 255);
            BtnUyeGiris.ForeColor = Color.FromArgb(0, 0, 0);
        }
    }
}
