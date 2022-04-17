using AppiumCSharpLearn101.Domain;
using AppiumCSharpLearn101.Framework.Core;
using NUnit.Framework;

namespace AppiumCSharpLearn101.Test
{
    [TestFixture(MobileType.ANDROID)]
    [TestFixture(MobileType.IOS)]
    public class AppiumTestBasic: TestBase
    {
        public AppiumTestBasic(MobileType mobileType): base(mobileType)
        {
            
        }
        
        [Test]
        [Category("Debug")]
        public void LaunchAppSampleTest()
        {
            System.Console.WriteLine("Testing ...");
            Screens.LoginScreen.Login("standard_user", "secret_sauce");
            Screens.LandingScreen.Menu.ExpandCollapse();
            Screens.LandingScreen.Menu.CloseMenu();
            Screens.LandingScreen.Menu.ExpandCollapse();
            Screens.LandingScreen.Menu.Logout();
        }
    }
}