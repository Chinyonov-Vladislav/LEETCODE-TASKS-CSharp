using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1287
{
    /*
     1287. Элемент, встречающийся более 25% раз в отсортированном массиве
    Дан целочисленный массив, отсортированный в порядке неубывания. В массиве есть ровно одно целое число, которое встречается более чем в 25% случаев. Найдите это число.
    https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array/description/
     */
    public class Task1287 : InfoBasicTask
    {
        public Task1287(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 1, 2, 2, 6, 6, 6, 6, 7, 10 };
            printArray(array, "Исходный массив: ");
            int result = findSpecialInteger(array);
            Console.WriteLine($"Число, которое встречается в более 25 процентов случаев = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findSpecialInteger(int[] arr)
        {
            Dictionary<int,int> dict = new Dictionary<int, int>();
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right) {
                if (dict.ContainsKey(arr[left]))
                {
                    dict[arr[left]]++;
                }
                else
                {
                    dict.Add(arr[left], 1);
                }
                if (dict.ContainsKey(arr[right]))
                {
                    dict[arr[right]]++;
                }
                else
                {
                    dict.Add(arr[right], 1);
                }
                left++;
                right--;
            }
            int max = dict.Values.Max();
            return dict.Where(x => x.Value == max).First().Key;
        }
        private int bestSolution(int[] arr)
        {
            int n = arr.Length;
            int threshold = n / 4;
            for (int i = 0; i < n - threshold; i++)
            {
                if (arr[i] == arr[i + threshold])
                {
                    return arr[i];
                }
            }
            return -1;
        }
    }
}
