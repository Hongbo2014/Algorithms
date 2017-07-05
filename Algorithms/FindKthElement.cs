using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindKthElement
    {
        public int Find(int[] nums, int k)
        {
            if (nums == null || nums.Length < k) return -1;
            return Helper(nums, 0, nums.Length - 1, nums.Length - k);
        }


        private int Helper(int[] nums, int left, int right, int k)
        {
            if (left >= right) return -1;

            int index = Partition(nums, left, right, k);
            while (left < right)
            {
                int m = Partition(nums, left, right, k);
                if (m == k) return nums[m];
                else if (m < k) left = m + 1;
                else right = m - 1;
            }

            return nums[left];
        }

        private int Partition(int[] nums, int left, int right, int k)
        {
            int pivot = nums[left];
            int index = right;
            while (left < right)
            {
                if (nums[right] > pivot)
                {
                    Swap(nums, right, index--);
                }
                right--;
            }

            Swap(nums, left, index);
            return index;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
