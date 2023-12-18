using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfDocument = PdfSharpCore.Pdf.PdfDocument;
using PdfPage = PdfSharpCore.Pdf.PdfPage;

namespace DataAccessLayer
{
    public class DALAidat
    {
        //Bütün verileri çeker.
        public static List<EntityAidat> DALAyAidatDoldur()
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Aidat", Baglanti.dbc))
            {
                List<EntityAidat> aidatlar = new List<EntityAidat>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityAidat ent = new EntityAidat();
                        ent.Yil = short.Parse(dr["Yil"].ToString());
                        ent.Ocak = decimal.Parse(dr["Ocak"].ToString());
                        ent.Subat = decimal.Parse(dr["Subat"].ToString());
                        ent.Mart = decimal.Parse(dr["Mart"].ToString());
                        ent.Nisan = decimal.Parse(dr["Nisan"].ToString());
                        ent.Mayis = decimal.Parse(dr["Mayis"].ToString());
                        ent.Haziran = decimal.Parse(dr["Haziran"].ToString());
                        ent.Temmuz = decimal.Parse(dr["Temmuz"].ToString());
                        ent.Agustos = decimal.Parse(dr["Agustos"].ToString());
                        ent.Eylul = decimal.Parse(dr["Eylul"].ToString());
                        ent.Ekim = decimal.Parse(dr["Ekim"].ToString());
                        ent.Kasim = decimal.Parse(dr["Kasim"].ToString());
                        ent.Aralik = decimal.Parse(dr["Aralik"].ToString());

                        aidatlar.Add(ent);
                    }
                    dr.Close();
                    return aidatlar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Verilen yıla göre tüm verileri çeker.
        public static List<EntityAidat> DALAyAidatDoldur(string yil)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Aidat WHERE Yil = @Yil", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@Yil", yil);

                List<EntityAidat> aidatlar = new List<EntityAidat>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityAidat ent = new EntityAidat();
                        ent.Yil = short.Parse(dr["Yil"].ToString());
                        ent.Ocak = decimal.Parse(dr["Ocak"].ToString());
                        ent.Subat = decimal.Parse(dr["Subat"].ToString());
                        ent.Mart = decimal.Parse(dr["Mart"].ToString());
                        ent.Nisan = decimal.Parse(dr["Nisan"].ToString());
                        ent.Mayis = decimal.Parse(dr["Mayis"].ToString());
                        ent.Haziran = decimal.Parse(dr["Haziran"].ToString());
                        ent.Temmuz = decimal.Parse(dr["Temmuz"].ToString());
                        ent.Agustos = decimal.Parse(dr["Agustos"].ToString());
                        ent.Eylul = decimal.Parse(dr["Eylul"].ToString());
                        ent.Ekim = decimal.Parse(dr["Ekim"].ToString());
                        ent.Kasim = decimal.Parse(dr["Kasim"].ToString());
                        ent.Aralik = decimal.Parse(dr["Aralik"].ToString());

                        aidatlar.Add(ent);
                    }
                    dr.Close();
                    return aidatlar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Girilen değerlere göre aidat değerlerini günceller.
        public static string AidatBelirle(EntityAidat aidatlar)
        {
            using (OleDbCommand cmd = new OleDbCommand("UPDATE Aidat SET Ocak = @P1, Subat = @P2, Mart = @P3, Nisan = @P4, Mayis = @P5, Haziran = @P6, Temmuz = @P7, Agustos = @P8, Eylul = @P9, Ekim = @P10, Kasim = @P11, Aralik = @P12 WHERE Yil = @P13", Baglanti.dbc))
            {
                try
                {
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    cmd.Parameters.AddWithValue("@P1", aidatlar.Ocak);
                    cmd.Parameters.AddWithValue("@P2", aidatlar.Subat);
                    cmd.Parameters.AddWithValue("@P3", aidatlar.Mart);
                    cmd.Parameters.AddWithValue("@P4", aidatlar.Nisan);
                    cmd.Parameters.AddWithValue("@P5", aidatlar.Mayis);
                    cmd.Parameters.AddWithValue("@P6", aidatlar.Haziran);
                    cmd.Parameters.AddWithValue("@P7", aidatlar.Temmuz);
                    cmd.Parameters.AddWithValue("@P8", aidatlar.Agustos);
                    cmd.Parameters.AddWithValue("@P9", aidatlar.Eylul);
                    cmd.Parameters.AddWithValue("@P10", aidatlar.Ekim);
                    cmd.Parameters.AddWithValue("@P11", aidatlar.Kasim);
                    cmd.Parameters.AddWithValue("@P12", aidatlar.Aralik);
                    cmd.Parameters.AddWithValue("@P13", aidatlar.Yil);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return "Güncelleme işlemi başarılı";
                    }
                    else
                    {
                        return "Değişiklik yapılmamıştır.";
                    }
                }
                catch (Exception e)
                {
                    return "Hata: " + e.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Bulunan aya göre aidat miktarı çek.
        public static decimal AidatMiktariAl(string ay, string yil)
        {
            try
            {
                List<EntityAidat> aidatlar = new List<EntityAidat>();

                decimal deneme = -1;

                aidatlar = DALAyAidatDoldur(yil);

                foreach (var item in aidatlar)
                {
                    switch (ay)
                    {
                        case "Ocak":
                            deneme = item.Ocak;
                            break;
                        case "Şubat":
                            deneme = item.Subat;
                            break;
                        case "Mart":
                            deneme = item.Mart;
                            break;
                        case "Nisan":
                            deneme = item.Nisan;
                            break;
                        case "Mayıs":
                            deneme = item.Mayis;
                            break;
                        case "Haziran":
                            deneme = item.Haziran;
                            break;
                        case "Temmuz":
                            deneme = item.Temmuz;
                            break;
                        case "Ağustos":
                            deneme = item.Agustos;
                            break;
                        case "Eylül":
                            deneme = item.Eylul;
                            break;
                        case "Ekim":
                            deneme = item.Ekim;
                            break;
                        case "Kasım":
                            deneme = item.Kasim;
                            break;
                        case "Aralık":
                            deneme = item.Aralik;
                            break;
                        default:
                            break;
                    }
                    return deneme;
                }

                return deneme;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Aktif üyelere o ayki aidat değerini girer.
        public static void UyeAidatEkle(decimal aidatMiktari)
        {
            if (aidatMiktari > 0)
            {
                using (OleDbCommand cmd = new OleDbCommand("UPDATE Uye SET Aidat = @P1 WHERE AktifPasif = @P2", Baglanti.dbc))
                {
                    try
                    {

                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }

                        cmd.Parameters.AddWithValue("@P1",aidatMiktari);
                        cmd.Parameters.AddWithValue("@P2",true);
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        //UyeAidat tablosuna aidat kayıtlarını ekler.
        public static bool AidatKayit(string tarih, decimal aidatMiktari)
        {
            List<EntityUye> Uyeler = DALUye.UyeListesi("AktifPasif",true);
            foreach (var i in Uyeler)
            {
                using (OleDbCommand cmd = new OleDbCommand("INSERT INTO UyeAidat(Tc,AidatMiktari,AidatTarihi,Odendi,EPosta) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", Baglanti.dbc))
                {
                    try
                    {

                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }

                        cmd.Parameters.AddWithValue("@P1", i.Tc);
                        cmd.Parameters.AddWithValue("@P2", aidatMiktari);
                        cmd.Parameters.AddWithValue("@P3", tarih);
                        cmd.Parameters.AddWithValue("@P4", false);
                        cmd.Parameters.AddWithValue("@P5", "Odenmedi");
                        cmd.Parameters.AddWithValue("@P6", i.Eposta);

                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            return true;
        }

        //Butona tıklandığında Mail başlığı ve içeriğine göre aktif üyelere mail atar.
        public static string AidatMailGonder(string konu, string mail)
        {
            try
            {
                // Gönderen e-posta adresi ve uygulama şifresi
                string GonderenMail = "dugorselprogramlama@gmail.com";
                string GonderenSifre = "rkbn sgit zkox diwf";

                // SMTP sunucu ayarları
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(GonderenMail, GonderenSifre);
                smtpClient.EnableSsl = true;

                // Alıcı e-posta adresi
                List<EntityBorc> borclar = DALAidat.UyeBorcGetir();
                List<string> mailler = new List<string>();
                foreach (var borc in borclar)
                {
                    mailler.Add(borc.EPosta);
                }

                foreach (var Alanmail in mailler)
                {
                    // Gönderen ve alıcı e-posta adresleri
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(GonderenMail);
                    mailMessage.To.Add(Alanmail);

                    // E-posta konu ve içeriği
                    mailMessage.Subject = konu;
                    mailMessage.Body = mail;

                    // E-posta gönderme işlemi
                    smtpClient.Send(mailMessage);

                }
                return "E-posta başarıyla gönderildi.";

            }
            catch (Exception ex)
            {
                return "E-posta başarıyla gönderildi. " + ex.Message;
            }
        }
        
        //Butona tıklandığında Mail başlığı ve içeriğine göre aktif üyelere mail atar.
        public static string BorcMailGonder(string konu, string mail)
        {
            try
            {
                // Gönderen e-posta adresi ve uygulama şifresi
                string GonderenMail = "dugorselprogramlama@gmail.com";
                string GonderenSifre = "rkbn sgit zkox diwf";

                // SMTP sunucu ayarları
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(GonderenMail, GonderenSifre);
                smtpClient.EnableSsl = true;

                // Alıcı e-posta adresi
                List<EntityUyeAidat> aidatlar = DALAidat.UyeAidatGetir();
                List<string> mailler = new List<string>();
                foreach (var aidat in aidatlar)
                {
                    mailler.Add(aidat.EPosta);
                }

                foreach (var Alanmail in mailler)
                {
                    // Gönderen ve alıcı e-posta adresleri
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(GonderenMail);
                    mailMessage.To.Add(Alanmail);

                    // E-posta konu ve içeriği
                    mailMessage.Subject = konu;
                    mailMessage.Body = mail;

                    // E-posta gönderme işlemi
                    smtpClient.Send(mailMessage);

                }
                return "E-posta başarıyla gönderildi.";

            }
            catch (Exception ex)
            {
                return "E-posta başarıyla gönderildi. " + ex.Message;
            }
        }

        //UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> UyeAidatGetir()
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM UyeAidat", Baglanti.dbc))
            {
                List<EntityUyeAidat> aidatlar = new List<EntityUyeAidat>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityUyeAidat ent = new EntityUyeAidat();

                        ent.AidatId = dr["AidatId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.AidatMiktari = int.Parse(dr["AidatMiktari"].ToString());
                        ent.AidatTarihi = dr["AidatTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        aidatlar.Add(ent);
                    }
                    dr.Close();
                    return aidatlar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Verilen Tc'ye göre UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> UyeAidatGetir(string Tc)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM UyeAidat WHERE Tc LIKE @P1", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1",Tc + "%");
                List<EntityUyeAidat> aidatlar = new List<EntityUyeAidat>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityUyeAidat ent = new EntityUyeAidat();

                        ent.AidatId = dr["AidatId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.AidatMiktari = int.Parse(dr["AidatMiktari"].ToString());
                        ent.AidatTarihi = dr["AidatTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        aidatlar.Add(ent);
                    }
                    dr.Close();
                    return aidatlar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //UyeAidat tablosundaki odenmiş/odenmemiş verileri çeker.
        public static List<EntityUyeAidat> UyeAidatGetir(bool odendi)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM UyeAidat WHERE Odendi = @P1", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1", odendi);

                List<EntityUyeAidat> aidatlar = new List<EntityUyeAidat>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityUyeAidat ent = new EntityUyeAidat();

                        ent.AidatId = dr["AidatId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.AidatMiktari = int.Parse(dr["AidatMiktari"].ToString());
                        ent.AidatTarihi = dr["AidatTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        aidatlar.Add(ent);
                    }
                    dr.Close();
                    return aidatlar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Verilen Tc ve Odeme durumuna göre UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> UyeAidatGetir(bool odendi, string Tc)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM UyeAidat WHERE Odendi = @P1 AND Tc LIKE @P2", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1", odendi);
                cmd.Parameters.AddWithValue("@P2", Tc + "%"); 

                List<EntityUyeAidat> aidatlar = new List<EntityUyeAidat>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityUyeAidat ent = new EntityUyeAidat();

                        ent.AidatId = dr["AidatId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.AidatMiktari = int.Parse(dr["AidatMiktari"].ToString());
                        ent.AidatTarihi = dr["AidatTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        aidatlar.Add(ent);
                    }
                    dr.Close();
                    return aidatlar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Borc tablosundaki verileri çeker.
        public static List<EntityBorc> UyeBorcGetir()
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Borc", Baglanti.dbc))
            {
                List<EntityBorc> borclar = new List<EntityBorc>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityBorc ent = new EntityBorc();

                        ent.BorcId = dr["BorcId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.BorcMiktari = int.Parse(dr["BorcMiktari"].ToString());
                        ent.BorcTarihi = dr["BorcTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        borclar.Add(ent);
                    }
                    dr.Close();
                    return borclar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Verilen tc'ye göre veritabanından borçları çeker.
        public static List<EntityBorc> UyeBorcGetir(string tc)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Borc WHERE Tc LIKE @P1",Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1", tc + "%");
                List<EntityBorc> borclar = new List<EntityBorc>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse bağlantıyı aç.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EntityBorc ent = new EntityBorc();

                        ent.BorcId = dr["BorcId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.BorcMiktari = int.Parse(dr["BorcMiktari"].ToString());
                        ent.BorcTarihi = dr["BorcTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        borclar.Add(ent);
                    }
                    dr.Close();
                    return borclar;
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

        //Odendi bilgisine göre veritabanından borçları çeker.
        public static List<EntityBorc> UyeBorcGetir(bool odendi)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Borc WHERE Odendi = @P1", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1", odendi);
                List<EntityBorc> borclar = new List<EntityBorc>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse bağlantıyı aç.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EntityBorc ent = new EntityBorc();

                        ent.BorcId = dr["BorcId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.BorcMiktari = int.Parse(dr["BorcMiktari"].ToString());
                        ent.BorcTarihi = dr["BorcTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        borclar.Add(ent);
                    }
                    dr.Close();
                    return borclar;
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

        //Borc tablosundaki verileri çeker.
        public static List<EntityBorc> UyeBorcGetir(bool odendi, string tc)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Borc WHERE Tc LIKE @P1 AND Odendi = @P2", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@P1", tc + "%");
                cmd.Parameters.AddWithValue("@P2",odendi);
                List<EntityBorc> borclar = new List<EntityBorc>();
                try
                {
                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityBorc ent = new EntityBorc();

                        ent.BorcId = dr["BorcId"].ToString();
                        ent.Tc = dr["Tc"].ToString();
                        ent.BorcMiktari = int.Parse(dr["BorcMiktari"].ToString());
                        ent.BorcTarihi = dr["BorcTarihi"].ToString();
                        ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                        ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                        ent.EPosta = dr["EPosta"].ToString();

                        borclar.Add(ent);
                    }
                    dr.Close();
                    return borclar;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        //Aidat kontrolü yapılan üyenin UyeAidat tablosundaki verilerini siler.
        public static void UyeAidatSil(List<EntityUyeAidat> aidatlar)
        {
            using (OleDbTransaction transaction = Baglanti.dbc.BeginTransaction())
            {
                using (OleDbCommand cmd = new OleDbCommand("DELETE FROM UyeAidat WHERE AidatId = @AidatId", Baglanti.dbc, transaction))
                {
                    try
                    {
                        if (cmd.Connection.State != ConnectionState.Open)
                        {
                            cmd.Connection.Open();
                        }

                        foreach (var i in aidatlar)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@AidatId", i.AidatId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Hata olmadığında işlemi onaylar.
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda geri alır.
                        transaction.Rollback();
                        throw new Exception("Transaction işlemi sırasında bir hata oluştu.", ex);
                    }
                }
            }
        }

        //Aidat kontrolü yapılan üyenin ödenmemiş aidatını Borç tablosuna ekler.
        public static void BorcEkle(List<EntityUyeAidat> aidatlar)
        {
            foreach (var i in aidatlar)
            {
                using (OleDbCommand KontrolCmd = new OleDbCommand("SELECT COUNT(*) FROM Borc WHERE Tc = @P1", Baglanti.dbc))
                {
                    try
                    {
                        if (KontrolCmd.Connection.State != ConnectionState.Open)
                        {
                            KontrolCmd.Connection.Open();
                        }

                        KontrolCmd.Parameters.AddWithValue("@P1", i.Tc);

                        int VeritabanindaKacTane = (int)KontrolCmd.ExecuteScalar();

                        if (VeritabanindaKacTane > 0)
                        {
                            // Eğer aynı Tc'ye sahip kayıt varsa, güncelleme yap
                            using (OleDbCommand GuncelleCmd = new OleDbCommand("UPDATE Borc SET BorcMiktari = BorcMiktari + @P1, BorcTarihi = @P2 WHERE Tc = @P3", Baglanti.dbc))
                            {
                                GuncelleCmd.Parameters.AddWithValue("@P2", i.AidatMiktari);
                                GuncelleCmd.Parameters.AddWithValue("@P1", DateTime.Now.ToString("d"));
                                GuncelleCmd.Parameters.AddWithValue("@P3", i.Tc);

                                GuncelleCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Eğer aynı Tc'ye sahip kayıt yoksa, yeni kayıt ekle
                            using (OleDbCommand insertCmd = new OleDbCommand("INSERT INTO Borc(Tc,BorcMiktari,BorcTarihi,Odendi,OdemeTarihi, EPosta) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", Baglanti.dbc))
                            {
                                DateTime dt = DateTime.Now;

                                insertCmd.Parameters.AddWithValue("@P1", i.Tc);
                                insertCmd.Parameters.AddWithValue("@P2", i.AidatMiktari);
                                insertCmd.Parameters.AddWithValue("@P3", dt.ToString("d"));
                                insertCmd.Parameters.AddWithValue("@P4", false);
                                insertCmd.Parameters.AddWithValue("@P5", "0");
                                insertCmd.Parameters.AddWithValue("@P6", i.EPosta);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        //Aidatları ödemeyen kişilerin borçlarını günceller ve aidat kaydını siler.
        public static void OdenmemisAidatKontrol(bool odeme)
        {
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM UyeAidat WHERE Odendi = @P1", Baglanti.dbc))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@P1", odeme);
                    List<EntityUyeAidat> aidatlar = new List<EntityUyeAidat>();

                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }

                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntityUyeAidat ent = new EntityUyeAidat();

                            ent.AidatId = dr["AidatId"].ToString();
                            ent.Tc = dr["Tc"].ToString();
                            ent.AidatMiktari = int.Parse(dr["AidatMiktari"].ToString());
                            ent.AidatTarihi = dr["AidatTarihi"].ToString();
                            ent.Odendi = bool.Parse(dr["Odendi"].ToString());
                            ent.OdemeTarihi = dr["OdemeTarihi"].ToString();
                            ent.EPosta = dr["EPosta"].ToString();

                            aidatlar.Add(ent);

                            // Aidatları borç tablosuna ekler.
                            BorcEkle(aidatlar);

                            // Borç tablosuna aktarılan UyeAidat verilerini siler.
                            UyeAidatSil(aidatlar);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }

        public static void PdfOlustur(List<EntityBorc> borcListesi, string pdfDosyaYolu)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Font ve diğer özellikleri belirle
                    XFont fontTitle = new XFont("Arial", 18, XFontStyle.Bold);
                    XFont fontHeader = new XFont("Arial", 12, XFontStyle.Bold);
                    XFont fontData = new XFont("Arial", 12, XFontStyle.Regular);

                    // Başlık
                    gfx.DrawString("Borç Raporu", fontTitle, XBrushes.Black, new XRect(30, 20, page.Width, page.Height), XStringFormats.TopLeft);

                    // Tablo başlıkları
                    gfx.DrawString("TC", fontHeader, XBrushes.Black, new XRect(30, 60, page.Width, page.Height), XStringFormats.TopLeft);
                    gfx.DrawString("Borç Miktarı", fontHeader, XBrushes.Black, new XRect(150, 60, page.Width, page.Height), XStringFormats.TopLeft);
                    gfx.DrawString("Borç Tarihi", fontHeader, XBrushes.Black, new XRect(300, 60, page.Width, page.Height), XStringFormats.TopLeft);

                    // Verileri tablo şeklinde ekle
                    int yPosition = 80;
                    foreach (var borc in borcListesi)
                    {
                        gfx.DrawString(borc.Tc, fontData, XBrushes.Black, new XRect(30, yPosition, page.Width, page.Height), XStringFormats.TopLeft);
                        gfx.DrawString(borc.BorcMiktari.ToString(), fontData, XBrushes.Black, new XRect(150, yPosition, page.Width, page.Height), XStringFormats.TopLeft);
                        gfx.DrawString(borc.BorcTarihi, fontData, XBrushes.Black, new XRect(300, yPosition, page.Width, page.Height), XStringFormats.TopLeft);
                        yPosition += 20; // Yeni satıra geç
                    }

                    // PDF dosyasını kaydet
                    document.Save(pdfDosyaYolu);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
