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
            }
        }
    }
}
