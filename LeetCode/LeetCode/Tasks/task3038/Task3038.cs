using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3038
{
    /*
     3038. Максимальное количество операций с одинаковым результатом
    Вам будет предоставлен массив целых чисел nums. Рассмотрим следующую операцию:
        Удалите первые два элемента nums и определите оценку операции как сумму этих двух элементов.
    Вы можете выполнять эту операцию до тех пор, пока nums не останется менее двух элементов. 
    Кроме того, одинаковый результат должен быть достигнут во всех операциях.
    Верните максимальное количество операций, которые вы можете выполнить.
    Ограничения:
        2 <= nums.length <= 100
        1 <= nums[i] <= 1000
    https://leetcode.com/problems/maximum-number-of-operations-with-the-same-score-i/description/
     */
    public class Task3038 : InfoBasicTask
    {
        public Task3038(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 5, 3, 3, 4, 1, 3, 2, 2, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = maxOperations(nums);
                Console.WriteLine($"Максимальное количество операций с одинаковым результатом = {count}");
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
            foreach (int num in nums) {
                if (num < 1 || num > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int maxOperations(int[] nums)
        {
            int count = 1;
            int sum = nums[0] + nums[1];
            int limit = nums.Length % 2 == 0 ? nums.Length : nums.Length - 1;
            for (int i = 2; i < limit; i += 2)
            {
                int localSum = nums[i]+nums[i+1];
                if (localSum == sum)
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            return count;
        }
    }
}
