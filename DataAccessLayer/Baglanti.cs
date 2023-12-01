using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Baglanti
    {
        //Her seferinde yeni bir nesne türetmemek için static olarak oluşturuyoruz
        public static OleDbConnection dbc = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\turgu\OneDrive\Masaüstü\DernekTakipApp\DernekTakipDb.accdb");
    }
}
