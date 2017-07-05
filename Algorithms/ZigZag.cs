using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ZigZag
    {
        public string Convert(string s, int numRows)
        {
            StringBuilder builder = new StringBuilder();
            if (string.IsNullOrEmpty(s) || numRows == 0) return builder.ToString();
            if (numRows == 1) return s;

            List<char>[] lists = new List<char>[numRows];
            for (int i = 0; i < numRows; i++)
            {
                lists[i] = new List<char>();
            }

            bool isAdd = true;
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                lists[j].Add(s[i]);
                if (isAdd)
                {
                    j++;
                    if (j == numRows) isAdd = false;
                }
                else
                {
                    j--;
                    if (j == -1) isAdd = true;
                }
            }

            for(int i = 0; i < numRows; i++)
            {
                foreach(var c in lists[i])
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
