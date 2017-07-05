using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ListWithRandom
    {
        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null) return null;

            RandomListNode rhead = new RandomListNode(0);
            rhead.next = head;
            RandomListNode node = head;
            var second = new RandomListNode(0);
            var snode = second;

            var hash = new Dictionary<RandomListNode, RandomListNode>();
            
            while (node != null)
            {
                RandomListNode copy = new RandomListNode(node.label);
                snode.next = copy;
                hash.Add(node, copy);
                snode = snode.next;
                node = node.next;
            }

            node = rhead.next;
            snode = second.next;
            while (node != null)
            {
                var ran = hash[node.random];
                snode.random = ran;
                node = node.next;
                snode = snode.next;
            }

            return second.next;
        }
    }
    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode(int x) { this.label = x; }
    }
}
