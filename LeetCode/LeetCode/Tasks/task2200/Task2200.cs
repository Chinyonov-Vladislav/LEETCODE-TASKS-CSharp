using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2200
{
    /*
     2200. Найдите все индексы K-дистанции в массиве
    Вам дан нумерованный с 0 целочисленный массив nums и два целых числа key и k.k-отдаленный индекс — это индекс i массива nums, для которого существует хотя бы один индекс j такой, что |i - j| <= k и nums[j] == key.
    Верните список всех индексов, расположенных на расстоянии k, отсортированный впорядке возрастания.
    https://leetcode.com/problems/find-all-k-distant-indices-in-an-array/description/
     */
    public class Task2200 : InfoBasicTask
    {
        public Task2200(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 3, 4, 9, 1, 3, 9, 5 };
            int key = 9;
            int k = 1;
            printArray(nums, "Исходный массив: ");
            Console.WriteLine($"Ключ = {key}\nЗначение расстояния = {k}");
            IList<int> result = findKDistantIndices(nums, key, k);
            printIListInt(result, "Индексы: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> findKDistantIndices(int[] nums, int key, int k)
        {
            HashSet<int> result = new HashSet<int>();
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] == key)
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (Math.Abs(i - j) <= k)
                        {
                            result.Add(i);
                        }
                    }
                }
            }
            return result.ToList().OrderBy(x => x).ToList();
        }
        // скопировано с leetcode
        private IList<int> bestSolution(int[] nums, int key, int k)
        {
            int n = nums.Length;
            List<int> ans = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (nums[i] == key)
                {
                    int start = Math.Max(0, i - k);
                    int end = Math.Min(n - 1, i + k);

                    if (ans.Count != 0)
                    {
                        start = Math.Max(ans[ans.Count - 1] + 1, start);
                    }

                    for (int j = start; j <= end; j++)
                    {
                        ans.Add(j);
                    }
                }
            }
            return ans;
        }
    }
}
