using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2515
{
    /*
     2515. Кратчайшее расстояние до целевой строки в кольцевом массиве
    Вам предоставляется 0-индексированный циклический массив строк words и строка target. Циклический массив означает, что конец массива соединяется с началом массива.
        Формально, следующий элемент words[i] — это words[(i + 1) % n], а предыдущий элемент words[i] — это words[(i - 1 + n) % n], где n — длина words.
    Начиная с startIndex, вы можете перейти либо к следующему, либо к предыдущему слову, делая по 1 шагу за раз.
    Верните кратчайшее расстояние, необходимое для достижения строки target. Если строка target не существует в words, верните -1.
    Ограничения:
        1 <= words.length <= 100
        1 <= words[i].length <= 100
        words[i] и target состоят только из строчных английских букв.
        0 <= startIndex < words.length
    https://leetcode.com/problems/shortest-distance-to-target-string-in-a-circular-array/description/
     */
    public class Task2515 : InfoBasicTask
    {
        public Task2515(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] words= new string[] { "hello", "i", "am", "leetcode", "hello" };
            string target = "hello";
            int startIndex = 1;
            printArray(words);
            Console.WriteLine($"Целевое слово: \"{target}\"\nСтартовый индекс = \"{startIndex}\"");
            if (isValid(words, target, startIndex))
            {
                int minDist = closestTarget(words, target, startIndex);
                Console.WriteLine(minDist == -1 ? "Целевое слово отсутствует в исходном массиве!" : $"Кратчайшее расстояние до целевого слова с индекса {startIndex} = {minDist}");
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
        private bool isValid(string[] words, string target, int startIndex)
        {
            if (words.Length < 1 || words.Length > 100)
            {
                return false;
            }
            foreach (string word in words) {
                if (word.Length < 1 || word.Length > 100)
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
            foreach (char c in target)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            if (startIndex < 0 || startIndex > words.Length - 1)
            {
                return false;
            }
            return true;
        }
        private int closestTarget(string[] words, string target, int startIndex)
        {
            if (!words.Contains(target))
            {
                return -1;
            }
            int toRight = 0;
            int toLeft = 0;
            for (int i = startIndex; ; i++)
            {
                if (i == words.Length)
                {
                    i = 0;
                }
                if (words[i] == target)
                {
                    break;
                }
                toRight++;
            }
            for (int i = startIndex; ; i--)
            {
                if (i < 0)
                {
                    i = words.Length - 1;
                }
                if (words[i] == target)
                {
                    break;
                }
                toLeft++;
            }
            return Math.Min(toRight, toLeft);
        }
    }
}
