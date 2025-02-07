using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1588
{
    /*
     1588. Сумма всех подмассивов нечетной длины
    Учитывая массив положительных целых чисел arr, верните сумму всех возможныхподмассивов нечётной длины из arr.
    Подмассив - это непрерывная подпоследовательность массива.
    https://leetcode.com/problems/sum-of-all-odd-length-subarrays/description/
     */
    public class Task1588 : InfoBasicTask
    {
        public Task1588(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 4, 2, 5, 3 };
            printArray(array, "Исходный массив: ");
            int sum = sumOddLengthSubarrays(array);
            Console.WriteLine($"Сумма элементов подмассивов нечетной длины = {sum}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int sumOddLengthSubarrays(int[] arr)
        {
            int sum = arr.Sum();
            for (int currentOddLength = 3; currentOddLength <= arr.Length; currentOddLength+=2)
            {
                for (int startIndex = 0; startIndex <= arr.Length - currentOddLength; startIndex++)
                {
                    int endIndex = startIndex + currentOddLength;
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        sum += arr[i];
                    }
                }
            }
            return sum;
        }
        // скопировано с leetcode
        private int bestSolution(int[] arr)
        {
            int n = arr.Length;
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                int l = i + 1;
                int r = n - i;

                int p = l * r;

                if (p % 2 != 0)
                    p = p / 2 + 1;
                else
                    p = p / 2;

                res += arr[i] * p;
            }
            return res;
        }
    }
}
