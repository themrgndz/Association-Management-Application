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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<EntityUye> UyeList = LogicUye.LLUyeListesi();
            dataGridView1.DataSource = UyeList;
        }
        private void BtnEkle_Click_1(object sender, EventArgs e)
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

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            EntityUye ent = new EntityUye();
            ent.Tc = TbTc.Text;
            LogicUye.LLUyeSil(ent.Tc);
            BtnListele_Click(sender, e);
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            EntityUye ent = new EntityUye();

            ent.Tc = TbTc.Text;
            ent.Ad = TbAd.Text;
            ent.Soyad = TbSoyad.Text;
            ent.Yas = int.Parse(TbYas.Text);
            ent.Sehir = CbSehir.Text;
            ent.Sifre = TbSifre.Text;
            ent.KanGrubu = CbKanGrubu.Text;

            LogicUye.LLUyeGuncelle(ent);
            BtnListele_Click(sender, e);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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

                // TextBox'lara atama yapabilirsin
                TbTc.Text = tc;
                TbAd.Text = ad;
                TbSoyad.Text = soyad;
                TbYas.Text = yas;
                CbSehir.Text = sehir;
                TbSifre.Text = sifre;
                CbKanGrubu.Text = kanGrubu;
                // ... diğer TextBox'lara atama yap
            }
        }

        private void Anasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
