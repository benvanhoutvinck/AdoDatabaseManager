using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Leverancier
    {
        private Int32 levNrValue;

        public Int32 LevNr
        {
            get { return levNrValue; }
            set { levNrValue = value; }
        }

        private string naamValue;

        public string Naam
        {
            get { return naamValue; }
            set { naamValue = value; }
        }

        private string adresValue;

        public string Adres
        {
            get { return adresValue; }
            set { adresValue = value; }
        }

        private string postNrValue;

        public string PostNr
        {
            get { return postNrValue; }
            set { postNrValue = value; }
        }

        private string woonplaatsValue;

        public string Woonplaats
        {
            get { return woonplaatsValue; }
            set { woonplaatsValue = value; }
        }

        public Leverancier(Int32 levNr, string naam, string adres, string postNr, string woonplaats)
        {
            this.LevNr = levNr;
            this.Naam = naam;
            this.Adres = adres;
            this.PostNr = postNr;
            this.Woonplaats = woonplaats;
        }
    }
}
