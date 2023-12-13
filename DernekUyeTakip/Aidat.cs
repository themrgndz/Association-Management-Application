﻿using System;
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
        //Aidatlar ile ilgili kodlar.
        public Aidat()
        {
            InitializeComponent();

            //RichTextBox'u kısayollar ile düzenlemek için.
            TsmKalin.ShortcutKeys = Keys.Control | Keys.K; // Ctrl + K
            TsmItalik.ShortcutKeys = Keys.Control | Keys.I; // Ctrl + I
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
        //Veritabanındaki Aidat değerlerini günceller.
        public void BtnAidatBelirle_Click(object sender, EventArgs e)
        {
            if (RbTumAylar.Checked)
            {
                //Tüm aylar radio butonu etkinse bütün aylara aynı değeri giriyoruz.
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
                //Eğer belirli aylar radio butonu etkinse her ayın kendi değerini giriyoruz.
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
            
            //DataGridView'i güncelliyoruz.
            List<EntityAidat> AidatList = LogicAidat.LLDoldur();
            DgwAidatlar.DataSource = AidatList;

        }
        //---------------------------------------------------------------------------------
        //Form kapatıldığında uygulamayı da kapatır.
        public void Aidat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //---------------------------------------------------------------------------------
        //Radio butonların seçimini kontrol eder.
        public void RbBelirliAylar_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTumAylar.Checked)
            {
                TbAidatMiktari.Enabled = true;
                PnlAylar.Visible = false;
                CbYil2.BackColor = Color.White;
                TbAidatMiktari.BackColor = Color.White;
                CbYil2.Enabled = true;
            }
            else
            {
                TbAidatMiktari.Enabled = false;
                PnlAylar.Visible = true;
                CbYil2.BackColor = Color.FromArgb(48, 48, 48);
                TbAidatMiktari.BackColor = Color.FromArgb(48, 48, 48);
                TbAidatMiktari.Text = "";
                CbYil2.Enabled = false;
            }
        }
        //---------------------------------------------------------------------------------
        //Yıl seçimine bağlı olarak textboxları ayların aidat değerine göre doldurur.
        public void CbYil_SelectedIndexChanged(object sender, EventArgs e)
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
        //Metin kutusundaki seçili yerleri kalın hale çevirir.
        public void TsmKalin_Click_1(object sender, EventArgs e)
        {
            FontOzellik(FontStyle.Bold);
        }
        //---------------------------------------------------------------------------------
        //Metin kutusundaki seçili yerleri eğik hale çevirir.
        public void TsmItalik_Click(object sender, EventArgs e)
        {
            FontOzellik(FontStyle.Italic);
        }
        //---------------------------------------------------------------------------------
        //Metin kutusundaki seçili yerleri altı çizili hale çevirir.
        public void TsmAltiCizili_Click_1(object sender, EventArgs e)
        {
            FontOzellik(FontStyle.Underline);
        }
        //---------------------------------------------------------------------------------
        //Metindeki seçili yerin font ayalarını değiştirir.
        public void FontOzellik(FontStyle style)
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
        //Butona basıldığında üyelere aidat ile ilgili mail atar.
        public void BtnEposta_Click(object sender, EventArgs e)
        {

        }
        //---------------------------------------------------------------------------------
        //Form yüklendiğinde DataGridView'i Aidat tablosuna göre doldurur.
        public void Aidat_Load(object sender, EventArgs e)
        {
            List<EntityAidat> AidatList = LogicAidat.LLDoldur();
            DgwAidatlar.DataSource = AidatList;
        }
        //---------------------------------------------------------------------------------
        //Aktif üyelerin aidatlarını günceller.
        public void UyeAidatGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                //Ay ve yıl verisini alıyoruz.
                DateTime bugun = DateTime.Today;
                string ay = bugun.ToString("MMMM");
                string yil = bugun.Year.ToString();

                //Bu ayki aidat miktarını alıyoruz.
                decimal aidatMiktari = LogicAidat.LLAidatMiktariAl(ay, yil);

                if (aidatMiktari > 0)
                {
                    //Tüm aktif üyeleri çekiyoruz.
                    List<EntityUye> uyeler = DALUye.UyeListesi("AktifPasif", true);

                    foreach (EntityUye uye in uyeler)
                    {
                        //Üyenin önceki aidatını ödeyip ödemediğini kontrol ediyoruz.
                        LogicAidat.LLBorcKontrol(uye);
                        //Her bir üyenin aidat kısmına bu ayki aidatı yazıyoruz.

                    }

                    // İşlem başarılıysa
                    Console.WriteLine("Aidatlar başarıyla atandı.");
                }
                else
                {
                    Console.WriteLine("Bu ay için belirlenmiş bir aidat miktarı yok.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            //MessageBox.Show("Aidat miktarı: " + aidatMiktari.ToString() + "₺","Aidat Güncellemesi");







        }
        //---------------------------------------------------------------------------------
    }
}
