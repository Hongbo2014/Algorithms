using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class PermutationSubsequence
    {
        public string GetPermutation(int n, int k)
        {
            if (n < 1) return string.Empty;
            StringBuilder bl = new StringBuilder();
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            int[] factorial = new int[n + 1];
            factorial[0] = 1;
            int sum = 1;
            for (int i = 1; i <= n; i++)
            {
                sum *= i;
                factorial[i] = sum;
            }

            k--;
            for (int i = 1; i <= n; i++)
            {
                int index = k / factorial[n - i];
                bl.Append(list[index]);
                list.RemoveAt(index);
                k -= index * factorial[n - i];
            }

            return bl.ToString();
        }

        // https://leetcode.com/problems/permutation-in-string/#/description
        public bool PermutationInString(string s1, string s2)
        {
            if (s2.Length < s1.Length || s2 == null) return false;

            int count = s1.Length;
            var hash = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if (hash.ContainsKey(s1[i]))
                {
                    hash[s1[i]]++;
                }
                else
                {
                    hash.Add(s1[i], 1);
                }
            }

            int left = 0;
            int right = 0;
            while (left + s1.Length <= s2.Length)
            {
                while (right - left + 1 <= s1.Length && right < s2.Length)
                {
                    if (hash.ContainsKey(s2[right]))
                    {
                        hash[s2[right]]--;
                        if (CheckEmpty(hash)) return true;
                    }
                    right++;
                }

                if (hash.ContainsKey(s2[left]))
                {
                    hash[s2[left]]++;
                }
                left++;
            }

            return false;
        }

        private bool CheckEmpty(Dictionary<char, int> hash)
        {
            foreach (var keyPair in hash)
            {
                if (keyPair.Value != 0) return false;
            }

            return true;
        }


        public int ArrayPairSum(int[] nums)
        {
            if (nums == null || nums.Length < 2) return 0;

            Array.Sort(nums);
            int sum = 0;
            for (int i = 0; i < nums.Length; i += 2)
            {
                sum += nums[i];
            }

            return sum;
        }

        private void Sort(int[] nums, int left, int right)
        {
            int start = left;
            int end = right;
            int mid = left + (right - left) / 2;
            while (left <= right)
            {
                while (left <= right && nums[left] < nums[mid])
                {
                    left++;
                }

                while (left <= right && nums[right] > nums[mid])
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(nums, left, right);
                }
            }
            Sort(nums, start, right);
            Sort(nums, left, end);
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;            
        }
    }
}
