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

        //public List<Alphabet> _Alphabet = new List<Alphabet>();   

        public MainWindow()
        {
            InitializeComponent();

            ((App)Application.Current).S = M.DeSerialise(); // Загрузка файла настроек

            //_Alphabet.Add(new Alphabet(Char.Parse("А"), "1"));
            //_Alphabet.Add(new Alphabet(Char.Parse("Б"), "0"));
            //listView.ItemsSource = _Alphabet;

            frameMain.Navigate(Pages.MainPage);
        }

        // Шифрование

        /*
        private void button_Click(object sender, RoutedEventArgs e)
        {           
            string Message = textBox.Text;
            string EditedMessage = "";

            if (((App)Application.Current).S.ASCII_Check() == 0)
            {
                for (int i = 0; i < Message.Length; i++)
                {
                    foreach (Alphabet A in _Alphabet)
                    {
                        if (Message[i] == A.Symbol)
                        {
                            EditedMessage += A.Code;
                        }
                    }
                }
            }

            else

            {
                for (int i = 0; i < Message.Length; i++)
                {
                    EditedMessage += Convert.ToString((byte)Message[i], 2).PadLeft(8, '0');
                }
            }

            textBox1.Text = EditedMessage;
        }

        // Создание алфавита, запись и построение кода

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CompInv<Alphabet> ci = new CompInv<Alphabet>();

            Encoding code = Encoding.Default;

            int Sum=0;

            using (var sr = new StreamReader("russian_original.txt", code))
            {
                while (!sr.EndOfStream)
                {
                    var text = sr.ReadLine();
                    Sum += text.Count();

                    for (int i = 0; i < text.Length; i++)
                    {
                        int count = 0;

                        foreach (Alphabet A in _Alphabet.ToArray())
                        {
                            if (text[i] == A.Symbol)
                            {
                                count += 1;
                                A.Amount += 1;
                            }
                        }

                        if (count == 0)
                        {
                            _Alphabet.Add(new Alphabet(text[i], 1));
                        }
                    }
                }
            }

            Alphabet_Count.ItemsSource = _Alphabet;

            _Alphabet.Sort(ci);

            Alphabet_Count.ItemsSource = _Alphabet;
        }*/

        private void MenuSettings_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(Pages.SettingsPage);
        }
    }
}
