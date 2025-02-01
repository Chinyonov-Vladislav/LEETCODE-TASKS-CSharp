using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task342
{
    /*
     342. Степень четырех
    Дано целое число n, верните true, если оно в степени четырех. В противном случае верните false.
    Целое число n является степенью четырех, если существует целое число, x такое, что n == 4x.
    https://leetcode.com/problems/power-of-four/description/
     */
    public class Task342 : InfoBasicTask
    {
        public Task342(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 16;
            Console.WriteLine(isPowerOfFour(number) ? $"Число {number} является степенью 4" : $"Число {number} не является степенью 4");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public bool isPowerOfFour(int n)
        {
            if (n <= 0)
            {
                return false;
            }
            while (n % 4 == 0)
            {
                n /= 4;
            }
            return n == 1;
        }
    }
}
