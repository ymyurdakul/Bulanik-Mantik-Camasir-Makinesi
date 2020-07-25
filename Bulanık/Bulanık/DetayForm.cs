using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class DetayForm : Form
    {
        
        public DetayForm()
        {
            InitializeComponent();
        }

        private void DetayForm_Load(object sender, EventArgs e)
        {

        }
         
        public void setChart(Chart cikisChart,String üyekümeAdı)
        {
            pbRenk1.BackColor = Color.Blue;
            pbRenk2.BackColor = Color.Orange;
            pbRenk3.BackColor = Color.Red;
            lblLegend1.Text = cikisChart.Series[0].Name;
            lblLegend2.Text = cikisChart.Series[1].Name;
            lblLegend3.Text = cikisChart.Series[2].Name;
            this.Text = üyekümeAdı.ToUpper() + " DETAY";
            switch (üyekümeAdı)
            {
                case "hassasiyet":
                {
                        textBox1.Text = "[ -4 , -1.5 , 2 , 4 ]";
                        textBox2.Text= "[ 3 , 5 , 7 ]";
                        textBox3.Text = "[ 5.5 , 8 , 12.5 , 14 ]";
                    }
                    break;
                case "miktar":
                    {
                        textBox1.Text = "[ -4 , -1.5 , 2 , 4 ]";
                        textBox2.Text = "[ 3 , 5 , 7 ]";
                        textBox3.Text = "[ 5.5 , 8 , 12.5 , 14 ]";
                    }
                    break;
                case "kirlilik":
                    {
                        textBox1.Text = "[ -4 , -2.5 , 2 , 4.5 ]";
                        textBox2.Text = "[ 3 , 5 , 7 ]";
                        textBox3.Text = "[ 5.5 , 8 , 12.5 , 15 ]";
                    }
                    break;
                default:
                    break;
            }

        }
         
    }
}
