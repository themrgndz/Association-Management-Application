using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityBorc
    {
        private string borcId;
        private string tc;
        private int borcMiktari;
        private string borcTarihi;
        private bool odendi;
        private string odemeTarihi;
        private string ePosta;

        public string BorcId { get => borcId; set => borcId = value; }
        
        public string Tc { get => tc; set => tc = value; }
        
        public int BorcMiktari { get => borcMiktari; set => borcMiktari = value; }
        
        public string BorcTarihi { get => borcTarihi; set => borcTarihi = value; }
        
        public bool Odendi { get => odendi; set => odendi = value; }
        
        public string OdemeTarihi { get => odemeTarihi; set => odemeTarihi = value; }

        public string EPosta { get => ePosta; set => ePosta = value; }
    }
}
