using LeetCode.Basic;
using System;
using System.Text;

namespace LeetCode.Tasks.task405
{
    /*
     415. Добавление строк
    Учитывая два неотрицательных целых числа num1 и num2 в виде строк, верните сумму num1 и num2 в виде строки.
    Вы должны решить задачу, не используя встроенную библиотеку для работы с большими целыми числами (например, BigInteger). Вы также не должны напрямую преобразовывать входные данные в целые числа.
    https://leetcode.com/problems/add-strings/
     */
    public class Task415 : InfoBasicTask
    {
        public Task415(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string number1 = "11";
            string number2 = "123";
            Console.WriteLine($"Результат: {number1} + {number2} = {addStrings(number1, number2)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string addStrings(string num1, string num2)
        {
            StringBuilder result = new StringBuilder();
            bool hasOverflow = false;
            string leadingString = "";
            string laggingString = "";
            if (num2.Length > num1.Length)
            {
                leadingString = num2;
                laggingString = num1;
            }
            else
            {
                leadingString = num1;
                laggingString = num2;
            }
            for (int i = 0; i < leadingString.Length; i++)
            {
                int firstDigit = Int32.Parse(leadingString[leadingString.Length - 1 - i].ToString());
                int secondDigit = 0<=laggingString.Length - 1 - i && laggingString.Length - 1 - i < laggingString.Length ? Int32.Parse(laggingString[laggingString.Length - 1 - i].ToString()) : 0;
                Console.WriteLine($"FirstDigit = {firstDigit} | SecondDigit = {secondDigit}");
                int resultValue = firstDigit + secondDigit;
                resultValue = hasOverflow ? resultValue + 1 : resultValue;
                hasOverflow = resultValue >= 10;
                int digitForStr = resultValue % 10;
                result.Insert(0, digitForStr.ToString(), 1);
            }
            if (hasOverflow)
            {
                result.Insert(0, "1", 1);
            }
            return result.ToString();
        }
        private string bestSolution(string num1, string num2)
        {
            if (num2.Length > num1.Length)
            {
                var t = num1;
                num1 = num2;
                num2 = t;
            }

            int p1 = num1.Length - 1;
            int p2 = num2.Length - 1;

            var carry = 0;
            char[] res = new char[num1.Length];
            while (p1 >= 0)
            {
                var d1 = num1[p1] - '0';
                var d2 = (p2 > -1) ? num2[p2] - '0' : 0;

                var sum = d1 + d2 + carry;
                carry = sum / 10;
                res[p1] = (char)('0' + (sum % 10));

                p1--;
                p2--;
            }

            var str = new string(res);

            return (carry == 0) ? str : $"1{str}";
        }
    }
}
