using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task524
{
    /*
     524. Самое длинное слово в словаре из-за удаления
    Учитывая строку s и массив строк dictionary, верните самую длинную строку в словаре, которую можно получить, удалив некоторые символы из заданной строки. 
    Если возможных результатов несколько, верните самое длинное слово с наименьшим лексикографическим порядком. 
    Если возможных результатов нет, верните пустую строку.
    Ограничения:
        1 <= s.length <= 1000
        1 <= dictionary.length <= 1000
        1 <= dictionary[i].length <= 1000
        s и dictionary[i] состоят из строчных английских букв.
    https://leetcode.com/problems/longest-word-in-dictionary-through-deleting/description/
     */
    public class Task524 : InfoBasicTask
    {
        public Task524(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abpcplea";
            string[] arr = new string[] { "ale", "apple", "monkey", "plea" };
            Console.WriteLine($"Исходная строка: \"{s}\"");
            printArray(arr);
            if (isValid(s, arr))
            {
                string res = findLongestWord(s, arr);
                Console.WriteLine(res == String.Empty ? $"Невозможно получить ни одно слово из массива путём удаления символов из строки \"{s}\"" : $"Самое длинное слово с наименьшим лексикографическим порядком, которое можно составить из строки \"{s}\" и оно содержится в массиве путём удаления определенного количества символов: \"{res}\"");
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
        private bool isValid(string s, IList<string> dictionary)
        {
            int lowLimit = 1;
            int highLimit = 1000;
            if (s.Length < lowLimit || s.Length > highLimit || dictionary.Count < lowLimit || dictionary.Count > highLimit)
            {
                return false;
            }
            foreach (string word in dictionary)
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
            return true;
        }
        private string findLongestWord(string s, IList<string> dictionary)
        {
            string result = String.Empty;
            foreach (string word in dictionary)
            {
                int left = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == word[left])
                    {
                        left++;
                        if (left == word.Length)
                        {
                            if (result.Length < word.Length)
                            {
                                result = word;
                            }
                            else if (result.Length == word.Length)
                            {
                                result = lessStringInLexicographicalOrder(result, word);
                            }
                            break;
                        }
                    }
                }
            }
            return result;
        }
        private string lessStringInLexicographicalOrder(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[i])
                {
                    continue;
                }
                else if (s1[i] < s2[i])
                {
                    return s1;
                }
                else
                {
                    return s2;
                }
            }
            return s1;
        }
    }
}
