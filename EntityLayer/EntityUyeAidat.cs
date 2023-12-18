using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityUyeAidat
    {
        //-----------------------------------------------------------------------------
        //Database kısmında oluşturduğumuz UyeAidat tablosunu Entity katmanında property'lere aktarıyoruz.

        private string aidatId;
        private string tc;
        private int aidatMiktari;
        private string aidatTarihi;
        private bool odendi;
        private string odemeTarihi;
        private string ePosta;

        public string AidatId { get => aidatId; set => aidatId = value; }

        public string Tc { get => tc; set => tc = value; }

        public int AidatMiktari { get => aidatMiktari; set => aidatMiktari = value; }

        public string AidatTarihi { get => aidatTarihi; set => aidatTarihi = value; }

        public bool Odendi { get => odendi; set => odendi = value; }

        public string OdemeTarihi { get => odemeTarihi; set => odemeTarihi = value; }

        public string EPosta { get => ePosta; set => ePosta = value; }
    }
}
