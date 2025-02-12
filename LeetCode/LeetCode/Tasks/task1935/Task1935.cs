using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1935
{
    /*
     1935. Максимальное количество слов, которые Вы можете ввести
    Неисправна клавиатура, некоторые клавиши не работают. Все остальные клавиши на клавиатуре работают исправно.
    Учитывая строку text слов, разделенных одним пробелом (без начальных или завершающих пробелов), и строку brokenLetters всех различных буквенных клавиш, которые разбиты, верните количество слов, которыев text вы можете полностью ввести с помощью этой клавиатуры.
    https://leetcode.com/problems/maximum-number-of-words-you-can-type/description/
     */
    public class Task1935 : InfoBasicTask
    {
        public Task1935(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string words = "hello world";
            string brokenLetters = "ad";
            Console.WriteLine($"Исходная строка: \"{words}\"\nСломанные буквы: \"{brokenLetters}\"");
            int count = canBeTypedWords(words, brokenLetters);
            Console.WriteLine($"Количество слов из исходной строки, которые могут быть напечатаны = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int canBeTypedWords(string text, string brokenLetters)
        {
            string[] words = text.Split(' ');
            int count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                bool canAddCurrentWord = true;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (brokenLetters.Contains(words[i][j]))
                    {
                        canAddCurrentWord = false;
                        break;
                    }
                }
                if (canAddCurrentWord)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
