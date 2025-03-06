using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3014
{
    /*
     3014. Минимальное количество нажатий для ввода слова I
    Вам будет предоставлена строка, word содержащая разные строчные английские буквы.
    На телефонных клавиатурах клавиши сопоставлены с различными наборами строчных букв английского алфавита, которые можно использовать для составления слов, нажимая на них. Например, клавиша 2 сопоставлена с ["a","b","c"], нам нужно нажать на клавишу один раз, чтобы напечатать "a", два раза, чтобы напечатать "b", и три раза, чтобы напечатать "c" .
    Можно переназначить клавиши с номерами 2 на 9 на разные наборы букв. Клавиши можно переназначить на любое количество букв, но каждая буква должна быть сопоставлена ровно с одной клавишей. Вам нужно найти минимальное количество нажатий клавиш для ввода строки word.
    Верните минимальное количество нажатий, необходимых для ввода word после переназначения клавиш.
    Обратите внимание, что 1,*, # и 0 не сопоставляются ни с какими буквами.
    Ограничения:
        1 <= word.length <= 26
        word состоит из строчных английских букв.
        Все буквы в word различимы.
    https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-i/description/
     */
    public class Task3014 : InfoBasicTask
    {
        public Task3014(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word = "xycdefghij";
            Console.WriteLine($"Исходная строка: \"{word}\"");
            if (isValid(word))
            {
                int min = minimumPushes(word);
                Console.WriteLine($"Минимальное количество нажатий на клавиши мобильного телефона после оптимального переназначения клавиш = {min}");
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
            if (word.Length < 1 || word.Length > 26)
            {
                return false;
            }
            foreach (char c in word) {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            HashSet<char> chars = new HashSet<char>(word);
            if (chars.Count != word.Length)
            {
                return false;
            }
            return true;
        }
        private int minimumPushes(string word)
        {
            int countPushes = 0;
            HashSet<char> chars = new HashSet<char>();
            foreach (char ch in word)
            {
                chars.Add(ch);
                if (chars.Count % 8 == 0)
                {
                    countPushes += chars.Count / 8;
                }
                else
                {
                    countPushes += chars.Count / 8+1;
                }
            }
            return countPushes;
        }
    }
}
