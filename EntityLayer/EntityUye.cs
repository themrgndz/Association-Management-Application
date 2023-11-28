using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityUye
    {

        //-----------------------------------------------------------------------------
        //Database kısmında oluşturduğumuz üye tablosunu Entity katmanında property'lere aktarıyoruz.
        private string tc;

        private string ad;

        private string soyad;

        private int yas;

        private string sehir;

        private string sifre;

        private string kanGrubu;

        private bool aktif_Pasif;

        private float borc;

        //-----------------------------------------------------------------------------
        public string Tc { get => tc; set => tc = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public int Yas { get => yas; set => yas = value; }
        public string Sehir { get => sehir; set => sehir = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string KanGrubu { get => kanGrubu; set => kanGrubu = value; }
        public bool Aktif_Pasif { get => aktif_Pasif; set => aktif_Pasif = value; }
        public float Borc { get => borc; set => borc = value; }

        //-----------------------------------------------------------------------------

    }
}
