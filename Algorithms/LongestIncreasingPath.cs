using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LongestIncreasingPath
    {
        int max = 0;
        private int[] visitRow = { 1, -1, 0, 0 };
        private int[] visitCol = { 0, 0, 1, -1 };

        public int Longest(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int[,] cache = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var val = Helper(matrix, i, j, int.MinValue, cache);
                }
            }
            return max;
        }

        private int Helper(int[,] matrix, int row, int col, int pre, int[,] cache)
        {
            if (row >= matrix.GetLength(0) || row < 0 || col >= matrix.GetLength(1) || col < 0)
            {
                return 0;
            }
            if (matrix[row, col] <= pre) return 0;
            if (cache[row, col] != 0) return cache[row, col];
            

            int curMax = 0;
            for (int i = 0; i < 4; i++)
            {
                int val = 1 + Helper(matrix, row + visitRow[i], col + visitCol[i], matrix[row, col], cache);
                curMax = curMax > val ? curMax : val;
            }
            cache[row, col] = curMax;
            max = max < curMax ? curMax : max;

            return curMax;
        }
    }
}
