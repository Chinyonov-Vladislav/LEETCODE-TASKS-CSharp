using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1550
{
    /*
     1550. Три последовательных нечетных числа
    Учитывая целочисленный массив arr, верните true, если в массиве есть три последовательных нечётных числа. В противном случае верните false.
    https://leetcode.com/problems/three-consecutive-odds/description/
     */
    public class Task1550 : InfoBasicTask
    {
        public Task1550(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] arr = new int[] { 1, 2, 34, 3, 4, 5, 7, 23, 12 };
            printArray(arr, "Исходный массив: ");
            Console.WriteLine(threeConsecutiveOdds(arr) ? "В массиве есть 3 или более последовательных нечетных числа" : "В массиве нет 3 или более последовательных нечетных числа");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool threeConsecutiveOdds(int[] arr)
        {
            if (arr.Length < 3)
            {
                return false;
            }
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    count = 0;
                }
                else
                {
                    count++;
                }
                if (count == 3)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
