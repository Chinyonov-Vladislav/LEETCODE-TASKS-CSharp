using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2455
{
    /*
     2455. Среднее значение чётных чисел, которые делятся на три
    Учитывая целочисленный массив nums положительных целых чисел, верните среднее значение всех четных целых чисел, которые делятся на 3.
    Обратите внимание, что среднее значениеn элементов — это сумма n элементов, делённая на n и округляемая в меньшую сторону до ближайшего целого числа.
    Ограничения:
        1 <= nums.length <= 1000
        1 <= nums[i] <= 1000
    https://leetcode.com/problems/average-value-of-even-numbers-that-are-divisible-by-three/description/
     */
    public class Task2455 : InfoBasicTask
    {
        public Task2455(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 3, 6, 10, 12, 15 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = averageValue(nums);
                Console.WriteLine(res == 0 ? "В массиве отсутствуют четные числа, которые делятся на 3" :$"Среднее значение чисел из массива, которые являются четными и делятся на 3 = {res}");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 1000)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int averageValue(int[] nums)
        {
            int sum = 0;
            int count = 0;
            foreach (int num in nums)
            {
                if (num %2==0 && num %3==0)
                {
                    sum+= num;
                    count++;
                }
            }
            if (count == 0)
            {
                return 0;
            }
            return sum / count;
        }
    }
}
