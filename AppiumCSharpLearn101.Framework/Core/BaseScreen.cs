using OpenQA.Selenium.Appium;

namespace AppiumCSharpLearn101.Framework.Core
{
    public class BaseScreen
    {
        public MobileType MobileType => FW.RunSettings.PlatformName;
        public AppiumDriver<AppiumWebElement> AppiumDriver => FW.Driver;
    }
}