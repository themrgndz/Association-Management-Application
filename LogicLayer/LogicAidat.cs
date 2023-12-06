using DataAccessLayer;
using System;

namespace LogicLayer
{
    public class LogicAidat
    {
        //--------------------------------------------------------------------
        public static void LLAidatBelirle(string tc, DateTime tarih, decimal miktar)
        {
            DALAidat.AidatBelirle(tc,tarih,miktar);
        }
        //--------------------------------------------------------------------
    }
}
