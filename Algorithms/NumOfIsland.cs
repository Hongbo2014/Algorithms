using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // problem: http://www.lintcode.com/en/problem/number-of-islands-ii/
    // solution with explantation https://discuss.leetcode.com/topic/29613/easiest-java-solution-with-explanations

    public class NumOfIsland
    {
        // my solution.
        private int[] updateRow = new int[] { 1, -1, 0, 0 };
        private int[] updateCol = new int[] { 0, 0, 1, -1 };

        public IList<int> IslandsII(int n, int m, Point[] operations)
        {
            IList<int> result = new List<int>();
            if (n * m <= 0 || operations == null || operations.Length == 0)
            {
                return result;
            }
            int[,] matrix = new int[n, m];
            int count = 0;
            int gap = 0;
            foreach (var p in operations)
            {
                matrix[p.x, p.y] = ++count;
                ConnectionInfo item = FindMin(matrix, p.x, p.y);
                if (item.count != 0)
                {
                    gap += item.count;
                    UpdateIsland(matrix, p.x, p.y, item.minVal);
                }
                result.Add(count - gap);
            }

            return result;

        }

        private ConnectionInfo FindMin(int[,] matrix, int n, int m)
        {
            HashSet<int> hash = new HashSet<int>();

            // Do some case checking.
            int minVal = 0;
            int left = m == 0 ? 0 : matrix[n, m - 1];
            int right = m == matrix.GetLength(1) - 1 ? 0 : matrix[n, m + 1];
            int up = n == 0 ? 0 : matrix[n - 1, m];
            int down = n == matrix.GetLength(0) - 1 ? 0 : matrix[n + 1, m];
            if (left != 0)
            {
                minVal = minVal == 0 ? left : Math.Min(minVal, left);
                if(!hash.Contains(left))
                    hash.Add(left);
            }
            if (right != 0)
            {
                minVal = minVal == 0 ? right: Math.Min(minVal, right);
                if (!hash.Contains(right))
                    hash.Add(right);
            }

            if (up != 0)
            {
                minVal = minVal == 0 ? up : Math.Min(minVal, up);
                if (!hash.Contains(up))
                    hash.Add(up);
            }

            if (down != 0)
            {
                minVal = minVal == 0 ? down : Math.Min(minVal, down);
                if (!hash.Contains(down))
                    hash.Add(down);
            }

            return new ConnectionInfo(minVal, hash.Count);
        }

        public void UpdateIsland(int[,] matrix, int row, int col, int val)
        {
            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);
            if(row >= rowLen || col >= colLen || row < 0 || col < 0)
            {
                return;
            }

            if (matrix[row, col] > val)
            {
                matrix[row, col] = val;
                for (int i = 0; i < 4; i++)
                {
                    UpdateIsland(matrix, row + updateRow[i], col + updateCol[i], val);
                }
            }
        }

        public class ConnectionInfo
        {
            public int minVal;
            public int count;
            public ConnectionInfo(int m, int c)
            {
                minVal = m;
                count = c;
            }
        }
    }
}
