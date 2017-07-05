using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SegTree
    {
        private TreeNode root;

        public SegTree(int[] nums)
        {
            root = GenereateTree(nums, 0, nums.Length - 1);
        }

        private TreeNode GenereateTree(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            TreeNode node = new TreeNode(start, end);
            if (start == end)
            {
                node.sum = nums[start];
                return node;
            }

            int mid = start + (end - start) / 2;
            node.left = GenereateTree(nums, start, mid);
            node.right = GenereateTree(nums, mid + 1, end);
            node.sum = node.left.sum + node.right.sum;
            return node;
        }

        public void Update(int i, int val)
        {
            this.Update(i, val, root);
        }

        private void Update(int i, int val, TreeNode node)
        {
            if (node.left == node.right)
            {
                node.sum = val;
                return;
            }

            int mid = node.start + (node.end - node.start) / 2;
            if (mid >= i)
            {
                Update(i, val, node.left);
            }
            else
            {
                Update(i, val, node.right);
            }
            node.sum = node.left.sum + node.right.sum;
        }

        public int GetValue(int i, int j)
        {
            return this.GetValue(i, j, root);
        }

        public int GetValue(int i, int j, TreeNode node)
        {
            if (node.start == i && node.end == j)
            {
                return node.sum;
            }

            int mid = node.start + (node.end - node.start) / 2;
            if (mid < i)
            {
                return GetValue(i, j, node.right);
            } 
            else if (mid >= j)
            {
                return GetValue(i, j, node.left);
            } 
            else
            {
                return GetValue(i, mid, node.left) + GetValue(mid + 1, j, node.right);
            }
        }
    }

    public class TreeNode
    {
        public int sum;
        public int start;
        public int end;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int l, int r)
        {
            this.start = l;
            this.end = r;
        }
    }
}
