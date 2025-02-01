using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task258
{
    public class Task258 : InfoBasicTask
    {
        /*
         258. Добавьте Цифры
        Дано целое число num. Последовательно складывайте все его цифры, пока в результате не останется только одна цифра, и верните результат.
        https://leetcode.com/problems/add-digits/description/
         */
        public Task258(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 38;
            Console.WriteLine($"Результат: {addDigits(number)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int addDigits(int num)
        {
            int sumOfDigits = 0;
            while (true) {
                sumOfDigits += num % 10;
                num /= 10;
                if (num == 0 && sumOfDigits >= 0 && sumOfDigits <= 9)
                {
                    return sumOfDigits;
                }
                else if (num == 0 && sumOfDigits >= 10)
                {
                    num = sumOfDigits;
                    sumOfDigits = 0;
                }
            }
        }
    }
}
