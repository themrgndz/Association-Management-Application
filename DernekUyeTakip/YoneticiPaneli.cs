using DataAccessLayer;
using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DernekUyeTakip
{
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------

        //Listele butonuna basıldığında DataGridView'e tüm verileri çeker
        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<EntityUye> UyeList = LogicUye.LLUyeListesi();
            dataGridView1.DataSource = UyeList;
        }

        //---------------------------------------------------------------------------------

        //Ekle butonuna basıldığında verileri girilen üyeyi veritabanına ekliyor
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            EntityUye ent = new EntityUye();

            ent.Tc = TbTc.Text;
            ent.Ad = TbAd.Text;
            ent.Soyad = TbSoyad.Text;
            ent.Yas = int.Parse(TbYas.Text);
            ent.Sehir = CbSehir.Text;
            ent.Sifre = TbSifre.Text;
            ent.KanGrubu = CbKanGrubu.Text;
            ent.Eposta = TbEposta.Text;
            ent.Aktif_Pasif = CbAktifPasif.Checked;
            ent.KayitTarihi = DateTime.Today.ToString("dd.MM.yyyy");

            LogicUye.LLUyeEkle(ent);
            BtnListele_Click(sender, e);

            TbTc.Text = "";
            TbAd.Text = "";
            TbSoyad.Text = "";
            TbYas.Text = "";
            CbSehir.Text = "";
            TbSifre.Text = "";
            CbKanGrubu.Text = "";
            TbEposta.Text = "";
            CbAktifPasif.Checked = false;
        }

        //---------------------------------------------------------------------------------

        //Sil butonuna basıldığında Tc'si girilen veriyi veritabanından siliyor
        private void BtnSil_Click(object sender, EventArgs e)
        {
            EntityUye ent = new EntityUye();
            ent.Tc = TbTc.Text;
            LogicUye.LLUyeSil(ent.Tc);
            BtnListele_Click(sender, e);
        }

        //---------------------------------------------------------------------------------

        //Güncelle butonuna basıldığında Tc'si verilen üyenin bilgilerini textboxlara girilen verilerle güncelliyor
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            EntityUye ent = new EntityUye();

            ent.Tc = TbTc.Text;
            ent.Ad = TbAd.Text;
            ent.Soyad = TbSoyad.Text;
            ent.Yas = int.Parse(TbYas.Text);
            ent.Sehir = CbSehir.Text;
            ent.Sifre = TbSifre.Text;
            ent.Eposta = TbEposta.Text;
            ent.KanGrubu = CbKanGrubu.Text;
            ent.Aktif_Pasif = CbAktifPasif.Checked;
            LogicUye.LLUyeGuncelle(ent);
            BtnListele_Click(sender, e);
        }

        //---------------------------------------------------------------------------------

        //Seçilen kan grubuna göre DataGridView'deki verileri filtreliyor
        private void BtnKanGrubu2_Click(object sender, EventArgs e)
        {
            if (CbKanGrubu2.SelectedItem != null)
            {
                List<EntityUye> UyeList = LogicUye.LLUyeListesi("KanGrubu", CbKanGrubu2.SelectedItem.ToString());
                dataGridView1.DataSource = UyeList;
            }
            else
            {
                MessageBox.Show("Lütfen listedeki değerleri seçin");
            }
        }

        //---------------------------------------------------------------------------------

        //Seçilen kan grubuna göre DataGridView'deki verileri filtreliyor
        private void BtnSehir2_Click(object sender, EventArgs e)
        {
            if (CbSehir2.SelectedItem != null) { 
                List<EntityUye> UyeList = LogicUye.LLUyeListesi("Sehir", CbSehir2.SelectedItem.ToString());
                dataGridView1.DataSource = UyeList;
            }
            else
            {
                MessageBox.Show("Lütfen listedeki değerleri seçin");
            }
        }

        //---------------------------------------------------------------------------------

        //Seçilen kan grubuna göre DataGridView'deki verileri filtreliyor
        private void BtnAP2_Click(object sender, EventArgs e)
        {
            if (CbAktifPasif2.SelectedItem != null)
            {
                if (CbAktifPasif2.SelectedIndex == 0)
                {
                    List<EntityUye> UyeList = LogicUye.LLUyeListesi("AktifPasif", false);
                    dataGridView1.DataSource = UyeList;
                }
                else
                {
                    List<EntityUye> UyeList = LogicUye.LLUyeListesi("AktifPasif", true);
                    dataGridView1.DataSource = UyeList;
                }
            }
            else
            {
                MessageBox.Show("Lütfen listedeki değerleri seçin");
            }
            
        }

        //---------------------------------------------------------------------------------

        //DataGridView'deki hücrelere tıklandığında o hücrelerdeki üyeyi panele yansıtıyor
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili satırın indeksi
            int selectedRow = e.RowIndex;

            // Satır seçilmişse devam ediyoruz
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                // Burada seçilen satırdaki verileri alıyoruz
                string tc = row.Cells["Tc"].Value.ToString();
                string ad = row.Cells["Ad"].Value.ToString();
                string soyad = row.Cells["Soyad"].Value.ToString();
                string yas = row.Cells["Yas"].Value.ToString();
                string sehir = row.Cells["Sehir"].Value.ToString();
                string sifre = row.Cells["Sifre"].Value.ToString();
                string kanGrubu = row.Cells["KanGrubu"].Value.ToString();
                string ap = row.Cells["Aktif_Pasif"].Value.ToString();
                string Eposta = row.Cells["Eposta"].Value.ToString();

                // TextBox'lara atama kısmı
                TbTc.Text = tc;
                TbAd.Text = ad;
                TbSoyad.Text = soyad;
                TbYas.Text = yas;
                CbSehir.Text = sehir;
                TbEposta.Text = Eposta;
                TbSifre.Text = sifre;
                CbKanGrubu.Text = kanGrubu;
                if (ap == "True")
                {
                    CbAktifPasif.Checked = true;
                }
                else
                {
                    CbAktifPasif.Checked = false;
                }
            }
        }

        //---------------------------------------------------------------------------------

        //Panel kapatılırsa uygulamayı da kapatır
        private void YoneticiPaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //---------------------------------------------------------------------------------

        //Textboxlarda bulunan tüm yazıları siler
        private void BtnSifirla_Click(object sender, EventArgs e)
        {
            TbTc.Text = "";
            TbAd.Text = "";
            TbSoyad.Text = "";
            TbYas.Text = "";
            CbSehir.Text = "";
            TbSifre.Text = "";
            CbKanGrubu.Text = "";
            TbEposta.Text = "";
            CbAktifPasif.Checked = false;
        }

        //---------------------------------------------------------------------------------

        //Aidat ile ilgili form sayfasını açar
        private void BtnAidatBelirle_Click(object sender, EventArgs e)
        {
            this.Hide();
            Aidat aidat = new Aidat();
            aidat.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}





