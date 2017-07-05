using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ValidSoduku
    {
        public bool IsValid(int[,] matrix)
        {
            if (matrix.Length == 0 || matrix.Length == 0)
            {
                return false;
            }

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (row != 9 || col != 9) return false;

            for (int i = 0; i < 9; i++)
            {
                int[] arr = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    int val = matrix[i / 3 * 3 + j / 3, i % 3 * 3 + j % 3] - '0';
                    if (val < 0 || val > 9) continue;
                    if (arr[val - 1] != 0) return false;
                    arr[val - 1]++;
                }
            }

            for (int i = 0; i < row; i++)
            {
                int[] arr = new int[9];
                for (int j = 0; j < col; j++)
                {
                    int val = matrix[i, j];
                    if (arr[val - 1] == 1) return false;
                    arr[val - 1]++;
                }
            }

            for (int i = 0; i < col; i++)
            {
                int[] arr = new int[9];
                for (int j = 0; j < row; j++)
                {
                    int val = matrix[j, i];
                    if (arr[val - 1] == 1) return false;
                    arr[val - 1]++;
                }
            }

            return true;
        }
    }
}
