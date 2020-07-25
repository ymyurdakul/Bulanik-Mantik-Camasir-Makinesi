using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class CıktıDetay : Form
    {
        public CıktıDetay()
        {
            InitializeComponent();
        }

        private void DeterjanDetay_Load(object sender, EventArgs e)
        {
            renkAyarla();
        }
        public void setDeterjanEkran()
        {
           
            textBox1.Text = "[ 0,0,20,85 ]";
            textBox2.Text = "[ 20,85,150 ]";
            textBox3.Text = "[ 85,150,215 ]";
            textBox4.Text = "[ 150,215,280 ]";
            textBox5.Text = "[ 215,280,300,300 ]";
        }
        public void setDonusHızıEkran()
        {

            textBox1.Text = "[ -5.8,-2.8,0,5,1.5 ]";
            textBox2.Text = "[ 0.5,2.75,5 ]";
            textBox3.Text = "[ 2.75,5,7.25 ]";
            textBox4.Text = "[ 5,7.25,9.5 ]";
            textBox5.Text = "[ 8.5,9.5,12.8,15.2 ]";
        }
        public void setSureEkran()
        {

            textBox1.Text = "[ -46.5,-25.28,22.3,39.9 ]";
            textBox2.Text = "[ 22.3,39.9.57,5 ]";
            textBox3.Text = "[ 39.9,57.5,75.1 ]";
            textBox4.Text = "[ 57.5,75.1,92.7 ]";
            textBox5.Text = "[ 75,92.7,111.6,130 ]";
        }
        public void renkAyarla()
        {
            pbRenk1.BackColor = Color.Yellow;
            pbRenk2.BackColor = Color.Red;
            pbRenk3.BackColor = Color.Pink;
            pictureBox1.BackColor = Color.DeepPink;
            pictureBox2.BackColor = Color.Orange;
        }
    }
}
