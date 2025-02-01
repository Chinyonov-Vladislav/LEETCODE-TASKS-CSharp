using System;
using System.Collections.Generic;
using LeetCode.Basic;
namespace LeetCode.Tasks.task202
{
    /*
    202. Счастливое Число

    Напишите алгоритм, чтобы определить, является ли число n счастливым.
    Счастливое число - это число, определенное следующим процессом:
        Начиная с любого положительного целого числа, замените его суммой квадратов его цифр.
        Повторяйте процесс до тех пор, пока число не станет равным 1 (и не останется на этом уровне) или не начнёт бесконечно повторяться в цикле, который не включает 1.
        Те числа, для которых этот процесс заканчивается на 1, являются счастливыми.
    Верните, true если n это счастливое число, и false если нет.
    */
    public class Task202 : InfoBasicTask
    {
        public Task202(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 19;
            Console.WriteLine(isHappy(number) ? $"Число {number} является счастливым" : $"Число {number} не является счастливым");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isHappy(int n)
        {
            int number = 19;
            List<int> numbersFromDigits = new List<int>();
            return sumOfPower2(number, numbersFromDigits);
        }
        private bool sumOfPower2(int number, List<int> numbers)
        {
            if (number == 1)
            {
                return true;
            }
            if (numbers.Contains(number))
            {
                return false;
            }
            numbers.Add(number);
            int sumOfPower2OfDigits = 0;
            while (number != 0)
            {
                int digit = number % 10;
                sumOfPower2OfDigits += digit * digit;
                number /= 10;
            }
            return sumOfPower2(sumOfPower2OfDigits, numbers);
        }
    }
}
