using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task324
{
    /*
     324. Сортировка покачиванием
    Учитывая целочисленный массив nums, измените его порядок таким образом, чтобы nums[0] < nums[1] > nums[2] < nums[3]....
    Вы можете предположить, что входной массив всегда содержит допустимый ответ.
    Ограничения:
        1 <= nums.length <= 5 * 10^4
        0 <= nums[i] <= 5000
        Гарантируется, что для данного ввода будет дан ответ nums.
    https://leetcode.com/problems/wiggle-sort-ii/description/
     */
    public class Task324 : InfoBasicTask
    {
        public Task324(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 5, 1, 1, 6, 4 };
            printArray(nums);
            if (isValid(nums))
            {
                wiggleSort(nums);
                printArray(nums, "Массив после сортировки: ");
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
            int lowLimit = 1;
            int highLimit = 5 * (int)Math.Pow(10, 4);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = 0;
            highLimit = 5000;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }
            foreach (var pair in dict)
            {
                if (pair.Value > (nums.Length + 1) / 2)
                {
                    return false;
                }
            }
            int[] copyNums = new int[nums.Length];
            for (int i = 0; i < copyNums.Length; i++)
            {
                copyNums[i] = nums[i];
            }
            Array.Sort(copyNums);
            int[] firstPart = new int[(nums.Length+1)/2];
            int[] secondPart = new int[nums.Length / 2];
            int indexFirstPart = 0;
            int indexSecondPart = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < firstPart.Length)
                {
                    firstPart[indexFirstPart] = copyNums[i];
                    indexFirstPart++;
                }
                else
                {
                    secondPart[indexSecondPart] = copyNums[i];
                    indexSecondPart++;
                }
            }
            int minLength = Math.Min(firstPart.Length, secondPart.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (firstPart[i] == secondPart[i])
                {
                    return false;
                }
            }
            return true;
        }
        private void wiggleSort(int[] nums)
        {
            int[] copyNums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                copyNums[i] = nums[i];
            }
            Array.Sort(copyNums);
            int firstPointer = nums.Length / 2;
            int secondPointer = nums.Length - 1;
            if (nums.Length % 2 == 0)
            {
                firstPointer--;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    nums[i] = copyNums[firstPointer];
                    firstPointer--;
                }
                else
                {
                    nums[i] = copyNums[secondPointer];
                    secondPointer--;
                }
            }
        }
    }
}
