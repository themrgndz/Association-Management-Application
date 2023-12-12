using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using EntityLayer;
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

            //Combobox'lara veritabanındaki yılları ekliyor.
            List<EntityAidat> aidatlar = new List<EntityAidat>();
            aidatlar = LogicAidat.LLDoldur();
            foreach (var i in aidatlar)
            {
                CbYil.Items.Add(i.Yil);
                CbYil2.Items.Add(i.Yil);
            }
        }
        //---------------------------------------------------------------------------------
        private void BtnAidatBelirle_Click(object sender, EventArgs e)
        {
            if (RbTumAylar.Checked)
            {
                EntityAidat ent = new EntityAidat();

                ent.Yil = short.Parse(CbYil2.Text);
                ent.Ocak = decimal.Parse(TbAidatMiktari.Text);
                ent.Subat = decimal.Parse(TbAidatMiktari.Text);
                ent.Mart = decimal.Parse(TbAidatMiktari.Text);
                ent.Nisan = decimal.Parse(TbAidatMiktari.Text);
                ent.Mayis = decimal.Parse(TbAidatMiktari.Text);
                ent.Haziran = decimal.Parse(TbAidatMiktari.Text);
                ent.Temmuz = decimal.Parse(TbAidatMiktari.Text);
                ent.Agustos = decimal.Parse(TbAidatMiktari.Text);
                ent.Eylul = decimal.Parse(TbAidatMiktari.Text);
                ent.Ekim = decimal.Parse(TbAidatMiktari.Text);
                ent.Kasim = decimal.Parse(TbAidatMiktari.Text);
                ent.Aralik = decimal.Parse(TbAidatMiktari.Text);

                MessageBox.Show(LogicAidat.LLAidatBelirle(ent));
                
            }
            else
            {
                EntityAidat ent = new EntityAidat();

                ent.Yil = short.Parse(CbYil.Text);
                ent.Ocak = decimal.Parse(TbOcak.Text);
                ent.Subat = decimal.Parse(TbSubat.Text);
                ent.Mart = decimal.Parse(TbMart.Text);
                ent.Nisan = decimal.Parse(TbNisan.Text);
                ent.Mayis = decimal.Parse(TbMayis.Text);
                ent.Haziran = decimal.Parse(TbHaziran.Text);
                ent.Temmuz = decimal.Parse(TbTemmuz.Text);
                ent.Agustos = decimal.Parse(TbAgustos.Text);
                ent.Eylul = decimal.Parse(TbEylul.Text);
                ent.Ekim = decimal.Parse(TbEkim.Text);
                ent.Kasim = decimal.Parse(TbKasim.Text);
                ent.Aralik = decimal.Parse(TbAralik.Text);


                MessageBox.Show(LogicAidat.LLAidatBelirle(ent));

            }
        }
        //---------------------------------------------------------------------------------
        //Form kapatıldığında uygulamayı da kapatır.
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
            List<EntityAidat> aidatlar = new List<EntityAidat>();
            aidatlar = LogicAidat.LLDoldur(CbYil.Text);
            foreach (var i in aidatlar)
            {
                TbOcak.Text = i.Ocak.ToString();
                TbSubat.Text = i.Subat.ToString();
                TbMart.Text = i.Mart.ToString();
                TbNisan.Text = i.Nisan.ToString();
                TbMayis.Text = i.Mayis.ToString();
                TbHaziran.Text = i.Haziran.ToString();
                TbTemmuz.Text = i.Temmuz.ToString();
                TbAgustos.Text = i.Agustos.ToString();
                TbEylul.Text = i.Eylul.ToString();
                TbEkim.Text = i.Ekim.ToString();
                TbKasim.Text = i.Kasim.ToString();
                TbAralik.Text = i.Aralik.ToString();
            }
            aidatlar.Clear();
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
            
        }
        //---------------------------------------------------------------------------------
    }
}
