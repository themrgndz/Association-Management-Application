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
using ZedGraph;
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
            try
            {
                using (OleDbCommand command = new OleDbCommand("UPDATE Aidat SET Miktar = @YeniMiktar WHERE Yil = @SecilenYil AND Ay = @SecilenAy", Baglanti.dbc))
                {
                    // Yeni miktarları al
                    int[] yeniMiktarlar = {
                    int.Parse(TbOcak.Text),
                    int.Parse(TbSubat.Text),
                    int.Parse(TbMart.Text),
                    int.Parse(TbNisan.Text),
                    int.Parse(TbMayis.Text),
                    int.Parse(TbHaziran.Text),
                    int.Parse(TbTemmuz.Text),
                    int.Parse(TbAgustos.Text),
                    int.Parse(TbEylul.Text),
                    int.Parse(TbEkim.Text),
                    int.Parse(TbKasim.Text),
                    int.Parse(TbAralik.Text)
                };

                    // Ay için döngüyü başlatın
                    for (short i = 0; i < 12; i++)
                    {
                        // Yeni parametreleri ekleyin
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@YeniMiktar", yeniMiktarlar[i]);
                        command.Parameters.AddWithValue("@SecilenYil", CbYil.Text);
                        command.Parameters.AddWithValue("@SecilenAy", i+1);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Aidat miktarları güncellendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yıllar yüklenirken hata oluştu: " + ex.Message);
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

        private void CbYil_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand("SELECT Ay,Miktar FROM Aidat WHERE Yil = @SecilenYil", Baglanti.dbc);
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@SecilenYil", CbYil.Text);
                
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ay = Convert.ToInt32(reader["Ay"])-1;
                        decimal aidatMiktari = decimal.Parse(reader["Miktar"].ToString());

                        // TextBox'lara değerleri atama işlemi
                        switch (ay)
                        {
                            case 0:
                                TbOcak.Text = aidatMiktari.ToString();
                                break;
                            case 1:
                                TbSubat.Text = aidatMiktari.ToString();
                                break;
                            case 2:
                                TbMart.Text = aidatMiktari.ToString();
                                break;
                            case 3:
                                TbNisan.Text = aidatMiktari.ToString();
                                break;
                            case 4:
                                TbMayis.Text = aidatMiktari.ToString();
                                break;
                            case 5:
                                TbHaziran.Text = aidatMiktari.ToString();
                                break;
                            case 6:
                                TbTemmuz.Text = aidatMiktari.ToString();
                                break;
                            case 7:
                                TbAgustos.Text = aidatMiktari.ToString();
                                break;
                            case 8:
                                TbEylul.Text = aidatMiktari.ToString();
                                break;
                            case 9:
                                TbEkim.Text = aidatMiktari.ToString();
                                break;
                            case 10:
                                TbKasim.Text = aidatMiktari.ToString();
                                break;
                            case 11:
                                TbAralik.Text = aidatMiktari.ToString();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yıllar yüklenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
