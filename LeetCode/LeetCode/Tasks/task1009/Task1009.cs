using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1009
{
    /*
     1009. Дополнение к целому числу с основанием 10
    Дополнение целого числа — это целое число, которое вы получите, если поменяете все 0 на 1 и все 1 на 0 в его двоичном представлении.
    Например, целое число 5 в двоичной системе счисления равно "101", а его дополнением является "010" — целое число 2
    Учитывая целое число n, верните его дополнение.
    https://leetcode.com/problems/complement-of-base-10-integer/description/
     */
    public class Task1009 : InfoBasicTask
    {
        public Task1009(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 5;
            Console.WriteLine($"Оригинальное число = {number}");
            Console.WriteLine($"Оригинальное число в двоичном представлении = {Convert.ToString(number, 2)}");
            int result = bitwiseComplement(number);
            Console.WriteLine($"Дополнение к числу {number} в десятичной системе = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int bitwiseComplement(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            int result = 0;
            int index = 0;
            while (n != 0)
            {
                int bit = n & 1;
                int reverseBit = bit == 0 ? 1 : 0;
                if (reverseBit == 1)
                {
                    result += (int)Math.Pow(2, index);
                }
                index++;
                n = n >> 1;
            }
            return result;
        }
    }
}
