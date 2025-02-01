using LeetCode.Basic;
using System;
using System.Text;

namespace LeetCode.Tasks.task476
{
    /*
     476. Дополнение к числу
    Дополнение целого числа — это целое число, которое вы получите, если поменяете все 0 на 1 и все 1 на 0 в его двоичном представлении.
    Например, целое число 5 в двоичной системе счисления равно "101", а его дополнением является "010" — целое число 2
    Учитывая целое число num, верните его дополнение.
    https://leetcode.com/problems/number-complement/description/
     */
    public class Task476 : InfoBasicTask
    {
        public Task476(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int num = 5;
            Console.WriteLine($"Исходное число = {num} | Число после инвертирования битов = {findComplement(num)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findComplement(int num)
        {
            string numBits = Convert.ToString(num,2);
            StringBuilder stringBuilder = new StringBuilder(numBits);
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] == '0')
                {
                    stringBuilder.Replace("0", "1", i, 1);
                }
                else
                {
                    stringBuilder.Replace("1", "0", i, 1);
                }
            }
            return Convert.ToInt32(stringBuilder.ToString(),2);
        }
    }
}
