using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    [Serializable]

    public class Settings
    {
        public int Use_ASCII;

        public void ASCII_Allowed()
        {
            Use_ASCII = 1;
        }

        public void ASCII_Forbidden()
        {
            Use_ASCII = 0;
        }

        public int ASCII_Check()
        {
            return Use_ASCII;
        }
    }
}
