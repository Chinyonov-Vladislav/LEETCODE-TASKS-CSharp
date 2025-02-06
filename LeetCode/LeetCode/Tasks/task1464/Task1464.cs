using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1464
{
    /*
     1464. Максимальное произведение двух элементов в массиве
     Учитывая массив целых чисел nums, вы выберете два разных индекса i и j этого массива. Верните максимальное значение (nums[i]-1)*(nums[j]-1).
    https://leetcode.com/problems/maximum-product-of-two-elements-in-an-array/description/
     */
    public class Task1464 : InfoBasicTask
    {
        public Task1464(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 4, 5, 2 };
            printArray(nums, "Исходный массив: ");
            int resultMaxProduct = maxProduct(nums);
            Console.WriteLine($"Максимальное произведение двух разных элементов, из которых вычитали 1 = {resultMaxProduct}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxProduct(int[] nums)
        {
            Array.Sort(nums);
            int firstProduct = (nums[0]-1) * (nums[1]-1);
            int secondProduct = (nums[nums.Length-2]-1) * (nums[nums.Length - 1]-1);
            return firstProduct > secondProduct ? firstProduct : secondProduct;
        }
    }
}
