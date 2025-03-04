using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2839
{
    /*
     2839. Проверьте, можно ли сделать строки равными с помощью операций I
    Вам даны две строки s1 и s2 длиной 4, состоящие из строчных английских букв.
    Вы можете применить следующую операцию к любой из двух строк любое количество раз:
        Выберите любые два индекса i и j такие, что j - i = 2, затем поменяйте местами два символа в этих индексах в строке.
    Верните trueесли вы можете сделать так, чтобы строки s1и s2 были равны, и false иначе.
    Ограничения:
        s1.length == s2.length == 4
        s1 и s2 состоят только из строчных английских букв.
    https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-i/description/
     */
    public class Task2839 : InfoBasicTask
    {
        public Task2839(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s1 = "abcd";
            string s2 = "cdab";
            Console.WriteLine($"Первая строка: \"{s1}\"\nВторая строка: \"{s2}\"");
            if (isValid(s1, s2))
            {
                Console.WriteLine(canBeEqual(s1, s2) ? "Строки могут быть одинаковы путём перестановок" : "Строки не могут быть одинаковы путём перестановок");
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
        private bool isValid(string s1, string s2)
        {
            if (s1.Length != 4 || s2.Length != 4)
            {
                return false;
            }
            foreach (char c in s1)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            foreach (char c in s2)
            {
                if (c < 'a' || c > 'z')
                {
                    return false;
                }
            }
            return true;
        }
        private bool canBeEqual(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            var charArrayS1 = s1.ToCharArray();
            for (int i = 0; i < charArrayS1.Length-2; i++)
            {
                if (charArrayS1[i] != s2[i])
                {
                    (charArrayS1[i + 2], charArrayS1[i]) = (charArrayS1[i], charArrayS1[i + 2]);
                }
            }
            return new string(charArrayS1) == s2;

        }
    }
}
