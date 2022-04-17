using AppiumCSharp101.Framework.Core;

namespace AppiumCSharp101.Framework.Config
{
    public class Settings
    {
        public static string AUTPath { get; set; }
        public static string ChromeDriverPath { get; set; }
        public static MobileType PlatformName { get; set; }
        public static string DeviceName { get; set; }
    }
}