using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using System.Data.SQLite;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    public partial class Methods
    {
        public void Serialise(Settings S)
        {
            using (var fs = new FileStream("settings.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Settings));
                xml.Serialize(fs, S);
            }
        }

        public Settings DeSerialise()
        {
            Settings S;

            using (var fs = new FileStream("settings.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Settings));
                return S = (Settings)xml.Deserialize(fs);
            }
        }

        public string Calculate(int count)
        {
            int a = ((App)Application.Current).S.A;
            int b = ((App)Application.Current).S.B;
            int n = (((App)Application.Current).S.N) % 2;

            count = count * 8;

            string code="";

            do
            {
                code += Convert.ToString((byte)n, 2);

                n = (a * n + b);
            }

            while (code.Count() < count);

            return code;
        }

        public void Clear()
        {
            ((App)Application.Current).Text.Clear();
        }

        public double BinToDec(string str)
        {
            double res = 0;
            for (int i = 0; i < 8; i++)
            {
                res += double.Parse(str[i].ToString()) * Math.Pow(2, 7 - i);
            }
            return res;
        }

        public string OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Текстовые файлы (txt,doc)|*.txt;*.doc";

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            else return null;
        }
    }
}
