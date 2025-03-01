using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2578
{
    /*
     2578. Разделить с минимальной суммой
    Дано положительное целое число num, разделите его на два неотрицательных целых числа num1 и num2 так, чтобы:
        Объединение num1 и num2 является перестановкой num.
            Другими словами, сумма количества вхождений каждой цифры в num1 и num2 равна количеству вхождений этой цифры в num.
        num1 и num2 может содержать начальные нули.
    Верните минимально возможную сумму num1 и num2.
    Примечания:
        Гарантируется, что num не содержит никаких начальных нулей.
        Порядок следования цифр в num1 и num2 может отличаться от порядка следования num.
    Ограничения:
        10 <= num <= 10^9
    https://leetcode.com/problems/split-with-minimum-sum/description/
     */
    public class Task2578 : InfoBasicTask
    {
        public Task2578(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 4325;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int res = splitNum(number);
                Console.WriteLine($"Результат = {res}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int num)
        {
            int lowLimit = 10;
            int highLimit = (int)Math.Pow(10,9);
            if (num < lowLimit || num > highLimit)
            {
                return false;
            }
            return true;
        }
        private int splitNum(int num)
        {
            List<int> digitsOfNum = new List<int>();
            while (num != 0) { 
                digitsOfNum.Add(num%10);
                num /= 10;
            }
            digitsOfNum.Sort();
            List<int> firstNumber = new List<int>();
            List<int> secondNumber = new List<int>();
            for (int i = 0; i < digitsOfNum.Count; i++)
            {
                if (i % 2 == 0)
                {
                    firstNumber.Add(digitsOfNum[i]);
                }
                else
                {
                    secondNumber.Add(digitsOfNum[i]);
                }
            }
            int firstValue = 0;
            int secondValue = 0;
            for (int i = 0; i < firstNumber.Count; i++)
            {
                firstValue += firstNumber[i] * (int)Math.Pow(10, firstNumber.Count - i - 1);
            }
            for (int i = 0; i < secondNumber.Count; i++)
            {
                secondValue += secondNumber[i] * (int)Math.Pow(10, secondNumber.Count - i - 1);
            }
            return firstValue + secondValue;
        }
    }
}
