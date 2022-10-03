using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki2017
{
    internal class Korcsolya
    {
        public string Nev;
        public string Orszag;
        public double TechPont;
        public double KompPont;
        public int Levonas;
        public double osszPont;

        public Korcsolya (string AdatSor)
        {
            string[] AdatSorElemek = AdatSor.Split(';');
            this.Nev = AdatSorElemek[0];
            this.Orszag = AdatSorElemek[1];
            this.TechPont = Convert.ToDouble(AdatSorElemek[2].Replace('.', ','));
            this.KompPont = Convert.ToDouble (AdatSorElemek[3].Replace('.', ','));
            this.Levonas = Convert.ToInt32(AdatSorElemek[4]);
        }
        
    }
}
