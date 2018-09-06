using Microsoft.Extensions.Configuration;
using System.IO;

namespace Channel7_Coding_FrontEnd
{
    internal static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }

        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("AppSettingFile.json")
                    .Build();
        }
    }
}