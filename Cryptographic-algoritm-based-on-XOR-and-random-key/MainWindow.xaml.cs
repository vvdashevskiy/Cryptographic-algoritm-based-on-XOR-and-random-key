using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Methods M = new Methods();

        public MainWindow()
        {
            InitializeComponent();

            Directory.CreateDirectory("Settings");

            using (SQLiteConnection Base = new SQLiteConnection("Data source=Users.db"))
            {
                try
                {
                    Base.Open();

                    M.CreateTables(Base);
                }
                catch { }
            }

            frameMain.Navigate(Pages.LoginPage);
        }

        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).CurrentUser == null)
                MessageBox.Show("Необходимо войти в систему");
            else
            { Application.Current.MainWindow.Height = 300; Application.Current.MainWindow.Width = 200;  frameMain.Navigate(Pages.SettingsPage); }
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).CurrentUser = null;

            frameMain.Navigate(Pages.LoginPage);
        }
    }
}
