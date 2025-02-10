using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1720
{
    /*
     1720. Декодирование XOR массива
    Существует скрытый целочисленный массив arr, состоящий из n неотрицательных целых чисел.
    Он был закодирован в другой целочисленный массив encoded длиной n - 1, такой что encoded[i] = arr[i] XOR arr[i + 1]. Например, если arr = [1,0,2,1], то encoded = [1,2,3].
    Вам дан массив encoded. Вам также дано целое число first, которое является первым элементом arr, то есть arr[0].
    Верните исходный массив arr. Можно доказать, что ответ существует и является уникальным.
    https://leetcode.com/problems/decode-xored-array/description/
     */
    public class Task1720 : InfoBasicTask
    {
        public Task1720(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] encodedArray = new int[] { 6, 2, 7, 3 };
            printArray(encodedArray, "Закодированный массив: ");
            int first = 4;
            int[] decodedArray = decode(encodedArray, first);
            printArray(decodedArray, "Декодированный массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] decode(int[] encoded, int first)
        {
            int[] result = new int[encoded.Length + 1];
            result[0] = first;
            for (int i = 0; i < encoded.Length; i++)
            {
                result[i+1] = result[i] ^ encoded[i];
            }
            return result;
        }
    }
}
