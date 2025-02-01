using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task693
{
    /*
     693. Двоичное число с чередующимися битами
    Дано положительное целое число. Проверьте, есть ли в нём чередующиеся биты, то есть всегда ли два соседних бита имеют разные значения.
    Ограничения:
        1 <= n <= 231 - 1
    https://leetcode.com/problems/binary-number-with-alternating-bits/description/
     */
    public class Task693 : InfoBasicTask
    {
        public Task693(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 5;
            Console.WriteLine(hasAlternatingBits(number) ? $"Биты в числе {number} чередуются: {Convert.ToString(number, 2)}" : $"Не все биты в числе {number} чередуются: {Convert.ToString(number, 2)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool hasAlternatingBits(int n)
        {
            List<int> bits = new List<int>();
            while (n != 0)
            {
                int bit = n & 1;
                if (bits.Count == 2)
                {
                    bits.RemoveAt(0);
                }
                bits.Add(bit);
                if (bits.Count == 2 && bits[0] == bits[1])
                {
                    return false;
                }
                n = n >> 1;
            }
            return true;
        }
    }
}
