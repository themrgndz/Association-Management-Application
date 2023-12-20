using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using EntityLayer;
using LogicLayer;
using ZedGraph;
using System.Net.Http.Headers;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;

namespace DernekUyeTakip
{
    public partial class Aidat : Form
    {
        //---------------------------------------------------------------------------------

        //Aidatlar ile ilgili kodlar.
        public Aidat()
        {
            InitializeComponent();
            RichTextBox();
            VeriDoldur();
            DgvDoldur();
            BorcKontrol();
            SehirGrafigiDoldur();
            UyeSehirDagilimi();
        }
        //---------------------------------------------------------------------------------

        //Şehirler ve o şehre bağlı üyeleri veritabanından çekiyoruz.
        public void UyeSehirDagilimi()
        {
            // Veritabanından verileri çekiyoruz.
            Dictionary<string, int> sehirUyeSayilari = LogicAidat.GetUyeSayilariBySehir();

            // Şehirleri üye sayılarına göre sırala (en çok üyeden en aza)
            var siraliSehirUyeSayilari = sehirUyeSayilari.OrderByDescending(pair => pair.Value);

            // ZedGraph kontrolünü temizliyoruz
            ZgcSehirler.GraphPane.CurveList.Clear();

            // Grafik için bir pane oluştur
            GraphPane grafikPane = ZgcSehirler.GraphPane;
            grafikPane.Title.Text = "Üye Dağılımı";
            grafikPane.XAxis.Title.Text = "Şehir";
            grafikPane.YAxis.Title.Text = "Üye Sayısı";

            // Bar tipinde bir çubuk grafik oluştur
            double[] sehirUye = siraliSehirUyeSayilari.Select(pair => (double)pair.Value).ToArray();
            BarItem barGrafik = grafikPane.AddBar("Üye Sayısı", null, sehirUye, Color.DarkRed);
            barGrafik.Bar.Fill.Type = FillType.Solid;

            // X ekseni etiketlerini şehir isimleri olarak ayarla
            grafikPane.XAxis.Scale.TextLabels = siraliSehirUyeSayilari.Select(pair => pair.Key).ToArray();
            grafikPane.XAxis.Type = AxisType.Text;

            // Grafik kontrolünü yeniden çiz
            ZgcSehirler.AxisChange();
            ZgcSehirler.Invalidate();
        }
        //---------------------------------------------------------------------------------

        public void SehirGrafigiDoldur()
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT Sehir, COUNT(*) AS UyeSayisi FROM Uye GROUP BY Sehir", Baglanti.dbc))
            {
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        // ZedGraph veri noktalarını tutacak listeler
                        List<string> sehirler = new List<string>();
                        List<double> uyeSayilari = new List<double>();

                        while (reader.Read())
                        {
                            string sehir = reader["Sehir"].ToString();

                            // Try-catch bloğu ile dönüştürme hatasını kontrol etme
                            try
                            {
                                double uyeSayisi = Convert.ToDouble(reader["UyeSayisi"]);
                                uyeSayilari.Add(uyeSayisi);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Dönüştürme hatası: {ex.Message}");
                            }

                            sehirler.Add(sehir);
                        }

                        // ZedGraph grafik oluşturma
                    }
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

        //Her ay sonu borç kontrolü yapar
        public void BorcKontrol()
        {
            DateTime now = DateTime.Now;

            int Gunumuz = now.Day;
            int AyinSonGunu = DateTime.DaysInMonth(now.Year, now.Month);
            LogicAidat.LLOdenmemisAidatKontrol(AyinSonGunu.ToString(), Gunumuz.ToString());
        }
        //---------------------------------------------------------------------------------

        //DataGridView'e UyeAidat listesini getirir.
        public void DgvDoldur()
        {
            DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir();
        }
        //---------------------------------------------------------------------------------

        //Combobox'lara veritabanındaki yılları ekliyor.
        public void VeriDoldur()
        {
            List<EntityAidat> aidatlar = LogicAidat.LLAyAidatDoldur();
            foreach (var i in aidatlar)
            {
                CbYil.Items.Add(i.Yil);
                CbYil2.Items.Add(i.Yil);
            }
        }
        //---------------------------------------------------------------------------------

        //RichTextBox'u kısayollar ile düzenlemek için.
        public void RichTextBox()
        {
            TsmKalin.ShortcutKeys = Keys.Control | Keys.K; // Ctrl + K
            TsmItalik.ShortcutKeys = Keys.Control | Keys.I; // Ctrl + I
            TsmAltiCizili.ShortcutKeys = Keys.Control | Keys.U; // Ctrl + U
        }
        //---------------------------------------------------------------------------------

        //Veritabanındaki Aidat değerlerini günceller.
        public void BtnAidatBelirle_Click(object sender, EventArgs e)
        {
            try
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
                List<EntityAidat> AidatList = LogicAidat.LLAyAidatDoldur();
                DgwAidatlar.DataSource = AidatList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen doğru işlem yapın. Hata: " + ex.Message, "Hata!");
            }
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
            List<EntityAidat> aidatlar = LogicAidat.LLAyAidatDoldur(CbYil.Text);
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
            //E posta içeriği
            string konu;
            string mail = TbMail.Text;
            switch (CbKonu.SelectedIndex)
            {
                case 0:
                    konu = "Aylık aidat hatırlatması.";
                    MessageBox.Show(LogicAidat.LLMailGonder(konu, mail,0));
                    break;
                case 1:
                    konu = "Borç hatırlatması.";
                    MessageBox.Show(LogicAidat.LLMailGonder(konu, mail, 1));
                    break;
                default:
                    konu = "";
                    break;
            }
            // E-posta gönderme işlemi
           // MessageBox.Show(LogicAidat.LLMailGonder(konu, mail));
        }
        //---------------------------------------------------------------------------------

        //Form yüklendiğinde DataGridView'i Aidat tablosuna göre doldurur.
        public void Aidat_Load(object sender, EventArgs e)
        {
            List<EntityAidat> AidatList = LogicAidat.LLAyAidatDoldur();
            DgwAidatlar.DataSource = AidatList;
            BorcGetir();
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

                //Aktif üyelere bu ayki aidat miktarını ekliyoruz.
                LogicAidat.LLUyeAidatEkle(aidatMiktari);

                if (LogicAidat.LLAidatKayit(DateTime.Now.ToString("d"), aidatMiktari))
                {
                    MessageBox.Show("Başarılı", "Veritabanı kaydı");
                }
                else
                {
                    MessageBox.Show("Başarısız", "Veritabanı kaydı");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata");
            }
        }
        //---------------------------------------------------------------------------------

        //Mail konusunun seçimine göre içerik metninin değişmesini sağlar.
        public void CbKonu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CbKonu.SelectedIndex)
            {
                case 0:
                    TbMail.Text = "Değerli üyemiz,\r\n\r\nBu mesajla size bu dönemin aidatını hatırlatmak istiyoruz. Ödemelerinizi aylık süreçte yapmanız önemlidir.\r\n\r\nKatılımınız ve desteklerinizle derneğimiz, topluma daha fazla hizmet etme fırsatı bulacaktır. Sorularınız veya yardım ihtiyaçlarınız için bize her zaman ulaşabilirsiniz.\r\n\r\nTeşekkür ederiz...";
                    break;
                case 1:
                    TbMail.Text = "Değerli üyemiz,\r\n\r\nBorcunuz bulunmaktadır. Ödemelerinizi aylık süreçte yapmanız önemlidir.\r\n\r\nKatılımınız ve desteklerinizle derneğimiz, topluma daha fazla hizmet etme fırsatı bulacaktır. \r\nSorularınız veya yardım ihtiyaçlarınız için bize her zaman ulaşabilirsiniz.\r\n\r\nTeşekkür ederiz...";
                    break;
                default:
                    break;
            }
        }
        //---------------------------------------------------------------------------------

        //UyeAidat tablosunu isterlere göre DataGridView'e aktarır.
        public void CbAidatTablosu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CTcFiltrele.Checked)
            {
                switch (CbUyeAidat.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir();
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(true);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(false);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
            else
            {
                switch (CbUyeAidat.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(TbAidatTc.Text);
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(true, TbAidatTc.Text);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(false, TbAidatTc.Text);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Checkbox'un durumuna göre değişiklikler yapar.
        public void CTcFiltrele_CheckedChanged(object sender, EventArgs e)
        {
            if (CTcFiltrele.Checked)
            {
                TbAidatTc.Enabled = true;
            }
            else
            {
                TbAidatTc.Enabled = false;
                TbAidatTc.Text = "";
            }
        }
        //---------------------------------------------------------------------------------

        //DataGridView'i Tc'ye göre filtrele
        public void TbAidatTc_TextChanged(object sender, EventArgs e)
        {
            if (!CTcFiltrele.Checked)
            {
                switch (CbUyeAidat.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir();
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(true);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(false);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
            else
            {
                switch (CbUyeAidat.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(TbAidatTc.Text);
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(true, TbAidatTc.Text);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DgvAidat.DataSource = LogicAidat.LLUyeAidatGetir(false, TbAidatTc.Text);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
        }
        //---------------------------------------------------------------------------------

        //DGVBorc'a borç verilerini getirir.
        public void BorcGetir()
        {
            DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir();
        }
        //---------------------------------------------------------------------------------

        //Combobox'ta seçilen veriye göre borç listelemesi yapar.
        public void CbBorc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CTcFiltrele.Checked)
            {
                switch (CbBorc.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir();
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(true);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(false);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
            else
            {
                switch (CbBorc.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(TbAidatTc.Text);
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(true, TbAidatTc.Text);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(false, TbAidatTc.Text);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Borc sekmesindeki checkbox'ın durumuna göre filtreleme ön hazırlığı yapıyor.
        public void CbTcFiltrele_CheckedChanged(object sender, EventArgs e)
        {
            if (CbTcFiltrele.Checked)
            {
                TbBorc.Enabled = true;
            }
            else
            {
                TbBorc.Enabled = false;
                TbBorc.Text = "";
            }
        }
        //---------------------------------------------------------------------------------

        //Borc sekmesindeki checkbox'ın durumuna göre tc numarasını filtreliyor.
        public void TbBorc_TextChanged(object sender, EventArgs e)
        {
            if (!CbTcFiltrele.Checked)
            {
                switch (CbBorc.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir();
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(true);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(false);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
            else
            {
                switch (CbBorc.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(TbBorc.Text);
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(true, TbBorc.Text);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        DGVBorc.DataSource = LogicAidat.LLUyeBorcGetir(false, TbBorc.Text);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
        }
        //---------------------------------------------------------------------------------

        //Butona basılınca Borçluları pdf halinde kaydeder.
        private void BtnPdf_Click(object sender, EventArgs e)
        {
            // DALAidat sınıfından seçili özelliklere göre veri al
            List<EntityBorc> borcListesi = new List<EntityBorc>();
            if (!CbTcFiltrele.Checked)
            {
                switch (CbBorc.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        borcListesi = LogicAidat.LLUyeBorcGetir();
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        borcListesi = LogicAidat.LLUyeBorcGetir(true);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        borcListesi = LogicAidat.LLUyeBorcGetir(false);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }
            else
            {
                switch (CbBorc.SelectedIndex)
                {
                    //Tüm Aidatlar
                    case 0:
                        borcListesi = LogicAidat.LLUyeBorcGetir(TbBorc.Text);
                        break;
                    //Ödenmiş Aidatlar
                    case 1:
                        borcListesi = LogicAidat.LLUyeBorcGetir(true, TbBorc.Text);
                        break;
                    //Ödenmemiş Aidatlar
                    case 2:
                        borcListesi = LogicAidat.LLUyeBorcGetir(false, TbBorc.Text);
                        break;
                    default:
                        MessageBox.Show("İşlem başarısız: Lütfen bir şey seçin!", "Uyarı");
                        break;
                }
            }

            // SaveFileDialog oluştur
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyaları|*.pdf";
            saveFileDialog.Title = "PDF Dosyasını Kaydet";

            // Kullanıcı kaydetmeyi seçerse devam et
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosya adını al
                string pdfDosyaYolu = saveFileDialog.FileName;

                // PDF oluştur ve kaydet
                LogicAidat.LLPdfOlustur(borcListesi,pdfDosyaYolu);
            }
        }
        //---------------------------------------------------------------------------------

        //Butona tıklandığında seçili tarihler aralığında ödenmiş/odenmemiş borçları getirir.
        private void BtnBorcGetir_Click(object sender, EventArgs e)
        {
            DGVBorc.DataSource = LogicAidat.LLBorcGetir(DTPBorcBaslangic.Value, DTPBorcSon.Value, RbBorcOdemis.Checked);
        }
        //---------------------------------------------------------------------------------

        //Butona tıklandığında seçili tarihler aralığında ödenmiş/ödenmemiş aidatları getirir.
        private void BtnAidatGetir_Click(object sender, EventArgs e)
        {
            DgvAidat.DataSource = LogicAidat.LLAidatGetir(DTPAidatBaslangic.Value, DTPAidatSon.Value, RbAidatOdemis.Checked);
        }
        //---------------------------------------------------------------------------------

        //Seçilen duruma göre grafik hazırlama sürecini kontrol eder.
        public void CbGrafik_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CbGrafik.SelectedIndex)
            {
                case 0:
                    CbAylar.Visible = false;
                    CbAylar.Enabled = false;
                    break;
                case 1:
                    CbAylar.Visible = true;
                    CbAylar.Enabled = true;
                    break;
                default:
                    MessageBox.Show("Doğru şekilde veri seçin.","Hata");
                    break;
            }
        }
        //---------------------------------------------------------------------------------

        //Seçilen duruma göre grafik hazırlama sürecini kontrol eder.
        private void BtnGrafikCiz_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime simdikiTarih = DateTime.Now;
                switch (CbGrafik.SelectedIndex)
                {
                    case 0:

                        DateTime yilinIlkGunu = new DateTime(simdikiTarih.Year, 1, 1);
                        DateTime yilinSonGunu = new DateTime(simdikiTarih.Year, 12, 31);

                        GrafikVerileriHazirla(yilinIlkGunu.ToString("d"), yilinSonGunu.ToString("d"));

                        break;
                    case 1:
                        switch (CbAylar.SelectedIndex)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                                // Seçilen ayın ilk günü ve son gününü belirler.
                                int secilenAy = CbAylar.SelectedIndex + 1;
                                DateTime secilenAyinIlkGunu = new DateTime(simdikiTarih.Year, secilenAy, 1);
                                DateTime secilenAyinSonGunu = new DateTime(simdikiTarih.Year, secilenAy, DateTime.DaysInMonth(simdikiTarih.Year, secilenAy));

                                GrafikVerileriHazirla(secilenAyinIlkGunu.ToString("d"), secilenAyinSonGunu.ToString("d"));
                                break;
                            
                            default:
                                MessageBox.Show("Ay doğru seçilmedi.", "Hata");
                                break;
                        }
                        
                        break;
                    default:
                        MessageBox.Show("Veriler doğru seçilmedi.", "Hata");
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //---------------------------------------------------------------------------------

        //Gelir tablosunun ön hazırlığını yapar.
        public string GrafikVerileriHazirla(string baslangic,string son)
        {
            List<int> veriler = new List<int>();
            using (OleDbCommand cmd = new OleDbCommand("SELECT AidatMiktari FROM UyeAidat WHERE OdemeTarihi BETWEEN @BaslangicTarihi AND @BitisTarihi", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@BaslangicTarihi", baslangic);
                cmd.Parameters.AddWithValue("@BitisTarihi", son);
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            veriler.Add(int.Parse(dr["AidatMiktari"].ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            if (CbGrafik.SelectedIndex == 0)
            {
                GrafikOlustur(veriler, "Yıllık");
            }
            else
            {
                GrafikOlustur(veriler, CbAylar.SelectedItem.ToString());
            }

            return "";
        //---------------------------------------------------------------------------------
        }
        //---------------------------------------------------------------------------------

        //Yıllık veya aylık olarak gelir tablosu çıkartır.
        public void GrafikOlustur(List<int> gelirVerileri, string secilenAy)
        {
            // ZedGraphControl'un GraphPane özelliğini kullanarak grafikle ilgili işlemleri gerçekleştirebilirsiniz
            GraphPane myPane = ZgAidat.GraphPane;
            myPane.CurveList.Clear(); // Önceki grafikleri temizleyelim

            // Grafik başlığı
            myPane.Title.Text = $"Aidat Gelir Grafiği ({secilenAy})";

            // Eksen etiketleri
            myPane.XAxis.Title.Text = "Aylar";
            myPane.YAxis.Title.Text = "Gelir Miktarı";

            // Verileri grafiğe ekleyelim
            PointPairList pointPairList = new PointPairList();
            int toplamgelir = 0;
            for (int i = 0; i < gelirVerileri.Count; i++)
            {
                toplamgelir += gelirVerileri[i];
                pointPairList.Add(i + 1, toplamgelir); // X eksenine ayları, Y eksenine gelir miktarını ekleyelim
            }

            // Çizgi tipi ve renk
            LineItem myCurve = myPane.AddCurve("Aidat Geliri", pointPairList, Color.Red, SymbolType.Circle);
            myCurve.Line.Width = 2;

            // Eksendeki ayları güncelleyelim
            myPane.XAxis.Scale.TextLabels = new string[] { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };

            // Grafik kontrolünü güncelleyelim
            ZgAidat.AxisChange();
            ZgAidat.Invalidate();
        }
        //---------------------------------------------------------------------------------
    }
}
