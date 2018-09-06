using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class CommaSeparatedFirstNameByAge
    {
        public static string GetCommaSeparatedFirstNameByAge(string JsonPath, int Age)
        {
            //Read the Json Source
            using (System.IO.StreamReader r = new StreamReader(JsonPath))
            {
                //String Builder for appending comma separated first names..............
                StringBuilder builder = new StringBuilder();
                var Json = r.ReadToEnd();
                JObject JsonObj = JObject.Parse(Json);
                //Get the FirstNames for Particular Age.........
                var GetFirstNames = (from h in JsonObj["Data"].Where(a => (int)a["age"] == Age)
                                     select new
                                     {
                                         firstname = (string)h["first"],
                                     }).ToList();
                //Check there are records...if there process otherwise dont go to loop........
                if (GetFirstNames.Count > 0)
                {
                    String SEPARATOR = "";
                    //Loop through the First Names.......
                    foreach (var Names in GetFirstNames)
                    {
                        builder.Append(SEPARATOR);
                        builder.Append(Names.firstname.ToString());
                        SEPARATOR = ",";
                    }
                }
                //return the string builder output as string............
                return builder.ToString();
            }
        }
    }
}