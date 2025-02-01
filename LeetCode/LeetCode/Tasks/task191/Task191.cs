using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task191
{
    /*
     191. Количество битов в 1
    Учитывая положительное целое число n, напишите функцию, которая возвращает число установленные биты в его двоичном представлении (также известном как вес Хэмминга).
    https://leetcode.com/problems/number-of-1-bits/description/
     */
    public class Task191 : InfoBasicTask
    {
        public Task191(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 128;
            Console.WriteLine($"В числе {number} количество единиц в бинарном виде равно {hammingWeight(number)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int hammingWeight(int n)
        {
            string binaryNumber = Convert.ToString(n, 2);
            int count = 0;
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] == '1')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
