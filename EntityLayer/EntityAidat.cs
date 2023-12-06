using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityAidat
    {
        private string tc;
        private string aidatTarih;
        private string aidatMiktar;
        private string sonOdemeTarihi;
        public string Tc { get => tc; set => tc = value; }
        public string AidatTarih { get => aidatTarih; set => aidatTarih = value; }
        public string AidatMiktar { get => aidatMiktar; set => aidatMiktar = value; }
        public string SonOdemeTarihi { get => sonOdemeTarihi; set => sonOdemeTarihi = value; }
    }
}
