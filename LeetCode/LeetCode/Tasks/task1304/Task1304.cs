using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1304
{
    /*
     1304. Найдите N уникальных целых чисел, сумма которых равна нулю
    Учитывая целое число n, верните любой массив, содержащий n уникальные целые числа, сумма которых равна 0.
    https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/description/
     */
    public class Task1304 : InfoBasicTask
    {
        public Task1304(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 3;
            Console.WriteLine($"Количество уникальных значений в массиве = {n}");
            int[] result = sumZero(n);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] sumZero(int n)
        {
            int[] result = new int[n];
            int startIndex = 0;
            if (n % 2 != 0)
            {
                result[startIndex] = 0;
                startIndex++;
            }
            int value = 1;
            for (; startIndex < n;)
            {
                result[startIndex] = value;
                startIndex++;
                result[startIndex] = value * -1;
                startIndex++;
                value++;
            }
            return result;
        }
    }
}
