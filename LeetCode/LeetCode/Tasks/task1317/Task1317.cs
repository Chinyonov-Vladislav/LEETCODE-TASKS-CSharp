using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1317
{
    /*
     1317. Преобразуйте целое число в сумму двух целых чисел, не равных нулю
    Целое число без нуля — это положительное целое число, которое не содержит нулей0 в своём десятичном представлении.
    Учитывая целое число, nверните список из двух целых чисел, [a, b] где:
        a и b являются целыми числами без нуля.
        a + b = n
    Тестовые примеры генерируются таким образом, чтобы существовало хотя бы одно допустимое решение. Если допустимых решений несколько, вы можете вернуть любое из них.
     https://leetcode.com/problems/convert-integer-to-the-sum-of-two-no-zero-integers/description/
     */
    public class Task1317 : InfoBasicTask
    {
        public Task1317(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 11;
            Console.WriteLine($"Целое число = {number}");
            int[] result = getNoZeroIntegers(number);
            printArray(result, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] getNoZeroIntegers(int n)
        {
            for (int i = 1; i < n; i++)
            {
                int copyOfI = i;
                bool hasZeroInI = false;
                while (copyOfI != 0)
                {
                    int digit = copyOfI % 10;
                    if (digit == 0)
                    {
                        hasZeroInI = true;
                        break;
                    }
                    copyOfI /= 10;
                }
                if (hasZeroInI)
                {
                    continue;
                }
                int remain = n - i;
                bool hasZero = false;
                while (remain != 0) {
                    int digit = remain % 10;
                    if (digit == 0)
                    {
                        hasZero = true;
                        break;
                    }
                    remain /= 10;
                }
                if (!hasZero)
                {
                    return new int[] { i, n-i };
                }
            }
            return new int[] { };
        }
    }
}
