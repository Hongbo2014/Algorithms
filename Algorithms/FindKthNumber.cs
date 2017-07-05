using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindKthNumber
    {
        public int FindKthNumberV(int n, int k)
        {
            if (n < 0 || k > n) return -1;

            int step = 0;
            int val1 = 1;
            int val2 = val1 + 1;
            while (step <= k - 1)
            {
                if (step == k - 1)
                    return val1;
                int gap = GetSteps(n, val1, val2);
                if (gap + step <= k - 1)
                {
                    val1 = val2;
                    val2 = val1 + 1;
                    step += gap;
                }
                else
                {
                    val1 *= 10;
                    val2 = val1 + 1;
                    step += 1;
                }
            }

            return -1;
        }

        private int GetSteps(int n, int a, int b)
        {
            int step = 0;
            while (a <= n)
            {
                step += Math.Min(n + 1, b) - a;
                a *= 10;
                b *= 10;
            }

            return step;
        }
    }
}
