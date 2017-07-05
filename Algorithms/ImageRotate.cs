using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ImageRotate
    {
        public void Rotate(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return;
            }

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            int[,] copy = new int[col, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    copy[j, row - i - 1] = matrix[i, j];
                }
            }

            matrix = copy;
        }
    }
}
