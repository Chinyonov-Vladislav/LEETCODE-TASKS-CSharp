using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2379
{
    /*
     2379. Минимальное количество перекрашиваний для получения K последовательных чёрных блоков
    Вам будет предоставлена строка с индексом blocks0n длины blocks[i], где 'W' - это либо 'B', либо ith, представляющий цвет, обозначающий блок. Символы 'W' и 'B' обозначают белый и черный цвета соответственно.
    Вам также задано целое число k, которое является желаемым количеством последовательных чёрных блоков.
    За одну операцию вы можете изменить цвет белого блока так, чтобы он стал чёрным.
    Верните минимальное количество операций, необходимых для того, чтобы появилось хотя бы одно последовательное появление k чёрных блоков.
    Ограничения:
        n == blocks.length
        1 <= n <= 100
        blocks[i] является либо 'W', либо 'B'.
        1 <= k <= n
    https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/description/
     */
    public class Task2379 : InfoBasicTask
    {
        public Task2379(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string blocks = "BWWWBB";
            int k = 6;
            Console.WriteLine($"Исходная строка блоков: \"{blocks}\"");
            Console.WriteLine($"Необходимое количество последовательных черных блоков = {k}");
            if (isValid(blocks, k))
            {
                int min = minimumRecolors(blocks, k);
                Console.WriteLine($"Минимальное количество перекрашиваний для получения {k}-последовательных черных блоков = {min}");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string blocks, int k)
        {
            int n = blocks.Length;
            if (n < 1 || n > 100)
            {
                return false;
            }
            foreach (var block in blocks)
            {
                if (block != 'W' && block != 'B')
                {
                    return false;
                }
            }
            if (k < 1 || k > n)
            {
                return false;
            }
            return true;
        }
        private int minimumRecolors(string blocks, int k)
        {
            int min = Int32.MaxValue;
            for (int i = 0; i <= blocks.Length - k; i++)
            {
                string substr = blocks.Substring(i, k);
                int localCountRecolor = 0;
                for (int j = 0; j < substr.Length; j++)
                {
                    if (substr[j] == 'W')
                    {
                        localCountRecolor++;
                    }  
                }
                if (localCountRecolor < min)
                {
                    min = localCountRecolor;
                }
            }
            return min;
        }
    }
}
