using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task567
{
    /*
     567. Перестановка в строке
    Даны две строки s1 и s2, верните true если s2 содержит перестановкуs1 или false в противном случае.
    Другими словами, верните true если одна из перестановок s1 является подстрокой s2.
    Ограничения:
        1 <= s1.length, s2.length <= 10^4
        s1 и s2 состоят из строчных английских букв.
    https://leetcode.com/problems/permutation-in-string/description/
     */
    public class Task567 : InfoBasicTask
    {
        
        public Task567(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string first = "ab";
            string second = "eidbaooo";
            Console.WriteLine($"Строка для проверки: \"{second}\"\nСтрока для перестановок: \"{first}\"");
            if (isValid(first, second))
            {
               Console.WriteLine(checkInclusion(first, second) ?$"Строка \"{second}\" содержит перестановку строки \"{first}\"" : $"Строка \"{second}\" не содержит перестановку строки \"{first}\"") ;
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
        private bool isValid(string s1, string s2)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,4);
            if (s1.Length < lowLimit || s1.Length > highLimit || s2.Length < lowLimit || s2.Length > highLimit)
            {
                return false;
            }
            List<string> strings = new List<string>() { s1, s2 };
            foreach (string s in strings)
            {
                foreach (char c in s)
                {
                    if (!(c >= 'a' && c <= 'z'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool checkInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return false;
            }
            int lengthAlphabet = 26;
            int[] freqStringOne = new int[lengthAlphabet];
            foreach (char c in s1)
            {
                freqStringOne[c - 'a']++;
            }
            int[] freqStringTwo = new int[lengthAlphabet];
            int firstPointer = 0;
            int secondPointer = firstPointer + s1.Length - 1;
            while (secondPointer < s2.Length)
            {
                if (firstPointer == 0)
                {
                    for (int index = firstPointer; index <= secondPointer; index++)
                    {
                        freqStringTwo[s2[index] - 'a']++;
                    }
                }
                else
                {
                    freqStringTwo[s2[firstPointer-1] - 'a']--;
                    freqStringTwo[s2[secondPointer] - 'a']++;
                }
                bool isEqual = true;
                for (int index = 0; index < lengthAlphabet; index++)
                {
                    if (freqStringOne[index] != freqStringTwo[index])
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual)
                {
                    return true;
                }
                firstPointer++;
                secondPointer++;
            }
            return false;
        }
    }
}
