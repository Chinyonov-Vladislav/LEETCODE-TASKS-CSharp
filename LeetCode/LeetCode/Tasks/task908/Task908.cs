using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task908
{
    /*
     908. Наименьший диапазон I
    Вам будет предоставлен целочисленный массив nums и целое число k.
    За одну операцию вы можете выбрать любой индекс i где 0 <= i < nums.length и изменить nums[i] на nums[i] + x где x целое число из диапазона [-k, k]. Вы можете применить эту операцию не более одного раза для каждого индекса i.
    Оценка nums — это разница между максимальным и минимальным элементами в nums.
    Верните минимальное значение оценки nums после применения упомянутой операции не более одного раза для каждого индекса в ней.
    Ограничения:
        1 <= nums.length <= 10^4
        0 <= nums[i] <= 10^4
        0 <= k <= 10^4
    https://leetcode.com/problems/smallest-range-i/description/
     */
    public class Task908 : InfoBasicTask
    {
        public Task908(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] {0,10 };
            int k = 2;
            printArray(nums);
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(nums, k))
            {
                int res = smallestRangeI(nums, k);
                Console.WriteLine($"Минимальная разница между максимальным и минимальным элементами в nums после прибавление числа из диапазона [-{k},{k}] к каждому элементу массива = {res}");
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
        private bool isValid(int[] nums, int k)
        {
            int highLimit = (int)Math.Pow(10, 4);
            if (nums.Length < 1 || nums.Length > highLimit)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 0 || num > highLimit)
                {
                    return false;
                }
            }
            if (k < 0 || k > highLimit)
            {
                return false;
            }
            return true;
        }
        private int smallestRangeI(int[] nums, int k)
        {
            int min = nums[0];
            int max = nums[0];
            foreach (int num in nums)
            {
                if (num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }
            int newMin = min + k;
            int newMax = max - k;
            if (newMin > newMax)
            {
                return 0;
            }
            return newMax - newMin;
        }
    }
}
