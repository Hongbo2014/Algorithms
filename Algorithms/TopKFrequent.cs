using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class TopKFrequent
    {
        public IList<int> Find(int[] nums, int k)
        {
            IList<int> result = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]]++;
                }
                else
                {
                    map.Add(nums[i], 1);
                }
            }

            List<int>[] lists = new List<int>[nums.Length + 1];
            foreach (var item in map)
            {
                if(lists[item.Value] == null)
                {
                    lists[item.Value] = new List<int>();
                }
                lists[item.Value].Add(item.Key);
            }

            for(int i = nums.Length; i >= 0; i--)
            {
                for(int j = 0; j < lists[i].Count && result.Count < k; j++)
                {
                    result.Add(lists[i][j]);
                }
            }

            return result;
        }
    }
}
