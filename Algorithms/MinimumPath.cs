using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MinimumPath
    {
        public int MinPathSum(int[,] grid)
        {
            if (grid == null || grid.Length == 0) return 0;

            int row = grid.GetLength(0);
            int col = grid.GetLength(1);

            int[,] result = new int[row, col];
            result[0, 0] = grid[0, 0];
            for (int i = 1; i < row; i++)
            {
                result[i, 0] = grid[i, 0] + result[i - 1, 0];
            }
            for (int j = 1; j < col; j++)
            {
                result[0, j] = grid[0, j] + result[0, j - 1];
            }
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    result[i, j] = grid[i, j] + Math.Min(result[i - 1, j], result[i, j - 1]);
                }
            }

            return result[row - 1, col - 1];
        }

        public IList<IList<int>> CombinationSum2(int[] can, int t)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (can == null || can.Length == 0) return res;
            Array.Sort(can);
            FindCombin(res, new List<int>(), can, 0, t);
            return res;
        }

        private void FindCombin(IList<IList<int>> res, List<int> list, int[] can, int index, int t)
        {
            if (t == 0)
            {
                res.Add(new List<int>(list));
                return;
            }

            if (index >= can.Length) return;

            for (int i = index; i < can.Length; i++)
            {
                if (can[i] > t) break;
                if (i > index && can[i - 1] == can[i]) continue;
                list.Add(can[i]);
                FindCombin(res, list, can, i + 1, t - can[i]);
                list.RemoveAt(list.Count - 1);
            }
        }
    }

}
