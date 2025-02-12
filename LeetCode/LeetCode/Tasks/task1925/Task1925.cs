using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1925
{
    /*
     1925. Подсчитайте количество троек из диапазона, которые дают квадратную сумму
    Квадратная тройка (a,b,c) — это тройка, в которой a, b, и c являются целыми числами и a^2 + b^2 = c^2.
    Учитывая целое число n, верните количествоквадратных троек,таких что 1 <= a, b, c <= n.
    https://leetcode.com/problems/count-square-sum-triples/description/
     */
    public class Task1925 : InfoBasicTask
    {
        public Task1925(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 10;
            Console.WriteLine($"Исходное число = {n}");
            if (isValidNumber(n))
            {
                int count = countTriples(n);
                Console.WriteLine($"Количество троек значений из диапазона 1<=a,b,c<={n}, которые соответствуют уравнению a^2+b^2 = c^2 равно {count}");
            }
            else
            {
                Console.WriteLine("Не валидное исходное число");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValidNumber(int number)
        {
            if (number < 1 || number > 250)
            {
                return false;
            }
            return true;
        }
        private int countTriples(int n)
        {
            int count = 0;
            for (int a = 1; a <= n; a++)
            {
                
                for (int b = 1; b <= n; b++)
                {
                    int sum = a * a + b * b;
                    double sqrt = Math.Sqrt(sum);
                    if (isSquareRootInteger(sqrt, sum))
                    {
                        int sqrtInteger = (int)sqrt;
                        if (sqrtInteger >= 1 && sqrtInteger <= n)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        private bool isSquareRootInteger(double sqrt, int number)
        {
            int sqrtInt = (int)sqrt; // Преобразуем результат в целое число
            // Проверяем, равен ли квадрат целого числа исходному числу
            return sqrtInt * sqrtInt == number;
        }
    }
}
