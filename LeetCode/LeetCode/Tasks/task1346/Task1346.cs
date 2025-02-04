using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1346
{
    /*
     1346. Проверьте, существуют ли N и его удвоенное значение
    Дан массив arr целых чисел. Проверьте, существуют ли два индекса i и j такие, что :
        i != j
        0 <= i, j < arr.length
        arr[i] == 2 * arr[j]
    https://leetcode.com/problems/check-if-n-and-its-double-exist/description/
     */
    public class Task1346 : InfoBasicTask
    {
        public Task1346(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { -2, 0, 10, -19, 4, 6, -8 };
            printArray(array, "Исходный массив: ");
            Console.WriteLine(checkIfExist(array) ? "В массиве существует элемент и элемент, который вдвое больше" : "В массиве не существует элемента и элемента, который вдвое больше");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkIfExist(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (set.Contains(2 * arr[i]) || (arr[i] % 2 == 0 && set.Contains(arr[i] / 2)))
                {
                    return true;
                }
                set.Add(arr[i]);
            }
            return false;
        }
    }
}
