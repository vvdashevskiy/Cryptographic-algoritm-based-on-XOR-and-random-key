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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        Methods M = new Methods();

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).S.A = Convert.ToInt32(a.Text);
            ((App)Application.Current).S.B = Convert.ToInt32(b.Text);
            ((App)Application.Current).S.N = Convert.ToInt32(Y1.Text);

            M.Serialise(((App)Application.Current).S);

            NavigationService.Navigate(Pages.MainPage);
        }
    } 
}
