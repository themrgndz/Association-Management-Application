using DataAccessLayer;
using EntityLayer;
using LogicLayer;
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
        private void UyePaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public UyePaneli(string tc)
        {
            InitializeComponent();
            
            UyeDoldur(tc);

            UyeAidatDoldur(tc);

            UyeBorcDoldur(tc);
        
        }
        public void UyeAidatDoldur(string tc)
        {
            DGVAidat.DataSource = LogicAidat.LLUyeAidatGetir(tc);
        }
        public void UyeDoldur(string tc)
        {
            List<EntityUye> uyeler = LogicUye.LLUyeListesi(tc);

            if (uyeler != null && uyeler.Count > 0)
            {
                TbTc.Text = uyeler[0].Tc.ToString();
                TbAd.Text = uyeler[0].Ad;
                TbSoyad.Text = uyeler[0].Soyad;
                TbYas.Text = uyeler[0].Yas.ToString();
                TbSehir.Text = uyeler[0].Sehir;
                TbKanGrubu.Text = uyeler[0].KanGrubu;
                TbEposta.Text = uyeler[0].Eposta;
            }
            else
            {
                Application.Exit();
            }
        }
        public void UyeBorcDoldur(string tc)
        {
            DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(tc);
        }
        private void BtnAidatOde_Click(object sender, EventArgs e)
        {

        }
        private void BtnBorcOde_Click(object sender, EventArgs e)
        {

        }

       
    }
}
