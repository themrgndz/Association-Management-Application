using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using LogicLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DernekUyeTakip
{
    public partial class Aidat : Form
    {
        public Aidat()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------

        //Belirtilen aidat miktarını veritanındaki aktif üyelere ekler
        private void BtnAidatBelirle_Click(object sender, EventArgs e)
        {
            if (RbTumAylar.Checked)
            {
                try
                {
                    decimal aidatMiktar = Convert.ToDecimal(TbAidatMiktari.Text);
                    DateTime today = DateTime.Now;

                    //02.11.2023

                    foreach (EntityLayer.EntityUye uye in LogicUye.LLUyeListesi("AktifPasif", true))
                    {
                        DateTime kayitTarihi = DateTime.ParseExact(uye.KayitTarihi, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        LogicAidat.LLAidatBelirle(uye.Tc, today, aidatMiktar);
                    }

                    MessageBox.Show("Aidatlar başarıyla belirlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //------------------------------------------------------------Bu kodları LLAidat içerisine, oradan da DALAidat'a götürüp orada yaz.
                if (CbYil.Text != "")
                {
                    try
                    {
                        using (OleDbCommand cnn = new OleDbCommand("", Baglanti.dbc))
                        {
                            //-----------------------------------------------Veritabanından ayların aidat miktarını güncelleyeceksin.
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Yıl Seçiniz");
                }
            }
        }

        //---------------------------------------------------------------------------------

        //Form kapatıldığında uygulamayı da kapatır
        private void Aidat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RbBelirliAylar_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTumAylar.Checked)
            {
                TbAidatMiktari.Enabled = true;
                PnlAylar.Visible = false;
                TbAidatMiktari.BackColor = Color.White;
            }
            else
            {
                TbAidatMiktari.Enabled = false;
                PnlAylar.Visible = true;
                TbAidatMiktari.BackColor = Color.FromArgb(48,48,48);
                TbAidatMiktari.Text = "";
            }
        }
    }
}
