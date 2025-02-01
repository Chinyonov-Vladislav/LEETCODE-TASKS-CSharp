using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task917
{
    /*
     917. Переворачивать только буквы
    Получив строку s, переверните строку в соответствии со следующими правилами:
        Все символы, которые не являются английскими буквами, остаются в том же положении.
        Все английские буквы (строчные или заглавные) должны быть перевернуты.
        Вернитесь s после того, как перевернете его.
    https://leetcode.com/problems/reverse-only-letters/description/
     */
    public class Task917 : InfoBasicTask
    {
        public Task917(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "ab-cd";
            string reversedStr = reverseOnlyLetters(s);
            Console.WriteLine($"Оригинальная строка = {s}");
            Console.WriteLine($"Строка, в которой перевернуты только английский буквы = {reversedStr}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reverseOnlyLetters(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            char[] chars = s.ToCharArray();
            while (left < right)
            {
                if (char.IsLetter(s[left]) && char.IsLetter(s[right]))
                {
                    (chars[left], chars[right]) = (chars[right], chars[left]);
                    left++;
                    right--;
                    continue;
                }
                if (!char.IsLetter(s[left]))
                {
                    left++;
                }
                if (!char.IsLetter(s[right]))
                {
                    right--;
                }
            }
            return new string(chars);
        }
    }
}
