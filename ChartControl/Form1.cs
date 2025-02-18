using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraCharts;

namespace ChartControlOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Bağlantı dizesi (Sunucu adını kontrol edin)
                string connectionString = "Server=ARDAPOS-1\\SQL2019;Initial Catalog=DbOrnekChart;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT Ay, Satislar FROM Satislar";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Chart kontrolünde var olan seriyi kullan
                        Series series = chartControl1.Series[0];

                        while (reader.Read())
                        {
                            string ay = reader["Ay"].ToString();
                            double satislar = Convert.ToDouble(reader["Satislar"]);

                            series.Points.Add(new SeriesPoint(ay, satislar));
                        }
                    }
                }

                // Diagram ayarları
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram; // Tip dönüşümü
                diagram.Rotated = false; // Dikey düzen
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}