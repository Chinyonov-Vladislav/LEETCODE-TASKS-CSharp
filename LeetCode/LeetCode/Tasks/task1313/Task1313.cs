using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1313
{
    /*
     1313. Распаковать список с кодировкой длины выполнения
    Нам дан список nums целых чисел, представляющих собой список, сжатый с помощью кодирования длин серий.
    Рассмотрим каждую соседнюю пару элементов [freq, val] = [nums[2*i], nums[2*i+1]] (с i >= 0). Для каждой такой пары есть freq элементов со значением val, объединённых в подсписок. Объедините все подсписки слева направо, чтобы получить распакованный список.
    Верните распакованный список.
    https://leetcode.com/problems/decompress-run-length-encoded-list/description/
     */
    public class Task1313 : InfoBasicTask
    {
        public Task1313(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 1, 2, 3, 4 };
            printArray(nums, "Исходный массив: ");
            int[] result = decompressRLElist(nums);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] decompressRLElist(int[] nums)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                for (int j = 0; j < nums[i]; j++)
                {
                    result.Add(nums[i + 1]);
                }
            }
            return result.ToArray();
        }
    }
}
