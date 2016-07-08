using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschap
{
    public class PlantenManager
    {
        public List<Plant> getPlanten(Int32 levNr)
        {
            var manager = new TuinDbManager();
            var planten = new List<Plant>();
            using (var conPlant = manager.GetConnection())
            {
                using (var comPlanten = conPlant.CreateCommand())
                {
                    comPlanten.CommandType = CommandType.Text;

                    var ParLevNr = comPlanten.CreateParameter();
                    ParLevNr.ParameterName = "@levnr";
                    ParLevNr.Value = levNr;
                    comPlanten.Parameters.Add(ParLevNr);

                    comPlanten.CommandText = "Select * from planten where Levnr=@levnr";
                    conPlant.Open();

                    using (var rdrPlanten = comPlanten.ExecuteReader())
                    {
                        Int32 plantNrPos = rdrPlanten.GetOrdinal("PlantNr");
                        Int32 naamPos = rdrPlanten.GetOrdinal("Naam");
                        Int32 soortNrPos = rdrPlanten.GetOrdinal("SoortNr");
                        Int32 levNrPos = rdrPlanten.GetOrdinal("Levnr");
                        Int32 kleurNrPos = rdrPlanten.GetOrdinal("Kleur");
                        Int32 verkoopPrijsNrPos = rdrPlanten.GetOrdinal("VerkoopPrijs");
                        //Int32 soortPos = rdrPlanten.GetOrdinal("Soort");

                        while (rdrPlanten.Read())
                        {
                            planten.Add(new Plant(rdrPlanten.GetInt32(plantNrPos),
                                rdrPlanten.GetString(naamPos),
                                rdrPlanten.GetInt32(levNrPos),
                                rdrPlanten.GetInt32(soortNrPos),
                                rdrPlanten.GetString(kleurNrPos),
                                rdrPlanten.GetDecimal(verkoopPrijsNrPos)));
                        } // while
                    } // using rdrPlanten
                } // using comPlanten
            } // using conplant
            return planten;
        }

        public void schrijfWijzigingen(Plant plant)
        {
            var manager = new TuinDbManager();
            using (var conPlant = manager.GetConnection())
            {
                using (var comUpdate = conPlant.CreateCommand())
                {
                    comUpdate.CommandType = CommandType.Text;
                    comUpdate.CommandText = "update planten set Naam=@naam, Kleur=@kleur, VerkoopPrijs=@prijs where PlantNr=@plantnr";

                    var parNaam = comUpdate.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comUpdate.Parameters.Add(parNaam);

                    var parKleur = comUpdate.CreateParameter();
                    parKleur.ParameterName = "@kleur";
                    comUpdate.Parameters.Add(parKleur);

                    var parPrijs = comUpdate.CreateParameter();
                    parPrijs.ParameterName = "@prijs";
                    comUpdate.Parameters.Add(parPrijs);

                    var parPlantNr = comUpdate.CreateParameter();
                    parPlantNr.ParameterName = "@plantnr";
                    comUpdate.Parameters.Add(parPlantNr);

                    conPlant.Open();

                    parNaam.Value = plant.Naam;
                    parKleur.Value = plant.Kleur;
                    parPrijs.Value = plant.Prijs;
                    parPlantNr.Value = plant.PlantNr;
                    comUpdate.ExecuteNonQuery();

                } // comupdate
            } // conbieren
        }

        public void SchrijfToevoeging(Plant plant)
        {
            var manager = new TuinDbManager();
            using (var conPlant = manager.GetConnection())
            {
                using (var comInsert = conPlant.CreateCommand())
                {
                    comInsert.CommandType = CommandType.Text;

                    comInsert.CommandText = "insert into Planten (Naam, SoortNr, Levnr, Kleur, verkoopPrijs) values (@naam, @soortnr, @levnr, @Kleur, @prijs)";

                    var parNaam = comInsert.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    comInsert.Parameters.Add(parNaam);

                    var parSoortNr = comInsert.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    comInsert.Parameters.Add(parSoortNr);

                    var parLevNr = comInsert.CreateParameter();
                    parLevNr.ParameterName = "@levnr";
                    comInsert.Parameters.Add(parLevNr);

                    var parKleur = comInsert.CreateParameter();
                    parKleur.ParameterName = "@kleur";
                    comInsert.Parameters.Add(parKleur);

                    var parPrijs = comInsert.CreateParameter();
                    parPrijs.ParameterName = "@prijs";
                    comInsert.Parameters.Add(parPrijs);

                    conPlant.Open();

                    parNaam.Value = plant.Naam;
                    parSoortNr.Value = plant.SoortNr;
                    parLevNr.Value = plant.LeveranciersNr;
                    parKleur.Value = plant.Kleur;
                    parPrijs.Value = plant.Prijs;
                 
                    comInsert.ExecuteNonQuery();

                } // cominsert
            } // conplant
        }

        public void SchrijfVerwijderingen(int plantNr)
        {
            var manager = new TuinDbManager();
            using (var conPlanten = manager.GetConnection())
            {
                using (var comDelete = conPlanten.CreateCommand())
                {
                    comDelete.CommandType = CommandType.Text;
                    comDelete.CommandText = "delete from Planten where PlantNr=@plantnr";

                    var parPlantNr = comDelete.CreateParameter();
                    parPlantNr.ParameterName = "@plantnr";
                    parPlantNr.Value = plantNr;
                    comDelete.Parameters.Add(parPlantNr);

                    conPlanten.Open();
                    comDelete.ExecuteNonQuery();


                }
            }
        }
    }
}
