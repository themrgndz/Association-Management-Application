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
        
        public static string LLAidatBelirle(EntityAidat Aidatlar)
        {
            return DALAidat.AidatBelirle(Aidatlar);
        }

        public static Decimal LLAidatMiktariAl(string ay, string yil)
        {
            return DALAidat.AidatMiktariAl(ay,yil);
        }

        public static bool LLBorcKontrol(EntityUye uye)
        {
            return DALAidat.BorcKontrol(uye);
        }

        public static bool LLBorcBelirle(string tc, string ay, string yil)
        {
            return DALAidat.BorcBelirle(tc,ay,yil);
        }
    }
}
