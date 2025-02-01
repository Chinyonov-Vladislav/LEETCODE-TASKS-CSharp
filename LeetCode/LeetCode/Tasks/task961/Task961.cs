using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task961
{
    /*
     961. N-кратный элемент в массиве размером 2N
    Вам будет предоставлен целочисленный массив nums со следующими свойствами:
        nums.length == 2 * n.
        nums содержит n + 1 уникальные элементы.
        Ровно один элемент nums повторяется n раз.
    Возвращает элемент, который повторяется n раз.
    https://leetcode.com/problems/n-repeated-element-in-size-2n-array/description/
     */
    public class Task961 : InfoBasicTask
    {
        public Task961(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 1, 2, 5, 3, 2 };
            Console.WriteLine($"Элемент, который повторяется {nums.Length/2} раз = {repeatedNTimes(nums)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int repeatedNTimes(int[] nums)
        {
            Array.Sort(nums);
            if (nums[nums.Length / 2] == nums[nums.Length / 2 + 1])
            {
                return nums[nums.Length / 2];
            }
            else
            {
                return nums[nums.Length / 2-1];
            }
        }
        private int bestSolution(int[] nums)
        {
            var map = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (map.ContainsKey(num))
                {
                    return num;
                }
                map[num] = 1;
            }
            return -1;
        }
    }
}
