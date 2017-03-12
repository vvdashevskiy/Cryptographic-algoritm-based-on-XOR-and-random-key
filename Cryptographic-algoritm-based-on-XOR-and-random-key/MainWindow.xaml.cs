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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Alphabet> _Alphabet = new List<Alphabet>();

        public MainWindow()
        {
            InitializeComponent();

            _Alphabet.Add(new Alphabet("А", "1"));
            _Alphabet.Add(new Alphabet("Б", "0"));
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
                    if (Message[i].ToString() == A.Symbol)
                    {
                        EditedMessage += A.Code.ToString();
                    }
                }
            }

            textBox1.Text = EditedMessage;
        }
    }
}
