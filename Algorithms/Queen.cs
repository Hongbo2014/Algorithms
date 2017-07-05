using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Queen
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> res = new List<IList<string>>();
            if (n < 1) return res;

            GenerateQueen(res, new List<string>(), 0, n);

            return res;
        }

        private void GenerateQueen(IList<IList<string>> res, List<string> list, int level, int n)
        {
            if (level == n)
            {
                res.Add(new List<string>(list));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (IsValid(list, i))
                {
                    list.Add(GenerateString(i, n));
                    GenerateQueen(res, list, level + 1, n);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }

        private string GenerateString(int index, int n)
        {
            StringBuilder bld = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                bld.Append('.');
            }
            bld.Append("Q");
            for(int i = index + 1; i < n; i++)
            {
                bld.Append(".");
            }

            return bld.ToString();
        }

        private bool IsValid(IList<string> res, int index)
        {
            if (res.Count == 0) return true;
            for (int i = res.Count - 1, j = 1; i >= 0; i--, j++)
            {
                if ((index - j >= 0 && res[i][index - j] == 'Q') ||
                    res[i][index] == 'Q' || (index + j < res[0].Length && res[i][index + j] == 'Q'))
                {
                    return false;
                }
            }

            return true;
        }


        int count = 0;
        public int TotalNQueens(int n)
        {
            bool[] cols = new bool[n];     // columns   |
            bool[] d1 = new bool[2 * n];   // diagonals \
            bool[] d2 = new bool[2 * n];   // diagonals /
            Backtracking(0, cols, d1, d2, n);
            return count;
        }

        public void Backtracking(int row, bool[] cols, bool[] d1, bool[] d2, int n)
        {
            if (row == n) count++;

            for (int col = 0; col < n; col++)
            {
                int id1 = col - row + n;
                int id2 = col + row;
                if (cols[col] || d1[id1] || d2[id2]) continue;

                cols[col] = true; d1[id1] = true; d2[id2] = true;
                Backtracking(row + 1, cols, d1, d2, n);
                cols[col] = false; d1[id1] = false; d2[id2] = false;
            }
        }
    }
}
