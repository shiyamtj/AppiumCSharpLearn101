using AppiumCSharpLearn101.Framework.Core;
using AppiumCSharpLearn101.Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumCSharpLearn101.Domain.Screen
{
    public class Menu : BaseScreen
    {
        By MenuLogoutLocator => MobileBy.AccessibilityId("test-LOGOUT");
        By MenuCloseLocator => MobileBy.AccessibilityId("test-Close");
        By MenuIconLocator => (MobileType == MobileType.IOS) ?
                    By.XPath("//XCUIElementTypeOther[@name=\"test-Menu\"]/XCUIElementTypeOther") :
                    By.XPath("//android.view.ViewGroup[@content-desc=\"test-Menu\"]/android.view.ViewGroup/android.widget.ImageView");

        public Menu() { }

        public void ExpandCollapse() => AppiumDriver.WaitForElement(MenuIconLocator).Click();

        public void Logout() => AppiumDriver.WaitForElement(MenuLogoutLocator).Click();

        public void CloseMenu() => AppiumDriver.WaitForElement(MenuCloseLocator).Click();
    }
}
