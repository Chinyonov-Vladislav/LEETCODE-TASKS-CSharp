using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2206
{
    /*
     2206. Разделите массив на равные пары
    Вам выдается целочисленный массив, nums состоящий из 2 * n целых чисел.
    Вам нужно разделить nums на n пары таким образом, чтобы:
        Каждый элемент принадлежит ровно одной паре.
        Элементы, присутствующие в паре, равны.
    Верните, true если числа могут быть разделены на n пары, в противном случае верните false.
    https://leetcode.com/problems/divide-array-into-equal-pairs/description/
     */
    public class Task2206 : InfoBasicTask
    {
        public Task2206(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] array = new int[] { 3, 2, 3, 2, 2, 2 };
            printArray(array, "Исходный массив: ");
            Console.WriteLine(divideArray(array) ? "Исходный массив может быть разделен на пары, где каждый из двух элементов - это одно и то же число" : "Исходный массив не может быть разделен на пары, где каждый из двух элементов - это одно и то же число");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool divideArray(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 1);
                }
                else
                {
                    dict[nums[i]]++;
                }
            }
            foreach (var pair in dict)
            {
                if (pair.Value % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
