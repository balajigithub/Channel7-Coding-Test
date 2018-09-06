using BusinessLogicLayer;
using System;
using System.Collections.Generic;

namespace Channel7_Coding_FrontEnd
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string JsonPath = ConfigurationManager.AppSetting["JsonFilePath:Path"];
                string FirstNames = CommaSeparatedFirstNameByAge.GetCommaSeparatedFirstNameByAge(JsonPath, 23);
                List<string> FullNameByIdResult = FullNameById.GetFullNameById(JsonPath, 31);
                List<string> GroupByAgeandGenderResult = GroupByAgeandGender.GetGroupByAgeandGender(JsonPath);
                Console.WriteLine("Get Comma Separated FirstName By Age 23 Result");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(FirstNames);
                Console.WriteLine("-------------------------------------------------");

                Console.WriteLine("Get Full Name By Id 31 Result");
                Console.WriteLine("-------------------------------------------------");
                foreach (string fnames in FullNameByIdResult)
                {
                    Console.WriteLine(fnames);
                }
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Get GroupBy Age and Gender Result");
                Console.WriteLine("-------------------------------------------------");
                foreach (string fnames in GroupByAgeandGenderResult)
                {
                    Console.WriteLine(fnames);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}