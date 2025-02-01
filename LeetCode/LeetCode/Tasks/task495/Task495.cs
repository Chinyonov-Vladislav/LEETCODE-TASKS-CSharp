using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task495
{
    /*
     495. Атакующий Тимо
    Наш герой Тимо атакует вражеского Эша ядовитыми атаками! 
    Когда Тимон атакует Эша, Эш получает отравление ровно на duration секунд. 
    Если говорить более формально, то атака в секунду t означает, что Эш получает отравление в течение включительно временного интервала [t, t + duration - 1]. Если Тимон атакует снова до окончания действия эффекта отравления, таймер обнуляется, и действие эффекта отравления закончится через duration секунд после новой атаки.
    Вам дан неубывающий целочисленный массив timeSeries, где timeSeries[i] означает, что Тимо атакует Эша на второй timeSeries[i] секунде, а duration — целое число.
    Верните общее количество секунд, в течение которых Эш был отравлен.
    https://leetcode.com/problems/teemo-attacking/description/
     */
    public class Task495 : InfoBasicTask
    {
        public Task495(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] timeSeries = new int[] { 1, 2 };
            int durationPoison = 2;
            Console.WriteLine($"Отравление будет длиться {findPoisonedDuration(timeSeries, durationPoison)} сек.");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries.Length == 1)
            {
                return duration;
            }
            int totalSecondPoisoned = 0;
            for (int i = 0; i < timeSeries.Length-1; i++)
            {
                if (timeSeries[i] + duration > timeSeries[i + 1])
                {
                    totalSecondPoisoned+= timeSeries[i + 1] - timeSeries[i];
                }
                else
                {
                    totalSecondPoisoned += duration;
                }
                if (i == timeSeries.Length - 2)
                {
                    totalSecondPoisoned += duration;
                }
            }
            return totalSecondPoisoned;
        }
    }
}
