using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task43
{
    /*
     43. Умножение строк
    Даны два неотрицательных целых числа num1 и num2, представленные в виде строк. Верните произведение num1 и num2, также представленное в виде строки.
    Примечание: вы не должны использовать встроенную библиотеку BigInteger или напрямую преобразовывать входные данные в целые числа.
    https://leetcode.com/problems/multiply-strings/description/
     */
    public class Task43 : InfoBasicTask
    {
        public Task43(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string firstNumber = "123";
            string secondNumber = "456";
            Console.WriteLine($"Первое значение = \"{firstNumber}\"");
            Console.WriteLine($"Второе значение = \"{secondNumber}\"");
            string resultProduct = multiply(firstNumber, secondNumber);
            Console.WriteLine($"Результат умножения = \"{resultProduct}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string multiply(string num1, string num2)
        {
            List<string> numbersStrs = new List<string>();
            string lessLengthStr = num1.Length > num2.Length ? num2 :num1;
            string moreLengthStr = num2.Length >= num1.Length ? num2 : num1;
            if (lessLengthStr == "0" || moreLengthStr == "0")
            {
                return "0";
            }
            int countZerosToEnd = 0;
            int indexForLessLengthStr = lessLengthStr.Length - 1;
            while (indexForLessLengthStr >= 0)
            {
                int indexForMoreLengthStr = moreLengthStr.Length - 1;
                StringBuilder sb = new StringBuilder();
                int firstMultiplier = lessLengthStr[indexForLessLengthStr]-'0';
                int remember = 0;
                while (indexForMoreLengthStr >= 0)
                {
                    int secondMultiplier = moreLengthStr[indexForMoreLengthStr] - '0';
                    int product = firstMultiplier * secondMultiplier + remember;
                    if (product >= 10)
                    {
                        int digit = product % 10;
                        sb.Insert(0, digit);
                        remember = product / 10;
                    }
                    else
                    {
                        sb.Insert(0, product);
                        remember = 0;
                    }
                    indexForMoreLengthStr--;
                }
                if (remember > 0)
                {
                    sb.Insert(0, remember);
                }
                sb.Append('0', countZerosToEnd);
                numbersStrs.Add(sb.ToString());
                sb.Clear();
                countZerosToEnd++;
                indexForLessLengthStr--;

            }
            int maxLength = numbersStrs.Max(s => s.Length);
            StringBuilder zeroBuilder = new StringBuilder();
            string result = zeroBuilder.Append('0', maxLength).ToString();
            foreach (var number in numbersStrs)
            {
                Console.WriteLine(number);
            }
            foreach (var number in numbersStrs)
            {
                result = addTwoStrings(result, number);
            }
            return result;
        }
        private string addTwoStrings(string a, string b)
        {
            StringBuilder result = new StringBuilder();
            int carry = 0;
            if (a.Length > b.Length)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('0', a.Length - b.Length);
                sb.Append(b);
                b = sb.ToString();
            }
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int firstSummand = a[i] - '0';
                int secondSummand = b[i] - '0';
                int sum = firstSummand + secondSummand+carry;
                if (sum >= 10)
                {
                    int digit = sum % 10;
                    result.Insert(0, digit);
                    carry = sum/10;
                }
                else
                {
                    result.Insert(0, sum);
                    carry = 0;
                }
            }
            if (carry > 0)
            {
                result.Insert(0, carry);
            }
            return result.ToString();
        }
    }
}
