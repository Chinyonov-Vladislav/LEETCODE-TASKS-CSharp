using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3432
{
    /*
     3432. Подсчитайте разделы с четной разницей сумм
    Вам предоставляется целочисленный массив nums длины n.
    Разбиение определяется как индекс i где 0 <= i < n - 1, разделяющий массив на два непустых подмассива таким образом, что:
        Левый подмассив содержит индексы [0, i].
        Правый подмассив содержит индексы [i + 1, n - 1].
    Верните количество разделов, в которых разница между суммой левого и правого подмассивов чётная.
    Ограничения:
        2 <= n == nums.length <= 100
        1 <= nums[i] <= 100
    https://leetcode.com/problems/count-partitions-with-even-sum-difference/description/
     */
    public class Task3432 : InfoBasicTask
    {
        public Task3432(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 10, 10, 3, 7, 6 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = countPartitions(nums);
                Console.WriteLine($"Количество разделов, в которых разница между суммой левого и правого подмассивов чётная = {count}");

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
            if (nums.Length < 2 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int countPartitions(int[] nums)
        {
            int count = 0;
            int totalSum = nums.Sum();
            int sumRightPart = totalSum;
            for (int i = 1; i < nums.Length; i++)
            {
                sumRightPart -= nums[i - 1];
                int sumLeftPart = totalSum - sumRightPart;
                if ((sumLeftPart - sumRightPart) % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
