using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2544
{
    /*
     2544. Сумма чередующихся цифр
    Вам дано положительное целое число n. Каждая цифра n имеет знак в соответствии со следующими правилами:
        Самой значащей цифре присваивается положительный знак.
        Каждая вторая цифра имеет знак, противоположный знаку соседних цифр.
    Возвращает сумму всех цифр с соответствующим знаком.
    Ограничения:
        1 <= n <= 10^9
    https://leetcode.com/problems/alternating-digit-sum/description/
     */
    public class Task2544 : InfoBasicTask
    {
        public Task2544(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 521;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int sum = alternateDigitSum(number);
                Console.WriteLine($"Ответ = {sum}");
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
        private bool isValid(int n)
        {
            int upperLimit = (int)Math.Pow(10, 9);
            if (n < 1 || n > upperLimit)
            {
                return false;
            }
            return true;
        }
        private int alternateDigitSum(int n)
        {
            int sum = 0;
            string val = n.ToString();
            for (int i = 0; i < val.Length; i++)
            {
                int value = val[i]-'0';
                if (i % 2 != 0)
                {
                    value *= -1;
                }
                sum+= value;
            }
            return sum;
        }
    }
}
