using LeetCode.Basic;
using System;
using System.Text;

namespace LeetCode.Tasks.task190
{
    /*
     190. Обратные биты
    Инвертируйте биты данного 32-битного целого числа без знака.
    https://leetcode.com/problems/reverse-bits/description/
     */
    public class Task190 : InfoBasicTask
    {
        public Task190(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            uint number = 43261596;
            uint result = reverseBits(number);
            Console.WriteLine($"Исходное число = {number} | Число после инвертирования битов = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private uint reverseBits(uint n)
        {
            StringBuilder reversedBitsNumber = new StringBuilder();
            string numberBinary = Convert.ToString(n,2);
            int countBinaryDigitsInUINT = 31;
            int countLeadingZero = countBinaryDigitsInUINT - numberBinary.Length;
            for (int i = 0; i <= countLeadingZero; i++)
            {
                numberBinary = "0" + numberBinary;
            }
            Console.WriteLine($"Исходное число в бинарном виде = {numberBinary}");
            int right = numberBinary.Length;
            for (int i = numberBinary.Length - 1; i >= 0; i--)
            {
                reversedBitsNumber.Append(numberBinary[i]);
            }
            Console.WriteLine($"Конечное число в бинарном виде = {reversedBitsNumber.ToString()}");
            return Convert.ToUInt32(reversedBitsNumber.ToString(), 2);
        }
    }
}
