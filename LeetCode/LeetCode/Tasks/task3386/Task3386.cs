using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3386
{
    /*
     3386. Кнопка с наибольшим временем нажатия
    Вам дан двумерный массив events, который представляет собой последовательность событий, когда ребёнок нажимает несколько кнопок на клавиатуре.
    Каждый из них events[i] = [indexi, timei] указывает на то, что кнопка под индексом indexi была нажата вовремя timei.
        Массив сортируется в порядке возрастания time.
        Время, затраченное на нажатие кнопки, — это разница во времени между последовательными нажатиями кнопок. Время нажатия первой кнопки — это просто время, когда она была нажата.
    Верните значение index для кнопки, нажатие на которую заняло наибольшее время. 
    Если несколько кнопок требуют одинакового времени, верните кнопку с наименьшим index значением.
    Ограничения:
        1 <= events.length <= 1000
        events[i] == [indexi, timei]
        1 <= indexi, timei <= 10^5
        Входные данные генерируются таким образом, что events сортируются в порядке возрастания timei.
    https://leetcode.com/problems/button-with-longest-push-time/description/
     */
    public class Task3386 : InfoBasicTask
    {
        public Task3386(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] events = new int[][] {
                new int[] { 1,2 },
                new int[] { 2,5 },
                new int[] { 3,9 },
                new int[] { 1, 15 }
            };
            printTwoDimensionalArray(events, "Двумерный массив нажатия кнопок в момент времени");
            if (isValid(events))
            {
                int numberButton = buttonWithLongestTime(events);
                Console.WriteLine($"Номер кнопки, нажатие на которую заняло наибольшее количество времени = {numberButton}");
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
        private bool isValid(int[][] events)
        {
            if (events.Length < 1 || events.Length > 1000)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 5);
            foreach (int[] currentEvent in events)
            {
                if (currentEvent.Length != 2)
                {
                    return false;
                }
                if (currentEvent[0] < 1 || currentEvent[0] > highLimit || currentEvent[1] < 1 || currentEvent[1] > highLimit)
                {
                    return false;
                }
            }
            if (events.Length > 1)
            {
                for (int i = 1; i < events.Length; i++)
                {
                    if (events[i][1] < events[i - 1][1])
                    {
                        return false;
                    }
                }
            }
            return true;

        }
        private int buttonWithLongestTime(int[][] events)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for(int i=0;i<events.Length;i++)
            {
                int countPush = 0;
                if (i == 0)
                {
                    countPush = events[i][1];
                }
                else
                {
                    countPush = events[i][1] - events[i-1][1];
                }
                if (dict.ContainsKey(countPush))
                {
                    dict[countPush].Add(events[i][0]);
                }
                else
                {
                    dict.Add(countPush, new List<int>() { events[i][0] });
                }
            }
            List<int> list = dict.OrderByDescending(e => e.Key).First().Value;
            list.Sort();
            return list[0];
        }
    }
}
