using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task448
{
    /*
     448. Найдите все числа, исчезнувшие в массиве
    Учитывая массив nums из n целых чисел, где nums[i] находится в диапазоне [1, n], верните массив всех целых чисел в диапазоне, [1, n] которые не встречаются в nums.
     */
    public class Task448 : InfoBasicTask
    {
        public Task448(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> res = findDisappearedNumbers(nums);
            printArray(nums, "Исходный массив: ");
            printIListInt(res, "Отсутствующие значения в массиве: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> findDisappearedNumbers(int[] nums)
        {
            IList<int> result = new List<int>();
            int length = nums.Length;
            nums = new HashSet<int>(nums).ToArray();
            for (int i = 1; i <= length; i++)
            {
                if (!nums.Contains(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }
        private IList<int> bestSolution(int[] nums)
        {
            bool[] values = new bool[nums.Length + 1];
            foreach (int num in nums)
            {
                values[num] = true;
            }
            var result = new List<int>();
            for (int i = 1; i < (nums.Length + 1); i++)

            {
                if (values[i] == false)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
