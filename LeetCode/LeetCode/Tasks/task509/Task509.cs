using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task509
{
    /*
     509. Число Фибоначчи
    Числа Фибоначчи, обычно обозначаемые F(n) образуют последовательность, называемую последовательностью Фибоначчи, в которой каждое число является суммой двух предыдущих, начиная с 0 и 1. То есть,
    F(0) = 0, F(1) = 1
    F(n) = F(n - 1) + F(n - 2), для n > 1.
    Дано n, вычислите F(n).
     */
    public class Task509 : InfoBasicTask
    {
        public Task509(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 4;
            Console.WriteLine($"Для n = {n} ответ = {fib(n)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int fib(int n)
        {
            if (n == 0 || n==1)
            {
                return n;
            }
            return fib(n-1)+ fib(n-2);
        }
        private int bestSolution(int n)
        {
            if (n <= 1) return n;

            int a = 0, b = 1;

            while (n > 1)
            {
                int sum = a + b;
                a = b;
                b = sum;
                n--;
            }
            return b;
        }

    }
}
