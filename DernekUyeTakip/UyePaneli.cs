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
        //Form kapatıldığında uygulamayı kapatır.
        private void UyePaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //-------------------------------------------------------------------------

        //Uye paneli genel işlemler.
        public UyePaneli(string tc)
        {
            InitializeComponent();
            
            UyeDoldur(tc);

            UyeAidatDoldur(tc);

            UyeBorcDoldur(tc);
        
        }
        //-------------------------------------------------------------------------

        //Verilen tc'ye göre DataGridView'i doldurur.
        public void UyeAidatDoldur(string tc)
        {
            DGVAidat.DataSource = LogicAidat.LLUyeAidatGetir(tc);
        }
        //-------------------------------------------------------------------------

        //Verilen tc'ye göre TextBox'ları doldurur.
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
        //-------------------------------------------------------------------------

        //Verilen tc'ye göre DataGridView'i doldurur.
        public void UyeBorcDoldur(string tc)
        {
            DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(tc);
        }
        //-------------------------------------------------------------------------

        //Combobox'ta seçili değere göre aidat öder.
        private void BtnAidatOde_Click(object sender, EventArgs e)
        {

        }
        //-------------------------------------------------------------------------

        //Combobox'ta seçili değere göre borç öder.
        private void BtnBorcOde_Click(object sender, EventArgs e)
        {

        }
        //-------------------------------------------------------------------------
    }
}
