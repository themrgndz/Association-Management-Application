using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace DernekUyeTakip
{
    public partial class YoneticiGirisPaneli : Form
    {
        public YoneticiGirisPaneli()
        {
            InitializeComponent();
        }

        private void BtnYgp_Click(object sender, EventArgs e)
        {
            if (DALUye.YoneticiDogrula(Tb_TcNo.Text.ToString(), Tb_Sifre.Text.ToString()) == true)
            {
                this.Hide();
                YoneticiPaneli Yp = new YoneticiPaneli();
                Yp.Show();
            }
            else
            {
                MessageBox.Show("Tc no veya şifre yanlış...");
            }
        }
        private void YoneticiGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
