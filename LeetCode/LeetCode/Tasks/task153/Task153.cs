using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task153
{
    /*
     153. Найдите минимум в повернутом отсортированном массиве
    Предположим, что массив длиной n отсортирован по возрастанию и поворачивается от 1 до n раз. Например, массив nums = [0,1,2,4,5,6,7] может стать таким:
        [4,5,6,7,0,1,2] если бы он был повернут 4 раз.
        [0,1,2,4,5,6,7] если бы он был повернут 7 раз.
    Обратите внимание, что поворот массива [a[0], a[1], a[2], ..., a[n-1]] на 1 шаг приводит к получению массива [a[n-1], a[0], a[1], a[2], ..., a[n-2]].
    Учитывая отсортированный повернутый массив nums уникальных элементов, верните минимальный элемент этого массива.
    Вы должны написать алгоритм, который выполняется в O(log n) time.
    Ограничения:
        n == nums.length
        1 <= n <= 5000
        -5000 <= nums[i] <= 5000
        Все целые числа nums являются уникальными.
        nums сортируется и ротируется между 1 и n временами.
    https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
     */
    public class Task153 : InfoBasicTask
    {
        public Task153(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 1, 2 };
            printArray(nums);
            if (isValid(nums))
            {
                int min = findMin(nums);
                Console.WriteLine($"Минимальное числов в массиве = {min}");
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
            int lowLimitLengthNums = 1;
            int highLimitLengthNums = 5000;
            int lowLimitValueNum = -5000;
            int highLimitValueNum = 5000;
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNums)
            {
                return false;
            }
            HashSet<int> uniqueValuesFromNum = new HashSet<int>();
            foreach (int num in nums)
            {
                if (num < lowLimitValueNum || num > highLimitValueNum)
                {
                    return false;
                }
                uniqueValuesFromNum.Add(num);
            }
            if (uniqueValuesFromNum.Count != nums.Length)
            {
                return false;
            }
            int countTippingPoints = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    countTippingPoints++;
                    int startLeftIndex = 0;
                    int finishLeftIndex = i - 1;
                    int startRightIndex = i;
                    int finishRightIndex = nums.Length - 1;
                    for (int j = startLeftIndex + 1; j <= finishLeftIndex; j++)
                    {
                        if (nums[j] <= nums[j - 1])
                        {
                            return false;
                        }
                    }
                    for (int j = startRightIndex + 1; j <= finishRightIndex; j++)
                    {
                        if (nums[j] <= nums[j - 1])
                        {
                            return false;
                        }
                    }
                }
            }
            if (countTippingPoints > 1)
            {
                return false;
            }
            return true;
        }
        private int findMin(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (mid > 0 && mid < nums.Length - 1)
                {
                    if (nums[mid] < nums[mid - 1] && nums[mid] < nums[mid + 1])
                    {
                        left = mid;
                        break;
                    }
                }
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return nums[left];
        }
    }
}
