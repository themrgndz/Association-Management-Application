using DataAccessLayer;
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
    public partial class UyeGirisPaneli : Form
    {
        public UyeGirisPaneli()
        {
            InitializeComponent();
        }
        private void BtnYgp_Click(object sender, EventArgs e)
        {
            if (DALUye.UyeDogrula(Tb_TcNo.Text.ToString(),Tb_Sifre.Text.ToString()) == true)
            {
                this.Hide();
                UyePaneli uyePaneli = new UyePaneli();
                uyePaneli.Show();
            }
        }
        private void UyeGirisPaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
