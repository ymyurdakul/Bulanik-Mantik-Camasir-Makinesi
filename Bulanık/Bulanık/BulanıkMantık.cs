using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WindowsFormsApplication1
{
    class BulanıkMantık
    {
        public double[] hassasYamukBas = { -4,-1.5,2,4};
        public double[] hassasUcgen = { 3, 5, 7 };
        public double[] hassasYamukSon = { 5.5, 8, 12.5, 14 };

        public double[] miktarYamukBas = { -4,-1.5,2,4};
        public double[] miktarUcgen = { 3,5,7};
        public double[] miktarYamukSon = { 5.5,8,12.5,14};

        public double[] kirlilikYamukBas = { -4.5, -2.5,2, 4.5 };
        public double[] kirlilikUcgen = { 3, 5, 7 };
        public double[] kirlilikYamukSon = { 5.5, 8, 12.5, 15};

        public double[] deterjanAzUcgen = {20,85,150 };
        public double[] deterjanCokAzYamuk = {0,0,20,85 };
        public double[] deterjanOrtaUcgen = {85,150,215 };
        public double[] deterjanFazla = { 150,215,280};
        public double[] deterjanCokFazla = { 215, 280, 300, 300 };

        public double[] sureKısaYamuk = {-46.5,-25.28,22.3,39.9 };
        public double[] sureNormalKısaUcgen = { 22.3, 39.9,57.5 };
        public double[] sureOrtaUcgen = {39.9,57.5,75.1 };
        public double[] sureNormalUzunUcgen = {57.5,75.1,92.7 };
        public double[] sureUzunYamuk = {75,92.7,111.6,130 };

        public double[] hızHassasYamuk = { -5.8,-2.8,0.5,1.5};
        public double[] hızNormalHassasUcgen = {0.5,2.75,5 };
        public double[] hızOrtaUcgen = {2.75,5,5 };
        public double[] hızNormalGüçlüUcgen = {5,7.25,5 };
        public double[] hızGüçlüYamuk = {8.5,9.5,12.8,15.2 };


        public double GirisUyelikHesapla(String bulanıkKumeAdı,String üyelik,double deger)
        {
            switch (bulanıkKumeAdı)
            {
                    case "Hassaslık":
                    {
                        if (üyelik == "sağlam")
                            return YamukUyelikHesapla(deger,hassasYamukBas);
                        if (üyelik == "orta")
                            return UcgenUyelikHesapla(deger,hassasUcgen);
                        if (üyelik == "hassas")
                            return YamukUyelikHesapla(deger,hassasYamukSon);
                    }break;
                case "Miktar":
                    {
                        if (üyelik == "küçük")
                            return YamukUyelikHesapla(deger, miktarYamukBas);
                        if (üyelik == "orta")
                            return UcgenUyelikHesapla(deger, miktarUcgen);
                        if (üyelik == "büyük")
                            return YamukUyelikHesapla(deger, miktarYamukSon);
                    }
                    break;
                case "Kirlilik":
                    {
                        if (üyelik == "küçük")
                            return YamukUyelikHesapla(deger, kirlilikYamukBas);
                        if (üyelik == "orta")
                            return UcgenUyelikHesapla(deger, kirlilikUcgen);
                        if (üyelik == "büyük")
                            return YamukUyelikHesapla(deger, kirlilikYamukSon);
                    }
                    break;
                default:
                    break;
            }
            return 0;
        }
      
        public double YamukUyelikHesapla(double deger,double []yamuk)
        {
            double a = deger;
            double a1, a2, a3, a4;
            a1 = yamuk[0];
            a2 = yamuk[1];
            a3 = yamuk[2];
            a4 = yamuk[3];

            double s1 = (a - a1) / (a2 - a1);
            double s2 = (a4 - a) / (a4 - a3);
            return Math.Max(Math.Min(s1,Math.Min(1,s2)),0);
        }
        public double UcgenUyelikHesapla(double deger, double[] ucgen)
        {
            double a = deger;
            double a1, a2, a3;
            a1 = ucgen[0];
            a2 = ucgen[1];
            a3 = ucgen[2];
            double s1 = (a - a1) / (a2-a1);
            double s2 = (a3 - a) / (a3 - a2);
            return Math.Max(Math.Min(s1,s2),0);
        }

       


    }
}
