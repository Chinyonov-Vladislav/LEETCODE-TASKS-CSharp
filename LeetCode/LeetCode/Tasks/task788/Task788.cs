using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task788
{
    /*
     788. Повернутые цифры
    Целое число x является хорошим, если после поворота каждой цифры на 180 градусов мы получаем корректное число, отличное от x. Каждую цифру нужно повернуть — мы не можем оставить её без изменений.
    Число является правильным, если каждая цифра остаётся цифрой после поворота. Например:
        0, 1, и 8 вращаться вокруг себя,
        2 и 5 поворачиваются друг к другу (в данном случае они поворачиваются в противоположных направлениях, другими словами, 2 или 5 зеркально отражаются),
        6 и 9 вращаются друг к другу, и
        остальные числа не переходят в другие числа и остаются прежними.
    Учитывая целое число n, верните количество хороших целых чисел в диапазоне[1, n].
    Ограничения:
        1 <= n <= 10^4
    https://leetcode.com/problems/rotated-digits/description/
     */
    public class Task788 : InfoBasicTask
    {
        public Task788(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 10;
            Console.WriteLine($"Диапазон для поиска: [1,{n}]");
            if (isValid(n))
            {
                int res = rotatedDigits(n);
                Console.WriteLine($"Количество хороших корректных чисел в диапазоне от 1 до {n} (включительно) = {res}");
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
        private int rotatedDigits(int n)
        {
            int count = 0;
            int[] dict = new int[] { 0, 1, 5, 3, 4, 2, 9, 7, 8, 6 };
            for (int num = 1; num <= n; num++)
            {
                int copyNum = num;
                List<int> digits = new List<int>();
                while (copyNum != 0)
                { 
                    digits.Add(copyNum%10);
                    copyNum /= 10;
                }
                digits.Reverse();
                int newNum = 0;
                for (int i = 0; i < digits.Count; i++)
                {
                    if (digits[i] == 3 || digits[i] == 4 || digits[i] == 7)
                    {
                        newNum = -1;
                        break;
                    }
                    digits[i] = dict[digits[i]];
                    newNum += digits[i] * (int)Math.Pow(10, digits.Count - i - 1);
                }
                if (newNum != num && newNum != -1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
