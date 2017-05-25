using System;
using System.Collections;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Methods M = new Methods();
        string tmp, DancingMen = "", temp, text = "", last;

        Encoding Encode = Encoding.Default;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Locked_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).S.A != 0 | ((App)Application.Current).S.A != 0 | ((App)Application.Current).S.A != 0)
            {
                try
                {
                    ((App)Application.Current).log.Trace("Начало кодировки файла");

                    string path = M.OpenFile();
                    int count = 0;

                    M.Clear();

                    var File = new FileStream(path.Replace(@".txt", "_encrypted.txt"), FileMode.Create);

                    using (var sr = new StreamReader(path, Encode))
                    {
                        while (!sr.EndOfStream)
                        {
                            tmp = sr.ReadLine();

                            byte[] code = Encoding.Default.GetBytes(tmp);

                            for (int i = 0; i < code.Length; i++)
                            {
                                DancingMen += Convert.ToString(code[i], 2).PadLeft(8, '0');
                            }

                            count += DancingMen.Count();

                            ((App)Application.Current).Text.Add(DancingMen);

                            DancingMen = "";
                        }
                    }

                    DancingMen = M.Calculate(count);

                    ((App)Application.Current).log.Trace("Рассчёт кода успешно завершён");

                    for (int i = 0; i < ((App)Application.Current).Text.Count; i++)
                    {
                        tmp = "";
                        temp = (((App)Application.Current).Text[i]);

                        using (var sw = new StreamWriter(File, Encode))
                        {
                            for (int j = 0; j < temp.Count(); j++)
                            {
                                tmp += ((Convert.ToInt32(temp[j]) ^ Convert.ToInt32(DancingMen[j]))).ToString();
                            }

                            sw.WriteLine(tmp);
                        }
                    }

                    ((App)Application.Current).log.Trace("Файл успешно закодирован");
                }
                catch { }
            }
            else MessageBox.Show("Необходимо указать параметры для генерации псевдослучайной последовательности в настройках программы");
        }

        private void Unlocked_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).S.A != 0 | ((App)Application.Current).S.A != 0 | ((App)Application.Current).S.A != 0)
            {
                try
                {
                    ((App)Application.Current).log.Trace("Начало декодирования файла");

                    string path = M.OpenFile();
                    int count = 0;

                    M.Clear();

                    var File = new FileStream(path.Replace(@".txt", "_decrypted.txt"), FileMode.Create);

                    using (var sr = new StreamReader(path, Encode))
                    {
                        while (!sr.EndOfStream)
                        {
                            tmp = sr.ReadLine();

                            count += tmp.Count();

                            ((App)Application.Current).Text.Add(tmp);
                        }
                    }

                    DancingMen = M.Calculate(count);

                    ((App)Application.Current).log.Trace("Рассчёт кода успешно завершён");

                    for (int i = 0; i < ((App)Application.Current).Text.Count; i++)
                    {
                        tmp = "";
                        temp = (((App)Application.Current).Text[i]);

                        using (var sw = new StreamWriter(File, Encode))
                        {
                            for (int j = 0; j < temp.Count(); j++)
                            {
                                tmp += ((Convert.ToInt32(temp[j]) ^ Convert.ToInt32(DancingMen[j]))).ToString();
                            }

                            for (int z = 0; z < tmp.Count(); z = z + 8)
                            {
                                byte[] B = new byte[1];

                                for (int x = 0; x < 8; x++)
                                {
                                    last += tmp[x + z];
                                }

                                B[0] = Convert.ToByte(M.BinToDec(last));

                                last = "";

                                text += Encoding.GetEncoding(1251).GetString(B, 0, B.Count());
                            }

                            sw.WriteLine(text);
                        }
                    }

                ((App)Application.Current).log.Trace("Файл успешно декодирован");
                }
                catch { }
            }
            else MessageBox.Show("Необходимо указать параметры для генерации псевдослучайной последовательности в настройках программы");
        }

        private void Locked_Enter(object sender, MouseEventArgs e)
        {
            Encrypt.Content = "Выберите текстовый файл для зашифровки";
        }

        private void Locked_Leave(object sender, MouseEventArgs e)
        {
            Encrypt.Content = new Image
            {
                Source = new BitmapImage(new Uri(@"Resources\Encryption.png", UriKind.Relative)),
                Stretch=Stretch.UniformToFill
            };
        }

        private void Unlocked_Enter(object sender, MouseEventArgs e)
        {
            Decrypt.Content = "Выберите текстовый файл для дешифровки";
        }

        private void Unlocked_Leave(object sender, MouseEventArgs e)
        {
            Decrypt.Content = new Image
            {
                Source = new BitmapImage(new Uri(@"Resources\Decryption.png", UriKind.Relative)),
                Stretch = Stretch.UniformToFill
            };
        }
    }
}
