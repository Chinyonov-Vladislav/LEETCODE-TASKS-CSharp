using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1592
{
    /*
     1592. Переставьте пробелы между словами
    Вам дана строка text из слов, разделённых некоторым количеством пробелов. Каждое слово состоит из одной или нескольких строчных букв английского алфавита и разделено хотя бы одним пробелом. Гарантируется, что text содержит хотя бы одно слово.
    Переставьте пробелы так, чтобы между каждой парой соседних слов было одинаковое количество пробелов, и это количество было максимальным. Если вы не можете перераспределить все пробелы равномерно, добавьте дополнительные пробелы в конце, то есть возвращаемая строка должна иметь ту же длину, что и text.
    Верните строку после перестановки пробелов.
    https://leetcode.com/problems/rearrange-spaces-between-words/description/
     */
    public class Task1592 : InfoBasicTask
    {
        public Task1592(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = " practice   makes   perfect";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            string result = reorderSpaces(str);
            Console.WriteLine($"Результирующая строка: \"{result}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public string reorderSpaces(string text)
        {
            int countSpaces = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    countSpaces++;
                }
            }
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(' ', countSpaces);
                return words[0] + sb.ToString();
            }
            int countSequenceSpaces = countSpaces / (words.Length - 1);
            int countExtraSpaces = countSpaces % (words.Length - 1);
            StringBuilder stringBuilderSpaceBetweenWords = new StringBuilder();
            stringBuilderSpaceBetweenWords.Append(' ', countSequenceSpaces);
            string result = String.Join(stringBuilderSpaceBetweenWords.ToString(), words);
            if (countExtraSpaces != 0)
            {
                StringBuilder stringBuilderExtraSpaces = new StringBuilder();
                stringBuilderExtraSpaces.Append(' ', countExtraSpaces);
                result += stringBuilderExtraSpaces.ToString();
            }
            return result;
        }
    }
}
