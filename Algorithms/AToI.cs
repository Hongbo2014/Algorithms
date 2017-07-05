using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AToI
    {

        public Int16 Parse(string s)
        {
            if (string.IsNullOrEmpty(s)) { return -1; }

            int val = 0;
            bool isNeg = false;
            if (s[0] == '-')
            {
                isNeg = true;
                s = s.Substring(1);
            }

            if (s.Length == 0) return -1;
            for (int i = 0; i < s.Length; i++)
            {
                if ((!isNeg && val > Int16.MaxValue / 10) || (isNeg && val > Math.Abs(Int16.MinValue / 10))) { return -1; }
                if (!char.IsDigit(s[i])) return -1;

                val = val * 10 + s[i] - '0';
            }

            if (!isNeg && val > Int16.MaxValue) return -1;
            if (isNeg && val / 10 > Math.Abs(Int16.MinValue / 10)) return -1;
            
            return isNeg ? (Int16)(-1 * val) : (Int16)val;
        }


        // base value from 2 - 32
        public Int16 Parse(string s, int baseValue)
        {
            string baseValueRange = "0123456789ABCDEFGHIJKLMNOPQRSTUW";
            if (string.IsNullOrEmpty(s)) { return -1; }

            int val = 0;
            bool isNeg = false;
            if (s[0] == '-')
            {
                isNeg = true;
                s = s.Substring(1);
            }

            if (s.Length == 0) { InvalidError(); }
            s = s.ToUpper();
            for (int i = 0; i < s.Length; i++)
            {
                VerifyValidInt16(val * 10, isNeg);
                int index = baseValueRange.IndexOf(s[i]);
                if (index < 0 || index >= baseValue) { InvalidError(); }

                val = val * baseValue + index;
            }
            VerifyValidInt16(val, isNeg);

            return isNeg ? (Int16)(-1 * val) : (Int16)val;
        }

        private void VerifyValidInt16(int val, bool isNeg)
        {
            if ((!isNeg && val > Int16.MaxValue) || (isNeg && val / 10 > Math.Abs(Int16.MinValue / 10)))
            {
                InvalidError();
            }

        }

        private void InvalidError()
        {
            throw new Exception("invalid int16 value");
        }

    }
}
