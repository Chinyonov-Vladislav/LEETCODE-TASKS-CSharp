using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task169
{
    /*
     * 169. Элемент большинства
     * Учитывая массив nums размера n, верните мажоритарный элемент.
     * Элемент большинства — это элемент, который встречается более [n / 2] раз. Можно предположить, что элемент большинства всегда присутствует в массиве.
     */
    public class Task169 : InfoBasicTask
    {
        public Task169(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            Console.WriteLine($"Мажорный элемент = {majorityElement(nums)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int majorityElement(int[] nums)
        {
            qucikSortArray(nums, 0, nums.Length - 1);
            return nums[nums.Length / 2];
        }
        private void qucikSortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    (array[j], array[i]) = (array[i], array[j]);
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
            {
                qucikSortArray(array, leftIndex, j);
            }
            if (i < rightIndex)
            {
                qucikSortArray(array, i, rightIndex);
            }
        }
        private int bestSolution(int[] nums) // скопировано с leetcode
        {
            int count = 0;
            int candidate = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }

            return candidate;
        }
}
}
