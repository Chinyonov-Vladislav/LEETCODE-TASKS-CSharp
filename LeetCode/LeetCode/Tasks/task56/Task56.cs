using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task56
{
    /*
     56. Объединение интервалов
    Учитывая массив intervals с intervals[i] = [starti, endi], объедините все перекрывающиеся интервалы и верните массив непересекающихся интервалов, которые охватывают все интервалы во входных данных.
    Ограничения:
        1 <= intervals.length <= 10^4
        intervals[i].length == 2
        0 <= starti <= endi <= 10^4
    https://leetcode.com/problems/merge-intervals/description/
     */
    public class Task56 : InfoBasicTask
    {
        public Task56(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] intervals = new int[][] {
                new int[] { 8,10 },
                new int[] { 2,6 },
                new int[] { 15,18 },
                new int[] {1,3 }
            };
            printTwoDimensionalArray(intervals, "Исходный двумерный массив интервалов");
            if (isValid(intervals))
            {
                int[][] newIntervals = merge(intervals);
                printTwoDimensionalArray(newIntervals, "Новый двумерный массив интервалов");
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
        private bool isValid(int[][] intervals)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,4);
            if (intervals.Length < lowLimit || intervals.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            foreach (int[] interval in intervals)
            {
                if (interval.Length != 2)
                {
                    return false;
                }
                if (!(lowLimit <= interval[0] && interval[0] <= interval[1] && interval[1] <= highLimit))
                {
                    return false;
                }
            }
            return true;
        }
        private int[][] merge(int[][] intervals)
        {
            List<int[]> newIntervals = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                for (int j = i + 1; j < intervals.Length; j++)
                {
                    if (intervals[i][0] > intervals[j][0])
                    {
                        (intervals[i][0], intervals[j][0]) = (intervals[j][0], intervals[i][0]);
                        (intervals[i][1], intervals[j][1]) = (intervals[j][1], intervals[i][1]);
                    }
                }
            }
            int[] currentInterval = new int[2];
            currentInterval[0] = intervals[0][0];
            currentInterval[1] = intervals[0][1];
            for (int i = 0; i < intervals.Length - 1; i++)
            {
                // если начало следующего интервала лежит в пределах текущего интервала и конца следующего интервала также лежит в пределах текущего интервала
                if (intervals[i + 1][0] >= currentInterval[0] && intervals[i + 1][0] <= currentInterval[1] && intervals[i + 1][1] >= currentInterval[0] && intervals[i + 1][1] <= currentInterval[1])
                {
                    continue;
                }
                else if (intervals[i + 1][0] >= currentInterval[0] && intervals[i + 1][0] <= currentInterval[1]) // если только начало лежит в пределах текущего интервала
                {
                    currentInterval[1] = intervals[i + 1][1];
                }
                else if (intervals[i + 1][1] >= currentInterval[0] && intervals[i + 1][1] <= currentInterval[1]) // если только конец лежит в пределах текущего интервала
                {
                    currentInterval[1] = intervals[i + 1][1];
                }
                else
                {
                    newIntervals.Add(new int[2] { currentInterval[0], currentInterval[1] });
                    currentInterval[0] = intervals[i + 1][0];
                    currentInterval[1] = intervals[i + 1][1];
                }
            }
            newIntervals.Add(new int[2] { currentInterval[0], currentInterval[1] });
            int[][] resultTwoDimensionalArr = new int[newIntervals.Count][];
            int index = 0;
            foreach (int[] arr in newIntervals)
            {
                resultTwoDimensionalArr[index] = arr;
                index++;
            }
            return resultTwoDimensionalArr;
        }
    }
}
