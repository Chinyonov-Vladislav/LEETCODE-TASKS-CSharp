using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task367
{
    /*
     367. Действительный идеальный квадрат
    Для заданного положительного целого числа num верните true если num оно является полным квадратом или false в противном случае.
    Полный квадрат — это целое число, которое является квадратом целого числа. Другими словами, это произведение некоторого целого числа на само себя.
    Вы не должны использовать какие-либо встроенные библиотечные функции, такие как sqrt.
    https://leetcode.com/problems/valid-perfect-square/description/
     */
    public class Task367 : InfoBasicTask
    {
        public Task367(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 16;
            Console.WriteLine(isPerfectSquare(16) ? $"Число {number} является идеальным квадратом" : $"Число {number} не является идеальным квадратом");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isPerfectSquare(int num)
        {
            if (num < 0)
            {
                return false;
            }
            int border = 46340;
            for (int i = 0; i <= border; i++)
            {
                if (i * i == num)
                {
                    return true;
                }
                else if (i * i > num)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
