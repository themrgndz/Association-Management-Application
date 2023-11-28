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
    }
}
