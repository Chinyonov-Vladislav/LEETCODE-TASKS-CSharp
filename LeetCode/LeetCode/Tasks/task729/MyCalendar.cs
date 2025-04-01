using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task729
{
    public class MyCalendar
    {
        private List<int[]> times;
        public MyCalendar()
        {
            times = new List<int[]>();
        }

        public bool Book(int startTime, int endTime)
        {
            endTime--;
            for (int i = 0; i < times.Count; i++)
            {
                if (startTime >= times[i][0] && startTime < times[i][1] && endTime >= times[i][0] && endTime < times[i][1])
                {
                    return false;
                }
                if (startTime <= times[i][0] && endTime >= times[i][1])
                {
                    return false;
                }
                if (startTime <= times[i][0] && endTime >= times[i][0] && endTime < times[i][1])
                {
                    return false;
                }
                if (startTime >= times[i][0] && startTime < times[i][1] && endTime >= times[i][1])
                {
                    return false;
                }
            }
            times.Add(new int[] { startTime, endTime+1 });
            return true;
        }
    }
}
