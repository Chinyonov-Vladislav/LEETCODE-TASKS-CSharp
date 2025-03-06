using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3019
{
    /*
     3019. Количество переключаемых клавиш
    Вам дана строка с индексом 0, s введённая пользователем. 
    Изменение ключа определяется как использование ключа, отличного от последнего использованного ключа. 
        Например, s = "ab" имеет изменение ключа, а s = "bBBb" — нет.
    Верните количество раз, которое пользователь должен был изменить ключ.
    Примечание: модификаторы, такие как shift или caps lock, не учитываются при смене клавиши. То есть, если пользователь ввёл букву 'a' и затем букву 'A', это не будет считаться сменой клавиши.
    Ограничения:
        1 <= s.length <= 100
        s состоит только из прописных и строчных английских букв.
    https://leetcode.com/problems/number-of-changing-keys/description/
     */
    public class Task3019 : InfoBasicTask
    {
        public Task3019(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "aAbBcC";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            if (isValid(s))
            {
                int count = countKeyChanges(s);
                Console.WriteLine($"Количество раз смены клавиши = {count}");
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
            foreach (char c in s) {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                {
                    return false;
                }
            }
            return true;
        }

        private int countKeyChanges(string s)
        {
            int count = 0;
            s = s.ToLower();
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
