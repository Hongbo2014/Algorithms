using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BeautifulArragement
    {
        // 1. have a list hold N number.
        // 2. put value from list into result.
        //     Check if the value is divisible from the count of result.
        //     add to result if yes, return if not.

        public int CountArrangement(int n)
        {
            if (n < 1) return 0;
            if (n == 1) return 1;

            List<int> list = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            List<List<int>> result = new List<List<int>>();
            Helper(new List<int>(), list, result);
            return result.Count;
        }

        private void Helper(List<int> cur, List<int> list, List<List<int>> result)
        {
            if(list.Count == 0)
            {
                result.Add(new List<int>(cur));
                return;
            }

            var copy = new List<int>(list);
            int count = cur.Count + 1;
            for(int i = 0; i < copy.Count; i++)
            {
                int val = copy[i];
                if(val % count == 0 || count % val == 0)
                {
                    cur.Add(copy[i]);
                    copy.RemoveAt(i);
                    Helper(cur, copy, result);
                    cur.RemoveAt(cur.Count - 1);
                    copy.Insert(i, list[i]);
                }
            }
        }
    }
}
