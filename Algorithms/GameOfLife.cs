using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class GameOfLife
    {
        int[] checkRow = new int[] { 1, -1, 0, 0, 1, -1, 1, -1 };
        int[] checkCol = new int[] { 0, 0, 1, -1, 1, -1, -1, 1 };
        public void Play(int[,] board)
        {
            if (board == null || board.Length == 0)
            {
                return;
            }

            int row = board.GetLength(0);
            int col = board.GetLength(1);

            //0-> 1    2
            //1-> 0  - 1
            //0-> 0    0
            //1-> 1    1
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int count = CountNeighbor(board, i, j, false);
                    if (count < 2 || count > 3)
                    {
                        board[i, j] = board[i, j] == 1 ? -1 : 0;
                    }
                    else if ((count == 2 || count == 3) && board[i, j] == 1)
                    {
                        board[i, j] = 1;
                    }
                    else if (count == 3 && board[i, j] == 0)
                    {
                        board[i, j] = 2;
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i, j] == -1)
                    {
                        board[i, j] = 0;
                    }
                    else if (board[i, j] == 2)
                    {
                        board[i, j] = 1;
                    }
                }
            }

        }

        private int CountNeighbor(int[,] board, int row, int col, bool isNeighbour)
        {
            if (row >= board.GetLength(0) || row < 0 || col < 0 || col >= board.GetLength(1))
            {
                return 0;
            }

            if (isNeighbour)
            {
                if (board[row, col] == -1)
                {
                    return 1;
                }else if(board[row, col] == 2)
                {
                    return 0;
                }
                return board[row, col];
            }

            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                count += CountNeighbor(board, row + checkRow[i], col + checkCol[i], true);
            }
            return count;
        }
    }
}
