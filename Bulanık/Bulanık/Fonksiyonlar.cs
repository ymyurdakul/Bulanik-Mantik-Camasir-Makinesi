using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Fonksiyonlar
    {
        public static List<String> UyeKumeAdıBul(double deger,string bulanık_kume_ismi)
        {


            if (bulanık_kume_ismi == "Hassaslık")
            {
                return HassasKumeAdıBul(deger);
            }
            else if (bulanık_kume_ismi == "Miktar")
            {
                return MiktarKumeAdıBul(deger);
            }
            else if (bulanık_kume_ismi == "Kirlilik")
            {
                return KirlilikKumeAdıBul(deger);
            }
            return null;

        }
        private static List<String> HassasKumeAdıBul(double deger)
        {
            List<String> temp = new List<string>();
            if (deger<3)
            {
                temp.Add("sağlam");
            }
            if (deger >= 3 && deger<=4)
            {
                temp.Add("sağlam");
                temp.Add("orta");
            }
            if (deger > 4 && deger < 5.5)
            {
                temp.Add("orta");
            }
            if (deger >= 5.5 && deger <7)
            {
                temp.Add("orta");
                temp.Add("hassas");
            }
            if (deger >= 7)
            {
                temp.Add("hassas");
            }
            return temp;
        }
        private static List<String> KirlilikKumeAdıBul(double deger)
        {
            List<String> temp = new List<string>();
            if (deger < 3)
            {
                temp.Add("küçük");
            }
            if (deger >= 3 && deger <= 4.5)
            {
                temp.Add("küçük");
                temp.Add("orta");
            }
            if (deger > 4.5 && deger < 5.5)
            {
                temp.Add("orta");
            }
            if (deger >= 5.5 && deger < 7)
            {
                temp.Add("orta");
                temp.Add("büyük");
            }
            if (deger >= 7)
            {
                temp.Add("büyük");
            }
            return temp;
        }
        private static List<String> MiktarKumeAdıBul(double deger)
        {
            List<String> temp = new List<string>();
            if (deger < 3)
            {
                temp.Add("küçük");
            }
            if (deger >= 3 && deger <= 4)
            {
                temp.Add("küçük");
                temp.Add("orta");
            }
            if (deger > 4 && deger < 5.5)
            {
                temp.Add("orta");
            }
            if (deger >= 5.5 && deger < 7)
            {
                temp.Add("orta");
                temp.Add("büyük");
            }
            if (deger >= 7)
            {
                temp.Add("büyük");
            }
            return temp;
        }
       public static List<int> KuralAteşlemeIndexBul(List<String>hassaslıkKumeAdları,List<String>miktarKumeAdları,List<String>kirlilikKumeAdları)
        {
            List<int> ateşlenenKurallar = new List<int>();
            for (int i = 0; i < hassaslıkKumeAdları.Count(); i++)
            {
                for (int j = 0; j < miktarKumeAdları.Count(); j++)
                {
                    for (int k = 0; k < kirlilikKumeAdları.Count(); k++)
                    {
                        Kural temp = new Kural(hassaslıkKumeAdları[i],miktarKumeAdları[j],kirlilikKumeAdları[k]);
                        ateşlenenKurallar.Add(indexBul(temp));
                    }
                }
            }
            return ateşlenenKurallar;
        }
        private static int indexBul(Kural temp)
        {
            for (int i = 0; i < Form1.KURAL_TABANI.Count(); i++)
            {
                if (Form1.KURAL_TABANI[i].Equals(temp))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
