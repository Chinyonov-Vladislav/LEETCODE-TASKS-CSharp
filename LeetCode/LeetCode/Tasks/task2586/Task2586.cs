using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2586
{
    /*
     2586. Подсчитайте количество гласных в диапазоне
    Вам предоставляется 0-индексированный массив строк words и два целых числа left и right.
    Строка называется глагольной строкой, если она начинается с гласного символа и заканчивается гласным символом, где гласными символами являются 'a', 'e', 'i', 'o', и 'u'.
    Возврат количество строк гласных words[i] где i относится к включающему диапазону [left, right].
    Ограничения:
        1 <= words.length <= 1000
        1 <= words[i].length <= 10
        words[i] состоит только из строчных английских букв.
        0 <= left <= right < words.length
    https://leetcode.com/problems/count-the-number-of-vowel-strings-in-range/description/
     */
    public class Task2586 : InfoBasicTask
    {
        public Task2586(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "hey", "aeo", "mu", "ooo", "artro" };
            int left = 1;
            int right = 4;
            printArray(words, "Массив слов: ");
            Console.WriteLine($"Левый индекс = {left}\nПравый индекс = {right}");
            if (isValid(words, left, right))
            {
                int count = vowelStrings(words, left, right);
                Console.WriteLine($"Количество гласных строк (начинаются и закончаются на гласную английскую букву) = {count}");
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
        private bool isValid(string[] words, int left, int right)
        {
            if (words.Length < 1 || words.Length > 1000)
            {
                return false;
            }
            foreach (string word in words)
            {
                if (word.Length < 1 || word.Length > 10)
                {
                    return false;
                }
                foreach (char ch in word)
                {
                    if (!char.IsLetter(ch) || !char.IsLower(ch))
                    {
                        return false;
                    }
                }
            }
            if (left < 0 || left > right || right >= words.Length)
            {
                return false;
            }
            return true;
        }
        private int vowelStrings(string[] words, int left, int right)
        {
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;
            while (left <= right)
            {
                string currentWord = words[left];
                if (vowels.Contains(currentWord[0]) && vowels.Contains(currentWord[currentWord.Length - 1]))
                {
                    count++;
                }
                left++;
            }
            return count;
        }
    }
}
