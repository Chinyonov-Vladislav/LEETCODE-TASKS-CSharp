using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task453
{
    /*
     453. Минимальные перемещения на равные элементы массива
    Учитывая целочисленный массив nums размером n, верните минимальное количество ходов, необходимых для того, чтобы сделать все элементы массива равными.
    За один ход вы можете увеличить n - 1 элементы массива на 1.
    Ограничения:
        n == nums.length
        1 <= nums.length <= 10^5
        -10^9 <= nums[i] <= 10^9
        Ответ гарантированно поместится в 32-битное целое число.
    https://leetcode.com/problems/minimum-moves-to-equal-array-elements/description/
     */
    public class Task453 : InfoBasicTask
    {
        public Task453(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = minMoves(nums);
                Console.WriteLine($"Минимальное количество увеличения {nums.Length-1} из {nums.Length} элементов исходного массива для того, чтобы все элементы были равны = {res}");
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
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,5);
            if (nums.Length < lowLimit || nums.Length > highLimit)
            {
                return false;
            }
            lowLimit = -1 * (int)Math.Pow(10,9);
            highLimit = (int)Math.Pow(10, 9);
            foreach (int num in nums)
            {
                if (num < lowLimit || num > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int minMoves(int[] nums)
        {
            int min = nums.Min();
            int count = 0;
            foreach (int num in nums)
            {
                count += num - min;
            }
            return count;
        }
    }
}
