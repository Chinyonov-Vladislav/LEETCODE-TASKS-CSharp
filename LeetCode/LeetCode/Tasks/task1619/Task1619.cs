using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1619
{
    /*
     1619. Среднее значение массива после удаления некоторых элементов
    Учитывая целочисленный массив arr, верните среднее значение оставшихся целых чисел после удаления наименьшего 5% и наибольшего 5% из элементов.
    Ответы в пределах 10-5 от фактического ответа будут считаться принятыми.
    https://leetcode.com/problems/mean-of-array-after-removing-some-elements/description/
     */
    public class Task1619 : InfoBasicTask
    {
        public Task1619(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 6, 2, 7, 5, 1, 2, 0, 3, 10, 2, 5, 0, 5, 5, 0, 8, 7, 6, 8, 0 };
            printArray(array, "Исходный массив: ");
            double result = trimMean(array);
            Console.WriteLine($"Среднее значение массива без 5% наименьших и наибольших значений = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private double trimMean(int[] arr)
        {
            Array.Sort(arr);
            double sum = 0;
            int fivePercent = arr.Length *5 / 100;
            for (int i = fivePercent; i < arr.Length - fivePercent; i++)
            {
                sum+= arr[i];
            }
            return sum / (arr.Length - 2*fivePercent);
        }
    }
}
