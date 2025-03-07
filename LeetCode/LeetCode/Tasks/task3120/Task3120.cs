using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3120
{
    /*
     3120. Подсчитайте количество специальных символов I
    Вам дана строка word. Буква называется специальной, если она встречается как в нижнем, так и в верхнем регистре в word.
    Возвращает количество специальных букв в word.
    Ограничения:
        1 <= word.length <= 50
        word состоит только из строчных и прописных английских букв.
     */
    public class Task3120 : InfoBasicTask
    {
        public Task3120(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word = "aaAbcBC";
            Console.WriteLine($"Исходная строка: \"{word}\"");
            if (isValid(word))
            {
                int count = numberOfSpecialChars(word);
                Console.WriteLine($"Количество символов в исходной строке, которые есть в нижнем и в верхнем регистре = {count}");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string word)
        {
            if (word.Length < 1 || word.Length > 50)
            {
                return false;
            }
            foreach (char c in word)
            {
                if (!(c >= 'a' && c <= 'z') && !(c >= 'A' && c <= 'Z'))
                {
                    return false;
                }
            }
            return true;
        }
        private int numberOfSpecialChars(string word)
        {
            HashSet<char> lowerChars = new HashSet<char>();
            HashSet<char> upperChars = new HashSet<char>();
            foreach (char c in word)
            {
                if (c >= 'a' && c <= 'z')
                {
                    lowerChars.Add(c);
                }
                else
                {
                    upperChars.Add(c);
                }
            }
            int count = 0;
            foreach (char c in upperChars)
            {
                char lowChar = (char)(c + 32);
                if (lowerChars.Contains(lowChar))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
