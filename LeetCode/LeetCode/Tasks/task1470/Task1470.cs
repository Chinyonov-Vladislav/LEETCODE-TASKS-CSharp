using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1470
{
    /*
     1470. Перетасуйте массив
    Дан массив, nums состоящий из 2n элементов в виде [x1,x2,...,xn,y1,y2,...,yn].
    Верните массив в виде [x1,y1,x2,y2,...,xn,yn].
    https://leetcode.com/problems/shuffle-the-array/description/
     */
    public class Task1470 : InfoBasicTask
    {
        public Task1470(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 5, 1, 3, 4, 7 };
            printArray(nums, "Исходный массив: ");
            int n = 3;
            Console.WriteLine($"N = {n}");
            int[] result = shuffle(nums, n);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] shuffle(int[] nums, int n)
        {
            int[] result = new int[nums.Length];
            if (nums.Length == 2 * n)
            {
                int pointerX = 0;
                int pointerY = nums.Length / 2;
                int pointerForNewArray = 0;
                for (int i = 0; i < n; i++)
                {
                    result[pointerForNewArray] = nums[pointerX];
                    pointerForNewArray++;
                    result[pointerForNewArray] = nums[pointerY];
                    pointerForNewArray++;
                    pointerX++;
                    pointerY++;
                }
            }
            return result;
        }
    }
}
