using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        Methods M = new Methods();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection Base = new SQLiteConnection("Data source=Users.db"))
            {
                Base.Open();

                if (M.FindUser(Base, LoginBox.Text) == null)
                {
                    if (M.PasswordHash(PasswordBox.Password) == M.PasswordHash(PasswordBox_Double.Password))
                    {
                        ((App)Application.Current).log.Trace("Пользователь успешно зарегистрирован");

                        M.NewUser(Base, LoginBox.Text, M.PasswordHash(PasswordBox.Password));

                        NavigationService.Navigate(Pages.LoginPage);
                    }
                    else { PasswordBox.Clear();  PasswordBox_Double.Clear(); MessageBox.Show("Вы ввели несовпадающие пароли"); }
                }
                else MessageBox.Show("Имя пользователя занято");
            }
        }
    }
}
