using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace BenigaDIP
{
    public partial class HistogramForm : Form
    {
        private Chart chartHistogram;

        public HistogramForm()
        {
            InitializeChart();
            this.Size = new System.Drawing.Size(425, 350);
        }

        private void InitializeChart()
        {
            chartHistogram = new Chart();
            chartHistogram.Size = new System.Drawing.Size(400, 300);
            chartHistogram.Location = new System.Drawing.Point(10, 10);
            chartHistogram.ChartAreas.Add(new ChartArea());
            chartHistogram.Series.Add(new Series("Intensity"));

            chartHistogram.ChartAreas[0].AxisX.Title = "Intensity";
            chartHistogram.ChartAreas[0].AxisY.Title = "Frequency";
            chartHistogram.Titles.Add(new Title("Histogram"));

            Controls.Add(chartHistogram);
        }

        public void DisplayHistogram(int[] histogram)
        {
            chartHistogram.Series[0].Points.Clear();

            for (int i = 0; i < histogram.Length; i++)
            {
                chartHistogram.Series[0].Points.AddXY(i, histogram[i]);
            }
        }
    }
}
