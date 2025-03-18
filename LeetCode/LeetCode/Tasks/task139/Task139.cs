using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task139
{
    /*
     139. Перерыв в словах
    Учитывая строку s и словарь строк wordDict, верните true если s можно разделить на последовательность из одного или нескольких слов из словаря, разделённых пробелами.
    Обратите внимание, что одно и то же слово в словаре может использоваться для сегментации несколько раз.
    Ограничения:
        1 <= s.length <= 300
        1 <= wordDict.length <= 1000
        1 <= wordDict[i].length <= 20
        s и wordDict[i] состоят только из строчных английских букв.
        Все строки wordDict являются уникальными.
    https://leetcode.com/problems/word-break/description/
     */
    public class Task139 : InfoBasicTask
    {
        private enum TypeSolution
        {
            Recursive,
            Fast,
            Both
        }
        public Task139(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "applepenapple";
            IList<string> wordDict = new List<string>() { "apple", "pen" };
            Console.WriteLine($"Исходная строка: \"{s}\"");
            printIListString(wordDict, "Массив слов: ");
            if (isValid(s, wordDict))
            {
                int userChoice = askUserTypeSolution();
                if (userChoice == 1)
                {
                    Console.WriteLine($"Решение с помощью рекурсивного метода: {(wordBreak(s, wordDict, TypeSolution.Recursive) ? "можно" : "нельзя")} разделить исходную строку на последовательность из одного или нескольких слов из словаря, разделённых пробелами");
                }
                else if (userChoice == 2)
                {
                    Console.WriteLine($"Решение с помощью быстрого метода: {(wordBreak(s, wordDict, TypeSolution.Fast) ? "можно" : "нельзя")} разделить исходную строку на последовательность из одного или нескольких слов из словаря, разделённых пробелами");
                }
                else if (userChoice == 3) {
                    Console.WriteLine($"Решение с помощью рекурсивного метода: {(wordBreak(s, wordDict, TypeSolution.Recursive) ? "можно" : "нельзя")} разделить исходную строку на последовательность из одного или нескольких слов из словаря, разделённых пробелами");
                    Console.WriteLine($"Решение с помощью быстрого метода: {(wordBreak(s, wordDict, TypeSolution.Fast) ? "можно" : "нельзя")} разделить исходную строку на последовательность из одного или нескольких слов из словаря, разделённых пробелами");
                }
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
        private bool isValid(string s, IList<string> wordDict)
        {
            int lowLimit = 1;
            int highLimit = 300;
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            highLimit = 1000;
            if (wordDict.Count < lowLimit || wordDict.Count > highLimit)
            {
                return false;
            }
            highLimit = 20;
            foreach (string word in wordDict)
            {
                if (word.Length < lowLimit || word.Length > highLimit)
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
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            HashSet<string> wordSet = new HashSet<string>(wordDict);
            if (wordSet.Count != wordDict.Count)
            {
                return false;
            }
            return true;
        }
        private bool wordBreak(string s, IList<string> wordDict, TypeSolution type)
        {
            if (type == TypeSolution.Recursive)
            {
                int currentIndex = 0;
                string currentString = String.Empty;
                return recursive(s, currentString, currentIndex, wordDict);
            }
            else
            {
                return fastMethod(s, wordDict);
            }
        }
        private bool recursive(string s, string currentString, int currentIndex, IList<string> wordDict)
        {
            for (int index = currentIndex; index < wordDict.Count; index++)
            {
                if (currentString + wordDict[index] == s)
                {
                    return true;
                }
                if (s.StartsWith(currentString + wordDict[index]))
                {
                    bool res = recursive(s, currentString + wordDict[index], 0, wordDict);
                    if (res)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool fastMethod(string s, IList<string> wordDict)
        {
            HashSet<string> wordsSet = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (dp[j] && wordsSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }
        private int askUserTypeSolution()
        {
            while (true)
            {
                Console.WriteLine("Выберите тип решения :\n" +
                    "1 - Рекурсивный\n" +
                    "2 - Быстрый\n" +
                    "3 - Протестировать оба решения\n" +
                    "0 - Отменить выполнения задачи");
                Console.Write("Ваш выбор: ");
                try
                {
                    int choiceUser = Int32.Parse(Console.ReadLine());
                    if (choiceUser < 0 || choiceUser > 3)
                    {
                        throw new FormatException();
                    }
                    return choiceUser;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
        }
    }
}
