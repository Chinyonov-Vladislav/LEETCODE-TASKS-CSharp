using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2729
{
    /*
     2729. Проверьте, является ли число завораживающим
    Вам дается целое число, n которое состоит ровно из 3 цифр.
    Мы называем число n захватывающим, если после следующей модификации полученное число содержит все цифры от 1 до 9 ровно один раз и не содержит 0:
        Объедините n с числами 2 * n и 3 * n.
    Верните, true если n будет интересно, или false иначе.
    Объединение двух чисел означает их соединение. Например, объединение 121 и 371 даёт 121371.
    Ограничения:
        100 <= n <= 999
    https://leetcode.com/problems/check-if-the-number-is-fascinating/description/
     */
    public class Task2729 : InfoBasicTask
    {
        public Task2729(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 192;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                Console.WriteLine(isFascinating(number) ? $"Число {number} является завораживающим" : $"Число {number} не является завораживающим");
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
            if (n < 100 || n > 999)
            {
                return false;
            }
            return true;
        }
        private bool isFascinating(int n)
        {
            int secondNumber = n * 2;
            int thirdNumber = n * 3;
            Dictionary<int, int> dict = new Dictionary<int, int>() {
                {1,0},
                {2,0 },
                {3,0 },
                {4,0 },
                {5,0 },
                {6,0 },
                {7,0 },
                {8,0 },
                {9,0 },
            };
            List<int> numbers = new List<int>() { n, secondNumber, thirdNumber };
            foreach (var num in numbers)
            {
                int currentNumber = num;
                while (currentNumber != 0)
                {
                    int digit = currentNumber % 10;
                    if (digit == 0)
                    {
                        return false;
                    }
                    dict[digit]++;
                    currentNumber /= 10;
                }
            }
            foreach (var pair in dict)
            {
                if (pair.Value != 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
