using DataAccessLayer;
using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace DernekUyeTakip
{
    public partial class UyeDetay : Form
    {
        private string GelenVeri;

        public UyeDetay(string gelenVeri)
        {
            InitializeComponent();
            GelenVeri = gelenVeri;
        }

        private void UyeDetay_Load(object sender, EventArgs e)
        {
            List<EntityUye> UyeList = LogicUye.LLUyeListesi();
            EntityUye seciliUye = GetUyeByTC(GelenVeri);

            label1.Text = seciliUye.Tc;
            label2.Text = seciliUye.Ad;
            label3.Text = seciliUye.Soyad;
            label4.Text = seciliUye.Yas.ToString();
            label5.Text = seciliUye.Sehir;
            label6.Text = seciliUye.KanGrubu;

            // ZedGraph kontrolünü ayarla
            SetupGraph();

            // Veritabanından verileri çek ve grafik oluştur
            PopulateGraph();
        }

        private EntityUye GetUyeByTC(string tc)
        {
            return LogicUye.LLUyeListesi().FirstOrDefault(u => u.Tc == tc);
        }








        private void SetupGraph()
        {
            // ZedGraph kontrolünü yapılandır
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Şehirlere Göre Üye Sayıları";
            myPane.XAxis.Title.Text = "Şehir";
            myPane.YAxis.Title.Text = "Üye Sayısı";
            myPane.XAxis.Type = AxisType.Text;

            // İsteğe bağlı olarak eksen etiketlerini döndürme
            myPane.XAxis.Scale.TextLabels = new string[] { CbSehir.Items.ToString() };
            myPane.XAxis.MajorTic.IsBetweenLabels = true;
        }

        private void PopulateGraph()
        {
            // Veritabanından şehir ve üye sayılarını çek
            List<string> cities = new List<string>();
            List<double> memberCounts = new List<double>();
            string bgl = Baglanti.dbc.ToString();
            string query = "SELECT Sehir, COUNT(*) AS MemberCount FROM Uye GROUP BY Sehir";
            using (OleDbCommand command = new OleDbCommand(query, Baglanti.dbc))
            {
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cities.Add(reader["Sehir"].ToString());
                        memberCounts.Add(Convert.ToInt32(reader["MemberCount"]));
                    }
                }
            }

            // Grafiği güncelle
            UpdateGraph(cities, memberCounts);
        }

        private void UpdateGraph(List<string> cities, List<double> memberCounts)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            // X eksenine şehirleri ekle
            myPane.XAxis.Scale.TextLabels = cities.ToArray();

            // Çubuk grafik tipini seç
            BarItem myBar = myPane.AddBar("Üye Sayısı", null, memberCounts.ToArray(), System.Drawing.Color.Blue);
            myBar.Bar.Fill = new Fill(System.Drawing.Color.Blue);

            // Grafik görünümünü güncelle
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

    }
}
