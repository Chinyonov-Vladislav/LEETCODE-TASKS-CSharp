using System;
using System.Collections.Generic;
using LeetCode.Basic;
namespace LeetCode.Tasks.task26
{
    public class Task26 : InfoBasicTask
    {
        public Task26(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] numbers = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.WriteLine($"Количество уникальных элементов в массиве: {removeDuplicates(numbers)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int removeDuplicates(int[] nums) // my solution
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!queue.Contains(nums[i]))
                {
                    queue.Enqueue(nums[i]);
                }
            }
            int countUniqueElements = queue.Count;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i < countUniqueElements ? queue.Dequeue() : 0; 
            }
            return countUniqueElements;
        }
        private int bestSolution(int[] nums) // copy from leetcode
        {
            int k = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }
    }
}
