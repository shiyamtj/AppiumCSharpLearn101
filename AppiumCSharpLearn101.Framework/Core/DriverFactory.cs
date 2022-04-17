using System;
using System.IO;
using System.Linq;
using AppiumCSharpLearn101.Framework.Core;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;

namespace AppiumCSharpLearn101.Framework.Core
{
    public class DriverFactory
    {
        private AppiumLocalService _appiumLocalService;
        private static Lazy<DriverFactory> _instance = new Lazy<DriverFactory>(() => new DriverFactory());
        private DriverFactory() { }

        public static DriverFactory Instance => _instance.Value;
        public AppiumDriver<AppiumWebElement> AppiumDriver { get; set; }
        public MobileType MobileType { get; set; }

        public void CloseApp() => AppiumDriver.CloseApp();

        public void InitialAppiumDriver(MobileType mobileType)
        {
            MobileType = mobileType;
            var appiumOptions = new AppiumOptions();

            if (MobileType == MobileType.ANDROID)
            {
                string testAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Android.SauceLabs.Mobile.Sample.app.2.7.1.apk");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12.0");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, false);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, true);
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12.0");
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.swaglabsmobileapp");
                appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "com.swaglabsmobileapp.SplashActivity");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, testAppPath);
                //AppiumDriver = new AndroidDriver<AppiumWebElement>(StartAppiumLocalService(), appiumOptions);
                AppiumDriver = new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), appiumOptions);
            }

            else
            {
                string testAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "iOS.Simulator.SauceLabs.Mobile.Sample.app.2.7.1.app");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone 13 Pro Max");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "15.4");
                appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, testAppPath);
                //AppiumDriver = new IOSDriver<AppiumWebElement>(StartAppiumLocalService(), appiumOptions);
                AppiumDriver = new IOSDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), appiumOptions);
            }
        }

        public void SwitchToWebview()
        {
            var contexts = ((IContextAware)AppiumDriver).Contexts;
            var nativeContext = contexts.ToList().Find(a => a.Contains("WEBVIEW"));
            ((IContextAware)AppiumDriver).Context = nativeContext;
        }

        public void SwitchToNative()
        {
            var contexts = ((IContextAware)AppiumDriver).Contexts;
            var nativeContext = contexts.ToList().Find(a => a.Contains("NATIVE"));
            ((IContextAware)AppiumDriver).Context = nativeContext;
        }

        public AppiumLocalService StartAppiumLocalService()
        {
            _appiumLocalService = new AppiumServiceBuilder()
                                                .UsingAnyFreePort()
                                                .WithAppiumJS(new FileInfo("/usr/local/lib/node_modules/appium/build/lib/main.js"))
                                                .Build();
            if (!_appiumLocalService.IsRunning)
                _appiumLocalService.Start();

            return _appiumLocalService;
        }

        public AppiumLocalService StartAppiumLocalService(int port)
        {
            _appiumLocalService = new AppiumServiceBuilder()
                                            .UsingPort(port)
                                            .WithAppiumJS(new FileInfo("/usr/local/lib/node_modules/appium/build/lib/main.js"))
                                            .Build();
            if (!_appiumLocalService.IsRunning)
                _appiumLocalService.Start();

            return _appiumLocalService;
        }
    }
}