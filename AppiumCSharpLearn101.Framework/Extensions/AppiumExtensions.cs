using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Support.UI;

namespace AppiumCSharpLearn101.Framework.Extensions
{
    public static class AppiumExtensions
    {
        public static AppiumWebElement WaitForElement(this AppiumDriver<AppiumWebElement> driver, By by)
        {
            var fluentWait = new DefaultWait<AppiumDriver<AppiumWebElement>>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait.Until(x => x.FindElement(by));
        }

        public static void WaitInSeconds(this AppiumDriver<AppiumWebElement> driver, int seconds)
        {
            try { Thread.Sleep(TimeSpan.FromSeconds(seconds)); }
            catch { }
        }

        public static void SwitchToWebview(this AppiumDriver<AppiumWebElement> driver)
        {
            var contexts = ((IContextAware)driver).Contexts;
            var nativeContext = contexts.ToList().Find(a => a.Contains("WEBVIEW"));
            ((IContextAware)driver).Context = nativeContext;
        }

        public static void SwitchToNative(this AppiumDriver<AppiumWebElement> driver)
        {
            var contexts = ((IContextAware)driver).Contexts;
            var nativeContext = contexts.ToList().Find(a => a.Contains("NATIVE"));
            ((IContextAware)driver).Context = nativeContext;
        }
    }
}