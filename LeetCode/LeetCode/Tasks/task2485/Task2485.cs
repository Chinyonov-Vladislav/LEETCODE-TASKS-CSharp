using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2485
{
    /*
     2485. Найдите сводное целое число
    Учитывая положительное целое число n, найдите сводное целое число x такое, что:
        Сумма всех элементов между 1 и x включительно равна сумме всех элементов между x и n включительно.
    Верните опорное целое числоx. Если такого целого числа не существует, верните -1. Гарантируется, что для заданных входных данных будет не более одного опорного индекса.
    Ограничения:
        1 <= n <= 1000
    https://leetcode.com/problems/find-the-pivot-integer/description/
     */
    public class Task2485 : InfoBasicTask
    {
        public Task2485(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 8;
            Console.WriteLine($"Исходное значение n = {n}");
            if (isValid(n))
            {
                int res = pivotInteger(n);
                Console.WriteLine(res == -1 ? $"Pivot Integer отсутствует в последовательности от 1 до {n}" : $"Pivot Integer в последовательности от 1 до {n} = {res}");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int n)
        {
            if (n < 1 || n > 1000)
            {
                return false;
            }
            return true;
        }
        private int pivotInteger(int n)
        {
            int totalSum = 0;
            for (int i = 1; i <=n; i++)
            {
                totalSum += i;
            }
            int leftSum = 0;
            for (int i = 1; i <=n; i++)
            {
                leftSum+= i;
                int rightSum = totalSum - leftSum + i;
                if (leftSum == rightSum)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
