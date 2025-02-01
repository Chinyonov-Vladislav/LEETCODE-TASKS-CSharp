using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task762
{
    /*
     762. Простое число заданных битов в двоичном представлении
    Учитывая два целых числа left и right, верните чисел в включительном диапазоне [left, right], в их двоичном представлении.
    Напомним, что количество установленных битов в числе — это количество 1 в двоичной записи.
    Например, 21 записанный в двоичном формате является 10101, который имеет 3 установленные биты.
    https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/description/
     */
    public class Task762 : InfoBasicTask
    {
        public Task762(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int leftNumber = 6;
            int rightNumber = 10;
            int countNumberWithBitsOnePrime = countPrimeSetBits(leftNumber, rightNumber);
            Console.WriteLine($"Количество чисел в диапазоне с {leftNumber} по {rightNumber} с простым количеством установленных битов = {countNumberWithBitsOnePrime}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countPrimeSetBits(int left, int right)
        {
            int countPrime = 0;
            for (; left <= right; left++)
            {
                int copyOfLeft = left;
                int countBitsPositive = 0;
                while (copyOfLeft != 0)
                {
                    int currentBit = copyOfLeft & 1;
                    if (currentBit == 1)
                    {
                        countBitsPositive++;
                    }
                    copyOfLeft >>= 1;
                }
                if (defineNumberIsPrime(countBitsPositive))
                {
                    countPrime++;
                }
            }
            return countPrime;
        }
        private bool defineNumberIsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
