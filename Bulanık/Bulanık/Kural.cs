using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
 public   class Kural
    {
        //Aslında gerek yok ama indexleme için kullanıcam
        public int Index_numarası { get; set; }
        public string Hassaslık { get; set; }
        public string Miktar { get; set; }
        public string Kirlilik { get; set; }
        public string Donus_Hizi { get; set; }
        public string Sure { get; set; }
        public string Deterjan { get; set; }
        public Kural()
        { }
        public Kural(int index_numarası, string hassaslık,
            string miktar, string kirlilik, string donus_hizi, string sure, string deterjan)
        {
            this.Index_numarası = index_numarası;
            this.Hassaslık = hassaslık;
            this.Miktar = miktar;
            this.Kirlilik = kirlilik;
            this.Donus_Hizi = donus_hizi;
            this.Sure = sure;
            this.Deterjan = deterjan;
        }
        public Kural( string hassaslık,
         string miktar, string kirlilik)
        {
            this.Hassaslık = hassaslık;
            this.Miktar = miktar;
            this.Kirlilik = kirlilik;
         
        }

        public override bool Equals(object obj)
        {
            Kural temp = (Kural)obj;
            return (this.Hassaslık == temp.Hassaslık && this.Miktar == temp.Miktar && this.Kirlilik == temp.Kirlilik);

        }

       

    }
}
