using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALUye
    {
        //Bütün üyelerin listesini datagridview'e aktarır
        public static List<EntityUye> UyeListesi()
        {
            List<EntityUye> uyeler = new List<EntityUye>();
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Uye", Baglanti.dbc)) 
            {
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
                        EntityUye ent = new EntityUye();
                        ent.Tc = dr["Tc"].ToString();
                        ent.Ad = dr["Ad"].ToString();
                        ent.Soyad = dr["Soyad"].ToString();
                        ent.Yas = int.Parse(dr["Yas"].ToString());
                        ent.Sehir = dr["Sehir"].ToString();
                        ent.Sifre = dr["Sifre"].ToString();
                        ent.KanGrubu = dr["KanGrubu"].ToString();
                        ent.KayitTarihi = dr["KayitTarihi"].ToString();
                        ent.Eposta = dr["Eposta"].ToString();
                        if (bool.Parse(dr["AktifPasif"].ToString()) == true)
                        {
                            ent.Aktif_Pasif = true;
                        }
                        else
                        {
                            ent.Aktif_Pasif = false;
                        }
                        uyeler.Add(ent);
                    }
                    dr.Close();
                    return uyeler;
                }
                catch 
                {
                    return null;
                }
            }
                
            
        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        //Tc'si verilen üyenin listesini aktarır
        public static List<EntityUye> UyeListesi(string tc)
        {
            List<EntityUye> uyeler = new List<EntityUye>();
            using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Uye WHERE Tc = @Tc", Baglanti.dbc))
            {
                cmd.Parameters.AddWithValue("@Tc", tc);
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
                        EntityUye ent = new EntityUye();
                        ent.Tc = dr["Tc"].ToString();
                        ent.Ad = dr["Ad"].ToString();
                        ent.Soyad = dr["Soyad"].ToString();
                        ent.Yas = int.Parse(dr["Yas"].ToString());
                        ent.Sehir = dr["Sehir"].ToString();
                        ent.Sifre = dr["Sifre"].ToString();
                        ent.KanGrubu = dr["KanGrubu"].ToString();
                        ent.Eposta = dr["Eposta"].ToString();
                        ent.KayitTarihi = dr["KayitTarihi"].ToString();
                        if (bool.Parse(dr["AktifPasif"].ToString()) == true)
                        {
                            ent.Aktif_Pasif = true;
                        }
                        else
                        {
                            ent.Aktif_Pasif = false;
                        }
                        uyeler.Add(ent);
                    }
                    dr.Close();
                    return uyeler;
                }
                catch
                {
                    return null;
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        //Bütün üyelerin listesini istenen sıralamaya durumuna göre datagridview'e aktarır
        public static List<EntityUye> UyeListesi(string Sec, string Deger)
        {
            List<EntityUye> uyeler = new List<EntityUye>();
            
            string sorgu = "SELECT * FROM Uye WHERE " +Sec+ "= @Deger";
            
            using (OleDbCommand cmd = new OleDbCommand(sorgu, Baglanti.dbc))
            {
                try 
                {
                    cmd.Parameters.AddWithValue("@Deger", Deger);

                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();
                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityUye ent = new EntityUye();
                        ent.Tc = dr["Tc"].ToString();
                        ent.Ad = dr["Ad"].ToString();
                        ent.Soyad = dr["Soyad"].ToString();
                        ent.Yas = int.Parse(dr["Yas"].ToString());
                        ent.Sehir = dr["Sehir"].ToString();
                        ent.Sifre = dr["Sifre"].ToString();
                        ent.Eposta = dr["Eposta"].ToString();
                        ent.KanGrubu = dr["KanGrubu"].ToString();
                        if (bool.Parse(dr["AktifPasif"].ToString()) == true)
                        {
                            ent.Aktif_Pasif = true;
                        }
                        else
                        {
                            ent.Aktif_Pasif = false;
                        }
                        uyeler.Add(ent);
                    }
                    dr.Close();
                    return uyeler;
                }
                catch 
                {
                    return null;
                }
                
            }
            
        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        
        //Bütün üyelerin listesini Aktif Pasif durumuna göre datagridview'e aktarır
        public static List<EntityUye> UyeListesi(string Sec, bool Deger)
        {
            List<EntityUye> uyeler = new List<EntityUye>();

            string sorgu = "SELECT * FROM Uye WHERE " + Sec + " = @Deger";

            using (OleDbCommand cmd = new OleDbCommand(sorgu, Baglanti.dbc))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Deger", Deger);

                    //Eğer veritabanı bağlantısı açık değilse açıyoruz.
                    if (cmd.Connection.State != ConnectionState.Open)
                    {
                        cmd.Connection.Open();
                    }
                    OleDbDataReader dr = cmd.ExecuteReader();
                    //Veritabanından bütün verileri çekiyoruz.
                    while (dr.Read())
                    {
                        EntityUye ent = new EntityUye();
                        ent.Tc = dr["Tc"].ToString();
                        ent.Ad = dr["Ad"].ToString();
                        ent.Soyad = dr["Soyad"].ToString();
                        ent.Yas = int.Parse(dr["Yas"].ToString());
                        ent.Sehir = dr["Sehir"].ToString();
                        ent.Sifre = dr["Sifre"].ToString();
                        ent.Eposta = dr["Eposta"].ToString();
                        ent.KanGrubu = dr["KanGrubu"].ToString();
                        ent.Aktif_Pasif = true;
                        ent.KayitTarihi = dr["KayitTarihi"].ToString();
                        
                        uyeler.Add(ent);
                    }
                    dr.Close();
                    return uyeler;
                }
                catch
                {
                    return null;
                }

            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------
        
        //Bilgileri girilen üyeyi veritabanına kaydeder
        public static int UyeEkle(EntityUye u)
        {
            using (OleDbCommand cmd2 = new OleDbCommand("INSERT INTO Uye(Tc,Ad,Soyad,Yas,Sehir,Sifre,KanGrubu,KayitTarihi,Eposta,AktifPasif) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10)", Baglanti.dbc))
            {
                try
                {
                    
                    if (cmd2.Connection.State != ConnectionState.Open)
                    {
                        cmd2.Connection.Open();
                    }
                    cmd2.Parameters.AddWithValue("@P1", u.Tc);
                    cmd2.Parameters.AddWithValue("@P2", u.Ad);
                    cmd2.Parameters.AddWithValue("@P3", u.Soyad);
                    cmd2.Parameters.AddWithValue("@P4", u.Yas);
                    cmd2.Parameters.AddWithValue("@P5", u.Sehir);
                    cmd2.Parameters.AddWithValue("@P6", u.Sifre);
                    cmd2.Parameters.AddWithValue("@P7", u.KanGrubu);
                    cmd2.Parameters.AddWithValue("@P8", u.KayitTarihi);
                    cmd2.Parameters.AddWithValue("@P9", u.Eposta);
                    cmd2.Parameters.AddWithValue("@P10", u.Aktif_Pasif);
                    

                    return cmd2.ExecuteNonQuery();
                }
                catch 
                {
                    return 0;
                    
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //Tc'si girilen üyeyi siler
        public static bool UyeSil(string u)
        {
            using (OleDbCommand cmd3 = new OleDbCommand("DELETE * FROM Uye WHERE Tc = @P1", Baglanti.dbc))
            {
                try
                {
                    
                    if (cmd3.Connection.State != ConnectionState.Open)
                    {
                        cmd3.Connection.Open();
                    }
                    cmd3.Parameters.AddWithValue("@P1", u);
                    //Belirtilen Tc'de bir veri varsa siliyor.
                    return cmd3.ExecuteNonQuery() > 0;
                }
                catch
                {

                    return false;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //Tc'si girilen üyeyi günceller
        public static bool UyeGuncelle(EntityUye ent)
        {
            using (OleDbCommand cmd4 = new OleDbCommand("UPDATE Uye SET Ad = @P1, Soyad = @P2, Yas = @P3, Sehir = @P4, Sifre = @P5, KanGrubu = @P6, AktifPasif = @P7, Eposta = @P8 WHERE Tc = @P9", Baglanti.dbc))
            {
                try
                {
                    if (cmd4.Connection.State != ConnectionState.Open)
                    {
                        cmd4.Connection.Open();
                    }
                    cmd4.Parameters.AddWithValue("@P1", ent.Ad);
                    cmd4.Parameters.AddWithValue("@P2", ent.Soyad);
                    cmd4.Parameters.AddWithValue("@P3", ent.Yas);
                    cmd4.Parameters.AddWithValue("@P4", ent.Sehir);
                    cmd4.Parameters.AddWithValue("@P5", ent.Sifre);
                    cmd4.Parameters.AddWithValue("@P6", ent.KanGrubu);
                    cmd4.Parameters.AddWithValue("@P7", ent.Aktif_Pasif);
                    cmd4.Parameters.AddWithValue("@P8", ent.Eposta);
                    cmd4.Parameters.AddWithValue("@P9", ent.Tc);

                    return cmd4.ExecuteNonQuery() > 0;
                }
                catch
                {

                    return false;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //Giriş yapmaya çalışan kişinin Tc ve şifresini yönetici tablosundan kontrol eder
        public static bool YoneticiDogrula(string tc, string sifre)
        {
            bool dogrulandi = false;
            using (OleDbCommand cmd5 = new OleDbCommand("SELECT * FROM Yonetici", Baglanti.dbc))
            {
                try
                {
                    if (cmd5.Connection.State != ConnectionState.Open)
                    {
                        cmd5.Connection.Open();
                    }

                    OleDbCommand cmd6 = new OleDbCommand($"SELECT * FROM Yonetici WHERE TC=@tc AND Sifre=@sifre", Baglanti.dbc);
                    cmd6.Parameters.AddWithValue("@tc", tc);
                    cmd6.Parameters.AddWithValue("@sifre", sifre);

                    OleDbDataReader reader = cmd6.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Kullanıcı doğrulandı.
                        dogrulandi = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cmd5.Connection.Close();
                }

                return dogrulandi;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //Giriş yapmaya çalışan kişinin Tc ve şifresini üye tablosundan kontrol eder
        public static bool UyeDogrula(string tc, string sifre)
        {
            bool dogrulandi = false;
            using (OleDbCommand cmd5 = new OleDbCommand("SELECT * FROM Uye", Baglanti.dbc))
            {
                try
                {
                    if (cmd5.Connection.State != ConnectionState.Open)
                    {
                        cmd5.Connection.Open();
                    }

                    OleDbCommand cmd6 = new OleDbCommand($"SELECT * FROM Uye WHERE TC=@tc AND Sifre=@sifre", Baglanti.dbc);
                    cmd6.Parameters.AddWithValue("@tc", tc);
                    cmd6.Parameters.AddWithValue("@sifre", sifre);

                    OleDbDataReader reader = cmd6.ExecuteReader();

                    if (reader.HasRows)
                    {
                        // Kullanıcı doğrulandı.
                        dogrulandi = true;
                    }
                }
                catch (Exception ex)
                {
                    // Hata yönetimi burada yapılabilir.
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cmd5.Connection.Close();
                }

                return dogrulandi;
            }
        }

    }
}
