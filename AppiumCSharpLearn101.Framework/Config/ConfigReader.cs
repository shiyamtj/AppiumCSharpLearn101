using System;
using System.IO;
using AppiumCSharpLearn101.Framework.Core;
using Microsoft.Extensions.Configuration;

namespace AppiumCSharpLearn101.Framework.Config
{
    public class ConfigReader
    {
        public static void InitializeSettings()
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appSettings.json");

            IConfigurationRoot configurationRoot = builder.Build();

            var settings = configurationRoot.GetSection("testSettings").Get<TestSettings>();

            Settings.PlatformName = Enum.TryParse(settings.PlatformName, out MobileType mobileType) ? mobileType : throw new Exception("[CRITICAL] Undefined Mobile Type");
            Settings.AUTPath = settings.AUTPath;
            Settings.ChromeDriverPath = settings.ChromeDriverPath;
            Settings.DeviceName = settings.DeviceName;
        }
    }
}