using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityAidat
    {
        private short yil;
        private decimal ocak;
        private decimal subat;
        private decimal mart;
        private decimal nisan;
        private decimal mayis;
        private decimal haziran;
        private decimal temmuz;
        private decimal agustos;
        private decimal eylul;
        private decimal ekim;
        private decimal kasim;
        private decimal aralik;

        public short Yil { get => yil; set => yil = value; }
        public decimal Ocak { get => ocak; set => ocak = value; }
        public decimal Subat { get => subat; set => subat = value; }
        public decimal Mart { get => mart; set => mart = value; }
        public decimal Nisan { get => nisan; set => nisan = value; }
        public decimal Mayis { get => mayis; set => mayis = value; }
        public decimal Haziran { get => haziran; set => haziran = value; }
        public decimal Temmuz { get => temmuz; set => temmuz = value; }
        public decimal Agustos { get => agustos; set => agustos = value; }
        public decimal Eylul { get => eylul; set => eylul = value; }
        public decimal Ekim { get => ekim; set => ekim = value; }
        public decimal Kasim { get => kasim; set => kasim = value; }
        public decimal Aralik { get => aralik; set => aralik = value; }
    }
}
