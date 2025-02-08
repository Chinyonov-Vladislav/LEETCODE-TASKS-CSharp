using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1662
{
    /*
     1662. Проверьте, эквивалентны ли два массива строк
    Учитывая два строковых массива word1 и word2, верните true если два массивапредставляют одну и ту же строку, и false иначе.
    Строка представлена массивом, если элементы массива, объединённые по порядку, образуют строку.
    https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent/description/
     */
    public class Task1662 : InfoBasicTask
    {
        public Task1662(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] word1 = new string[] { "ab", "c" };
            string[] word2 = new string[] { "a", "bc" };
            printArray(word1, "Первый массив строк: ");
            printArray(word2, "Первый массив строк: ");
            Console.WriteLine(arrayStringsAreEqual(word1, word2) ? "Два массива строк эквивалентны" : "Два массива строк не эквивалентны");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool arrayStringsAreEqual(string[] word1, string[] word2)
        {
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            for (int i = 0; i < word1.Length; i++)
            {
                str1.Append(word1[i]);
            }
            for (int i = 0; i < word2.Length; i++)
            {
                str2.Append(word2[i]);
            }
            return str1.ToString().Equals(str2.ToString());
        }
    }
}
