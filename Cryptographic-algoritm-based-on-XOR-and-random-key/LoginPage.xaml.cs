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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Methods M = new Methods();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string Hash;

            using (SQLiteConnection Base = new SQLiteConnection("Data source=Users.db"))
            {
                Base.Open();

                Hash = M.FindUser(Base, LoginBox.Text);

                if (Hash != null)
                {
                    if (Hash == M.PasswordHash(PasswordBox.Password))
                    {
                        ((App)Application.Current).log.Trace("Пользователь успешно вошёл в систему");

                        ((App)Application.Current).CurrentUser = LoginBox.Text;

                        try
                        {
                            ((App)Application.Current).S = M.DeSerialise(((App)Application.Current).CurrentUser); // Загрузка файла настроек

                            Pages.SettingsPage.Refresh();

                            ((App)Application.Current).log.Trace("Загружены настройки");
                        }
                        catch { ((App)Application.Current).log.Trace("Файл настроек не найден и будет создан в дальнейшем"); }

                        Base.Close();

                        NavigationService.Navigate(Pages.MainPage);
                    }
                    else { MessageBox.Show("Введён неверный пароль"); PasswordBox.Clear(); }
                }
                else { MessageBox.Show("Пользователь не существует"); LoginBox.Clear(); PasswordBox.Clear(); }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.RegisterPage);
        }
    }
}
