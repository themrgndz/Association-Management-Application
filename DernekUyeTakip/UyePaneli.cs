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
        public UyePaneli(string tc)
        {
            InitializeComponent();

            List<EntityUye> uyeler = LogicUye.LLUyeListesi(tc);

            if (uyeler != null && uyeler.Count > 0)
            {
                TbAd.Text = uyeler[0].Ad;
                TbSoyad.Text = uyeler[0].Soyad;
                TbYas.Text = uyeler[0].Yas.ToString();
                TbSehir.Text = uyeler[0].Sehir;
                TbKanGrubu.Text = uyeler[0].KanGrubu;
                TbEposta.Text = uyeler[0].Aktif_Pasif ? "Aktif" : "Pasif";
            }
            else
            {
                // Veri bulunamadıysa veya hata oluştuysa uyarı mesajı yazdırabilirsiniz
                MessageBox.Show("Veri bulunamadı veya bir hata oluştu.");
            }
        }
        private void UyePaneli_Load(object sender, EventArgs e)
        {
            
        }
        private void UyePaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
