using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class CommaSeparatedFirstNameByAge
    {
        public static string GetCommaSeparatedFirstNameByAge(string JsonPath, int Age)
        {
            //String Builder for appending comma separated first names..............
            StringBuilder builder = new StringBuilder();
            //Get JSON Object
            JObject JsonObj = Utility.GetJSON(JsonPath);

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