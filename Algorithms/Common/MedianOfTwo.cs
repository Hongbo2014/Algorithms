using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Common
{
    public class MedianOfTwo
    {
        public double FindMedian(int[] nums1, int[] nums2)
        {
            if (nums1 == null && nums2 == null) return 0;
            if (nums1.Length == 0 && nums2.Length == 0) return 0;
            int len = nums1.Length + nums2.Length;
            if (len % 2 == 1)
            {
                return Helper(nums1, 0, nums2, 0, (len + 1) / 2);
            }
            else
            {
                return (double)(Helper(nums1, 0, nums2, 0, len / 2) + (Helper(nums1, 0, nums2, 0, len / 2 + 1))) / 2.0;
            }
        }

        private double Helper(int[] nums1, int s1, int[] nums2, int s2, int k)
        {
            if (s1 >= nums1.Length) return nums2[s2 + k - 1];
            if (s2 >= nums2.Length) return nums1[s1 + k - 1];
            if (k == 1) return nums1[s1] < nums2[s2] ? nums1[s1] : nums2[s2];

            int val1 = s1 + k / 2 - 1 < nums1.Length ? nums1[s1 + k / 2 - 1] : int.MaxValue;
            int val2 = s2 + k / 2 - 1 < nums2.Length ? nums2[s2 + k / 2 - 1] : int.MaxValue;
            if (val1 > val2)
            {
                return Helper(nums1, s1, nums2, s2 + k / 2, k - k / 2);
            }
            return Helper(nums1, s1 + k / 2, nums2, s2, k - k / 2);
        }
    }
}
