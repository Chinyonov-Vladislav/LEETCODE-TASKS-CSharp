using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task357
{
    /*
     357. Считайте числа с уникальными цифрами
    Учитывая целое число n, верните количество всех чисел с уникальными цифрами, x, где 0 <= x < 10^n.
    Ограничения:
        0 <= n <= 8
    https://leetcode.com/problems/count-numbers-with-unique-digits/description/
     */
    public class Task357 : InfoBasicTask
    {
        public Task357(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int numberPow = 2;
            Console.WriteLine($"Поиск количества чисел с уникальными цифрами в диапазоне от 0 до 10^{numberPow} (не включительно)");
            if (isValid(numberPow))
            {
                int res = countNumbersWithUniqueDigits(numberPow);
                Console.WriteLine($"Количество чисел с уникальными цифрами в диапазоне от 0 до 10^{numberPow} (не включительно) = {res}");
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
            int lowLimit = 0;
            int highLimit = 8;
            if (n <lowLimit || n>highLimit)
            {
                return false;
            }
            return true;
        }
        private int countNumbersWithUniqueDigits(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                int val = 9;
                int currentPow = i-1;
                int currentMultiple = 9;
                while (currentPow != 0)
                {
                    val *= currentMultiple;
                    currentPow--;
                    currentMultiple--;
                }
                dp[i] = val + dp[i - 1];
            }
            return dp[dp.Length - 1];
        }
    }
}
