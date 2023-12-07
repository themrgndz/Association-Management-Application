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
        public static void AidatBelirle(string tc, DateTime tarih, decimal miktar)
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

        //Değeri verilen aidat miktarını aktif üyelere ekleme
        public static void TumAylarAidatBelirle(string miktar, string tarih)
        {
            string query = "INSERT INTO Aidat (Tarih, Aidat) VALUES (@Tarih,@Aidat)";

            using (OleDbCommand command = new OleDbCommand(query, Baglanti.dbc))
            {
                command.Parameters.AddWithValue("@Aidat", miktar);
                command.Parameters.AddWithValue("Tarih", tarih);

                command.ExecuteNonQuery();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        

    }
}
