using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicUye
    {
        public static List<EntityUye> LLUyeListesi()
        {
            return DALUye.UyeListesi();
        }

        public static int LLUyeEkle(EntityUye u)
        {
            if (u.Tc != "" && u.Ad != "" && u.Soyad != "" && u.KanGrubu != "" && u.Sifre != "" && u.Sehir != "")
            {
                return DALUye.UyeEkle(u);
            }
            else
            {
                return 0;
            }
        }

        public static bool LLUyeSil(string u)
        {
            if (u != "")
            {
                return DALUye.UyeSil(u);
            }
            else
            {
                return false;
            }
        }

        public static bool LLUyeGuncelle(EntityUye u)
        {
            if (u.Tc != "" && u.Sifre != "")
            {
                return DALUye.UyeGuncelle(u);
            }
            else
            {
                return false;
            }
        }
        public static List<EntityUye> LLUyeListesi(string Sec, string deger)
        {
            return DALUye.UyeListesi(Sec,deger);
        }
    }
}
