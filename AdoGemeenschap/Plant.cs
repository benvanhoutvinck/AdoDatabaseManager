using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Plant
    {

        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set
            {
                naamValue = value;
               
            }
        }


        private Int32 plantNrValue;
        public Int32 PlantNr
        {
            get { return plantNrValue; }
            set { plantNrValue = value; }
        }

        private Int32 soortNrValue;

        public Int32 SoortNr
        {
            get { return soortNrValue; }
            set { soortNrValue = value; }
        }


        private string soortValue;
        public string Soort
        {
            get { return soortValue; }
            set { soortValue = value; }
        }

        private Int32 leveranciersNrValue;
        public Int32 LeveranciersNr
        {
            get { return leveranciersNrValue; }
            set { leveranciersNrValue = value; }
        }

        private string kleurValue;

        public string Kleur
        {
            get { return kleurValue; }
            set
            {
                kleurValue = value;
               
            }
        }

        private decimal prijsValue;

        public decimal Prijs
        {
            get { return prijsValue; }
            set
            {
                prijsValue = value;
                
            }
        }

        public Plant() { }

        public Plant(Int32 plantnR, string naam, Int32 LevNr, Int32 soortNr, string kleur, decimal prijs)
        {
            this.PlantNr = plantnR;
            this.Naam = naam;
            this.LeveranciersNr = LevNr;
            this.SoortNr = soortNr;
            this.Kleur = kleur;
            this.Prijs = prijs;
           
        }
    }
}
