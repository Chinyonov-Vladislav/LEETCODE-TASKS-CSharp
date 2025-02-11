using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1752
{
    /*
     1752. Проверьте, отсортирован ли массив и повернут ли он
    Учитывая массив nums, верните trueесли массив изначально был отсортирован в порядке неубывания, то поверните его на некоторое количество позиций (включая ноль). В противном случае верните false.
    В исходном массиве могут быть дубликаты.
    Примечание: массив A при повороте на x позиций превращается в массив B той же длины, что и A[i] == B[(i+x) % A.length], где % — операция по модулю.
    https://leetcode.com/problems/check-if-array-is-sorted-and-rotated/description/
     */
    public class Task1752 : InfoBasicTask
    {
        public Task1752(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 2, 1 };
            printArray(array, "Исходный массив: ");
            Console.WriteLine(check(array) ? "Массив изначально был отсортирован и повернут на определенное количество позиций" : "Массив изначально не был отсортирован");

        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool check(int[] nums)
        {
            int countRotate = 0;
            while (countRotate < nums.Length)
            {
                bool isSortedArray = isSorted(nums);
                if (isSortedArray)
                {
                    return true;
                }
                if (countRotate != nums.Length - 1)
                {
                    for (int i = 1; i < nums.Length; i++)
                    {
                        (nums[i - 1], nums[i]) = (nums[i], nums[i - 1]);
                    }
                }
                countRotate++;
            }
            return false;
        }
        private bool isSorted(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        // скопировано с leetcode
        private bool bestSolution(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > nums[(i + 1) % nums.Length])
                {
                    count++;
                }
                if (count > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
