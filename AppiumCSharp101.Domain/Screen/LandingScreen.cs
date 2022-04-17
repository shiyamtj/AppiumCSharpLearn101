using AppiumCSharp101.Framework.Core;

namespace AppiumCSharp101.Domain.Screen
{
    public class LandingScreen: BaseScreen
    {
        public Menu Menu;

        public LandingScreen()
        {
            Menu = new Menu();
        }      
    }
}