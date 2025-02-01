using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1089
{
    /*
     1089. Повторяющиеся Нули
    Дан целочисленный массив фиксированной длины arr. Дублируйте каждое вхождение нуля, сдвигая остальные элементы вправо.
    Обратите внимание, что элементы, выходящие за пределы исходного массива, не записываются. Внесите указанные выше изменения во входной массив на месте и ничего не возвращайте.
    https://leetcode.com/problems/duplicate-zeros/description/
     */
    public class Task1089 : InfoBasicTask
    {
        public Task1089(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] nums = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            printArray(nums, "Исходный массив: ");
            duplicateZeros(nums);
            printArray(nums, "Массив после дублирования нулей");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private void duplicateZeros(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == 0)
                {
                    for (int j = arr.Length - 2; j >= i+1 ; j--)
                    {
                        arr[j+1] = arr[j];
                    }
                    arr[i + 1] = 0;
                    i++;
                }
            }
        }
    }
}
