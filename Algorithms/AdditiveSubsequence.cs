using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AdditiveSubsequence
    {
        public bool IsAdditive(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 3)
            {
                return false;
            }

            return Helper(s, 0, -1, -1);
        }

        private bool Helper(string s, int index, int pre1, int pre2)
        {
            if (index >= s.Length) return false;

            for (int i = 1; i + index <= s.Length; i++)
            {
                int v1 = pre1;
                int v2 = pre2;
                //if (s[index] == '0') return false;
                int val = 0;
                var str = s.Substring(index, i);

                if (!int.TryParse(str, out val)) continue;
                if ((v1 != -1 && v2 != -1 && val != v1 + v2) || str.Length > val.ToString().Length) continue;
                if (v1 + v2 == val && index + i == s.Length) return true;
                v1 = v2;
                v2 = val;
                var result = Helper(s, index + i, v1, v2);
                if (result) return result;
            }

            return false;
        }
    }
}
