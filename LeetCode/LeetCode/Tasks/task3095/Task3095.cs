using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3095
{
    /*
     3095. Кратчайший подмассив с ИЛИ не менее K I
    Вам дан массив nums неотрицательных целых чисел и целое число k.
    Массив называется специальным, если побитовое OR сложение всех его элементов равно как минимум k.
    Возврат длина кратчайшего специального непустого подмассива из nums, или возвращает -1 , если специального подмассива не существует.
    Ограничения:
        1 <= nums.length <= 50
        0 <= nums[i] <= 50
        0 <= k < 64
    https://leetcode.com/problems/shortest-subarray-with-or-at-least-k-i/description/
     */
    public class Task3095 : InfoBasicTask
    {
        public Task3095(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 1, 8 };
            int k = 10;
            printArray(nums);
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(nums, k))
            {
                int res = minimumSubarrayLength(nums,k);
                Console.WriteLine(res == -1 ? $"Не существует подмассива, для которого побитовое OR сложение всех его элементов равно как минимум {k} " : $"Минимальная длина подмассива, для которого побитовое OR сложение всех его элементов равно как минимум {k} = {res}");
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
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 0 || num > 50)
                {
                    return false;
                }
            }
            if (k < 0 || k >= 64)
            {
                return false;
            }
            return true;
        }
        private int minimumSubarrayLength(int[] nums, int k)
        {
            int length = 1;
            while (length != nums.Length + 1)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int endIndex = i + length;
                    if (endIndex>nums.Length)
                    {
                        break;
                    }
                    int sumOr = 0;
                    for (int index = i; index < endIndex; index++)
                    {
                        sumOr = sumOr | nums[index];
                    }
                    if (sumOr >= k)
                    {
                        return length;
                    }
                }
                length++;
            }
            return -1;
        }
    }
}
