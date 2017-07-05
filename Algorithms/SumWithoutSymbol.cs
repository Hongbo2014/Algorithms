using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SumWithoutSymbol
    {
        public int Sum(int val1, int val2)
        {
            if (val2 == 0) return val1;
            int xor = val1 ^ val2;
            int andOp = val1 & val2;
            return Sum(xor, andOp << 1);
        }
    }
}
