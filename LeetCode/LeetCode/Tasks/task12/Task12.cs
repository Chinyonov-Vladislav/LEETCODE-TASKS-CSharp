using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;
using LeetCode.Basic;

namespace LeetCode.Tasks.task12
{
    public class Task12 : InfoBasicTask
    {
        Dictionary<int, string> pairs;
        public Task12(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            pairs = new Dictionary<int, string>() {
                { 1, "I" },
                { 4, "IV"},
                { 5, "V"},
                { 9, "IX" },
                { 10, "X" },
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                { 100, "C" },
                { 400, "CD" },
                { 500, "D" },
                { 900, "CM" },
                { 1000, "M" },
            };
        }

        public override void execute()
        {
            int number = 0;
            while (true)
            {
                Console.Write("Введите число больше 0, но меньше 4000: ");
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                    if (number < 1 || number > 3999)
                    {
                        throw new FormatException();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы введи неверное значение для числа. Повторите попытку");
                }
            }
            Console.WriteLine($"Число = {number} | Римское число = {intToRoman(number)}");
        }

        public override void testing()
        {
            int number = 58;
            string expected = "LVIII";
            try {
                Assert.Equal(expected, intToRoman(number));
                Console.WriteLine("Тест пройден");
            }
            catch (EqualException ex)
            {
                Console.WriteLine("Тест не пройден");
                Console.WriteLine(ex.Message);
            }
        }
        private string intToRoman(int num)
        {
            string result = "";
            string initialNumStr = num.ToString();
            for (int i = 0; i < initialNumStr.Length; i++)
            {
                char currentDigit = (char)initialNumStr[i];
                int firstMultiplier = Int32.Parse(currentDigit.ToString());
                int secondMultiplier = (int)Math.Pow(10,initialNumStr.Length - i - 1);
                if (secondMultiplier == 1000)
                {
                    for (int j = 0; j < firstMultiplier; j++)
                    {
                        result += pairs[secondMultiplier];
                    }
                }
                else
                {
                    if (firstMultiplier >= 1 && firstMultiplier <= 3)
                    {
                        for (int j = 0; j < firstMultiplier; j++)
                        {
                            result += pairs[secondMultiplier];
                        }
                    }
                    else if (firstMultiplier == 4 || firstMultiplier == 5 || firstMultiplier == 9)
                    {
                        result += pairs[firstMultiplier * secondMultiplier];
                    }
                    else if(firstMultiplier >= 6 && firstMultiplier <= 8)
                    {
                        result += pairs[5 * secondMultiplier];
                        int remain = firstMultiplier - 5;
                        for (int j = 0; j < remain; j++)
                        {
                            result += pairs[secondMultiplier];
                        }
                    }
                }
            }
            return result;
        }
        private string intToRomanBestSolution(int num) // скопировано с leetCode
        {
            if (num >= 1000) return "M" + intToRomanBestSolution(num - 1000);
            if (num >= 900) return "CM" + intToRomanBestSolution(num - 900);
            if (num >= 500) return "D" + intToRomanBestSolution(num - 500);
            if (num >= 400) return "CD" + intToRomanBestSolution(num - 400);
            if (num >= 100) return "C" + intToRomanBestSolution(num - 100);
            if (num >= 90) return "XC" + intToRomanBestSolution(num - 90);
            if (num >= 50) return "L" + intToRomanBestSolution(num - 50);
            if (num >= 40) return "XL" + intToRomanBestSolution(num - 40);
            if (num >= 10) return "X" + intToRomanBestSolution(num - 10);
            if (num >= 9) return "IX" + intToRomanBestSolution(num - 9);
            if (num >= 5) return "V" + intToRomanBestSolution(num - 5);
            if (num >= 4) return "IV" + intToRomanBestSolution(num - 4);
            if (num >= 1) return "I" + intToRomanBestSolution(num - 1);
            return "";
        }
    }
}
