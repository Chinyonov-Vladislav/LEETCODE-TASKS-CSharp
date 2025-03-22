using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task264
{
    /*
     264. Уродливое Число II
    Некрасивое число — это положительное целое число, простые множители которого ограничены значениями 2, 3, и 5.
    Учитывая целое число n, верните nth уродливое число.
    Ограничения:
        1 <= n <= 1690
    https://leetcode.com/problems/ugly-number-ii/description/
     */
    public class Task264 : InfoBasicTask
    {
        public Task264(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 10;
            if (isValid(n))
            {
                int res = NthUglyNumber(n);
                Console.WriteLine($"{n} уродливое число (множители которого 2 или 3 или 5) = {res}");
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
            int highLimit = 1690;
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int NthUglyNumber(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int[] dp = new int[n];
            dp[0] = 1;
            int pointer = 1;
            int pointerTwo = 0;
            int pointerThree = 0;
            int pointerFive = 0;
            while (pointer != n)
            {
                int valueTwo = dp[pointerTwo]*2;
                int valueThree = dp[pointerThree] * 3;
                int valueFive = dp[pointerFive] * 5;
                int min = Math.Min(valueTwo, Math.Min(valueThree, valueFive));
                dp[pointer] = min;
                if (valueTwo == min)
                {
                    pointerTwo++;
                }
                if (valueThree == min)
                {
                    pointerThree++;
                }
                if (valueFive == min)
                {
                    pointerFive++;
                }
                pointer++;
            }
            return dp[dp.Length-1];
        }
    }
}
