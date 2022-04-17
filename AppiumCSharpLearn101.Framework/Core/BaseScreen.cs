using AppiumCSharpLearn101.Framework.Core;
using OpenQA.Selenium.Appium;

namespace AppiumCSharpLearn101.Framework.Core
{
    public class BaseScreen
    {
        public MobileType MobileType => DriverFactory.Instance.MobileType;
        public AppiumDriver<AppiumWebElement> AppiumDriver => DriverFactory.Instance.AppiumDriver;
    }
}