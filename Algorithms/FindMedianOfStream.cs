using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindMedianOfStream
    {
        List<int> list;
        public FindMedianOfStream()
        {
            list = new List<int>();
        }

        public void AddNum(int num)
        {
            list.Add(num);
            list.Sort();
        }

        public double FindMedian()
        {
            if (list.Count % 2 == 1) return list[list.Count % 2];
            return (list[list.Count % 2] + list[list.Count % 2 + 1]) / 2.0;
        }
    }
}
