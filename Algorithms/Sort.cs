using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Sort
    {
        public void QuickSort(int[] nums, int left, int right)
        {
            if (left >= right || left < 0 || right >= nums.Length)
            {
                return;
            }

            int start = left;
            int end = right;
            
            int mid = nums[left + (right - left) / 2];
            while(start <= end)
            {
                while(nums[start] < mid)
                {
                    start++;
                }

                while(nums[end] > mid)
                {
                    end--;
                }

                if (start <= end)
                {
                    int tmp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = tmp;
                    start++;
                    end--;
                }
            }

            QuickSort(nums, left, start - 1);
            QuickSort(nums, start, right);
        }

        public void QuickSort2(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int p = Partition(nums, left, right);
                QuickSort2(nums, left, p - 1);
                QuickSort2(nums, p + 1, right);
            }
        }

        private int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[left];
            int index = right;
            for (int i = right; i > left; i--)
            {
                if (nums[i] < pivot)
                {
                    Swap(nums, index, i);
                    index--;
                }
            }
            Swap(nums, index, left);
            return index;
        }

        private void Swap(int[] nums, int left, int right)
        {
            int tmp = nums[left];
            nums[left] = nums[right];
            nums[right] = tmp;
        }
    }
}
