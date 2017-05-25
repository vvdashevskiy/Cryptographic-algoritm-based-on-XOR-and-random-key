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
using System.Security.Cryptography;
using System.Diagnostics;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    public partial class Methods
    {
        public void CreateTables(SQLiteConnection connection)
        {
            SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE Users (id integer primary key, Username char(100), Password char(100))", connection);
            cmd.ExecuteNonQuery();
        }

        public void NewUser(SQLiteConnection connection, string username, string password)
        {
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Users (Username, Password) VALUES(@Username,@Password)", connection);
            
            cmd.Parameters.Add(new SQLiteParameter("@Username", username));
            cmd.Parameters.Add(new SQLiteParameter("@Password", password));

            cmd.ExecuteNonQuery();
        }

        public string FindUser(SQLiteConnection connection, string Username)
        {
            SQLiteCommand Base = new SQLiteCommand("SELECT Password FROM Users WHERE Username=@Username", connection);

            Base.Parameters.Add(new SQLiteParameter("@Username", Username));

            try
            {
            return Base.ExecuteScalar().ToString();
            }
            catch { return null; };
        }

        public void Serialise(FormSettings S, string CurrentUser)
        {
            CurrentUser = "Settings\\Settings_" + CurrentUser + ".xml";

            using (var fs = new FileStream(CurrentUser, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(FormSettings));
                xml.Serialize(fs, S);
            }
        }

        public FormSettings DeSerialise(string CurrentUser)
        {
            FormSettings S;

            CurrentUser = "Settings\\Settings_" + CurrentUser + ".xml";

            using (var fs = new FileStream(CurrentUser, FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(FormSettings));
                return S = (FormSettings)xml.Deserialize(fs);
            }
        }

        public string PasswordHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
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

        public void OpenReadMe()
        {
            Process p = new Process();
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.UseShellExecute = true;
            pi.FileName = @"Руководство пользователя.txt";
            p.StartInfo = pi;

            try
            {
                p.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
