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
        int a, b, n;

        public int A
        {
            get { return a; }

            set { a = value; }
        }

        public int B
        {
            get { return b; }

            set { b = value; }
        }

        public int N
        {
            get { return n; }

            set { n = value; }
        }
    }
}
