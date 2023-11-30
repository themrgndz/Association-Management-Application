using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALAidat
    {
        public static Dictionary<DateTime, decimal> AidatBelirle(DateTime baslangicTarihi, DateTime bitisTarihi, decimal aylikAidatTutari)
        {
            Dictionary<DateTime, decimal> aidatlar = new Dictionary<DateTime, decimal>();

            DateTime simdikiAy = baslangicTarihi;

            while (simdikiAy <= bitisTarihi)
            {
                aidatlar.Add(simdikiAy, aylikAidatTutari);
                simdikiAy = simdikiAy.AddMonths(1);
            }

            return aidatlar;
        }
    }
}
    
