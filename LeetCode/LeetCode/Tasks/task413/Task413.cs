using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task413
{
    /*
     413. Арифметические срезы
    Целочисленный массив называется арифметическим, если он состоит как минимум из трёх элементов и если разница между любыми двумя последовательными элементами одинакова.
        Например, [1,3,5,7,9], [7,7,7,7] и [3,-1,-5,-9] являются арифметическими последовательностями.
    Учитывая целочисленный массив nums, верните количество арифметическихподмассивов из nums.
    Подмассив - это непрерывная подпоследовательность массива.
    Ограничения:
        1 <= nums.length <= 5000
        -1000 <= nums[i] <= 1000
    https://leetcode.com/problems/arithmetic-slices/description/
     */
    public class Task413 : InfoBasicTask
    {
        public Task413(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3,4 };
            printArray(nums);
            if (isValid(nums))
            {
                int res = numberOfArithmeticSlices(nums);
                Console.WriteLine($"количество арифметических подмассивов (Целочисленный массив называется арифметическим, если он состоит как минимум из трёх элементов и если разница между любыми двумя последовательными элементами одинакова) из исходного массива = {res}");
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
            int lowLimitLengthNums = 1;
            int highLimitLengthNums = 5000;
            int lowLimitValueNum = -1000;
            int highLimitValueNum = 1000;
            if (nums.Length < lowLimitLengthNums || nums.Length > highLimitLengthNums)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < lowLimitValueNum || num > highLimitValueNum)
                {
                    return false;
                }
            }
            return true;
        }
        private int numberOfArithmeticSlices(int[] nums)
        {
            int minLengthOfArithmeticSubArray = 3;
            int count = 0;
            if (nums.Length < minLengthOfArithmeticSubArray)
            {
                return count;
            }
            for (int startWindow = 0; startWindow <= nums.Length - 3; startWindow++)
            {
                int localDifference = nums[startWindow+1] - nums[startWindow];
                int finishWindow = startWindow + 1;
                for (; finishWindow < nums.Length; finishWindow++)
                {
                    if (nums[finishWindow] - nums[finishWindow - 1] != localDifference)
                    {
                        finishWindow--;
                        break;
                    }
                    if (finishWindow == nums.Length - 1)
                    {
                        break;
                    }
                }
                int lengthOfSubArray = finishWindow - startWindow + 1;
                if (lengthOfSubArray >= minLengthOfArithmeticSubArray)
                {
                    count += lengthOfSubArray - minLengthOfArithmeticSubArray + 1;
                }
            }
            return count;

        }
    }
}
