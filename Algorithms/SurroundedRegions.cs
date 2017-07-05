using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SurroundedRegions
    {
        private static int[] checkRow = { 1, -1, 0, 0 };
        private static int[] checkCol = { 0, 0, 1, -1 };
        public void Surround(char[,] board)
        {
            if (board == null || board.Length == 0)
            {
                return;
            }

            int row = board.GetLength(0);
            int col = board.GetLength(1);
            int[,] cache = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i, j] == 'X' || cache[i, j] != 0) continue;
                    Helper(board, i, j, cache);
                }
            }
        }

        // check board helper
        // O -> X return 0;
        // O -> O return 1;
        // X return 0;
        private int Helper(char[,] board, int row, int col, int[,] cache)
        {
            if (row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1))
            {
                return 1;
            }

            if (board[row, col] == 'X') return 0;
            if (cache[row, col] != 0) return cache[row, col] == 1 ? 1 : 0;
            cache[row, col] = 2;
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                result |= Helper(board, row + checkRow[i], col + checkCol[i], cache);
            }

            if (result == 0)
            {
                board[row, col] = 'X';
                cache[row, col] = -1;
            }
            else
            {
                cache[row, col] = 1;
            }
            return result;
        }

        public void SurroundII(char[,] board)
        {
            if (board == null || board.Length == 0) return;

            int row = board.GetLength(0);
            int col = board.GetLength(1);

            for (int i = 0; i < row;i++)
            {
                if (board[i,0] == 'O') HelperII(board, i, 0);
                if (board[i, col - 1] == 'O') HelperII(board, i, col - 1);
            }

            for (int i = 0; i < col; i++)
            {
                if (board[0, i] == 'O') HelperII(board, 0, i);
                if (board[row - 1, i] == 'O') HelperII(board, row - 1, i);
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i, j] == '1') board[i, j] = 'O';
                    else board[i, j] = 'X';
                }
            }
        }

        public void HelperII(char[,] board, int row, int col)
        {
            if (row < 0 || col < 0 || row >= board.GetLength(0) || col >= board.GetLength(1)) return;
            if (board[row, col] == 'O')
            {
                board[row, col] = '1';
                if (row > 1 && board[row - 1, col] == 'O') HelperII(board, row - 1, col);
                if (row < board.GetLength(0) - 2 && board[row + 1, col] == 'O') HelperII(board, row + 1, col);
                if (col > 1 && board[row, col - 1] == 'O') HelperII(board, row, col - 1);
                if (col < board.GetLength(1) - 2 && board[row, col + 1] == 'O') HelperII(board, row, col + 1);
            }
        }
    }
}
