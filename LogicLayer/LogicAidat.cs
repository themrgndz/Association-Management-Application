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
    }
}
