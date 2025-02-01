using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task922
{
    /*
     922. Отсортировать массив по четности II
    Дан массив целых чисел nums, половина чисел в numsнечётные, а другая половина чётные.
    Отсортируйте массив так, чтобы, когда nums[i] является нечётным, i было нечётным, а когда nums[i] является чётным, i было чётным.
    Возвращает любой массив ответов, удовлетворяющий этому условию.
    https://leetcode.com/problems/sort-array-by-parity-ii/description/
     */
    public class Task922 : InfoBasicTask
    {
        public Task922(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 2, 5, 7 };
            printArray(nums, "Исходный массив: ");
            int[] result = sortArrayByParityII(nums);
            printArray(result, "Отсортированный массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] sortArrayByParityII(int[] nums)
        {
            int[] result = new int[nums.Length]; 
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
            foreach (int num in nums) {
                if (num % 2 == 0)
                {
                    evenNumbers.Add(num);
                }
                else
                {
                    oddNumbers.Add(num);
                }
            }
            int evenPointer = 0;
            int oddPointer = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = evenNumbers[evenPointer];
                    evenPointer++;
                }
                else
                {
                    result[i] = oddNumbers[oddPointer];
                    oddPointer++;
                }
            }
            return result;
        }
        // скопировано с leetcode
        private int[] bestSolution(int[] nums)
        {
            var oddPointer = 1;
            var evenPointer = 0;
            while (oddPointer < nums.Length && evenPointer < nums.Length)
            {
                if (nums[oddPointer] % 2 == 0)
                {
                    (nums[evenPointer], nums[oddPointer]) = (nums[oddPointer], nums[evenPointer]);
                    evenPointer += 2;
                }
                else
                {
                    oddPointer += 2;
                }
            }
            return nums;
        }
    }
}
