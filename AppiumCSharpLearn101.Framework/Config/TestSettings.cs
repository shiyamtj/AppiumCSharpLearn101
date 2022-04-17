using Newtonsoft.Json;

namespace AppiumCSharpLearn101.Framework.Config
{
    public class TestSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("autPath")]
        public string AUTPath { get; set; }

        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }

        [JsonProperty("platformName")]
        public string PlatformName { get; set; }

        [JsonProperty("chromeDriverPath")]
        public string ChromeDriverPath { get; set; }
    }
}