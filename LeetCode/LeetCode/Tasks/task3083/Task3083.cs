using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3083
{
    /*
     3083. Существование подстроки в строке и её обратное расположение
    Дана строка s, найдите любую подстроку длиной 2, которая также присутствует в обратном порядке в s.
    Возврат true если такая подстрока существует, и false в противном случае.
    Ограничения:
        1 <= s.length <= 100
        s состоит только из строчных английских букв.
    https://leetcode.com/problems/existence-of-a-substring-in-a-string-and-its-reverse/description/
     */
    public class Task3083 : InfoBasicTask
    {
        public Task3083(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "abcd";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                Console.WriteLine(isSubstringPresent(s) ? "Перевернутая исходная строка содержит подстроку длиной 2 из оригинальной строки" : "Перевернутая исходная строка не содержит подстроку длиной 2 из оригинальной строки");
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
            if (s.Length < 1 || s.Length > 100)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            return true;
        }
        private bool isSubstringPresent(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            for (int i = 0; i < s.Length - 1; i++)
            {
                string subStr = s.Substring(i, 2);
                if (reversed.Contains(subStr))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
