using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class SoortManager
    {
        public List<Soort> GetSoorten()
        {
            var soorten = new List<Soort>();
            var manager = new TuinDbManager();

            using (var conTuin = manager.GetConnection())
            {
                using (var comSoorten = conTuin.CreateCommand())
                {
                    comSoorten.CommandType = CommandType.Text;
                    comSoorten.CommandText = "select SoortNr, Soort from Soorten order by Soort";

                    conTuin.Open();
                    using (var rdrSoorten = comSoorten.ExecuteReader())
                    {
                        var soortPos = rdrSoorten.GetOrdinal("soort");
                        var soortnrPos = rdrSoorten.GetOrdinal("soortnr");

                        while (rdrSoorten.Read())
                        {
                            soorten.Add(new Soort(rdrSoorten.GetString(soortPos), rdrSoorten.GetInt32(soortnrPos)));
                        }
                    }
                }
            }
            return soorten;
        }
    }
}
