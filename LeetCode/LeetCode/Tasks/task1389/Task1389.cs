using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1389
{
    /*
     1389. Создание целевого массива в заданном порядке
    Даны два массива целых чисел nums и index. Ваша задача — создать массив target по следующим правилам:
        Изначально целевой массив пуст.
        Слева направо считайте nums[i] и index[i], вставьте в индекс index[i] значение nums[i] в целевой массив.
        Повторяйте предыдущий шаг до тех пор, пока не останется элементов для чтения в nums и index.
    Возвращает целевой массив.
    Гарантируется, что операции вставки будут корректными.
    https://leetcode.com/problems/create-target-array-in-the-given-order/description/
     */
    public class Task1389 : InfoBasicTask
    {
        public Task1389(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 1, 2, 3, 4 };
            printArray(nums, "Массив целых чисел: ");
            int[] indexs = new int[] { 0, 1, 2, 2, 1 };
            printArray(indexs, "Массив индексов: ");
            int[] result = createTargetArray(nums, indexs);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] createTargetArray(int[] nums, int[] index)
        {
            int[] target = new int[index.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = target.Length - 1; j > index[i]; j--)
                {
                    (target[j], target[j - 1]) = (target[j - 1], target[j]);
                }
                target[index[i]] = nums[i];
            }
            return target;
        }
        private int[] bestSolution(int[] nums, int[] index)
        {
            List<int> target = new List<int>();
            int i = 0;
            int j = 0;
            while (i < nums.Length && j < index.Length)
            {
                target.Insert(index[j], nums[i]);
                i++;
                j++;
            }
            return target.ToArray();
        }
    }
}
