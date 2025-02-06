using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1528
{
    /*
     1528. Перетасовать строку
    Вам дана строка s и целочисленный массив indices той же длины. Строка s будет перемешана таким образом, что символ в позиции ith переместится в indices[i] в перемешанной строке.
    Верните перетасованную строку.
    https://leetcode.com/problems/shuffle-string/description/
     */
    public class Task1528 : InfoBasicTask
    {
        public Task1528(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "codeleet";
            int[] indices = new int[] { 4, 5, 6, 7, 0, 2, 1, 3 };
            Console.WriteLine($"Исходная строка: \"{str}\"");
            printArray(indices, "Массив индексов: ");
            string shuffleString = restoreString(str,indices);
            Console.WriteLine($"Перемешанная строка: \"{shuffleString}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string restoreString(string s, int[] indices)
        {
            char[] chars = new char[s.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                chars[indices[i]] = s[i];
            }
            StringBuilder sb = new StringBuilder();
            foreach (var c in chars)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
