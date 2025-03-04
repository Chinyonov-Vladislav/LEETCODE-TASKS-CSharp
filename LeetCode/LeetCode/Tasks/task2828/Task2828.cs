using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2828
{
    /*
     2828. Проверьте, является ли строка аббревиатурой из слов
    Учитывая массив строк words и строку s, определите, является ли sакронимом из слов.
    Строка s считается аббревиатурой words если она может быть образована путём объединения первых символов каждой строки words по порядку. Например, "ab" может быть образована из ["apple", "banana"], но не может быть образована из ["bear", "aardvark"].
    Вернуть true если s это аббревиатура words, а false в противном случае.
    Ограничения:
        1 <= words.length <= 100
        1 <= words[i].length <= 10
        1 <= s.length <= 100
        words[i] и s состоят из строчных английских букв.
    https://leetcode.com/problems/check-if-a-string-is-an-acronym-of-words/description/
     */
    public class Task2828 : InfoBasicTask
    {
        public Task2828(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            IList<string> words = new List<string>() { "never", "gonna", "give", "up", "on", "you" };
            printIListString(words, "Лист слов: ");
            string s = "ngguoy";
            Console.WriteLine($"Аббревиатура: \"{s}\"");
            if (isValid(words, s))
            {
                Console.WriteLine(isAcronym(words, s) ? $"Строка \"{s}\" является абберевиатурой для массива слов" : $"Строка \"{s}\" не является абберевиатурой для массива слов");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(IList<string> words, string s)
        {
            if (words.Count < 1 || words.Count > 100)
            {
                return false;
            }
            foreach (string word in words) {
                if (word.Length < 1 || word.Length > 10)
                {
                    return false;
                }
                foreach (char c in word)
                {
                    if (c < 'a' || c > 'z')
                    {
                        return false;
                    }
                }
            }
            if (s.Length < 1 || s.Length > 100)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            return true;
        }
        private bool isAcronym(IList<string> words, string s)
        {
            if (words.Count != s.Length)
            {
                return false;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (words[i][0] != s[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
