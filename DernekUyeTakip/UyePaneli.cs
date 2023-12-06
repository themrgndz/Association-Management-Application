using DataAccessLayer;
using EntityLayer;
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

            List<EntityUye> uyeler = DALUye.UyeListesi(tc);


            if (uyeler != null && uyeler.Count > 0)
            {
                textBox1.Text = uyeler[0].Ad;
                textBox2.Text = uyeler[0].Soyad;
                textBox3.Text = uyeler[0].Yas.ToString();
                textBox4.Text = uyeler[0].Sehir;
                textBox5.Text = uyeler[0].KanGrubu;
                textBox7.Text = uyeler[0].KayitTarihi.ToString();
                textBox8.Text = uyeler[0].Aktif_Pasif ? "Aktif" : "Pasif";
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

    }
}
