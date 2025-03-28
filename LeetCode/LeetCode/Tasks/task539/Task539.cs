using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task539
{
    /*
     539. Минимальная разница во времени
    Учитывая список точек времени в 24-часовом формате "HH:MM", верните минимальное количество минут между любыми двумя точками времени в списке.
    Ограничения:
        2 <= timePoints.length <= 2 * 10^4
        timePoints[i] имеет формат "ЧЧ:ММ".
    https://leetcode.com/problems/minimum-time-difference/description/
     */
    public class Task539 : InfoBasicTask
    {
        public Task539(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] timePoints = new string[] { "23:59", "00:00" };
            printArray(timePoints, "Временные отметки: ");
            if (isValid(timePoints))
            {
                int res = findMinDifference(timePoints);
                Console.WriteLine($"Минимальное количество минут между любыми двумя точками времени в списке = {res}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(IList<string> timePoints)
        {
            int lowLimit = 2;
            int highLimit = 2*(int)Math.Pow(10,4);
            if (timePoints.Count < lowLimit || timePoints.Count > highLimit)
            {
                return false;
            }
            foreach(string time in timePoints)
            {
                if (time.Length != 5)
                {
                    return false;
                }
                if (time[2] != ':')
                {
                    return false;
                }
                string[] parts = time.Split(':');
                if (parts.Length != 2)
                {
                    return false;
                }
                int hour = 0;
                bool resultConvert = int.TryParse(parts[0], out hour);
                if (!resultConvert)
                {
                    return false;
                }
                if (!(hour >= 0 && hour <= 23))
                {
                    return false;
                }
                int minutes = 0;
                resultConvert = int.TryParse(parts[1], out minutes);
                if (!resultConvert)
                {
                    return false;
                }
                if (!(minutes >= 0 && minutes <= 59))
                {
                    return false;
                }
            }
            return true;
        }
        private int findMinDifference(IList<string> timePoints)
        {
            int[] minutes = new int[timePoints.Count];
            for (int i = 0; i < timePoints.Count; i++)
            {
                string[] parts = timePoints[i].Split(':');
                int hourValue = int.Parse(parts[0]);
                int minutesValue = int.Parse(parts[1]);
                minutes[i] = hourValue*60+minutesValue;
            }
            Array.Sort(minutes);
            int min = Int32.MaxValue;
            for (int index = 1; index < minutes.Length; index++)
            {
                int firstDifference = Math.Abs(minutes[index] - minutes[index-1]);
                int secondDifference = 1440 - Math.Abs(minutes[index] - minutes[index - 1]);
                int localMin = Math.Min(firstDifference, secondDifference);
                if (localMin < min)
                {
                    min = localMin;
                }
            }
            int firstDifferenceLast = Math.Abs(minutes[0] - minutes[minutes.Length-1]);
            int secondDifferencelast = 1440 - Math.Abs(minutes[0] - minutes[minutes.Length - 1]);
            int localMinlast = Math.Min(firstDifferenceLast, secondDifferencelast);
            if (localMinlast < min)
            {
                min = localMinlast;
            }
            return min;
        }
    }
}
