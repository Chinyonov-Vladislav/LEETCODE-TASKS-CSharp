using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3136
{
    /*
     3136. Действительное слово
    Слово считается действительным, если:
        Он содержит минимум из 3 символов.
        Он содержит только цифры (0-9) и английские буквы (прописные и строчные).
        Оно включает по крайней мере одну гласную.
        Оно включает по крайней мере одну согласную.
    Вам дается строка word.
    Верните, true если word значение действительно, в противном случае верните false.
    Примечания:
        'a', 'e', 'i', 'o' 'u', , а их заглавные буквы - это гласные.
        Согласная — это английская буква, которая не является гласной.
    Ограничения:
        1 <= word.length <= 20
        word состоит из английских заглавных и строчных букв, цифр, '@', '#' и '$'.
    https://leetcode.com/problems/valid-word/description/
     */
    public class Task3136 : InfoBasicTask
    {
        public Task3136(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string word = "234Adas";
            Console.WriteLine($"Исходная строка: \"{word}\"");
            if (checkValidWord(word))
            {
                Console.WriteLine(isValid(word) ? "Исходная строка валидна" : "Исходная строка не валидна");
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
        private bool checkValidWord(string word)
        {
            if (word.Length < 1 || word.Length > 20)
            {
                return false;
            }
            word.ToLower();
            List<char> symbols = new List<char>() { '@', '#', '$' };
            foreach (char c in word)
            {
                if (!char.IsLetterOrDigit(c) && !symbols.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool isValid(string word)
        {
            if (word.Length < 3)
            {
                return false;
            }
            word = word.ToLower();
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            bool existVowel = false;
            bool existConsonant = false;
            foreach (char c in word)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
                if (c >= '0' && c <= '9')
                {
                    continue;
                }
                else if (vowels.Contains(c))
                {
                    existVowel = true;
                }
                else
                {
                    existConsonant = true;
                }
            }
            if (!existVowel || !existConsonant)
            {
                return false;
            }
            return true;
        }
    }
}
