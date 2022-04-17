using AppiumCSharp101.Framework.Core;
using AppiumCSharp101.Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumCSharp101.Domain.Screen
{
    public class LoginScreen: BaseScreen
    {
        By usernameLocator => MobileBy.AccessibilityId("test-Username");
        By passwordLocator => MobileBy.AccessibilityId("test-Password");
        By loginBtnLocator => MobileBy.AccessibilityId("test-LOGIN");

        public void SetUsername(string username) => AppiumDriver.WaitForElement(usernameLocator).SendKeys(username);
        public void SetPassword(string password) => AppiumDriver.WaitForElement(passwordLocator).SendKeys(password);
        public void ClickLogin() => AppiumDriver.WaitForElement(loginBtnLocator).Click();
        public void Login(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
            ClickLogin();
        }
    }
}