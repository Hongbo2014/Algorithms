using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Maze
    {
        int[] checkRow = new int[] { 0, 0, 1, -1 };
        int[] checkCol = new int[] { 1, -1, 0, 0 };
        public bool IsPassAble(int[,] board)
        {
            if (board == null || board.Length == 0)
            {
                return false;
            }

            int row = board.GetLength(0);
            int col = board.GetLength(1);
            Queue<Coordinate> queue = new Queue<Coordinate>();
            Coordinate start = new Coordinate(0, 0);
            queue.Enqueue(start);
            while(queue.Count > 0)
            {
                var point = queue.Dequeue();
                if (point.x == row - 1 && point.y == col - 1)
                {
                    return true;
                }
                IList<Coordinate> neighbours = FindNeighbour(board, point.x, point.y);
                foreach (var item in neighbours)
                {
                    queue.Enqueue(item);
                }
            }

            return false;
        }

        private IList<Coordinate> FindNeighbour(int[,] board, int row, int col)
        {
            if (row >= board.GetLength(0) || row < 0 || col < 0 || col >= board.GetLength(1))
            {
                return null;
            }

            IList<Coordinate> result = new List<Coordinate>();
            for(int i = 0; i < 4; i++)
            {
                var point = GetNeighbourCoordinate(board,  row + checkRow[i],  col + checkCol[i]);
                if (point != null) result.Add(point);
            }
            return result;
        }

        private Coordinate GetNeighbourCoordinate(int[,] board, int row, int col)
        {
            if (row >= board.GetLength(0) || row < 0 || col < 0 || col >= board.GetLength(1))
            {
                return null;
            }
            if (board[row, col] == 1) return null;

            board[row, col] = 1;
            return new Coordinate(row, col);
        }
    }

     
}
