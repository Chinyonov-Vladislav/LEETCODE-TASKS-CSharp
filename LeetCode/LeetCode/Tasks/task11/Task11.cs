using LeetCode.Basic;
using System;
using Xunit;
using Xunit.Sdk;

namespace LeetCode.Tasks.task11
{
    public class Task11 : InfoBasicTask
    {
        public Task11(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine($"Max Area = {maxArea(height)}");
        }

        public override void testing()
        {
            try
            {
                int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
                int expected = 49;
                Assert.Equal(expected, maxArea(height));
                Console.WriteLine("Тест пройден!");
            }
            catch (EqualException ex)
            {
                Console.WriteLine("Тест не пройден!");
                Console.WriteLine(ex.Message);
            }
            
        }
        private int maxArea(int[] height)
        {
            if (height.Length < 2)
            {
                return 0;
            }
            if (height.Length == 2)
            {
                return height[0] < height[1] ? height[0] : height[1];
            }
            int leftPointer = 0;
            int rightPointer = height.Length - 1;
            int maxArea = 0;
            while (leftPointer < rightPointer) {
                int localMinHeight = height[leftPointer] < height[rightPointer] ? height[leftPointer] : height[rightPointer];
                int localWidth = rightPointer - leftPointer;
                int localArea = localMinHeight * localWidth;
                if (localArea > maxArea)
                {
                    maxArea = localArea;
                }
                if (height[leftPointer] < height[rightPointer])
                {
                    leftPointer++;
                }
                else
                {
                    rightPointer--;
                }
            }
            return maxArea;
        }
    }
}
