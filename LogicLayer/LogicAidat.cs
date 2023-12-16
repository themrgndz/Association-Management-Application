using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.CompilerServices;

namespace LogicLayer
{
    public class LogicAidat
    {
        //Aidat tablosuna ait tüm verileri çeker.
        public static List<EntityAidat> LLDoldur()
        {
            return DALAidat.DALDoldur();
        }

        //Verilen yıla göre Aidat tablosundaki verileri çeker.
        public static List<EntityAidat> LLDoldur(string yil)
        {
            return DALAidat.DALDoldur(yil);
        }

        //Aidat verilerini günceller
        public static string LLAidatBelirle(EntityAidat Aidatlar)
        {
            return DALAidat.AidatBelirle(Aidatlar);
        }

        //Verilen tarihe göre aidat miktarı döndürür
        public static Decimal LLAidatMiktariAl(string ay, string yil)
        {
            return DALAidat.AidatMiktariAl(ay, yil);
        }

        //Aidat miktarlarını veritabanına ekler
        public static void LLUyeAidatEkle(decimal aidatmiktari)
        {
            DALAidat.UyeAidatEkle(aidatmiktari);
        }

        //Aktif üyelere o ayki aidat ücretini ekleyerek UyeAidat tablosuna işler
        public static bool LLAidatKayit(string tarih,decimal aidatMiktari)
        {
            return DALAidat.AidatKayit(tarih,aidatMiktari);
        }
        
        //Aktif üyelere aidat mail'i atar.
        public static string LLMailGonder(string konu,string mail)
        {
            if (mail != "" && konu != "")
            {
                return DALAidat.MailGonder(konu,mail);
            }
            else
            {
                return "Lütfen mail içeriği ekleyin...";
            }
        }

        //UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir()
        {
            return DALAidat.UyeAidatGetir();
        }
       
        //Verilen Tc'ye göre UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir(string Tc)
        {
            return DALAidat.UyeAidatGetir(Tc);
        }

        //UyeAidat tablosundaki odenmiş/odenmemiş verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir(bool odendi)
        {
            return DALAidat.UyeAidatGetir(odendi);
        }

        ////Verilen Tc ve Odeme durumuna göre UyeAidat tablosundaki tüm verileri çeker.
        public static List<EntityUyeAidat> LLUyeAidatGetir(bool odendi,string Tc)
        {
            return DALAidat.UyeAidatGetir(odendi, Tc);
        }
    }
}
