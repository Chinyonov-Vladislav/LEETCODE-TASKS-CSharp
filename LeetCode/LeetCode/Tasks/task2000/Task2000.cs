using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2000
{
    /*
     2000. Обратный префикс слова
    Учитывая строку с индексом 0 word и символ ch, переверните сегмент word, который начинается с индекса 0 и заканчивается индексом первого вхождения ch (включительно). 
    Если символ ch не существует в word, ничего не делайте.
        Например, если word = "abcdefd" и ch = "d", то вам нужно повернуть сегмент, который начинается с 0 и заканчивается на 3 (включительно). 
        В результате получится "dcbaefd".
    Верните результирующую строку.
    https://leetcode.com/problems/reverse-prefix-of-word/description/
     */
    public class Task2000 : InfoBasicTask
    {
        public Task2000(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word = "abcefd";
            char ch = 'd';
            Console.WriteLine($"Исходное слово = \"{word}\"");
            Console.WriteLine($"Символ окончания префикса = \'{ch}\'");
            Console.WriteLine($"Слово с перевернутым префиксом = \"{reversePrefix(word, ch)}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reversePrefix(string word, char ch)
        {
            int indexOfChar = -1;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ch)
                {
                    indexOfChar = i;
                    break;
                }
            }
            if (indexOfChar == -1)
            {
                return word;
            }
            string substringPrefix = word.Substring(0, indexOfChar + 1);
            char[] charArray = substringPrefix.ToCharArray();
            Array.Reverse(charArray);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(new string(charArray));
            stringBuilder.Append(word.Substring(indexOfChar + 1));
            return stringBuilder.ToString();
        }
    }
}
