using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2399
{
    /*
    2399. Проверьте расстояния между одинаковыми буквами
    Вам выдается строка с индексом s0, состоящая только из строчных английских букв, где каждая буква в s появляется ровно дважды. Вам также предоставляется целочисленный массив длины distance, проиндексированный260.
    Каждая буква алфавита пронумерована от 0 до 25 (то есть 'a' -> 0, 'b' -> 1, 'c' -> 2, ... , 'z' -> 25).
    В строке с правильным интервалом количество букв между двумя вхождениями буквы ith равно distance[i]. Если буква ith не встречается в s, то distance[i] можно игнорировать.
    Верните, true если s это строка с интервалами false, в противном случае верните, в противном случае верните.
    Ограничения:
        2 <= s.length <= 52
        s consists only of lowercase English letters.
        Each letter appears in s exactly twice.
        distance.length == 26
        0 <= distance[i] <= 50
    https://leetcode.com/problems/check-distances-between-same-letters/description/
     */
    public class Task2399 : InfoBasicTask
    {
        public Task2399(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abaccb";
            int[] dist = new int[] { 1, 3, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Console.WriteLine($"Исходная строка: \"{s}\"");
            printArray(dist, "Массив расстояний для каждой английской буквы: ");
            if (isValid(s, dist))
            {
                Console.WriteLine(checkDistances(s, dist) ? "Расстояния между одинаковыми буквами в исходной строке соответствует заявленному расстоянию из массива" : "Расстояния между одинаковыми буквами в исходной строке не соответствует заявленному расстоянию из массива");
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
        private bool isValid(string s, int[] dist)
        {
            if (s.Length < 2 || s.Length>52)
            {
                return false;
            }
            if (dist.Length != 26)
            {
                return false;
            }
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            foreach (char ch in s)
            {
                if (!alphabet.Contains(ch))
                {
                    return false;
                }
            }
            foreach (int item in dist)
            {
                if (item < 0 || item > 50)
                {
                    return false;
                }
            }
            HashSet<char> chars = new HashSet<char>(s);
            if (chars.Count != s.Length / 2)
            {
                return false;
            }
            return true;
        }
        private bool checkDistances(string s, int[] distance)
        {
            HashSet<char> chars = new HashSet<char>(s);
            foreach (char ch in chars)
            {
                int left = 0;
                int right = s.Length-1;
                while(left< right)
                {
                    if (s[left] == ch && s[right] == ch)
                    {
                        break;
                    }
                    if (s[left] != ch)
                    {
                        left++;
                    }
                    if (s[right] != ch)
                    {
                        right--;
                    }
                    
                }
                int diff = right - left - 1;
                if (distance[ch - 'a'] != diff)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
