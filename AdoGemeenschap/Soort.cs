using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class Soort
    {
        public int SoortNr { get; set; }
        public string SoortNaam { get; set; }
        public Soort(String nSoort, int nSoortNr)
        {
            SoortNaam = nSoort;
            SoortNr = nSoortNr;
        }

        public Soort()
        {

        }
        public override String ToString()
        {
            return SoortNaam;
        }
    }
}
