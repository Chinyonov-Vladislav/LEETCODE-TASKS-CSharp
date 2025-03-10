using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3190
{
    /*
     3190. Найдите минимальное количество операций, чтобы все элементы делились на три
    Вам дан целочисленный массив nums. За одну операцию вы можете прибавить или отнять 1 от любого элемента nums.
    Верните минимальное количество операций, чтобы все элементы nums делились на 3.
    Ограничения:
        1 <= nums.length <= 50
        1 <= nums[i] <= 50
    https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/description/
     */
    public class Task3190 : InfoBasicTask
    {
        public Task3190(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                int min = minimumOperations(nums);
                Console.WriteLine($"Минимальное количество операций (прибавить или отнять 1 от числа в массиве) для того, чтобы все элементы делились на 3 нацело = {min}");
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
            if (nums.Length < 1 || nums.Length > 50)
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
        private int minimumOperations(int[] nums)
        {
            int count = 0;
            foreach (int i in nums)
            {
                if (i % 3 != 0)
                {
                    int currentNum = i;
                    int countAdd = 0;
                    int countSubstract = 0;
                    while (currentNum % 3 != 0)
                    {
                        currentNum++;
                        countAdd++;
                    }
                    currentNum = i;
                    while (currentNum % 3 != 0)
                    {
                        currentNum--;
                        countSubstract++;
                    }
                    count += Math.Min(countAdd, countSubstract);
                }
            }
            return count;
        }
    }
}
