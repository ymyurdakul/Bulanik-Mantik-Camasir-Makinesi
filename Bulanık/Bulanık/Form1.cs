using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //tüm program boyunca bu kullanılacaktır
        BulanıkMantık bulanıkMantık;
        public static List<Kural> KURAL_TABANI;
        public List<String> kirlilikkumeAdlari;
        public List<String> miktarkumeAdlari;
        List<String> hassasiyetkumeAdlari;
        private double donusHızıAgırlıklıOrtalama;
        Dictionary<string, double> deterjanKumeVeKestikleri = new Dictionary<string, double>();
        Dictionary<string, double> hızKumeVeKestikleri = new Dictionary<string, double>();
        Dictionary<string, double> sureKumeVeKestikleri = new Dictionary<string, double>();
        CıktıDetay cıktıDetafForm;
        public Dictionary<string, double> deterjanÇarpan = new Dictionary<string, double>()
        {
            {"çok az",20 }, {"az",85 }, {"orta",150 }, {"fazla",215 }, {"çok fazla",270 }
        };
        public Dictionary<string, double> hızÇarpan = new Dictionary<string, double>()
        {
            {"hassas",0.514 }, {"normal hassas",2.75 }, {"orta",5.0 }, {"normal güçlü",7.25 }, {"güçlü",9.5 }
        };
        public Dictionary<string, double> sureÇarpan = new Dictionary<string, double>()
        {
            {"kısa",22.3 }, {"normal kısa",39.9 }, {"orta",57.5 }, {"normal uzun",75.1 }, {"uzun",92.7 }
        };
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            bulanıkMantık = new BulanıkMantık();
            double a=bulanıkMantık.UcgenUyelikHesapla(6.7,bulanıkMantık.hassasUcgen);
          //  a=bulanıkMantık.GirisUyelikHesapla("Miktar", "küçük", 2.40);
           // MessageBox.Show(a.ToString());
            init();
           
        }
        public void init()
        {
            chrtDeterjan.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chrtDeterjan.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chrtDeterjan.ChartAreas[0].AxisX.IsMarginVisible = false;

            chrtHız.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chrtHız.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chrtHız.ChartAreas[0].AxisX.IsMarginVisible = false;

            chrtSure.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chrtSure.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chrtSure.ChartAreas[0].AxisX.IsMarginVisible = false;



            KURAL_TABANI = new List<Kural>();
            kuralTabanıDoldur();
            grfHassasiyet.numericUpDown = nudHassasiyet;
            grfHassasiyet.Ad = "hassasiyet";
            grfKirlilik.numericUpDown = nudKirlilik;
            grfKirlilik.Ad = "kirlilik";
            grfMiktar.numericUpDown = nudMiktar;
            grfMiktar.Ad = "miktar";
            grfMiktar.changeLegends(new String[]{"KÜÇÜK","ORTA","BÜYÜK"});
            grfKirlilik.changeLegends(new String[] { "KÜÇÜK", "ORTA", "BÜYÜK" });
            grfKirlilik.getChart().Series["KÜÇÜK"].Points.RemoveAt(grfKirlilik.getChart().Series["KÜÇÜK"].Points.Count()-1);
            grfKirlilik.getChart().Series["KÜÇÜK"].Points.AddXY(4.5,0);

            hassasiyetkumeAdlari = new List<string>();
            kirlilikkumeAdlari = new List<string>();
            miktarkumeAdlari = new List<string>();
        }
        private void kuralTabanıDoldur()
        {
            KURAL_TABANI.Clear();
           String[]kurallarListesi= File.ReadAllLines("kural_tabanı.txt");
            for (int i = 0; i < kurallarListesi.Length; i++)
            {
                String[] kural = kurallarListesi[i].Split(',');
                Kural temp = new Kural((i + 1), kural[0], kural[1], kural[2], kural[3], kural[4], kural[5]);
                KURAL_TABANI.Add(temp);
                mainGrid.Rows.Add(temp.Index_numarası,temp.Hassaslık,temp.Miktar,temp.Kirlilik,temp.Donus_Hizi,temp.Sure,temp.Deterjan);

            }
        }
        private decimal aralık_dönüstür(decimal deger, decimal x1, decimal x2, decimal y1, decimal y2)
        {
            return (deger - x1) * (y2 - y1) / (x2 - x1) + y1;
        }

        private void nudHassasiyet_ValueChanged(object sender, EventArgs e)
        {
            nudHassaslıkSağlam.Value = 0;
            nudHassasOrta.Value = 0;
            nudHassaslıkHassas.Value = 0;
            hassasiyetkumeAdlari.Clear();
            lblHassasiyet.Text = "";
            decimal x = aralık_dönüstür(nudHassasiyet.Value, 0, 10, 0, 50);
            TrackBar temp = grfHassasiyet.getTrackBar();
            temp.Value = ((int)x);
            
            hassasiyetkumeAdlari=Fonksiyonlar.UyeKumeAdıBul(((double)nudHassasiyet.Value),"Hassaslık");
            hassasiyetkumeAdlari.ForEach(uye=> {
                double ax=bulanıkMantık.GirisUyelikHesapla("Hassaslık",uye,((double)nudHassasiyet.Value));
                if(uye=="sağlam")
                nudHassaslıkSağlam.Value = (decimal)ax;
                else if (uye == "orta")
                    nudHassasOrta.Value = (decimal)ax;
                else if (uye == "hassas")
                    nudHassaslıkHassas.Value = (decimal)ax;

                lblHassasiyet.Text +="-"+ uye;
            });
            ateşle();
            
        }

        private void nudMiktar_ValueChanged(object sender, EventArgs e)
        {
            nudMiktarKücük.Value = 0;
            nudMiktarOrta.Value = 0;
            nudMiktarBüyük.Value = 0;

            miktarkumeAdlari.Clear();
            lblMiktar.Text = "";
            decimal x = aralık_dönüstür(nudMiktar.Value, 0, 10, 0, 50);
            TrackBar temp = grfMiktar.getTrackBar();
            temp.Value = ((int)x);
         
            miktarkumeAdlari= Fonksiyonlar.UyeKumeAdıBul(((double)nudMiktar.Value), "Miktar");
            miktarkumeAdlari.ForEach(uye => {
                double ax = bulanıkMantık.GirisUyelikHesapla("Miktar", uye, ((double)nudMiktar.Value));
                if (uye == "küçük")
                    nudMiktarKücük.Value = (decimal)ax;
                else if (uye == "orta")
                    nudMiktarOrta.Value = (decimal)ax;
                else if (uye == "büyük")
                    nudMiktarBüyük.Value = (decimal)ax;

                lblMiktar.Text += "-" + uye;
            });
            ateşle();

        }

        private void nudKirlilik_ValueChanged(object sender, EventArgs e)
        {
            nudKirlilikKüçük.Value = 0;
            nudKirlilikOrta.Value = 0;
            nudKirlilikBüyük.Value = 0;

            kirlilikkumeAdlari.Clear();
            lblKirlilik.Text = "";
            decimal x = aralık_dönüstür(nudKirlilik.Value, 0, 10, 0, 50);
            TrackBar temp = grfKirlilik.getTrackBar();
            temp.Value = ((int)x);
            kirlilikkumeAdlari = Fonksiyonlar.UyeKumeAdıBul(((double)nudKirlilik.Value), "Kirlilik");
            kirlilikkumeAdlari.ForEach(uye => {
                double ax = bulanıkMantık.GirisUyelikHesapla("Kirlilik", uye, ((double)nudKirlilik.Value));
                if (uye == "küçük")
                    nudKirlilikKüçük.Value = (decimal)ax;
                else if (uye == "orta")
                    nudKirlilikOrta.Value = (decimal)ax;
                else if (uye == "büyük")
                    nudKirlilikBüyük.Value = (decimal)ax;


                lblKirlilik.Text +=  "-"+uye;
            });
            ateşle();
        }
        
    
    

        public void ateşle() {
            cikisChartTemizle();
            /*
            if (nudHassasiyet.Value == 0 || nudKirlilik.Value == 0 || nudMiktar.Value == 0)
                return;
            */
          List<int>indexler= Fonksiyonlar.KuralAteşlemeIndexBul(hassasiyetkumeAdlari, miktarkumeAdlari, kirlilikkumeAdlari);
            gridisaretle(indexler);
            indexler.Sort();
            listBox1.Items.Clear();
            for (int i = 0; i < indexler.Count(); i++)
            {
                kuralMandaniÇıkarımıYap(KURAL_TABANI[ indexler[i]]);
            }


            deterjanKumeVeKestikleri.Clear();
            hızKumeVeKestikleri.Clear();
            sureKumeVeKestikleri.Clear();

            for (int i = 0; i < indexler.Count(); i++)
            {
                Kural temp = KURAL_TABANI[indexler[i]];
                double yükseklik =(double) listBox1.Items[i];
                cıkısGrafiğiKes(temp,yükseklik);

            }
            
            agirlikliOrtalamaHesapla();
         


        }
    
        public void agirlikliOrtalamaHesapla() {
            StringBuilder builder = new StringBuilder();
            double pay = 0.0;
            double payda = 0.0;


            foreach (string item in deterjanKumeVeKestikleri.Keys)
            {
                pay += (deterjanÇarpan[item] * deterjanKumeVeKestikleri[item]);
                payda += deterjanKumeVeKestikleri[item];
                builder.Append(item.ToUpper()+": " + deterjanKumeVeKestikleri[item]+" ");
            }
            lblDeterjanAgırlıklıOrtalama.Text =Math.Round( (pay/payda ),9).ToString();
            lblDeterjanKume.Text = builder.ToString();
            builder.Clear();

            pay = 0.0;
            payda = 0.0;

            foreach (string item in hızKumeVeKestikleri.Keys)
            {
                pay += (hızÇarpan[item] * hızKumeVeKestikleri[item]);
                payda += hızKumeVeKestikleri[item];
                builder.Append(item.ToUpper() + " :" + hızKumeVeKestikleri[item]+" ");
            }
            lblHızAgırlıklıOrtalama.Text =Math.Round( (pay / payda),9).ToString();
            lblHızKume.Text = builder.ToString();
            builder.Clear();

            pay = 0.0;
            payda = 0.0;


            foreach (string item in sureKumeVeKestikleri.Keys)
            {
                pay += (sureÇarpan[item] * sureKumeVeKestikleri[item]);
                payda += sureKumeVeKestikleri[item];
                builder.Append(item.ToUpper() + ": " + sureKumeVeKestikleri[item]+" ");
            }
            lblSureAgırlıklıOrtalama.Text =Math.Round( (pay / payda),9).ToString();
            labelblSureKümel12.Text = builder.ToString();
        }
        public void cıkısGrafiğiKes(Kural temp, double aralık)
        {
            switch (temp.Deterjan)
            {
                case "çok az":
                    {
                        if (deterjanKumeVeKestikleri.ContainsKey("çok az") && deterjanKumeVeKestikleri["çok az"] < aralık)
                        {
                            deterjanKumeVeKestikleri.Remove("çok az");
                            deterjanKumeVeKestikleri.Add("çok az", aralık);
                        }
                        else if (deterjanKumeVeKestikleri.ContainsKey("çok az")) { }
                        else
                        {
                            deterjanKumeVeKestikleri.Add("çok az", aralık);
                        }
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(0, aralık);
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(85, aralık);
                    }
                    break;
                case "az":
                    {
                        if (deterjanKumeVeKestikleri.ContainsKey("az") && deterjanKumeVeKestikleri["az"] < aralık)
                        {
                            deterjanKumeVeKestikleri.Remove("az");
                            deterjanKumeVeKestikleri.Add("az", aralık);
                        }
                        else if (deterjanKumeVeKestikleri.ContainsKey("az")){ }
                        else
                        {
                            deterjanKumeVeKestikleri.Add("az", aralık);
                        }
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanAzUcgen[0], aralık);
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanAzUcgen[2], aralık);
                    }
                    break;
                case "orta":
                    {
                        if (deterjanKumeVeKestikleri.ContainsKey("orta") && deterjanKumeVeKestikleri["orta"] < aralık)
                        {
                            deterjanKumeVeKestikleri.Remove("orta");
                            deterjanKumeVeKestikleri.Add("orta", aralık);
                        }
                        else if(deterjanKumeVeKestikleri.ContainsKey("orta"))
                        { }
                        else
                        {
                            deterjanKumeVeKestikleri.Add("orta", aralık);
                        }
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanOrtaUcgen[0], aralık);
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanOrtaUcgen[2], aralık);
                    }
                    break;
                case "fazla":
                    {
                        if (deterjanKumeVeKestikleri.ContainsKey("fazla") && deterjanKumeVeKestikleri["fazla"] < aralık)
                        {
                            deterjanKumeVeKestikleri.Remove("fazla");
                            deterjanKumeVeKestikleri.Add("fazla", aralık);
                        }
                        else if (deterjanKumeVeKestikleri.ContainsKey("fazla"))
                        { }
                        else
                        {
                            deterjanKumeVeKestikleri.Add("fazla", aralık);
                        }
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanFazla[0], aralık);
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanFazla[2], aralık);
                    }
                    break;
                case "çok fazla":
                    {
                        if (deterjanKumeVeKestikleri.ContainsKey("çok fazla") && deterjanKumeVeKestikleri["çok fazla"] < aralık)
                        {
                            deterjanKumeVeKestikleri.Remove("çok fazla");
                            deterjanKumeVeKestikleri.Add("çok fazla", aralık);
                        }
                        else if (deterjanKumeVeKestikleri.ContainsKey("çok fazla"))
                        { }
                        else
                        {
                            deterjanKumeVeKestikleri.Add("çok fazla", aralık);
                        }
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanCokFazla[0], aralık);
                        chrtDeterjan.Series["cıkıs"].Points.AddXY(bulanıkMantık.deterjanCokFazla[2], aralık);
                    }
                    break;
            }
            switch (temp.Donus_Hizi)
            {
                case "hassas":
                    {
                        if (hızKumeVeKestikleri.ContainsKey("hassas") && hızKumeVeKestikleri["hassas"] < aralık)
                        {
                            hızKumeVeKestikleri.Remove("hassas");
                            hızKumeVeKestikleri.Add("hassas", aralık);
                        }
                        else if (hızKumeVeKestikleri.ContainsKey("hassas")) { }
                        else
                        {
                            hızKumeVeKestikleri.Add("hassas", aralık);
                        }
                        chrtHız.Series["cıkıs"].Points.AddXY(0,aralık);
                        chrtHız.Series["cıkıs"].Points.AddXY(bulanıkMantık.hızHassasYamuk[3],aralık);
                    }
                break;
                case "normal hassas":
                    {
                        if (hızKumeVeKestikleri.ContainsKey("normal hassas") && hızKumeVeKestikleri["normal hassas"] < aralık)
                        {
                            hızKumeVeKestikleri.Remove("normal hassas");
                            hızKumeVeKestikleri.Add("normal hassas", aralık);
                        }
                        else if (hızKumeVeKestikleri.ContainsKey("normal hassas")) { }
                        else
                        {
                            hızKumeVeKestikleri.Add("normal hassas", aralık);
                        }
                        chrtHız.Series["cıkıs"].Points.AddXY(bulanıkMantık.hızNormalHassasUcgen[0], aralık);
                        chrtHız.Series["cıkıs"].Points.AddXY(bulanıkMantık.hızNormalHassasUcgen[2], aralık);
                       
                    }
                    break;
                case "orta":
                    {
                        if (hızKumeVeKestikleri.ContainsKey("orta") && hızKumeVeKestikleri["orta"] < aralık)
                        {
                            hızKumeVeKestikleri.Remove("orta");
                            hızKumeVeKestikleri.Add("orta", aralık);
                        }
                        else if (hızKumeVeKestikleri.ContainsKey("orta")) { }
                        else
                        {
                            hızKumeVeKestikleri.Add("orta", aralık);
                        }
                        chrtHız.Series["cıkıs"].Points.AddXY(3, aralık);
                        chrtHız.Series["cıkıs"].Points.AddXY(7, aralık);
                    }
                    break;
                case "normal güçlü":
                    {
                        if (hızKumeVeKestikleri.ContainsKey("normal güçlü") && hızKumeVeKestikleri["normal güçlü"] < aralık)
                        {
                            hızKumeVeKestikleri.Remove("normal güçlü");
                            hızKumeVeKestikleri.Add("normal güçlü", aralık);
                        }
                        else if (hızKumeVeKestikleri.ContainsKey("normal güçlü")) { }
                        else
                        {
                            hızKumeVeKestikleri.Add("normal güçlü", aralık);
                        }
                        chrtHız.Series["cıkıs"].Points.AddXY(bulanıkMantık.hızNormalGüçlüUcgen[0], aralık);
                        chrtHız.Series["cıkıs"].Points.AddXY(bulanıkMantık.hızNormalGüçlüUcgen[2], aralık);
                    }
                    break;
                case "güçlü":
                    {
                        if (hızKumeVeKestikleri.ContainsKey("güçlü") && hızKumeVeKestikleri["güçlü"] < aralık)
                        {
                            hızKumeVeKestikleri.Remove("güçlü");
                            hızKumeVeKestikleri.Add("güçlü", aralık);
                        }
                        else if (hızKumeVeKestikleri.ContainsKey("güçlü")) { }
                        else
                        {
                            hızKumeVeKestikleri.Add("güçlü", aralık);
                        }
                        chrtHız.Series["cıkıs"].Points.AddXY(bulanıkMantık.hızGüçlüYamuk[0], aralık);
                        chrtHız.Series["cıkıs"].Points.AddXY(10, aralık);
                    }
                    break;
            }
            switch (temp.Sure) {
                case "kısa":
                    {
                        if (sureKumeVeKestikleri.ContainsKey("kısa") && sureKumeVeKestikleri["kısa"] < aralık)
                        {
                            sureKumeVeKestikleri.Remove("kısa");
                            sureKumeVeKestikleri.Add("kısa", aralık);
                        }
                        else if (sureKumeVeKestikleri.ContainsKey("kısa")) { }
                        else
                        {
                            sureKumeVeKestikleri.Add("kısa", aralık);
                        }
                        chrtSure.Series["cıkıs"].Points.AddXY(0,aralık);
                        chrtSure.Series["cıkıs"].Points.AddXY(40,aralık);

                    }
                    break;
                case "normal kısa":
                    {
                        if (sureKumeVeKestikleri.ContainsKey("normal kısa") && sureKumeVeKestikleri["normal kısa"] < aralık)
                        {
                            sureKumeVeKestikleri.Remove("normal kısa");
                            sureKumeVeKestikleri.Add("normal kısa", aralık);
                        }
                        else if (sureKumeVeKestikleri.ContainsKey("normal kısa")) { }
                        else
                        {
                            sureKumeVeKestikleri.Add("normal kısa", aralık);
                        }
                        chrtSure.Series["cıkıs"].Points.AddXY(22, aralık);
                        chrtSure.Series["cıkıs"].Points.AddXY(60, aralık);

                    }
                    break;
                case "orta":
                    {
                        if (sureKumeVeKestikleri.ContainsKey("orta") && sureKumeVeKestikleri["orta"] < aralık)
                        {
                            sureKumeVeKestikleri.Remove("orta");
                            sureKumeVeKestikleri.Add("orta", aralık);
                        }
                        else if (sureKumeVeKestikleri.ContainsKey("orta")) { }
                        else
                        {
                            sureKumeVeKestikleri.Add("orta", aralık);
                        }
                        chrtSure.Series["cıkıs"].Points.AddXY(40, aralık);
                        chrtSure.Series["cıkıs"].Points.AddXY(75, aralık);

                    }
                    break;
                case "normal uzun":
                    {
                        if (sureKumeVeKestikleri.ContainsKey("normal uzun") && sureKumeVeKestikleri["normal uzun"] < aralık)
                        {
                            sureKumeVeKestikleri.Remove("normal uzun");
                            sureKumeVeKestikleri.Add("normal uzun", aralık);
                        }
                        else if (sureKumeVeKestikleri.ContainsKey("normal uzun")) { }
                        else
                        {
                            sureKumeVeKestikleri.Add("normal uzun", aralık);
                        }
                        chrtSure.Series["cıkıs"].Points.AddXY(58, aralık);
                        chrtSure.Series["cıkıs"].Points.AddXY(92, aralık);

                    }
                    break;
                case "uzun":
                    {
                        if (sureKumeVeKestikleri.ContainsKey("uzun") && sureKumeVeKestikleri["uzun"] < aralık)
                        {
                            sureKumeVeKestikleri.Remove("uzun");
                            sureKumeVeKestikleri.Add("uzun", aralık);
                        }
                        else if (sureKumeVeKestikleri.ContainsKey("uzun")) { }
                        else
                        {
                            sureKumeVeKestikleri.Add("uzun", aralık);
                        }
                        chrtSure.Series["cıkıs"].Points.AddXY(73, aralık);
                        chrtSure.Series["cıkıs"].Points.AddXY(95, aralık);

                    }
                    break;
            }
        }
        public void cikisChartTemizle() {
            chrtDeterjan.Series["cıkıs"].Points.Clear();
            chrtHız.Series["cıkıs"].Points.Clear();
            chrtSure.Series["cıkıs"].Points.Clear();
        }


        public void kuralMandaniÇıkarımıYap(Kural kural) {
            
            double hassaslık = 0.0;
            double miktar = 0.0;
            double kirlilik = 0.0;
            switch (kural.Hassaslık)
            {
                case "hassas":
                    hassaslık =(double) nudHassaslıkHassas.Value;
                    break;
                case "orta":
                    hassaslık = (double)nudHassasOrta.Value;
                    break;
                case "sağlam":
                    hassaslık = (double)nudHassaslıkSağlam.Value;
                    break;
                
            }
            switch (kural.Miktar)
            {
                case "küçük":
                    miktar =(double) nudMiktarKücük.Value;
                    break;
                case "orta":
                    miktar = (double)nudMiktarOrta.Value;
                    break;
                case "büyük":
                    miktar = (double)nudMiktarBüyük.Value;
                    break;
                    
            }
            switch (kural.Kirlilik)
            {
                case "küçük":
                    kirlilik = (double)nudKirlilikKüçük.Value;
                    break;
                case "orta":
                    kirlilik = (double)nudKirlilikOrta.Value;
                    break;
                case "büyük":
                    kirlilik = (double)nudKirlilikBüyük.Value;
                    break;

            }
            listBox1.Items.Add(Math.Min(Math.Min(kirlilik,miktar),hassaslık));
           
        }
        public void gridisaretle(List<int>indexler)
        {
            gridTemizle();
            StringBuilder builder = new StringBuilder();
            indexler.ForEach(index=> {
                mainGrid.Rows[index].DefaultCellStyle.BackColor = Color.Red;
            });
          
        }
        public void gridTemizle()
        {
            foreach (DataGridViewRow row in mainGrid.Rows)
            {
                
                    row.DefaultCellStyle.BackColor = Color.White;

               
            }
        }
        private void grfHassasiyet_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.Text.Substring(1) + this.Text.Substring(0, 1);
        }

        private void deterjanDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
           CıktıDetay fx= new CıktıDetay();
           fx.setDeterjanEkran();
           fx.Show();
        
        }

        private void döndürmeHızıDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CıktıDetay fx = new CıktıDetay();
            fx.setDonusHızıEkran();
            fx.Show();
        }

        private void süreDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CıktıDetay fx = new CıktıDetay();
            fx.setSureEkran();
            fx.Show();
        }

        private void hassaslıkDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetayForm formx = new DetayForm();
            formx.setChart(grfHassasiyet.getChart(),"hassasiyet");
            formx.Show();
           
            
        }

        private void miktarDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetayForm formx = new DetayForm();
            formx.setChart(grfMiktar.getChart(), "miktar");
            formx.Show();
        }

        private void kirlilikDetayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetayForm formx = new DetayForm();
            formx.setChart(grfKirlilik.getChart(), "kirlilik");
            formx.Show();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkında hk = new Hakkında();
            hk.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ymyurdakul");
        }
    }
}
