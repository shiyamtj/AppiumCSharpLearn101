using AppiumCSharpLearn101.Domain;
using AppiumCSharpLearn101.Framework.Config;
using AppiumCSharpLearn101.Framework.Core;
using NUnit.Framework;

namespace AppiumCSharpLearn101.Test
{
    public class TestBase
    {
        private MobileType _mobileType;

        public TestBase(MobileType mobileType)
        {
            _mobileType = mobileType;
        }

        [SetUp]
        public void SetupTest()
        {
            ConfigReader.InitializeSettings();
            DriverFactory.Instance.InitialAppiumDriver(_mobileType);
            Screens.Init();
        }

        [TearDown]
        public void TearDownTest()
        {
            DriverFactory.Instance.CloseApp();
        }
    }
}