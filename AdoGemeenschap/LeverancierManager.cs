using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class LeverancierManager
    {
        public List<Leverancier> GetLeveranciers()
        {
            var manager = new TuinDbManager();
            var leveranciers = new List<Leverancier>();

            using (var conPlant = manager.GetConnection())
            {
                using (var comPlanten = conPlant.CreateCommand())
                {
                    comPlanten.CommandType = CommandType.Text;
                    comPlanten.CommandText = "Select * from Leveranciers";

                    conPlant.Open();
                    using (var rdrPlanten = comPlanten.ExecuteReader())
                    {
                        Int32 levNrPos = rdrPlanten.GetOrdinal("LevNr");
                        Int32 naamPos = rdrPlanten.GetOrdinal("Naam");
                        Int32 adresPos = rdrPlanten.GetOrdinal("Adres");
                        Int32 postNrPos = rdrPlanten.GetOrdinal("PostNr");
                        Int32 woonplaatsPos = rdrPlanten.GetOrdinal("Woonplaats");

                        while (rdrPlanten.Read())
                        {
                            leveranciers.Add(new Leverancier(rdrPlanten.GetInt32(levNrPos),
                                rdrPlanten.GetString(naamPos),
                                rdrPlanten.GetString(adresPos),
                                rdrPlanten.GetString(postNrPos),
                                rdrPlanten.GetString(woonplaatsPos)));
                        } // while
                    } // using rdrPlanten
                } // using complanten
            } // using conplant
            return leveranciers;
        }
    }
}
