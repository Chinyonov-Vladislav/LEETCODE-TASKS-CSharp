using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task279
{
    /*
     279. Идеальные квадраты
    Для заданного целого числа n верните наименьшее количество полных квадратов, сумма которых равна n.
    Полный квадрат — это целое число, которое является квадратом целого числа; другими словами, это произведение некоторого целого числа на само себя. Например, 1, 4, 9 и 16 являются полными квадратами, а 3 и 11 — нет.
    Ограничения:
        1 <= n <= 10^4
     https://leetcode.com/problems/perfect-squares/description/
     */
    public class Task279 : InfoBasicTask
    {
        public Task279(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 12;
            Console.WriteLine($"Значение переменной n = {n}");
            if (isValid(n))
            {
                int res = numSquares(n);
                Console.WriteLine($"Количество полных квадратов, сумма которых даёт n = {res}");
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
        private bool isValid(int n)
        {
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10,4);
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int numSquares(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j*j<=i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            return dp[n];
        }
    }
}
