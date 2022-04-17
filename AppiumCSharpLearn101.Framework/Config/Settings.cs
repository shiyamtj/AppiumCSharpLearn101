using AppiumCSharpLearn101.Framework.Core;

namespace AppiumCSharpLearn101.Framework.Config
{
    public class Settings
    {
        public string AUTPath { get; set; }
        public string ChromeDriverPath { get; set; }
        public MobileType PlatformName { get; set; }
        public string DeviceName { get; set; }
    }
}