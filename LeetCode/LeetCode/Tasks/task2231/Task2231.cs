using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2231
{
    /*
     2231. Наибольшее число после перестановки цифр по чётности
    Вам дано положительное целое число num. Вы можете поменять местами любые две цифры num с одинаковой чётностью (то есть обе нечётные или обе чётные).
    Верните наибольшее возможное значение после num любого количества перестановок.
    https://leetcode.com/problems/largest-number-after-digit-swaps-by-parity/description/
     */
    public class Task2231 : InfoBasicTask
    {
        public Task2231(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 65875;
            Console.WriteLine($"Исходное число = {number}");
            int result = largestInteger(number);
            Console.WriteLine($"Самое большое число, которое можно получить путём перестановок цифр на четных и нечетных позициях = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int largestInteger(int num)
        {
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
            string str = num.ToString();
            int[] finalNumber = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                int digit = str[i] - '0';
                if (digit % 2 == 0)
                {
                    evenNumbers.Add(digit);
                }
                else
                {
                    oddNumbers.Add(digit);
                }
                finalNumber[i] = digit;
            }
            evenNumbers.Sort();
            evenNumbers.Reverse();
            oddNumbers.Sort();
            oddNumbers.Reverse();
            int indexEven = 0;
            int indexOdd = 0;
            for (int i = 0; i < finalNumber.Length; i++)
            {
                if (finalNumber[i] % 2 == 0)
                {
                    finalNumber[i] = evenNumbers[indexEven];
                    indexEven++;
                }
                else
                {
                    finalNumber[i] = oddNumbers[indexOdd];
                    indexOdd++;
                }
            }
            int result = 0;
            for (int i = 0; i < finalNumber.Length; i++)
            {
                result += finalNumber[i] * (int)Math.Pow(10, finalNumber.Length - i-1);
            }
            return result;
        }
    }
}
