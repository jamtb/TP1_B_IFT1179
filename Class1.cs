using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_B_IFT1179
{
    internal class Voitures
    {
        private string noSerie;
        private string marque;
        private int annee;
        private double prix;



        public Voitures(string noSerie, string marque, int annee, int prix)
        {
            this.noSerie = noSerie;
            this.marque = marque;
            this.annee = annee;
            this.prix = prix;
        }

        public string Serie
        {
            get { return noSerie; }
            set { noSerie = value; }
        }
        public string Marque
        {
            get { return marque; }
            set { marque = value; }
        }
        public int Annee
        {
            get { return annee; }
            set { annee = value; }
        }
        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }
    }
}
