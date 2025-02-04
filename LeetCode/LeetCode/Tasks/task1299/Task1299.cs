using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1299
{
    /*
     1299. Замените элементы на самый большой элемент с правой стороны
    Дан массив arr. Замените каждый элемент этого массива на наибольший элемент среди элементов справа от него, а последний элемент замените на -1.
    После этого верните массив.
    https://leetcode.com/problems/replace-elements-with-greatest-element-on-right-side/description/
     */
    public class Task1299 : InfoBasicTask
    {
        public Task1299(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 17, 18, 5, 4, 6, 1 };
            printArray(array, "Исходный массив: ");
            array = replaceElements(array);
            printArray(array, "Результирующий массив: ");

        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] replaceElements(int[] arr)
        {
            int max = arr[arr.Length - 1];
            arr[arr.Length - 1] = -1;
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > max)
                {
                    int temp = arr[i];
                    arr[i] = max;
                    max = temp;
                }
                else
                {
                    arr[i] = max;
                }
            }
            return arr;
        }
    }
}
