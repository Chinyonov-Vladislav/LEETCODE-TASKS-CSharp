using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3285
{
    /*
     3285. Найдите индексы cтабильных гор
    Здесь есть n горы в ряд, и у каждой горы есть своя высота. Вам предоставляется целочисленный массив, height где height[i] представляет высоту горы i, и целое число threshold.
    Гора называется устойчивой, если гора, расположенная непосредственно перед ней (если она существует), имеет высоту, строго превышающуюthreshold. Обратите внимание, что гора 0 не является устойчивой.
    Верните массив, содержащий индексы всех устойчивых гор в любом порядке.
    Ограничения:
        2 <= n == height.length <= 100
        1 <= height[i] <= 100
        1 <= threshold <= 100
    https://leetcode.com/problems/find-indices-of-stable-mountains/description/
     */
    public class Task3285 : InfoBasicTask
    {
        public Task3285(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] height = new int[] { 1, 2, 3, 4, 5 };
            int threshold = 2;
            printArray(height);
            Console.WriteLine($"Пороговое значение = {threshold}");
            if (isValid(height, threshold))
            {
                IList<int> res = stableMountains(height, threshold);
                printIListInt(res, "Массив индексов стабильных гор (высота предыдущей горы строго больше порогового значения): ");
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
        private bool isValid(int[] height, int threshold)
        {
            if (height.Length < 2 || height.Length > 100)
            {
                return false;
            }
            foreach (int num in height)
            {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            if (threshold < 1 || threshold > 100)
            {
                return false;
            }
            return true;
        }
        private IList<int> stableMountains(int[] height, int threshold)
        {
            IList<int> res = new List<int>();
            for (int i = 1; i < height.Length; i++)
            {
                if (height[i - 1] > threshold)
                {
                    res.Add(i);
                }
            }
            return res;
        }
    }
}
