using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptographic_algoritm_based_on_XOR_and_random_key
{
    public class Alphabet
    {
        private char _symbol;

        public char Symbol
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

        private int _amount = 0;

        public int Amount
        {
            get { return _amount; }

            set { _amount = value; }
        }

        public string Info
        {
            get
            {
                return $"{_symbol} - {_code}";
            }
        }

        public string Info_Amount
        {
            get
            {
                return $"{_symbol} - {_amount}";
            }
        }

        public Alphabet(char symbol, int amount)
        {
            _symbol = symbol;
            _amount = amount;
        }

        public Alphabet(char symbol, string code)
        {
            _symbol = symbol;
            _code = code;
        }
    }
}
