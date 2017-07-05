using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BuildQueueUsingTwoStack
    {
        Stack<int> one;
        Stack<int> two;
        public BuildQueueUsingTwoStack()
        {
            one = new Stack<int>();
            two = new Stack<int>();
        }
        public void Enqueue(int val)
        {
            one.Push(val);
        }

        public int Dequeue()
        {
            if(two.Count > 0)
            {
                return two.Pop();
            }

            while(one.Count> 0)
            {
                two.Push(one.Pop());
            }
            return two.Pop();
        }

        public int Peek()
        {
            if (two.Count > 0)
            {
                return two.Peek();
            }
            while(one.Count> 0)
            {
                two.Push(one.Pop());
            }

            return two.Peek();
        }
    }
}
