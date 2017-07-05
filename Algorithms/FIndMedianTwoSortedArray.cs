using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    // https://leetcode.com/problems/median-of-two-sorted-arrays/#/description
    public class FIndMedianTwoSortedArray
    {
        public double MedianOfTwo(int[] nums1, int[] nums2)
        {
            if (nums1 == null && nums2 == null) return 0;
            int len = nums1.Length + nums2.Length;

            if (len % 2 == 1)
            {
                return FindMedian(nums1, 0, nums2, 0, len / 2 + 1);
            }
            else
            {
                var val1 = FindMedian(nums1, 0, nums2, 0, len / 2);
                var val2 = FindMedian(nums1, 0, nums2, 0, len / 2 + 1);
                return (val1 + val2) / 2.0;
            }
        }

        private int FindMedian(int[] A, int a1, int[] B, int b1, int k)
        {
            if (a1 >= A.Length)
            {
                return B[b1 + k - 1];
            }
            if (b1 >= B.Length)
            {
                return A[a1 + k - 1];
            }

            if (k == 1) return A[a1] > B[b1] ? B[b1] : A[a1];

            int m = a1 + k / 2 - 1 < A.Length ? A[a1 + k / 2 - 1] : int.MaxValue;
            int n = b1 + k / 2 - 1 < B.Length ? B[b1 + k / 2 - 1] : int.MaxValue;

            if (m > n)
            {
                return FindMedian(A, a1, B, b1 + k / 2, k - k / 2);
            }
            else
            {
                return FindMedian(A, a1 + k / 2, B, b1, k - k / 2);
            }
        }

    }
}
