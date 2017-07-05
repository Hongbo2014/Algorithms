using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    //https://leetcode.com/problems/course-schedule-ii/#/description
    public class CourseSchedule
    {
        public int[] CourseScheduleCheck(int numCourses , int[,] prerequisites)
        {
            if (numCourses < 1) return new int[0];
            List<int> result = new List<int>();

            int[] arr = new int[numCourses];
            for (int i = 0; i < prerequisites.GetLength(0); i++)
            {
                arr[prerequisites[i, 0]]++;
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i< arr.Length; i++)
            {
                if (arr[i] == 0) queue.Enqueue(i);
            }

            while(queue.Count > 0)
            {
                var pre = queue.Dequeue();
                result.Add(pre);
                for (int i = 0; i < prerequisites.GetLength(0); i++)
                {
                    if (pre == prerequisites[i, 1])
                    {
                        var courseRef = prerequisites[i, 0];
                        arr[courseRef]--;
                        if (arr[courseRef] == 0) queue.Enqueue(courseRef);
                    }
                }
            }

            return result.Count == numCourses ? result.ToArray() : new int[0];
        }
    }
}
