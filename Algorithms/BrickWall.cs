using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BrickWall
    {
        public int LeastBricks(IList<IList<int>> wall)
        {
            if (wall == null || wall.Count == 0) return 0;
            var hash = new Dictionary<int, int>();
            foreach (var list in wall)
            {
                int sum = 0;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    sum += list[i];
                    if (!hash.ContainsKey(list[i]))
                    {
                        hash.Add(list[i], 1);
                    }
                    else
                    {
                        hash[list[i]]++;
                    }
                }
            }

            int max = 0;
            foreach (var keyPair in hash)
            {
                max = keyPair.Value > max ? keyPair.Value : max;
            }

            return wall.Count - max;
        }
    }
}
