using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3151
{
    /*
     3151. Специальный массив I
    Массив считается особым, если чётность каждой пары соседних элементов отличается. 
    Другими словами, один элемент в каждой паре должен быть чётным, а другой должен быть нечётным.
    Вам дан массив целых чисел nums. Верните true, если nums является особым массивом, в противном случае верните false.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 100
    https://leetcode.com/problems/special-array-i/description/
     */
    public class Task3151 : InfoBasicTask
    {
        public Task3151(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 1, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                Console.WriteLine(isArraySpecial(nums) ? "В массиве происходит чередование четности" : "В массиве происходит нарушение чередования четности");
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
            foreach (int num in nums) {
                if (num < 1 || num > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isArraySpecial(int[] nums)
        {
            if (nums.Length == 1)
            {
                return true;
            }
            for (int i = 1; i < nums.Length; i++)
            {
                int sum = nums[i] + nums[i - 1];
                if (sum % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
