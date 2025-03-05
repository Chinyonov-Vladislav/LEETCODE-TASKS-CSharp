using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2937
{
    /*
     2937. Сделайте три строки равными
    Вам даны три строки: s1, s2 и s3. 
    За одну операцию вы можете выбрать одну из этих строк и удалить её крайний правый символ. 
    Обратите внимание, что вы не можете полностью очистить строку.
    Верните минимальное количество операций, необходимых для того, чтобы строки стали равны. Если сделать их равными невозможно, верните -1.
    Ограничения:
        1 <= s1.length, s2.length, s3.length <= 100
        s1, s2 и s3 состоит только из строчных английских букв.
    https://leetcode.com/problems/make-three-strings-equal/description/
     */
    public class Task2937 : InfoBasicTask
    {
        public Task2937(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s1 = "abc";
            string s2 = "abb";
            string s3 = "ab";
            Console.WriteLine($"Строка №1: \"{s1}\"\nСтрока №2: \"{s2}\"\nСтрока №3: \"{s3}\"");
            if (isValid(s1, s2, s3))
            {
                int res = findMinimumOperations(s1, s2, s3);
                Console.WriteLine(res == -1 ? "Невозможно сделать строки одинаковыми" : $"Строки возможно сделать одинаковыми за {res} операций удаления правого символа");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string s1, string s2, string s3)
        {
            List<string> strings = new List<string>() { s1,s2,s3};
            foreach (string s in strings)
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
            }
            return true;
        }
        private int findMinimumOperations(string s1, string s2, string s3)
        {
            int lengthMaxPrefix = 0;
            int minLength = Math.Min(s1.Length, Math.Min(s2.Length, s3.Length));
            for (int i = 0; i < minLength; i++)
            {
                if (s1[i] == s2[i] && s2[i] == s3[i])
                {
                    lengthMaxPrefix++;
                }
                else
                {
                    break;
                }
            }
            if (lengthMaxPrefix == 0)
            {
                return -1;
            }
            return s1.Length - lengthMaxPrefix + s2.Length - lengthMaxPrefix + s3.Length - lengthMaxPrefix;
        }
    }
}
