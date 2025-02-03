using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1122
{
    /*
     1122. Массив относительной сортировки
    Даны два массива arr1 и arr2, элементы arr2 уникальны, и все элементы arr2 также находятся в arr1.
    Отсортируйте элементы arr1 так, чтобы относительный порядок элементов в arr1 был таким же, как в arr2. Элементы, которых нет в arr2, должны быть помещены в конец arr1 в возрастающем порядке.
    https://leetcode.com/problems/relative-sort-array/description/
     */
    public class Task1122 : InfoBasicTask
    {
        public Task1122(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {

        }

        public override void execute()
        {
            int[] arr1 = new int[] { 28, 6, 22, 8, 44, 17 };
            int[] arr2 = new int[] { 22, 28, 8, 6 };
            printArray(arr1, "Исходный массив");
            printArray(arr2, "Массив относительного порядка элементов для сортировки: ");
            int[] result = relativeSortArray(arr1, arr2);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] relativeSortArray(int[] arr1, int[] arr2)
        {
            int index = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                int currentValue = arr2[i];
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr1[j] == currentValue)
                    {
                        (arr1[index], arr1[j]) = (arr1[j], arr1[index]);
                        index++;
                    }
                }
            }
            Array.Sort(arr1, index, arr1.Length - index);
            return arr1;
        }
    }
}
