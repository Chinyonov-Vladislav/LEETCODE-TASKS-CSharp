using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task318
{
    /*
     318. Максимальное произведение длин слов
    Учитывая массив строк words, верните максимальное значение, при котором length(word[i]) * length(word[j]) два слова не имеют общих букв. Если таких двух слов не существует, верните 0.
    Ограничения:
        2 <= words.length <= 1000
        1 <= words[i].length <= 1000
        words[i] состоит только из строчных английских букв.
    https://leetcode.com/problems/maximum-product-of-word-lengths/description/
     */
    public class Task318 : InfoBasicTask
    {
        public Task318(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words = new string[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" };
            printArray(words);
            if (isValid(words))
            {
                int res = maxProduct(words);
                Console.WriteLine($"Максимальное произведение длин слов, не имеющих общих букв = {res}");
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
        private bool isValid(string[] words)
        {
            int lowLimit = 2;
            int highLimit = 1000;
            if (words.Length < lowLimit || words.Length > highLimit)
            {
                return false;
            }
            lowLimit = 1;
            highLimit = 1000;
            foreach (string word in words)
            {
                if (word.Length<lowLimit || word.Length>highLimit)
                {
                    return false;
                }
                foreach (char c in word)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int maxProduct(string[] words)
        {
            int max = 0;
            for (int i = 0; i < words.Length-1; i++)
            {
                HashSet<char> chars = new HashSet<char>(words[i]);
                for (int j = i + 1; j < words.Length; j++)
                {
                    bool isCorrect = true;
                    foreach (char c in words[j])
                    {
                        if (chars.Contains(c))
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                    if (isCorrect)
                    {
                        int localMax = words[i].Length * words[j].Length;
                        if (localMax > max)
                        {
                            max = localMax;
                        }
                    }
                }
            }
            return max;
        }
    }
}
