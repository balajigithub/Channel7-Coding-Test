using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class TestJsonSource
    {
        private string JsonPath = string.Empty;
        //Constructor to get the Json path once for all the methods to access..........
        public TestJsonSource()
        {
            JsonPath = ConfigurationManager.AppSetting["JsonFilePath:Path"];
        }

        [Fact]
        //Test Get First Names By Age Comma Separated.........
        public void TestGetFirstNamesByAge()
        {
            //Expected Result...........
            String ExpectedResult = "Bill,Frank";
            //Result got from the Method GetCommaSeparatedFirstNameByAge
            string FirstNameByAgeList = CommaSeparatedFirstNameByAge.GetCommaSeparatedFirstNameByAge(JsonPath, 23);
            //Checking whether the Expected Result Values are same as Result from the Method developed......
            bool flag = ExpectedResult.All(e => FirstNameByAgeList.Contains(e));
            //True means Success else Failure
            Assert.True(flag);
        }

        [Fact]
        //Test Get Full Names By Id ...................
        public void TestGetFullNameById()
        {
            List<string> Result = new List<string>();
            List<string> ExpectedResult = new List<string>();
            //Expected Result...........
            ExpectedResult.Add("Jill Scott");
            ExpectedResult.Add("Anna Meredith");
            ExpectedResult.Add("Janet Jackson");
            //Result got from the Method GetFullNameById
            Result = FullNameById.GetFullNameById(JsonPath, 31);
            //Checking whether the Expected Result Values are same as Result from the Method developed......
            bool flag = ExpectedResult.All(e => Result.Contains(e));
            //True means Success else Failure
            Assert.True(flag);
        }

        [Fact]
        //Test Get Group By Age and Genger..........
        public void TestGroupByAgeandGender()
        {
            List<string> Result = new List<string>();
            //Expected Result...........
            List<string> ExpectedResult = new List<string>();
            ExpectedResult.Add("Age: 23 Female 0 Male 2");
            ExpectedResult.Add("Age: 54 Female 0 Male 1");
            ExpectedResult.Add("Age: 66 Female 2 Male 1");
            //Result got from the Method GetGroupByAgeandGender
            Result = GroupByAgeandGender.GetGroupByAgeandGender(JsonPath);
            //Checking whether the Expected Result Values are same as Result from the Method developed......
            bool flag = ExpectedResult.All(e => Result.Contains(e));
            //True means Success else Failure
            Assert.True(flag);
        }
    }
}