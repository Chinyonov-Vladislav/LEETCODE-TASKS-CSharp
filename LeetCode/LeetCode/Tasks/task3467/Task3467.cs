using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3467
{
    /*
     3467. Преобразование массива по четности
    Вам дан целочисленный массив nums. Преобразуйте nums путём выполнения следующих операций в точном указанном порядке:
        Замените каждое четное число на 0.
        Замените каждое нечетное число на 1.
        Отсортируйте измененный массив в неубывающем порядке.
    Верните результирующий массив после выполнения этих операций.
    Ограничения:
        1 <= nums.length <= 100
        1 <= nums[i] <= 1000
    https://leetcode.com/problems/transform-array-by-parity/description/
     */
    public class Task3467 : InfoBasicTask
    {
        public Task3467(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 3, 2, 1 };
            printArray(nums);
            if (isValid(nums))
            {
                int[] res = transformArray(nums);
                printArray(res, "Результирующий массив из 0 и 1: ");
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
            if (nums.Length < 1 || nums.Length > 100)
            {
                return false;
            }
            foreach (int num in nums) {
                if (num < 1 || num > 1000)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] transformArray(int[] nums)
        {
            int countEven = 0;
            int countOdd = 0;
            int[] result = new int[nums.Length];
            for (int i = 0; i < result.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    countEven++;
                }
                else
                {
                    countOdd++;
                }
            }
            int countInsertedZero = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (countInsertedZero != countEven)
                {
                    result[i] = 0;
                    countInsertedZero++;
                }
                else
                {
                    result[i] = 1;
                }
            }
            return result;
        }
    }
}
