using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Lexicographical
    {
        public IList<int> LexicalOrder(int n)
        {
            //int[] nums = new int[n];
            //for(int i = 0; i < n; i++)
            //{
            //    nums[i] = i;
            //}
            //Sort(nums, 0, nums.Length - 1);
            //return nums.ToList();

            IList<int> result = new List<int>();
            int cur = 1;
            for(int i = 1; i <= n; i++)
            {
                result.Add(cur);
                if (cur * 10 <= n)
                {
                    cur *= 10;
                }
                else if (cur % 10 != 9 && cur +  1<= n)
                {
                    cur++;
                }
                else
                {
                    while ((cur / 10) % 10 == 9)
                    {
                        cur /= 10;
                    }
                    cur = cur / 10 + 1;
                }
            }

            return result;
        }

        public IList<int> LexicalOrder2(int n)
        {
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = i;
            }
            Sort(nums, 0, nums.Length - 1);
            return nums.ToList();
        }

            private void Sort(int[] nums, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int index = Partition(nums, left, right);
            Sort(nums, left, index - 1);
            Sort(nums, index + 1, right);
        }

        private int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[left];
            int index = right;
            for (int i = right; i > left; i--)
            {
                if (IsLexicalBigger(nums[i], pivot))
                {
                    swap(nums, i, index);
                    index--;
                }
            }
            swap(nums, index, left);
            return index;
        }

        private void swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        private bool IsLexicalBigger(int a, int b)
        {
            string val1 = a.ToString();
            string val2 = b.ToString();
            int index1 = 0;
            int index2 = 0;
            while(index1 < val1.Length && index2 < val2.Length)
            {
                if(val1[index1] > val2[index2])
                {
                    return true;
                }
                else if (val1[index1] < val2[index2])
                {
                    return false;
                }
                index1++;
                index2++;
            }

            if (index1 < val1.Length)
            {
                return true;
            }

            if (index2 < val2.Length)
            {
                return false;
            }

            return true;
        }
    }
}
