using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class OzelKontrol : UserControl
    {
        Point labelSıfırNoktası;
        public String Ad { get; set; }
        public NumericUpDown numericUpDown{get;set;}

        public OzelKontrol()
        {
            InitializeComponent();
        }
        DetayForm detayForm;
        private void OzelKontrol_Load(object sender, EventArgs e)
        {
            labelSıfırNoktası = label1.Location;
            chart1.Series["SAĞLAM"].Points.AddXY(0, 1);
            chart1.Series["SAĞLAM"].Points.AddXY(1, 1);
            chart1.Series["SAĞLAM"].Points.AddXY(2, 1);
            chart1.Series["SAĞLAM"].Points.AddXY(4, 0);

            chart1.Series["ORTA"].Points.AddXY(3, 0);
            chart1.Series["ORTA"].Points.AddXY(5, 1);
            chart1.Series["ORTA"].Points.AddXY(7, 0);



            chart1.Series["HASSAS"].Points.AddXY(5.5, 0);
            chart1.Series["HASSAS"].Points.AddXY(8, 1);
            chart1.Series["HASSAS"].Points.AddXY(9, 1);
            chart1.Series["HASSAS"].Points.AddXY(10, 1);


            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
        }

        
        private static decimal map(decimal deger, decimal fromLow, decimal fromHigh, decimal toLow, decimal toHigh)
        {
            return (deger - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }
        public void updateUi()
        {
            if (numericUpDown != null)
            {
                numericUpDown.Value = getValue();
            }
        }
        public TrackBar getTrackBar()
        {
            return trackBar1;
        }
        public decimal getValue()
        {
            decimal x = map(trackBar1.Value, 0, 50, 0, 10);
            return x;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          
            
            label1.Location = new Point(labelSıfırNoktası.X +((int)(trackBar1.Value*5)) ,21);
            updateUi();
        }
        public void changeLegends(String[]args) {
            chart1.Series[0].Name = args[0];
            chart1.Series[1].Name = args[1];
            chart1.Series[2].Name= args[2];
        
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1_Scroll(sender,e);
        }
        public Chart getChart (){
            return this.chart1;
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
          detayForm = new DetayForm();
            detayForm.setChart(this.chart1,Ad);
            detayForm.Show();
        }
    }
}
