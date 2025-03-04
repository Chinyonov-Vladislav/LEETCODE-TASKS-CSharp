using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2670
{
    /*
     2670. Найдите отдельный массив различий
    Вам дан массив с нулевой индексацией nums длиной n.
    Массив различий nums — это массив diff длиной n, в котором diff[i] равно количеству различных элементов в суффиксе, nums[i + 1, ..., n - 1] вычитаемому из количества различных элементов в префиксе nums[0, ..., i].
    Возвращает nums.
    Обратите внимание, что nums[i, ..., j] обозначает подмассив nums с индексом i и до индекса j включительно. В частности, если i > j то nums[i, ..., j] обозначает пустой подмассив.
    Ограничения:
        1 <= n == nums.length <= 50
        1 <= nums[i] <= 50
    https://leetcode.com/problems/find-the-distinct-difference-array/description/
     */
    public class Task2670 : InfoBasicTask
    {
        public Task2670(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            printArray(array);
            if (isValid(array))
            {
                int[] result = distinctDifferenceArray(array);
                printArray(result, "Массив различий: ");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] nums)
        {
            if (nums.Length < 1 || nums.Length > 50)
            {
                return false;
            }
            foreach (int num in nums)
            {
                if (num < 1 || num > 50)
                {
                    return false;
                }
            }
            return true;
        }
        private int[] distinctDifferenceArray(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                HashSet<int> prefixSet = new HashSet<int>();
                HashSet<int> postfixSet = new HashSet<int>();
                for (int j = 0; j <= i; j++)
                {
                    prefixSet.Add(nums[j]);
                }
                for (int k = i+1; k < nums.Length; k++)
                {
                    postfixSet.Add(nums[k]);
                }
                result[i] = prefixSet.Count() - postfixSet.Count();
            }
            return result;
        }
    }
}
