using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindDiagnal
    {
        public int[] FindDiagonalOrder(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return new int[0];

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int[] res = new int[row * col];
            res[0] = matrix[0, 0];
            int i = 0;
            int m = 0;
            int n = 0;
            while (i < col * row)
            {
                while (m >= 0 && n < col && i < col * row)
                {
                    res[i++] = matrix[m--, n++];
                }

                if (m == -1 && n == col)
                {
                    m = 1;
                    n = col - 1;
                }
                else if (m == -1)
                {
                    m = 0;
                }
                else
                {
                    m += 2;
                    n = col - 1;
                }


                while (m < row && n >= 0 && i < col * row)
                {
                    res[i++] = matrix[m++, n--];
                }

                if (n == -1 && m == row)
                {
                    n = 1;
                    m = row - 1;
                }
                else if (n == -1)
                {
                    n = 0;
                }
                else
                {
                    m = row - 1;
                    n += 2;
                }
            }
            return res;

        }
    }
}
