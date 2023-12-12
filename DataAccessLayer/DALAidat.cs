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
        //Bütün verileri çeker.
        public static List<EntityAidat> DALDoldur()
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
        public static List<EntityAidat> DALDoldur(string yil)
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

        public static decimal AidatMiktariAl(string ay, string yil)
        {
            //Burada kaldın
            DALDoldur(yil);
        }
    }
}
