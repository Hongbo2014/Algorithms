using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class RomanToInteger
    {
        public int Convert(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int sum = 0;
            int pre = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int cur = 0;
                switch (c)
                {
                    case 'I': cur = 1; break;
                    case 'V': cur = 5; break;
                    case 'X': cur = 10; break;
                    case 'L': cur = 50; break;
                    case 'C': cur = 100; break;
                    case 'D': cur = 500; break;
                    case 'M': cur = 1000; break;
                    default: break;
                }

                if (cur <= pre)
                {
                    sum += cur;
                }
                else
                {
                    sum -= 2 * pre;
                    sum += cur;
                }
                pre = cur;
            }

            return sum;
        }

        private string[] str = { "I", "V", "X", "L", "C", "D", "M" };
        public string ConvertFromInt(int nums)
        {
            if (nums <= 0 || nums >= 4000) return string.Empty;

            string number = nums.ToString();
            int len = number.Length - 1;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i <= len; i++)
            {
                builder.Append(Helper(number[i] - '0', len - i));
            }

            return builder.ToString();
        }

        private string Helper(int val, int i)
        {
            if (val == 0) return "";
            string str = "";
            if (val == 9)
            {
                if (i == 2) return "CM";
                if (i == 1) return "XC";
                if (i == 0) return "IX";
            }
            else if (val >= 4 && val < 9)
            {
                if (i == 2) str = "D";
                if (i == 1) str = "L";
                if (i == 0) str = "V";
                val -= 5;
            }

            if (val == -1)
            {
                if (i == 2) str = "C" + str;
                if (i == 1) str = "X" + str;
                if (i == 0) str = "I" + str;
            }

            while (val > 0)
            {
                if (i == 3) str += "M";
                if (i == 2) str += "C";
                if (i == 1) str += "X";
                if (i == 0) str += "I";
                val--;
            }

            return str;
        }
    }
}
