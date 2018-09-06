using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class FullNameById
    {
        public static List<string> GetFullNameById(string JsonPath, int Id)
        {
            try
            {
                //Read the Json Source

                JObject JsonObj = Utility.GetJSON(JsonPath);
                //Get the First and Last Names for a given Id.................
                var GetFirstAndLastNames = (from h in JsonObj["Data"].Where(a => (int)a["id"] == Id)
                                            select new
                                            {
                                                FirstName = (string)h["first"],
                                                LastName = (string)h["last"]
                                            }).ToList();

                List<string> FullNamesList = new List<string>();
                //Check there are records...if there process otherwise dont go to loop........
                if (GetFirstAndLastNames.Count > 0)
                {
                    //Loop through to get Full Names and add it to the List<string> FullNamesList = new List<string>();
                    foreach (var Names in GetFirstAndLastNames)
                    {
                        FullNamesList.Add((Names.FirstName.ToString()) + " " + Names.LastName.ToString());
                    }
                }
                //Return the Full Name List..........
                return FullNamesList;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}