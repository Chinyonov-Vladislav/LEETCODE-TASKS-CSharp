using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task389
{
    /*
     389. Найди разницу
    Вам даны две строки s и t.
    Строка t генерируется путём случайного перемешивания строки s и последующего добавления ещё одной буквы в случайном месте.
    Верните букву, которая была добавлена в t.
    https://leetcode.com/problems/find-the-difference/description/
     */
    public class Task389 : InfoBasicTask
    {
        public Task389(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string first = "abcd";
            string second = "abcde";
            char addedLetter = findTheDifference(first, second);
            Console.WriteLine(addedLetter == ' ' ? "Буква не была добавлена" :$"Добавленная буква = {addedLetter}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public char findTheDifference(string s, string t)
        {
            Dictionary<char, int> firstStringDict = new Dictionary<char, int>();
            Dictionary<char, int> secondStringDict = new Dictionary<char, int>();
            char result = ' ';
            for (int i = 0; i < t.Length; i++)
            {
                if (!secondStringDict.ContainsKey(t[i]))
                {
                    secondStringDict.Add(t[i], 1);
                }
                else
                {
                    secondStringDict[t[i]]++;
                }

                if (i < t.Length - 1) // индекс подходит под первую строку
                {
                    if (!firstStringDict.ContainsKey(s[i]))
                    {
                        firstStringDict.Add(s[i], 1);
                    }
                    else
                    {
                        firstStringDict[s[i]]++;
                    }
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (!firstStringDict.ContainsKey(t[i]) || firstStringDict[t[i]] != secondStringDict[t[i]])
                {
                    result = t[i];
                    break;
                }
            }
            return result;
        }
        private char bestSolution(string s, string t) // скопировано с leetCode
        {
            int charSum = 0;

            foreach (int c in s)
            {
                charSum -= c;
            }

            foreach (int c in t)
            {
                charSum += c;
            }

            return (char)charSum;
        }
    }
}
