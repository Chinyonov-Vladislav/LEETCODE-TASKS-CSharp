using System;
using LeetCode.Basic;

namespace LeetCode.Tasks.task231
{
    /*
     231. Степень двойки

    Учитывая целое число n, верните true если оно является степенью двойки. В противном случае верните false.
    Целое число n является степенью двойки, если существует целое число x такое, что n == 2^x.
     */
    public class Task231 : InfoBasicTask
    {
        public Task231(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 16;
            Console.WriteLine(isPowerOfTwo(number) ? $"Число {number} является степенью числа 2" : $"Число {number} не является степенью числа 2");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        // решение через цикл
        public bool isPowerOfTwo(int n)
        {
            if (n == 1 || n ==2)
            {
                return true;
            }
            int initialValue = 2;
            while (initialValue <= n)
            {
                if (initialValue == n)
                {
                    return true;
                }
                if (initialValue > int.MaxValue / 2)
                {
                    return false;
                }
                initialValue*=2;
            }
            return false;
        }

        private bool bestSolution(int n)
        {
            return n > 0 && (n & n - 1) == 0;
        }
    }
}
