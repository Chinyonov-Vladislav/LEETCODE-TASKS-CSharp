using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3065
{
    /*
     3065. Минимальное количество операций для превышения порогового значения I
    Вам дан нумерованный с 0 целочисленный массив nums и целое число k.
    За одну операцию вы можете удалить одно вхождение наименьшего элемента nums.
    Верните минимальное количество операций, необходимых для того, чтобы все элементы массива были больше или равны k.
    Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= 10^9
        1 <= k <= 10^9
        Входные данные генерируются таким образом, чтобы существовал хотя бы один индекс i такой, что nums[i] >= k.
    https://leetcode.com/problems/minimum-operations-to-exceed-threshold-value-i/description/
     */
    public class Task3065 : InfoBasicTask
    {
        public Task3065(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 11, 10, 1, 3 };
            int k = 10;
            printArray(nums);
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(nums, k))
            {
                int res = minOperations(nums, k);
                Console.WriteLine(res ==0 ? $"Все элементы массива больше или равны {k}":$"Минимальное количество операций удаления наименьшего элемента из массива для того, что бы все элементы были больше или равны {k} = {res}");
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
            int highLimit = (int)Math.Pow(10, 9);
            if (k < 1 || k > highLimit)
            {
                return false;
            }
            int count = 0;
            foreach (int num in nums)
            {
                if (num < 1 || num > highLimit)
                {
                    return false;
                }
                if (num >= k)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return false;
            }
            return true;
        }
        private int minOperations(int[] nums, int k)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < k)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
