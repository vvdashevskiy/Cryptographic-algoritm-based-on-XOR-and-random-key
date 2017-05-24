using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public List<string> Text = new List<string>();
        public List<string> EncryptedText = new List<string>();

        public FormSettings S = new FormSettings();
        public Logger log = LogManager.GetCurrentClassLogger();

        public string CurrentUser = null;
    }
}
