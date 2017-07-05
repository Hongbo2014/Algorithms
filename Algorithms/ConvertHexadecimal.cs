using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ConvertHexadecimal
    {
        public string ToHex(int num)
        {
            if (num == 0) return "0";
            string arr = "0123456789abcdef";
            bool isNeg = num < 0 ? true : false;

            long val = num & 0x00000000ffffffff;

            string res = "";
            while (val > 0)
            {
                res = arr[(int)(val % 16)] + res;
                val = val / 16;
            }

            return res;
        }
    }
}
