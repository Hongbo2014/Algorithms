using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindKthSmallNum
    {
        public int FindInMatrix(int[,] matrix, int k)
        {
            if (matrix == null || matrix.Length < k)
            {
                return -1;
            }

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int left = matrix[0,0];
            int right = matrix[row - 1, col - 1];

            while(left < right)
            {
                int mid = left + (right - left) / 2;
                int count = 0;
                for(int i = 0; i < matrix.GetLength(0); i++)
                {
                    int j = matrix.GetLength(1) - 1;
                    while (j >= 0 && matrix[i, j] > mid) j--;
                    count += (j + 1);
                }

                if (count < k) left = mid + 1;
                else right = mid;
            }

            return left;
        }

    }
}
