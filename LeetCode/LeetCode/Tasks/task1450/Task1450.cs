using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1450
{
    /*
     1450. Количество учеников, выполняющих домашнее задание в определённый момент времени
    Даны два массива целых чисел startTime и endTime и дано целое число queryTime.
    Ученик ith начал выполнять домашнее задание в startTime[i] и закончил его в endTime[i].
    Верните количество учеников, выполняющих домашнее задание в момент queryTime. Более формально, верните количество учеников, для которых queryTime находится в интервале [startTime[i], endTime[i]] включительно.
     Ограничения:
        startTime.length == endTime.length
        1 <= startTime.length <= 100
        1 <= startTime[i] <= endTime[i] <= 1000
        1 <= queryTime <= 1000
     */
    public class Task1450 : InfoBasicTask
    {
        public Task1450(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] startTime = new int[] { 1, 2, 3 };
            int[] finishTime = new int[] { 3, 2, 7 };
            for (int i = 0; i < startTime.Length; i++)
            {
                Console.WriteLine($"Ученик №{i+1} начал выполнение задания в период с {startTime[i]} по {finishTime[i]}");
            }
            int queryTime = 4;
            Console.WriteLine($"Момент времени = {queryTime}");
            int count = busyStudent(startTime, finishTime, queryTime);
            Console.WriteLine($"Количество учеников, выполнявщих задание в момент {queryTime} = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int busyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int count = 0;
            for (int i = 0; i < startTime.Length; i++)
            {
                if (startTime[i] <= queryTime && endTime[i] >= queryTime)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
