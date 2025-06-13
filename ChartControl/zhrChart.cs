using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace ChartControl
{
    public partial class zhrChart : Form
    {
        public zhrChart()
        {
            InitializeComponent();
        }

        private void zhrChart_Load(object sender, EventArgs e)
        {
            BarGrafikOlustur();
        }

        private void BarGrafikOlustur()
        {
            // Önce serileri temizle
            chartControl1.Series.Clear();

            // Yeni bir seri oluştur (Bar tipi)
            Series seri = new Series("Yıllar", ViewType.Bar);

            // Manuel veri ekle
            seri.Points.Add(new SeriesPoint("2019", 65));
            seri.Points.Add(new SeriesPoint("2022", 15));
            seri.Points.Add(new SeriesPoint("2023", 30));
            //seri.Points.Add(new SeriesPoint("Ürün D", 70));
            seri.Points[0].Color = Color.Red;
            seri.Points[1].Color = Color.Green;
            seri.Points[2].Color = Color.Brown;
            //seri.Points[3].Color = Color.Orange;

            // Seriyi kontrol'e ekle
            chartControl1.Series.Add(seri);

            seri.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //PointSeriesLabel label = (PointSeriesLabel)seri.Label;
            //label.TextPattern = "{V:#,#.0}M";  // Örn: 27.2M
            // Başlık ekle
            ChartTitle baslik = new ChartTitle();
            baslik.Text = "Çin'e Gelen Turist Sayısı (2019-2022-2023";
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(baslik);

            // X ve Y eksen isimlerini ayarla
            XYDiagram diagram = chartControl1.Diagram as XYDiagram;
            if (diagram != null)
            {
                diagram.AxisX.Title.Text = "Yıllar";
                diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                diagram.AxisY.Title.Text = "Turist Sayısı(Milyon)";
                diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                //diagram.AxisX.GridLines.Visible = false;
                //diagram.AxisY.GridLines.Visible = false;
            }
        }
    }
}
