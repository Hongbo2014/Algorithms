using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Common;

namespace Algorithms
{
    public class SwapNode
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode dummy = new ListNode(0)
            {
                next = head
            };
            ListNode pre = dummy;
            ListNode first = dummy.next;
            while (first != null && first.next != null)
            {
                ListNode second = first.next;
                first.next = second.next;
                second.next = first;
                pre.next = second;
                pre = first;
                first = pre.next;
            }

            return dummy.next;
        }
    }
}
