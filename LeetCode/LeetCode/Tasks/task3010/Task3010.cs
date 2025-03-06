using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3010
{
    /*
     3010. Разделите массив на подмассивы с минимальной стоимостью
    Вам предоставляется массив целых чисел nums длины n.
    Стоимость массива — это значение его первого элемента. Например, стоимость [1,2,3] равна 1, а стоимость [3,4,1] равна 3.
    Вам нужно разделить nums на 3 непересекающиеся последовательные подмассивы.
    Верните минимально возможную сумму стоимости этих подмассивов.
    Ограничения:
        3 <= n <= 50
        1 <= nums[i] <= 50
    https://leetcode.com/problems/divide-an-array-into-subarrays-with-minimum-cost-i/description/
     */
    public class Task3010 : InfoBasicTask
    {
        public Task3010(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 6, 1, 5 };
            printArray(nums);
            if (isValid(nums))
            {
                int min = minimumCost(nums);
                Console.WriteLine($"Минимально возможная сумма стоимости 3 подмассивов оригинального массива = {min}");
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
            if (nums.Length < 3 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private int minimumCost(int[] nums)
        {
            int smallestSumOfTwo = nums[1] + nums[2];
            for (int i = 1; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int localSum = nums[i] + nums[j];
                    if (localSum < smallestSumOfTwo)
                    {
                        smallestSumOfTwo = localSum;
                    }
                }
            }
            return nums[0]+ smallestSumOfTwo;
        }
    }
}
