using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogicLayer
{
    public class GroupByAgeandGender
    {
        public static List<string> GetGroupByAgeandGender(string path)
        {
            try
            {
                //Read the Json Source
                using (System.IO.StreamReader r = new StreamReader(path))
                {
                    var Json = r.ReadToEnd();
                    JObject JsonObj = JObject.Parse(Json);
                    //Get the information based on Group By Age and How many of them are Male and Female..........
                    var GrpByAge = (from h in JsonObj["Data"]
                                    select new
                                    {
                                        age = (int)h["age"],
                                        gender = (string)h["gender"]
                                    }).GroupBy(a => new { a.age }).ToList();

                    List<string> GrpByAgeAndGenderList = new List<string>();
                    //Check there are records...if there process otherwise dont go to loop........
                    if (GrpByAge.Count > 0)
                    {
                        //Loop through and Get Count of Male and Female,Age and Gender and add it to List<string> GrpByAgeAndGenderList = new List<string>();..............
                        foreach (var AgeGrp in GrpByAge)
                        {
                            GrpByAgeAndGenderList.Add("Age:" + " " + AgeGrp.Key.age + " " + "Female" + " "
                            + AgeGrp.Where(a => a.gender == "F").Count() + " " + "Male" + " " +
                            AgeGrp.Where(a => a.gender == "M").Count());
                        }
                    }
                    //List the output as List
                    return GrpByAgeAndGenderList;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}