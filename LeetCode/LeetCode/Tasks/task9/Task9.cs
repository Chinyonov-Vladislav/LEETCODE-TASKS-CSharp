using System;
using System.Collections.Generic;
using Xunit.Sdk;
using Xunit;
using LeetCode.Basic;

namespace LeetCode.Tasks.Task9
{
    public class Task9 : InfoBasicTask
    {
        private const int codeOfFirstMethod = 1;
        private const int codeOfSecondMethod = 2;
        private const int codeOfThirdMethod = 3;
        public Task9(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number;
            while (true)
            {
                Console.Write("Введите целое число для проверки на палиндром: ");
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch(FormatException) {
                    Console.WriteLine("Введено неверное значение. Повторите попытку!");
                }
            }
            int numberUsedMethod = askUserNumberMethodToUse();
            bool resultOfCheckPalindrome;
            switch (numberUsedMethod)
            {
                case codeOfFirstMethod:
                    resultOfCheckPalindrome = IsPalindromeFirstMethod(number);
                    break;
                case codeOfSecondMethod:
                    resultOfCheckPalindrome = IsPalindromeSecondMethod(number);
                    break;
                case codeOfThirdMethod:
                    resultOfCheckPalindrome = isPalindromeThirdMethod(number);
                    break;
                default:
                    resultOfCheckPalindrome = false;
                    break;
            }
            string value = resultOfCheckPalindrome ? $"Число {number} является палиндромом!" : $"Число {number} не является палиндромом!";
            Console.WriteLine(value);
        }

        public override void testing()
        {
            testCase1();
        }

        private void testCase1()
        {
            int number = 121;
            try
            {
                Assert.True(IsPalindromeFirstMethod(121), $"Число {number} не является палиндромом");
            }
            catch (TrueException ex)
            {
                Console.WriteLine("Тест не пройден");
                Console.WriteLine(ex.Message);
            }
        }

        private bool IsPalindromeFirstMethod(int x)
        {
            return x.ToString() == reverse(x.ToString());
        }
        private bool IsPalindromeSecondMethod(int x)
        {
            if (x < 0)
            {
                return false;
            }
            List<int> digits = new List<int>();
            while (x != 0)
            {
                digits.Add(x % 10);
                x /= 10;
            }
            int firstIndex = 0;
            int secondIndex = digits.Count - 1;
            while (firstIndex < digits.Count && secondIndex >= 0)
            {
                if (digits[firstIndex] != digits[secondIndex])
                {
                    return false;
                }
                firstIndex++;
                secondIndex--;
            }
            return true;
        }
        private bool isPalindromeThirdMethod(int x) // взято из решений
        {
            if (x < 0)
            {
                return false;
            }
            int og = x;
            int rev = 0;
            while (x != 0)
            {
                rev = rev * 10 + (x % 10);
                x = x / 10;
            }
            return rev == og;
        }
        private string reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private int askUserNumberMethodToUse()
        {
            while (true)
            {
                Console.WriteLine("Выберите метод для решения задачи: 1 - на основании инверсии строки, 2 - разбиение на разряды, 3 - инверсия числа на основании арифметических действий");
                Console.Write("Ваш выбор: ");
                try
                { 
                    int numberChoice = Int32.Parse(Console.ReadLine());
                    if (numberChoice < 1 && numberChoice > 3)
                    {
                        throw new FormatException();
                    }
                    return numberChoice;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено неверное значение. Повторите попытку");
                }
            }
        }
    }
}
