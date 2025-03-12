using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3364
{
    /*
     3364. Подмассив с минимальной положительной суммой 
    Вам дан целочисленный массив nums и два целых числа l и r. Ваша задача — найти минимальную сумму подмассива, размер которого находится в диапазоне от l до r (включительно) и сумма элементов которого больше 0.
    Верните минимальную сумму такого подмассива. Если такого подмассива не существует, верните -1.
    Подмассив — это непрерывная непустая последовательность элементов внутри массива.
    Ограничения:
        1 <= nums.length <= 100
        1 <= l <= r <= nums.length
        -1000 <= nums[i] <= 1000
    https://leetcode.com/problems/minimum-positive-sum-subarray/description/
     */
    public class Task3364 : InfoBasicTask
    {
        public Task3364(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<int> nums = new List<int>() { 3, -2, 1, 4 };
            int l =2;
            int r = 3;
            printIListInt(nums);
            Console.WriteLine($"Нижняя граница длины подмассива = {l}\nВерхняя граница длины подмассива = {r}");
            if (isValid(nums, l, r))
            {
                int min = minimumSumSubarray(nums, l, r);
                Console.WriteLine($"Минимальная сумма подмассива размером от {l} до {r}, где сумма элементов больше 0 = {min}");
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
        private bool isValid(IList<int> nums, int l, int r)
        {
            if (nums.Count < 1 || nums.Count > 100)
            {
                return false;
            }
            if (!(l >= 1 && r >= l && nums.Count >= r))
            {
                return false;
            }
            foreach (int item in nums)
            {
                if (item < -1000 || item > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int minimumSumSubarray(IList<int> nums, int l, int r)
        {
            int min = -1;
            for (int length = l; length <= r; length++)
            {
                for (int i = 0; i <= nums.Count - length; i++)
                {
                    int localSum = 0;
                    for (int j = i; j < i + length; j++)
                    {
                        localSum += nums[j];
                    }
                    if (localSum > 0)
                    {
                        if (min == -1)
                        {
                            min = localSum;
                        }
                        else if(localSum < min)
                        {
                            min = localSum;
                        }
                    }
                }
            }
            return min;
        }
    }
}
