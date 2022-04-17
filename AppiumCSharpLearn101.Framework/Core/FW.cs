using System;
using System.IO;
using AppiumCSharpLearn101.Framework.Config;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;

namespace AppiumCSharpLearn101.Framework.Core
{
    public class FW
    {
        public static AppiumDriver<AppiumWebElement> Driver => _driver ?? throw new NullReferenceException("Driver not Set. Please set Init");
        public static Settings RunSettings => _runSettings ?? throw new NullReferenceException("Settings not Set. Please set Init");

        [ThreadStatic]
        private static AppiumDriver<AppiumWebElement> _driver;

        [ThreadStatic]
        private static Settings _runSettings;

        public static AppiumLocalService AppiumLocalService;

        public static void Init(MobileType mobileType)
        {
            var settings = ConfigReader.GetSettings();
            InitialAppiumDriver(mobileType);
            settings.PlatformName = mobileType;
            _runSettings = settings;
        }

        public static AppiumLocalService StartAppiumLocalService()
        {
            var appiumLocalService = new AppiumServiceBuilder()
                                                .UsingAnyFreePort()
                                                .WithAppiumJS(new FileInfo("/usr/local/lib/node_modules/appium/build/lib/main.js"))
                                                .Build();
            if (!appiumLocalService.IsRunning)
                appiumLocalService.Start();

            return appiumLocalService;
        }

        public static AppiumLocalService StartAppiumLocalService(int port)
        {
            var appiumLocalService = new AppiumServiceBuilder()
                                                .UsingPort(port)
                                                .WithAppiumJS(new FileInfo("/usr/local/lib/node_modules/appium/build/lib/main.js"))
                                                .Build();
            if (!appiumLocalService.IsRunning)
                appiumLocalService.Start();

            return appiumLocalService;
        }

        public static void InitialAppiumDriver(MobileType mobileType)
        {
            var appiumOptions = new AppiumOptions();

            if (mobileType == MobileType.ANDROID)
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
                _driver = new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), appiumOptions);
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
                _driver = new IOSDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), appiumOptions);
            }
        }
    }
}
