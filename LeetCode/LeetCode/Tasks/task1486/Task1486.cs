using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1486
{
    /*
     1486. Операция XOR в массиве
    Вам дается целое число n и целое число start.
    Определите массив, nums где nums[i] = start + 2 * i (0-индексированный) и n == nums.length.
    Возвращает побитовое значение XOR для всех элементов nums.
    https://leetcode.com/problems/xor-operation-in-an-array/description/
     */
    public class Task1486 : InfoBasicTask
    {
        public Task1486(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 5;
            int start = 0;
            Console.WriteLine($"Количество элементов = {n}");
            Console.WriteLine($"Стартовое значение = {start}");
            int result = xorOperation(n, start);
            Console.WriteLine($"Результат применения операции XOR = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int xorOperation(int n, int start)
        {
            int result = start;
            for (int i = 1; i < n; i++)
            {
                result = result ^ (start + 2 * i);
            }
            return result;
        }
    }
}
