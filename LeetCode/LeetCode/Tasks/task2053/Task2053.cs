using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2053
{
    /*
     2053. K - я уникальная строка в массиве
    Уникальная строка — это строка, которая встречается в массиве только один раз.
    Учитывая массив строк arr и целое число k, верните kth отдельную строку, присутствующую в arr. 
    Если их меньше, чем k отдельных строк, верните пустую строку "".
    Обратите внимание, что строки рассматриваются в том порядке, в котором они представлены в массиве.
    https://leetcode.com/problems/kth-distinct-string-in-an-array/description/
     */
    public class Task2053 : InfoBasicTask
    {
        public Task2053(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] array = new string[] { "d", "b", "c", "b", "c", "a" };
            int k = 2;
            printArray(array, "Исходный массив: ");
            Console.WriteLine($"Номер уникального элемента в массиве = {k}");
            string result = kthDistinct(array, k);
            Console.WriteLine(result == String.Empty ? $"В массиве нет уникального элемента на позиции {k} (нумерация с 1)" : $"Уникальный элемент в массиве на позиции {k} (нумерация с 1): \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string kthDistinct(string[] arr, int k)
        {
            Dictionary<string, int> dictFreq = new Dictionary<string, int>();
            foreach (string str in arr) {
                if (dictFreq.ContainsKey(str))
                {
                    dictFreq[str]++;
                }
                else
                {
                    dictFreq.Add(str, 1);
                }
            }
            List<string> uniqueStrings = new List<string>();
            foreach (string str in arr)
            {
                if (dictFreq[str] == 1)
                {
                    uniqueStrings.Add(str);
                }
            }
            if (k > uniqueStrings.Count)
            {
                return String.Empty;
            }
            return uniqueStrings[k - 1];
        }
    }
}
