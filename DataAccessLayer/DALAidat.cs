using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALAidat
    {
        //--------------------------------------------------------------------------------------------------------------------------------------
       
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
    }
}
