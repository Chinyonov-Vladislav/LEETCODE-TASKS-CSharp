using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1365
{
    /*
     1365. Сколько чисел меньше текущего числа
    Учитывая массив nums, для каждого nums[i] найдите, сколько чисел в массиве меньше него. То есть для каждого nums[i] вы должны подсчитать количество допустимых j's таких, что j != i и nums[j] < nums[i].
    Верните ответ в виде массива.
    https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number/description/
     */
    public class Task1365 : InfoBasicTask
    {
        public Task1365(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 8, 1, 2, 2, 3 };
            printArray(array, "Исходный массив: ");
            int[] resultArray = smallerNumbersThanCurrent(array);
            printArray(resultArray, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] smallerNumbersThanCurrent(int[] nums)
        {
            int[] result = new int[nums.Length];
            int[] sortedArray = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                sortedArray[i] = nums[i];
            }
            Array.Sort(sortedArray);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int index = 0; index < sortedArray.Length; index++)
                {
                    if (sortedArray[index] == nums[i])
                    {
                        result[i] = index;
                        break;
                    }
                }
            }
            return result;
        }
        // скопировано с leetcode
        private int[] bestSolution(int[] nums)
        {
            int[] storeCount = new int[101];
            int[] smallCount = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                storeCount[nums[i]]++;
            }
            int count = 0;
            int temp = 0;
            for (int i = 0; i < storeCount.Length; i++)
            {
                temp += storeCount[i];
                storeCount[i] = count;
                count = temp;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                smallCount[i] = storeCount[nums[i]];
            }
            return smallCount;
        }
    }
}
