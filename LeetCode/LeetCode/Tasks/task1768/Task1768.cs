using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1768
{
    /*
     1768. Объединяйте строки поочередно
    Вам даны две строки word1 и word2. Объедините строки, добавляя буквы в шахматном порядке, начиная с word1. Если одна строка длиннее другой, добавьте дополнительные буквы в конец объединённой строки.
    Возвращает объединенную строку.
    https://leetcode.com/problems/merge-strings-alternately/description/
     */
    public class Task1768 : InfoBasicTask
    {
        public Task1768(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str1 = "ab";
            string str2 = "pqrs";
            Console.WriteLine($"Строка №1: \"{str1}\"");
            Console.WriteLine($"Строка №2: \"{str2}\"");
            string result = mergeAlternately(str1, str2);
            Console.WriteLine($"Результирующая строка, полученная путём слияния: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string mergeAlternately(string word1, string word2)
        {
            int minLength = word1.Length < word2.Length ? word1.Length : word2.Length;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < minLength; i++)
            {
                stringBuilder.Append(word1[i]);
                stringBuilder.Append(word2[i]);
            }
            int remainLength = word1.Length >= word2.Length ? word1.Length - word2.Length : word2.Length - word1.Length;
            if (word1.Length >= word2.Length)
            {
                stringBuilder.Append(word1.Substring(minLength, remainLength));
            }
            else
            {
                stringBuilder.Append(word2.Substring(minLength, remainLength));
            }
            return stringBuilder.ToString();
        }
    }
}
