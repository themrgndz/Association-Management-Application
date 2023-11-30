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

        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<EntityUye> UyeList = LogicUye.LLUyeListesi();
            dataGridView1.DataSource = UyeList;
        }

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

            LogicUye.LLUyeEkle(ent);
            BtnListele_Click(sender, e);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            EntityUye ent = new EntityUye();
            ent.Tc = TbTc.Text;
            LogicUye.LLUyeSil(ent.Tc);
            BtnListele_Click(sender, e);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            EntityUye ent = new EntityUye();

            ent.Tc = TbTc.Text;
            ent.Ad = TbAd.Text;
            ent.Soyad = TbSoyad.Text;
            ent.Yas = int.Parse(TbYas.Text);
            ent.Sehir = CbSehir.Text;
            ent.Sifre = TbSifre.Text;
            ent.KanGrubu = CbKanGrubu.Text;
            ent.Aktif_Pasif = CbAktifPasif.Checked;
            ent.Borc = float.Parse(TbBorc.Text);
            LogicUye.LLUyeGuncelle(ent);
            BtnListele_Click(sender, e);
        }

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
        
        private void BtnBorc2_Click(object sender, EventArgs e)
        {
            if (CbBorc2.SelectedItem != null)
            {
                List<EntityUye> UyeList = LogicUye.LLUyeListesi(CbBorc2.SelectedIndex);
                dataGridView1.DataSource = UyeList;
            }
            else
            {
                MessageBox.Show("Lütfen listedeki değerleri seçin");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili satırın indeksi
            int selectedRow = e.RowIndex;

            // Satır seçilmişse devam et
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
                string borc = row.Cells["Borc"].Value.ToString();


                // TextBox'lara atama kısmı
                TbTc.Text = tc;
                TbAd.Text = ad;
                TbSoyad.Text = soyad;
                TbYas.Text = yas;
                CbSehir.Text = sehir;
                TbSifre.Text = sifre;
                CbKanGrubu.Text = kanGrubu;
                TbBorc.Text = borc;
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

        private void YoneticiPaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnUyeDetay_Click(object sender, EventArgs e)
        {
            if (TbTc.Text != "")
            {
                UyeDetay uyeDetay = new UyeDetay(TbTc.Text);
                uyeDetay.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir tc değeri giriniz...");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Kullanım örneği
            DateTime baslangicTarihi = new DateTime(2023, 1, 1);
            DateTime bitisTarihi = new DateTime(2023, 12, 31);
            decimal aylikAidatTutari = 100; // Ay başına düşen aidat tutarı

            Dictionary<DateTime, decimal> aidatlar = DALAidat.AidatBelirle(baslangicTarihi, bitisTarihi, aylikAidatTutari);

            // Elde edilen aidatları kullanabilirsiniz
            foreach (var aidat in aidatlar)
            {
                MessageBox.Show($"{aidat.Key.ToString("MMMM yyyy")}: {aidat.Value} TL");
            }



        }
    }
}
