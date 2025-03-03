using LeetCode.Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2595
{
    /*
     2595. Количество четных и нечетных битов
    Вам дается положительное целое число n.
    Пусть even обозначает количество чётных индексов в двоичном представлении n со значением 1
    Пусть odd обозначает количество нечётных индексов в двоичном представлении n со значением 1.
    Обратите внимание, что биты в двоичном представлении числа индексируются справа налево.
    Возвращает массив [even, odd].
    Ограничения:
        1 <= n <= 1000
    https://leetcode.com/problems/number-of-even-and-odd-bits/description/
     */
    public class Task2595 : InfoBasicTask
    {
        public Task2595(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 50;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int[] result = evenOddBit(number);
                Console.WriteLine($"Количество четных индексов со значением 1 = {result[0]}.\nКоличество нечетных индексов со значением 1 = {result[1]}.");
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
            if (n < 1 || n > 1000)
            {
                return false;
            }
            return true;
        }
        private int[] evenOddBit(int n)
        {
            int[] result = new int[2];
            int index = 0;
            while (n != 0)
            {
                int bit = n & 1;
                if (bit == 1)
                {
                    if (index % 2 == 0)
                    {
                        result[0]++;
                    }
                    else
                    {
                        result[1]++;
                    }
                }
                index++;
                n = n >> 1;
            }
            return result;
        }
    }
}
