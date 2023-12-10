using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        //---------------------------------------------------------------------------------
        public Aidat()
        {
            InitializeComponent();

            //RichTextBox'u kısayollar ile düzenlemek için.
            TsmKalin.ShortcutKeys = Keys.Control | Keys.K; // Ctrl + K
            Tsmİtalik.ShortcutKeys = Keys.Control | Keys.I; // Ctrl + I
            TsmAltiCizili.ShortcutKeys = Keys.Control | Keys.U; // Ctrl + U
        }

        //---------------------------------------------------------------------------------

        //Belirtilen aidat miktarını veritanındaki aktif üyelere ekler.
        private void BtnAidatBelirle_Click(object sender, EventArgs e)
        {
            if (RbBelirliAylar.Checked)
            {
                try
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
                    MessageBox.Show(LogicAidat.LLAidatBelirle(yeniMiktarlar, CbYil.Text));

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yıllar yüklenirken hata oluştu: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(LogicAidat.LLAidatBelirle(int.Parse(TbAidatMiktari.Text),CbYil2.Text));
            }
        }

        //---------------------------------------------------------------------------------

        //Form kapatıldığında uygulamayı da kapatır
        private void Aidat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //---------------------------------------------------------------------------------

        //Radio butonların seçimini kontrol eder.
        private void RbBelirliAylar_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTumAylar.Checked)
            {
                TbAidatMiktari.Enabled = true;
                PnlAylar.Visible = false;
                TbAidatMiktari.BackColor = Color.White;
                CbYil2.Enabled = true;
            }
            else
            {
                TbAidatMiktari.Enabled = false;
                PnlAylar.Visible = true;
                TbAidatMiktari.BackColor = Color.FromArgb(48,48,48);
                TbAidatMiktari.Text = "";
                CbYil2.Enabled = false;
            }
        }

        //---------------------------------------------------------------------------------

        //Yıl seçimine bağlı olarak textboxları ayların aidat değerine göre doldurur.
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
        
        //---------------------------------------------------------------------------------
       
        private void TsmKalin_Click(object sender, EventArgs e)
        {
            FontOzellik(FontStyle.Bold);
        }

        private void Tsmİtalik_Click(object sender, EventArgs e)
        {
            FontOzellik(FontStyle.Italic);
        }

        private void TsmAltiCizili_Click(object sender, EventArgs e)
        {
            FontOzellik(FontStyle.Underline);
        }

        private void FontOzellik(FontStyle style)
        {
            int selectionStart = TbMail.SelectionStart;
            int selectionLength = TbMail.SelectionLength;

            Font currentFont = TbMail.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ style;

            Font newFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);

            TbMail.SelectionFont = newFont;

            TbMail.Select(selectionStart, selectionLength);
            TbMail.Focus();
        }

        //---------------------------------------------------------------------------------

        private void BtnEpostaGonder_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("KaynakEposta");
                mail.To.Add("HedefEposta");
                mail.Subject = "Subject";
                mail.Body = TbMail.Text;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("KaynakEposta", "Şifre");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);

                MessageBox.Show("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderirken bir hata oluştu: " + ex.Message);
            }
        }
        //---------------------------------------------------------------------------------
    }
}
