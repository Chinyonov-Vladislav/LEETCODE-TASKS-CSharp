using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1837
{
    /*
     1837. Сумма цифр в базе K
    Учитывая целое число n (в базе 10) и основание k, верните сумму цифр n после преобразования n из базы 10 в базу k.
    После преобразования каждая цифра должна интерпретироваться как число в системе счисления 10, а сумма должна быть возвращена в системе счисления 10.
    https://leetcode.com/problems/sum-of-digits-in-base-k/description/
     */
    public class Task1837 : InfoBasicTask
    {
        public Task1837(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 34;
            int k = 6;
            Console.WriteLine($"Число = {n}");
            Console.WriteLine($"Основание системы = {k}");
            if (isValid(n, k))
            {
                int result = sumBase(n, k);
                Console.WriteLine($"Сумма цифр числа {n} по базе {k} = {result}");
            }
            else
            {
                Console.WriteLine("Число или основание системы не валидны для задачи!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int n, int k)
        {
            if (n < 1 || n > 100 || k < 2 || k > 10)
            {
                return false;
            }
            return true;
        }
        private int sumBase(int n, int k)
        {
            if (k == 10)
            {
                int result = 0;
                while (n != 0)
                {
                    int digit = n % 10;
                    result += digit;
                    n /= 10;
                }
                return result;
            }
            if (n < k)
            {
                return n;
            }
            int sum = 0;
            while (n >= k)
            { 
                sum += n % k;
                n /= k;
                if (n < k)
                {
                    sum += n;
                }
            }
            return sum;
        }
    }
}
