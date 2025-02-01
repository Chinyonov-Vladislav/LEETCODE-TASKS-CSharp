using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task977
{
    /*
     977. Квадраты отсортированного массива
    Учитывая целочисленный массив nums, отсортированный в неубывающем порядке, верните массив изквадратов каждого числа отсортированных в неубывающем порядке.
    https://leetcode.com/problems/squares-of-a-sorted-array/description/
     */
    public class Task977 : InfoBasicTask
    {
        public Task977(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            throw new NotImplementedException();
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] sortedSquares(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i]*nums[i];
            }
            Array.Sort(result);
            return result;
        }
        // скопировано с leetcode
        private int[] bestSolution(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int left = 0, right = n - 1;
            int pos = n - 1;

            while (left <= right)
            {
                int leftSquare = nums[left] * nums[left];
                int rightSquare = nums[right] * nums[right];

                if (leftSquare > rightSquare)
                {
                    result[pos] = leftSquare;
                    left++;
                }
                else
                {
                    result[pos] = rightSquare;
                    right--;
                }

                pos--;
            }

            return result;
        }
    }
}
