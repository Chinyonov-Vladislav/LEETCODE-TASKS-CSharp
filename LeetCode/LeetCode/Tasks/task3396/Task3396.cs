using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3396
{
    /*
     3396. Минимальное количество операций для того, чтобы сделать элементы массива уникальными
    Вам дан целочисленный массив nums. Вам нужно убедиться, что элементы массива отличаются друг от друга. Для этого вы можете выполнить следующую операцию любое количество раз:
    Удалите 3 элемента из начала массива. Если в массиве меньше 3 элементов, удалите все оставшиеся элементы
    Обратите внимание, что пустой массив считается состоящим из различных элементов. Верните минимальное количество операций, необходимых для того, чтобы элементы в массиве стали различными.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
    https://leetcode.com/problems/minimum-number-of-operations-to-make-elements-in-array-distinct/description/
     */
    public class Task3396 : InfoBasicTask
    {
        public Task3396(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 2, 3, 3, 5, 7 };
            printArray(nums);
            if (isValid(nums))
            {
                int count = minimumOperations(nums);
                Console.WriteLine($"Минимальное количество операций удаления первых трех элементов массива для того, чтобы сделать массив элементов уникальным = {count}");
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
            if (nums.Length < 1 || nums.Length > 100)
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
        private int minimumOperations(int[] nums)
        {
            int countOper = 0;
            int pointer = 0;
            while (true)
            {
                HashSet<int> result = new HashSet<int>();
                if (pointer >= nums.Length)
                {
                    break;
                }
                for (int i = pointer; i < nums.Length; i++)
                {
                    result.Add(nums[i]);
                }
                if (result.Count == nums.Length - pointer)
                {
                    break;
                }
                pointer += 3;
                countOper++;
            }
            return countOper;
        }
    }
}
