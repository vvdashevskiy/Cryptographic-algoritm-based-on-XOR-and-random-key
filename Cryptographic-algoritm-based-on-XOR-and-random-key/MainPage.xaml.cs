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
        string tmp, code = "", temp, text = "", last;

        Encoding Encode = Encoding.Default;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Locked_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = M.OpenFile();
                int count = 0;

                M.Clear();

                var File = new FileStream(path.Replace(@".txt", "_encrypted.txt"), FileMode.Create);

                using (var sr = new StreamReader(path, Encode))
                {
                    while (!sr.EndOfStream)
                    {
                        tmp = sr.ReadLine();

                        for (int i = 0; i < tmp.Length; i++)
                        {
                            code += Convert.ToString((byte)tmp[i], 2).PadLeft(8, '0');
                        }
                        count += code.Count();

                        ((App)Application.Current).Text.Add(code);
                    }
                }

                code = M.Calculate(count);

                for (int i = 0; i <= ((App)Application.Current).Text.Count; i++)
                {
                    tmp = "";
                    temp = (((App)Application.Current).Text[i]);

                    using (var sw = new StreamWriter(File, Encode))
                    {
                        for (int j = 0; j < temp.Count(); j++)
                        {
                            tmp += ((Convert.ToInt32(temp[j]) + Convert.ToInt32(code[j])) % 2).ToString();
                        }

                        sw.WriteLine(tmp);
                    }
                }
            }
            catch { /*MessageBox.Show("Необходимо выбрать файл с текстом");*/ }
        }

        private void Unlocked_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = M.OpenFile();
                int count = 0, Dec;
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

                code = M.Calculate(count);

                for (int i = 0; i <= ((App)Application.Current).Text.Count; i++)
                {
                    tmp = "";
                    temp = (((App)Application.Current).Text[i]);

                    using (var sw = new StreamWriter(File, Encode))
                    {
                        for (int j = 0; j < temp.Count(); j++)
                        {
                            tmp += ((Convert.ToInt32(temp[j]) + Convert.ToInt32(code[j])) % 2).ToString();
                        }

                        for (int z = 0; z < tmp.Count(); z = z + 8)
                        {
                            for (int x = 0; x < 8; x++)
                            {
                                last += tmp[x+z];
                            }

                            Dec = Convert.ToInt32(M.BinToDec(last));

                            last = "";

                            text += Convert.ToChar(Dec);
                        }

                        sw.WriteLine(text);
                    }
                }
            }
            catch { }
        }
    }
}
