using DataAccessLayer;
using System;
using System.Data.OleDb;

namespace LogicLayer
{
    public class LogicAidat
    {
        //--------------------------------------------------------------------
        public static void LLAidatBelirle(string tc, DateTime tarih, decimal miktar)
        {
            DALAidat.DALAidatBelirle(tc,tarih,miktar);
        }
        
        //--------------------------------------------------------------------
        
        //Her ay için farklı aidat
        public static string LLAidatBelirle(int[] yeniMiktarlar, string CbYil)
        {
            
            return DALAidat.DALAidatBelirle(yeniMiktarlar, CbYil);
        }

        //--------------------------------------------------------------------

        //Bütün aylar için aynı aidat
        public static string LLAidatBelirle(int yeniMiktar, string CbYil)
        {

            return DALAidat.DALAidatBelirle(yeniMiktar, CbYil);
        }
        
        //--------------------------------------------------------------------
    }
}
