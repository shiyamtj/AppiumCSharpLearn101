using System;
using AppiumCSharpLearn101.Domain.Screen;

namespace AppiumCSharpLearn101.Domain
{
    public class Screens
    {
        public static LoginScreen LoginScreen => _loginScreen ?? throw new NullReferenceException("LoginScreen not Set. Please set LoginScreen");
        public static LandingScreen LandingScreen => _landingScreen ?? throw new NullReferenceException("LandingScreen not Set. Please set LoginScreen");


        [ThreadStatic]
        static LoginScreen _loginScreen;

        [ThreadStatic]
        static LandingScreen _landingScreen;

        public static void Init()
        {
            _loginScreen = new LoginScreen();
            _landingScreen = new LandingScreen();
        }
    }
}
