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
                Console.WriteLine("Enter Age");
                int Age = Convert.ToInt32(Console.ReadLine());
                string FirstNames = CommaSeparatedFirstNameByAge.GetCommaSeparatedFirstNameByAge(JsonPath, Age);
                Console.WriteLine("Enter Id");
                int Id = Convert.ToInt32(Console.ReadLine());
                List<string> FullNameByIdResult = FullNameById.GetFullNameById(JsonPath, Id);
                List<string> GroupByAgeandGenderResult = GroupByAgeandGender.GetGroupByAgeandGender(JsonPath);

                Console.WriteLine("Get Comma Separated FirstName(s) for Age" + " " + Age + " " + "Result for all");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(FirstNames);
                Console.WriteLine("-------------------------------------------------");

                Console.WriteLine("Get Full Name for Id" + " " + Id + " " + "Result");
                Console.WriteLine("-------------------------------------------------");
                foreach (string fnames in FullNameByIdResult)
                {
                    Console.WriteLine(fnames);
                }
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Get GroupBy Age and Gender Result for all");
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