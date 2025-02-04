using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1200
{
    /*
     1200. Минимальная абсолютная разница
    Дан массив различных целых чисел arr. Найдите все пары элементов с минимальной абсолютной разницей между любыми двумя элементами.
    Верните список пар в порядке возрастания (относительно пар), каждая пара [a, b] следует
        a, b находятся от arr
        a < b
        b - a равно минимальной абсолютной разнице любых двух элементов в arr
    https://leetcode.com/problems/minimum-absolute-difference/description/
     */
    public class Task1200 : InfoBasicTask
    {
        public Task1200(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 4, 2, 1, 3 };
            printArray(arr, "Исходный массив: ");
            IList<IList<int>> result = minimumAbsDifference(arr);
            Console.Write("Список пар элементов с минимальной абсолютной разницей: ");
            for (int i = 0; i < result.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write("[");
                }
                if (i != result.Count - 1)
                {
                    Console.Write($"[{result[i][0]},{result[i][1]}], ");
                }
                else
                {
                    Console.Write($"[{result[i][0]},{result[i][1]}]]");
                }
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<IList<int>> minimumAbsDifference(int[] arr)
        {
            int min = int.MaxValue;
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(arr);
            for (int i = 1; i < arr.Length; i++)
            {
                int absoluteDistance = Math.Abs(arr[i] - arr[i - 1]);
                if (absoluteDistance < min)
                {
                    min = absoluteDistance;
                }
            }
            for (int i = 1; i < arr.Length; i++)
            {
                int absoluteDistance = Math.Abs(arr[i] - arr[i - 1]);
                if (absoluteDistance ==  min)
                {
                    result.Add(new List<int>() { arr[i - 1], arr[i] });
                }
            }
            return result;
        }
    }
}
