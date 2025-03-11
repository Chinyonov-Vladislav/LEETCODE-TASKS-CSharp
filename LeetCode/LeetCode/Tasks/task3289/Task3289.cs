using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3289
{
    /*
     3289. Два подлых числа из диджитвилля
    В городе Дигитвилль был список чисел под названием nums с целыми числами от 0 до n - 1. 
    Каждое число должно было появляться в списке ровно один раз, однако два озорных числа пробрались в список ещё раз, сделав его длиннее обычного.
    Ваша задача как городского детектива — найти эти два коварных числа. Верните массив размером два, содержащий эти два числа (в любом порядке), чтобы в Дигитвэйл вернулся покой.
    Ограничения:
        2 <= n <= 100
        nums.length == n + 2
        0 <= nums[i] < n
        Входные данные генерируются таким образом, что nums содержат ровно два повторяющихся элемента.
    https://leetcode.com/problems/the-two-sneaky-numbers-of-digitville/description/
     */
    public class Task3289 : InfoBasicTask
    {
        public Task3289(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 7, 1, 5, 4, 3, 4, 6, 0, 9, 5, 8, 2 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] res = getSneakyNumbers(nums);
                Console.WriteLine($"Числа {res[0]} и {res[1]} каждое появляются в массиве дважды");
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
            int n = nums.Length - 2;
            if (n < 2 || n > 100)
            {
                return false;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                dict.Add(i, 0);
            }
            foreach (int num in nums)
            {
                if (!(num >= 0 && num < n))
                {
                    return false;
                }
                if (!dict.ContainsKey(num))
                {
                    return false;
                }
                dict[num]++;
            }
            int countPairWithValueTwo = 0;
            foreach (var pair in dict)
            {
                if (pair.Value == 0)
                {
                    return false;
                }
                else if (pair.Value == 2)
                {
                    countPairWithValueTwo++;
                }
            }
            if (countPairWithValueTwo != 2)
            {
                return false;
            }
            return true;
            
        }
        private int[] getSneakyNumbers(int[] nums)
        {
            int[] res = new int[2];
            int index = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1;)
            {
                if (nums[i] == nums[i + 1])
                {
                    res[index] = nums[i];
                    index++;
                    i += 2;
                }
                else
                {
                    i++;
                }
            }
            return res;
        }
    }
}
