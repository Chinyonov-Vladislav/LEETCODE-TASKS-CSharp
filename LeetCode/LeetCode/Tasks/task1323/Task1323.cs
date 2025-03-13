using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1323
{
    /*
     1323. Максимальное число 69
    Вам дается положительное целое число, num состоящее только из цифр 6 и 9.
    Верните максимальное число, которое вы можете получить, изменив не более одной цифры (6 становится 9, и 9 становится 6).
    Ограничения:
        1 <= num <= 10^4
        num состоит только из 6 и 9 цифр.
    https://leetcode.com/problems/maximum-69-number/description/
     */
    public class Task1323 : InfoBasicTask
    {
        public Task1323(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int num = 9669;
            Console.WriteLine($"Исходное число = {num}");
            if (isValid(num))
            {
                int res = maximum69Number(num);
                Console.WriteLine(num == res ? "Для получения максимального числа не стоит делать замену 6 на 9 или 9 на 6" :$"Максимальное число, полученное путём замены одной цифры из числа {num} на 6 (в случае цифры 9) или на 9 (в случае цифры 6) = {res}");
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
        private bool isValid(int num)
        {
            int highLimit = (int)Math.Pow(10, 4);
            if (num < 1 || num > highLimit)
            {
                return false;
            }
            while (num != 0)
            {
                int digit = num % 10;
                if (digit != 6 && digit != 9)
                {
                    return false;
                }
                num /= 10;
            }
            return true;
        }
        private int maximum69Number(int num)
        {
            List<int> digits = new List<int>();
            while (num != 0)
            {
                digits.Insert(0,num % 10);
                num /= 10;
            }
            bool hasChange = false;
            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] == 6)
                {
                    digits[i] = 9;
                    hasChange = true;
                    break;
                }
            }
            if (!hasChange)
            {
                return num;
            }
            int result = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                result += digits[i] * (int)Math.Pow(10, digits.Count - i - 1);
            }
            return result;
        }
    }
}
