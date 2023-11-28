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
    public partial class UyePaneli : Form
    {
        public UyePaneli()
        {
            InitializeComponent();
        }

        private void UyePaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
