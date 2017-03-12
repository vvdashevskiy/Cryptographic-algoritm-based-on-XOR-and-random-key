using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    public class Alphabet
    {
        private string _symbol;

        public string Symbol
        {
            get { return _symbol; }

            set { _symbol = value; }
        }

        private string _code;

        public string Code
        {
            get { return _code; }

            set { _code = value; }
        }

        public Alphabet(string symbol, string code)
        {
            _symbol = symbol;
            _code = code;
        }
    }
}
