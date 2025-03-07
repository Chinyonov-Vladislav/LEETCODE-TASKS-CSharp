using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3074
{
    /*
     3074. Разложение яблок по коробкам
    Вам дан массив apple размером n и массив capacity размером m.
    Существуют n упаковки, в ith которых находятся apple[i] яблоки. Есть также m коробки, и ith коробка вмещает capacity[i] яблоки.
    Верните минимальное количество коробок, которые вам нужно выбрать, чтобы перераспределить эти n упаковки яблок по коробкам.
    Обратите внимание, что яблоки из одной упаковки могут быть распределены по разным коробкам.
    Ограничения:
        1 <= n == apple.length <= 50
        1 <= m == capacity.length <= 50
        1 <= apple[i], capacity[i] <= 50
        Входные данные генерируются таким образом, чтобы можно было перераспределить упаковки яблок по коробкам.
    https://leetcode.com/problems/apple-redistribution-into-boxes/description/
     */
    public class Task3074 : InfoBasicTask
    {
        public Task3074(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] apple = new int[] { 1, 3, 2 };
            int[] capacity = new int[] { 4, 3, 1, 5, 2 };
            printArray(apple, "Массив количества яблок в коробках: ");
            printArray(capacity, "Массив вместимости яблок по коробкам: ");
            if (isValid(apple, capacity))
            {
                int countBoxes = minimumBoxes(apple, capacity);
                Console.WriteLine($"Минимальное количество используемых коробок = {countBoxes}");
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
        private bool isValid(int[] apple, int[] capacity)
        {
            if (apple.Length < 1 || apple.Length > 50 || capacity.Length < 1 || capacity.Length > 50)
            {
                return false;
            }
            int sumApple = 0;
            int sumCapacity = 0;
            foreach (int item in apple)
            {
                if (item < 1 || item > 50)
                {
                    return false;
                }
                sumApple += item;
            }
            foreach (int item in capacity)
            {
                if (item < 1 || item > 50)
                {
                    return false;
                }
                sumCapacity += item;
            }
            if (sumCapacity < sumApple)
            {
                return false;
            }
            return true;
        }
        private int minimumBoxes(int[] apple, int[] capacity)
        {
            int sum = 0;
            foreach (int box in apple) { 
                sum+= box;
            }
            Array.Sort(capacity);
            int count = 0;
            int sumCapacity = 0;
            for (int i = capacity.Length - 1; i >= 0; i--)
            {
                count++;
                sumCapacity+=capacity[i];
                if (sumCapacity >= sum)
                {
                    break;
                }
            }
            return count;
        }
    }
}
