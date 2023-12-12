using System.Data.OleDb;

namespace DataAccessLayer
{
    public class Baglanti
    {
        //Her seferinde yeni bir nesne türetmemek için static olarak oluşturuyoruz
        public static OleDbConnection dbc = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\emrgn\OneDrive\Masaüstü\DTA\DernekTakipDb.accdb");
    }
}
