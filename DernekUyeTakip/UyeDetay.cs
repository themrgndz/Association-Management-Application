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
    public partial class UyeDetay : Form
    {
        private string GelenVeri;
        public UyeDetay(string gelenVeri)
        {
            InitializeComponent();
            GelenVeri = gelenVeri;
        }

        private void UyeDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = GelenVeri;
        }
    }
}
