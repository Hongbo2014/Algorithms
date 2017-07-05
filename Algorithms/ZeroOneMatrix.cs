using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ZeroOneMatrix
    {
        public IList<IList<int>> UpdateMatrix(IList<IList<int>> matrix)
        {
            if (matrix == null || matrix.Count == 0) return matrix;

            int row = matrix.Count;
            int col = matrix[0].Count;

            bool[,] visited = new bool[row, col];
            Queue<Coordinate> queue = new Queue<Coordinate>();
            for(int i =0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        queue.Enqueue(new Coordinate(i, j));
                    }
                }
            }

            while(queue.Count > 0)
            {
                var point = queue.Dequeue();
                CheckAndUpdateNeighbor(matrix, point.x, point.y, queue, visited);
            }

            return matrix;
        }

        private void CheckAndUpdateNeighbor(IList<IList<int>> matrix, int x, int y, Queue<Coordinate> queue, bool[,] visited)
        {
            if (x < matrix.Count - 1 && matrix[x+1][y] != 0 && !visited[x+1, y])
            {
                matrix[x + 1][ y] = matrix[x][y] + 1;
                visited[x + 1, y] = true;
                queue.Enqueue(new Coordinate(x + 1, y));
            }
            if (x > 0 && matrix[x - 1][y] != 0 && !visited[x - 1, y])
            {
                matrix[x - 1][y] = matrix[x][y] + 1;
                visited[x - 1, y] = true;
                queue.Enqueue(new Coordinate(x - 1, y));
            }
            if (y < matrix[0].Count - 1 && matrix[x][y + 1] != 0 && !visited[x, y + 1])
            {
                matrix[x ][ y+ 1] = matrix[x][y] + 1;
                visited[x , y +1] = true;
                queue.Enqueue(new Coordinate(x , y + 1));
            }
            if (y >0 && matrix[x][y - 1] != 0 && !visited[x, y - 1])
            {
                matrix[x][y - 1] = matrix[x][y] + 1;
                visited[x, y - 1] = true;
                queue.Enqueue(new Coordinate(x, y - 1));
            }
        }
    }
}
