using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task784
{
    /*
     784. Перестановка регистров букв
    Если у вас есть строка s, вы можете преобразовать каждую букву в нижний или верхний регистр, чтобы создать другую строку.
    Верните список всех возможных строк, которые мы могли бы создать. Верните результат в любом порядке.
    Ограничения:
        1 <= s.length <= 12
        s состоит из строчных английских букв, прописных английских букв и цифр.
    https://leetcode.com/problems/letter-case-permutation/description/
     */
    public class Task784 : InfoBasicTask
    {
        public Task784(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }


        public override void execute()
        {
            string initialString = "a1b2";
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            if (isValid(initialString))
            {
                IList<string> res = letterCasePermutation(initialString);
                printIListString(res, "Результирующий список строк: ");
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
        private bool isValid(string s)
        {
            int lowLimitLength = 1;
            int highLimitLength = 12;
            if (s.Length < lowLimitLength || s.Length > highLimitLength)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9'))
                {
                    return false;
                }
            }
            return true;
        }
        private IList<string> letterCasePermutation(string s)
        {
            IList<string> result = new List<string>();
            recursive(s, result, 0);
            return result;

        }
        private void recursive(string s, IList<string> result, int currentIndex)
        {
            result.Add(s);
            for (int i = currentIndex; i < s.Length; i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z')
                {
                    char[] chars = s.ToCharArray();
                    chars[i] = (char)(chars[i] - 32);
                    string newString = new string(chars);
                    recursive(newString, result, i + 1);
                }
                if (s[i] >= 'A' && s[i] <= 'Z')
                {
                    char[] chars = s.ToCharArray();
                    chars[i] = (char)(chars[i] + 32);
                    string newString = new string(chars);
                    recursive(newString, result, i + 1);
                }
            }
        }
    }
}
