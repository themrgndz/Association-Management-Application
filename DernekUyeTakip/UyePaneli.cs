using DataAccessLayer;
using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
            ComboAidatdoldur(tc);
            ComboBorcdoldur(tc);
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

        //
        public void ComboAidatdoldur(string tc)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM UyeAidat Where Odendi = false AND Tc = @P1", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1",tc);
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();
                    int[] ent = new int[10000];

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {

                        CbAidatOde.Items.Add(int.Parse(dr["AidatId"].ToString()));

                    }
                    dr.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
        //

        //
        public void ComboBorcdoldur(string tc)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Borc Where Odendi = false AND Tc = @P1", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1", tc);
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();
                    int[] ent = new int[10000];

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {

                        CbBorcOde.Items.Add(int.Parse(dr["BorcId"].ToString()));

                    }
                    dr.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }
        //

        //Verilen tc'ye göre DataGridView'i doldurur.
        public void UyeBorcDoldur(string tc)
        {
            DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(tc);
        }
        //-------------------------------------------------------------------------

        //Verilen tc'ye göre DataGridView'i doldurur.
        public void UyeAidatDoldur(string tc)
        {
            DGVAidat.DataSource = LogicAidat.LLUyeAidatGetir(tc);
        }
        //-------------------------------------------------------------------------

        //Combobox'ta seçili değere göre borç öder.
        private void BtnBorcOde_Click(object sender, EventArgs e)
        {
            //Teknik olarak devam edemeyeceğim için ödeme sistemini pas geçiyorum.
            MessageBox.Show("Odeme isleminiz başarılı...","Odeme");
            LogicAidat.LLBorcOde(TbTc.Text);
            UyeBorcDoldur(TbTc.Text);
        }

        //Combobox'ta seçili değere göre aidat öder.
        private void BtnAidatOde_Click_1(object sender, EventArgs e)
        {
            //Teknik olarak devam edemeyeceğim için ödeme sistemini pas geçiyorum.
            MessageBox.Show("Odeme isleminiz başarılı...", "Odeme");
            LogicAidat.LLAidatOde(TbTc.Text);
            UyeAidatDoldur(TbTc.Text);
        }
        //-------------------------------------------------------------------------
    }
}
