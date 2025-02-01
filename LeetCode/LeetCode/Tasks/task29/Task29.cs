using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task29
{
    public class Task29 : InfoBasicTask
    {
        public Task29(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int dividend = -1010369383;
            int divisor = -2147483648;
            int result = divideSecondMethod(dividend, divisor);
            Console.WriteLine($"Частное равно = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }

        private int divideSecondMethod(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }
            if (divisor == 1)
            {
                return dividend;
            }
            if (divisor == -1)
            {
                return 0 - dividend;
            }
            bool isNegativeResult = (dividend >= 0 && divisor < 0) || (dividend < 0 && divisor >= 0);
            long absDividend = dividend < 0 ? 0 - dividend : dividend;
            absDividend = absDividend == int.MinValue ? 2147483648 : absDividend;
            long absDivisor = divisor < 0 ? 0 - divisor : divisor;
            absDivisor = absDivisor == int.MinValue ? 2147483648 : absDivisor;
            if (absDividend < absDivisor || absDivisor == 0)
            {
                return 0;
            }
            int positionBit = 30;
            long result = 0;
            while (positionBit >= 0)
            {
                if ((absDivisor << positionBit) <= absDividend)
                {
                    absDividend -= (absDivisor << positionBit);
                    result |= (1L << positionBit);
                }
                positionBit--;
            }
            return isNegativeResult ? (int)(0 - result) : (int)result;
        }

        private int divideFirstMethod(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1) {
                return int.MaxValue;
            }
            if (divisor == 1)
            {
                return dividend;
            }
            if (divisor == -1)
            {
                return 0 - dividend;
            }
            bool isNegativeResult = (dividend >= 0 && divisor < 0) || (dividend < 0 && divisor >= 0);
            dividend = dividend < 0 ?  0 - dividend : dividend;
            divisor = divisor < 0 ? 0 - divisor : divisor;
            if (dividend < divisor)
            {
                return 0;
            }
            if (divisor == 0)
            {
                return 0;
            }
            int result = recursiveSubtraction(dividend, divisor);
            return isNegativeResult ? 0 - result : result;
        }
        private int recursiveSubtraction(int dividend, int divisor)
        {
            dividend -= divisor;
            if (dividend < divisor)
            {
                return 1;
            }
            return 1 + recursiveSubtraction(dividend, divisor);
        }
    }
}
