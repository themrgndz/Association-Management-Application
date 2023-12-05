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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DernekUyeTakip
{
    public partial class Aidat : Form
    {
        public Aidat()
        {
            InitializeComponent();
        }

        private void Aidat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void RbBelirliBirAy_CheckedChanged(object sender, EventArgs e)
        {
            GbAylar.Enabled = true;
        }

        private void RbTumAylar_CheckedChanged(object sender, EventArgs e)
        {
            GbAylar.Enabled = false;
        }

        private void BtnAidatBelirle_Click(object sender, EventArgs e)
        {
            if (GbAylar.Enabled)
            {
                //Seçili olan radiobutonu buluyoruz.
                foreach (Control control in GbAylar.Controls)
                {
                    if (control is System.Windows.Forms.RadioButton)
                    {
                        System.Windows.Forms.RadioButton radioButton = (System.Windows.Forms.RadioButton)control;
                        if (radioButton.Checked)
                        {
                            string deger = radioButton.Text;
                            AidatBelirle();
                        }
                    }
                }
            }
            else
            {

            }
        }

        
    }
}
