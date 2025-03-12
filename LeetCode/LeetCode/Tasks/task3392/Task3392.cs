using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3392
{
    /*
     3392. Подсчитайте количество подмассивов длиной три с условием
    Учитывая целочисленный массив nums, верните количество подмассивов длиной 3, в которых сумма первого и третьего чисел в точности равна половине второго числа.
    Ограничения:
        3 <= nums.length <= 100
        -100 <= nums[i] <= 100
    https://leetcode.com/problems/count-subarrays-of-length-three-with-a-condition/description/
     */
    public class Task3392 : InfoBasicTask
    {
        public Task3392(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 1, 4, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = countSubarrays(nums);
                Console.WriteLine($"Количество подмассивов длины 3, где сумма боковых элементов равна половине среднего элемента = {count}");
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
        private bool isValid(int[] nums)
        {
            if(nums.Length<3||nums.Length>100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < -100 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int countSubarrays(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                double sum = nums[i] + nums[i+2];
                if (sum == nums[i+1]/2.0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
