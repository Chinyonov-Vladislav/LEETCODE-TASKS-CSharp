using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task462
{
    /*
     462. Минимальные перемещения до равных элементов массива II
    Учитывая целочисленный массив nums размером n, верните минимальное количество ходов, необходимых для того, чтобы сделать все элементы массива равными.
    За один шаг вы можете увеличить или уменьшить значение элемента массива на 1.
    Тестовые примеры составлены таким образом, чтобы ответ помещался в 32-битное целое число.
    Ограничения:
        n == nums.length
        1 <= nums.length <= 10^5
        -10^9 <= nums[i] <= 10^9
    https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/description/
     */
    public class Task462 : InfoBasicTask
    {
        public Task462(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 10, 2, 9 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = minMoves2(nums);
                Console.WriteLine($"Минимальное количество операций увеличения или уменьшения значения элемента массива на 1 = {res}");
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
            int lowLimitLength = 1;
            int highLimitLength = (int)Math.Pow(10,5);
            int lowLimitNum = -1 * (int)Math.Pow(10, 9);
            int highLimitNum = (int)Math.Pow(10, 9);
            if (nums.Length < lowLimitLength || nums.Length > highLimitLength)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < lowLimitNum || num > highLimitNum)
                {
                    return false;
                }
            }
            return true;
        }
        private int minMoves2(int[] nums)
        {
            int countMoves = 0;
            Array.Sort(nums);
            if (nums.Length % 2 == 0)
            {
                int mid = nums.Length / 2;
                int val = (nums[mid] + nums[mid-1])/2;
                for (int i = 0; i < nums.Length; i++)
                {
                    countMoves += Math.Abs(nums[i] - val);
                }   
            }
            else
            {
                int mid = nums.Length / 2;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == mid)
                    {
                        continue;
                    }
                    else if (i < mid)
                    {
                        countMoves += nums[mid] - nums[i];
                    }
                    else
                    {
                        countMoves += nums[i] - nums[mid];
                    }
                }
            }
            return countMoves;
        }
    }
}
