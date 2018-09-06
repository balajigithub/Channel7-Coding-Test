using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace BusinessLogicLayer
{
    public class Utility
    {
        public static JObject GetJSON(String JsonPath)
        {
            try
            {
                using (System.IO.StreamReader r = new StreamReader(JsonPath))
                {
                    var Json = r.ReadToEnd();
                    JObject JsonObj = JObject.Parse(Json);
                    return JsonObj;
                }
            }
            catch(Exception ex)
            {

                throw ex.InnerException;
            }
        }
    }
}