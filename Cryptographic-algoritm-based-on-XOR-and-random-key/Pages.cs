using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    static class Pages
    {
        private static LoginPage _loginPage = new LoginPage();
        private static MainPage _mainPage = new MainPage();
        private static SettingsPage _settingsPage = new SettingsPage();
        private static RegisterPage _registerPage = new RegisterPage();

        public static LoginPage LoginPage
        {
            get { return _loginPage; }
        }

        public static MainPage MainPage
        {
            get { return _mainPage; }
        }

        public static SettingsPage SettingsPage
        {
            get { return _settingsPage; }
        }

        public static RegisterPage RegisterPage
        {
            get { return _registerPage; }
        }
    }
}
