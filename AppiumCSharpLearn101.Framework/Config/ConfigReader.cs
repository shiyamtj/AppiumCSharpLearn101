using System;
using System.IO;
using AppiumCSharpLearn101.Framework.Core;
using Microsoft.Extensions.Configuration;

namespace AppiumCSharpLearn101.Framework.Config
{
    public class ConfigReader
    {
        public static Settings GetSettings()
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appSettings.json");

            IConfigurationRoot configurationRoot = builder.Build();

            var testSettings = configurationRoot.GetSection("testSettings").Get<TestSettings>();
            var settings = new Settings();
            settings.PlatformName = Enum.TryParse(testSettings.PlatformName, out MobileType mobileType) ? mobileType : throw new Exception("[CRITICAL] Undefined Mobile Type");
            settings.AUTPath = testSettings.AUTPath;
            settings.ChromeDriverPath = testSettings.ChromeDriverPath;
            settings.DeviceName = testSettings.DeviceName;
            return settings;
        }
    }
}