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
        FormSettings S = new FormSettings();

        public SettingsPage()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            if (((App)Application.Current).S.A != 0 & ((App)Application.Current).S.B != 0 & ((App)Application.Current).S.N != 0)
            {
                a.AppendText(((App)Application.Current).S.A.ToString());
                b.AppendText(((App)Application.Current).S.B.ToString());
                n.AppendText(((App)Application.Current).S.N.ToString());
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((App)Application.Current).S.A = Convert.ToInt32(a.Text);
                ((App)Application.Current).S.B = Convert.ToInt32(b.Text);
                ((App)Application.Current).S.N = Convert.ToInt32(n.Text);

                M.Serialise(((App)Application.Current).S, ((App)Application.Current).CurrentUser);

                ((App)Application.Current).log.Trace("Файл настроек обновлён");

                NavigationService.Navigate(Pages.MainPage);
            }
            catch { MessageBox.Show("Пожалуйста, вводите натуральные цисла"); }
        }
    }
}
