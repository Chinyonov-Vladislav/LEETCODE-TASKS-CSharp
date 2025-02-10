using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1732
{
    /*
     1732. Найдите самую высокую высоту
    Байкер отправляется в путешествие. Маршрут состоит из n + 1 точек на разной высоте. Байкер начинает путешествие в точке 0 на высоте 0.
    Вам предоставляется целочисленный массив gain длины n, где gain[i] - чистый прирост высоты между точками i и i + 1 для всех (0 <= i < n). Возвращает наибольшую высоту точки.
     https://leetcode.com/problems/find-the-highest-altitude/description/
     */
    public class Task1732 : InfoBasicTask
    {
        public Task1732(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { -5, 1, 5, 0, -7 };
            printArray(arr, "Массив высот: ");
            int max = largestAltitude(arr);
            Console.WriteLine($"Максимальная высота = {max}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int largestAltitude(int[] gain)
        {
            int max = 0;
            int current = 0;
            for (int i = 0; i < gain.Length; i++)
            {
                current += gain[i];
                if (current > max)
                {
                    max = current;
                }
            }
            return max;
        }
    }
}
