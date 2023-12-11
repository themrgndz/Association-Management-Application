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

namespace DataAccessLayer
{
    public class DALAidat
    {
        //Değeri verilen aidat miktarını aktif üyelere ekleme
        public static void DALAidatBelirle(string tc, DateTime tarih, decimal miktar)
        {
            string query = "INSERT INTO UyeAidat (Tc, AidatTarih, AidatMiktar, SonOdemeTarihi) VALUES (@Tc, @AidatTarih, @AidatMiktar, @SonOdemeTarihi)";

            using (OleDbCommand command = new OleDbCommand(query, Baglanti.dbc))
            {
                command.Parameters.AddWithValue("@Tc", tc);
                command.Parameters.AddWithValue("@AidatTarih", tarih.ToString("dd.MM.yyyy"));
                command.Parameters.AddWithValue("@AidatMiktar", miktar);
                command.Parameters.AddWithValue("SonOdemeTarihi", tarih.AddMonths(1).ToString("dd.MM.yyyy"));

                command.ExecuteNonQuery();
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        //Her ay için farklı aidat
        public static string DALAidatBelirle(int[] yeniMiktarlar, string CbYil)
        {
            try
            {
                using (OleDbCommand command = new OleDbCommand("UPDATE Aidat SET Miktar = @YeniMiktar WHERE Yil = @SecilenYil AND Ay = @SecilenAy", Baglanti.dbc))
                {
                    // Ay için döngüyü başlatın
                    for (short i = 0; i < 12; i++)
                    {
                        // Yeni parametreleri ekleyin
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@YeniMiktar", yeniMiktarlar[i]);
                        command.Parameters.AddWithValue("@SecilenYil", CbYil);
                        command.Parameters.AddWithValue("@SecilenAy", i + 1);

                        command.ExecuteNonQuery();
                    }
                    return "Aidat miktarları güncellendi.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        //Bütün aylar için aynı aidat
        public static string DALAidatBelirle(int yeniMiktar, string CbYil)
        {
            try
            {
                using (OleDbCommand command = new OleDbCommand("UPDATE Aidat SET Miktar = @YeniMiktar WHERE Yil = @SecilenYil", Baglanti.dbc))
                {
                    // Yeni parametreleri ekleyin
                    command.Parameters.AddWithValue("@YeniMiktar", yeniMiktar);
                    command.Parameters.AddWithValue("@SecilenYil", CbYil);

                    command.ExecuteNonQuery();
                    return "Aidat miktarı güncellendi.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        //E posta gonder
        public static string DALEpostaGonder(string metin)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("KaynakEposta");
                mail.To.Add("HedefEposta");
                mail.Subject = "Subject";
                mail.Body = metin;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential("KaynakEposta", "Şifre");
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);

                return "E-posta başarıyla gönderildi!";
            }
            catch (Exception ex)
            {
                return "E-posta gönderirken bir hata oluştu: " + ex.Message;
            }
        }
    }
}
