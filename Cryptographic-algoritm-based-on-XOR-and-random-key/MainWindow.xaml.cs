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
        List<Alphabet> _Alphabet = new List<Alphabet>();   

        public MainWindow()
        {
            const string FileName = "russian_alphabet.txt";

            InitializeComponent();

            _Alphabet.Add(new Alphabet(Char.Parse("А"), "1"));
            _Alphabet.Add(new Alphabet(Char.Parse("Б"), "0"));

            listView.ItemsSource = _Alphabet;
        }

        // Шифрование

        private void button_Click(object sender, RoutedEventArgs e)
        {           
            string Message = textBox.Text;
            string EditedMessage = "";

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
        }
    }
}

/*
        public void correctColumnWidths()
        {
            double remainingSpace = listView.ActualWidth;

            if (remainingSpace > 0)
            {
                for (int i = 0; i < (listView.View as GridView).Columns.Count; i++)
                    if (i != 2)
                        remainingSpace -= (listView.View as GridView).Columns[i].ActualWidth;

                //Leave 15 px free for scrollbar
                remainingSpace -= 15;

                (listView.View as GridView).Columns[2].Width = remainingSpace;
            }
        }
 * */
