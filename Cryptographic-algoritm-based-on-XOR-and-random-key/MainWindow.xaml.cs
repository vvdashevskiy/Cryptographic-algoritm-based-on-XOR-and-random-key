using NLog;
using System;
using System.Collections.Generic;
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

            try
            {
                ((App)Application.Current).S = M.DeSerialise(); // Загрузка файла настроек

                ((App)Application.Current).log.Trace("Загружены настройки");
            } catch { ((App)Application.Current).log.Trace("Файл настроек не найден"); }

            frameMain.Navigate(Pages.MainPage);
        }

        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(Pages.SettingsPage);
        }
    }
}
