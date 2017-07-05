using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindSmallestKPair
    {
        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<int[]> result = new List<int[]>();
            if (nums1 == null || nums2 == null || nums1.Length == 0 || nums2.Length == 0)
            {
                return result;
            }

            List<Helper> list = new List<Helper>();
            for(int i = 0; i < nums1.Length; i++)
            {
                for(int j = 0; j < nums2.Length; j++)
                {
                    int sum = nums1[i] + nums2[j];
                    list.Add(new Helper(sum, nums1[i], nums2[j]));
                }
            }

            list.Sort((h1, h2) =>
            {
                if (h1.sum > h2.sum) return 1;
                if (h1.sum < h2.sum) return -1;
                return 0;
            });

            for(int i = 0; i < k && i < list.Count; i++)
            {
                result.Add(list[i].nums);
            }

            return result;
        }

        private class Helper
        {
            public int sum;
            public int[] nums;
            public Helper(int s, int val1, int val2)
            {
                sum = s;
                nums = new int[2];
                nums[0] = val1;
                nums[1] = val2;
            }
        }
    }
}
