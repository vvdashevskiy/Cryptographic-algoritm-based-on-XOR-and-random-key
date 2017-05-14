using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class SettingsClass : Window
    {
        Methods M = new Methods();

        public SettingsClass()
        { 
            InitializeComponent();

            Refresh();
        }

        private void Refresh()
        {
            if (((App)Application.Current).S.ASCII_Check() == 1)
                ASCII_Status.Content = "Используется кодировка ASCII";
            else
                ASCII_Status.Content = "Кодировка ACII не испольуется";
        }

        private void ASCII_Load_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).S.ASCII_Allowed();

            Refresh();
        }

        private void ASCII_Forbidden_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).S.ASCII_Forbidden();

            Refresh();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
