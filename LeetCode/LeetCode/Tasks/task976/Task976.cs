using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task976
{
    /*
     976. Треугольник с наибольшим периметром
    Учитывая целочисленный массив nums, верните наибольший периметр треугольника с ненулевой площадью, образованного тремя отрезками этой длины. Если невозможно образовать треугольник с ненулевой площадью, верните 0.
    https://leetcode.com/problems/largest-perimeter-triangle/description/
     */
    public class Task976 : InfoBasicTask
    {
        public Task976(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 1, 10 };
            printArray(nums, "Стороны для треугольника: ");
            int maxPerimeter = largestPerimeter(nums);
            Console.WriteLine(maxPerimeter == 0 ? "Треугольник не может быть построен из заданных сторон" : $"Максимальный периметр треугольника, созданный из трех сторон = {maxPerimeter}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int largestPerimeter(int[] nums)
        {
            Array.Sort(nums);
            for (int i = nums.Length - 1; i >= 2; i--)
            {
                int j = i - 1;
                int k = i - 2;
                if (nums[i] + nums[j] > nums[k] && nums[i] + nums[k] > nums[j] && nums[k] + nums[j] > nums[i])
                {
                    return nums[i] + nums[j] + nums[k];
                }
            }
            return 0;
        }
        // скопировано с leetcode
        private int bestSolution(int[] nums)
        {
            Array.Sort(nums, (x, y) => y.CompareTo(x));
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i - 2] < nums[i - 1] + nums[i])
                {
                    return nums[i - 2] + nums[i - 1] + nums[i];
                }  
            }
            return 0;
        }
    }
}
