using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2006
{
    /*
     2006. Подсчитайте количество пар с абсолютной разницей K
    Учитывая целочисленный массив nums и целое число k, верните количество пар (i, j) где i < j таких, что |nums[i] - nums[j]| == k.
    Значение |x| определяется как:
        x если x >= 0
        -x если x < 0.
     */
    public class Task2006 : InfoBasicTask
    {
        public Task2006(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 3, 2, 1, 5, 4 };
            printArray(array, "Исходный массив: ");
            int k = 2;
            Console.WriteLine($"Значение переменной k = {k}");
            Console.WriteLine($"Количество пар с абсолютной разницей K = {countKDifference(array, k)}");

        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countKDifference(int[] nums, int k)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int difference = nums[i] - nums[j];
                    if (difference < 0)
                    {
                        difference *= -1;
                    }
                    if (difference == k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
