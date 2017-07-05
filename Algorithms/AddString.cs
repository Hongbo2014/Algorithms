using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AddString
    {
        public string Add(string num1, string num2)
        {
            if (string.IsNullOrEmpty(num1)) return num2;
            if (string.IsNullOrEmpty(num2)) return num1;

            if (num1.Length < num2.Length)
            {
                string tmp = num1;
                num1 = num2;
                num2 = tmp;
            }

            int len1 = num1.Length;
            int len2 = num2.Length;
            string res = "";
            int flag = 0;

            for (int i = 1; i <= num1.Length; i++)
            {
                int v1 = num1[len1 - i] - '0';
                int v2 = i <= len2 ? num2[len2 - i] - '0' : 0;
                int val = v1 + v2 + flag;
                flag = val % 10;
                res = val / 10 + res;
            }
            if (flag == 1) res = "1" + res;

            return res;
        }
    }
}
