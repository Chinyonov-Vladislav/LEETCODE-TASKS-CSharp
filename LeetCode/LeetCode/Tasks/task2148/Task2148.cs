using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2148
{
    /*
     2148. Подсчитайте количество элементов, которые строго меньше или больше других элементов 
    Учитывая целочисленный массив nums, верните количество элементов, у которых есть истрого меньший, и строго больший элементnums.
    https://leetcode.com/problems/count-elements-with-strictly-smaller-and-greater-elements/description/
     */
    public class Task2148 : InfoBasicTask
    {
        public Task2148(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { -71, -71, 93, -71, 40 };
            printArray(nums, "Исходный массив: ");
            int result = countElements(nums);
            Console.WriteLine($"Количество элементов, которые имеют строго больший и строго меньший элемент в массиве = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countElements(int[] nums)
        {
            HashSet<int> result = new HashSet<int>(nums);
            if (result.Count == 1)
            {
                return 0;
            }
            int min = nums.Min();
            int max = nums.Max();
            int countMin = 0;
            int countMax = 0;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                if (left != right)
                {
                    if (nums[left] == min)
                    {
                        countMin++;
                    }
                    if (nums[right] == min)
                    {
                        countMin++;
                    }
                    if (nums[left] == max)
                    {
                        countMax++;
                    }
                    if (nums[right] == max)
                    {
                        countMax++;
                    }
                }
                else
                {
                    if (nums[left] == min)
                    {
                        countMin++;
                    }
                    if (nums[left] == max)
                    {
                        countMax++;
                    }
                }
                left++;
                right--;
            }
            return nums.Length - countMin - countMax;
        }
    }
}
