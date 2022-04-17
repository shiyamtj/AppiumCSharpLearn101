using OpenQA.Selenium.Appium;

namespace AppiumCSharp101.Framework.Core
{
    public class BaseScreen
    {
        public MobileType MobileType => DriverFactory.Instance.MobileType;
        public AppiumDriver<AppiumWebElement> AppiumDriver => DriverFactory.Instance.AppiumDriver;
    }
}
