using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task598
{
    /*
     598. Дополнение диапазона II
    Вам предоставляется m x n матрица M, инициализированная  0, и массив операций ops, где ops[i] = [ai, bi] средние M[x][y] значения должны быть увеличены на единицу для всех 0 <= x < ai и 0 <= y < bi.
    Подсчитайте и верните количество максимальных целых чисел в матрице после выполнения всех операций.
    https://leetcode.com/problems/range-addition-ii/description/
     */
    public class Task598 : InfoBasicTask
    {
        public Task598(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int m = 3;
            int n = 3;
            int[][] ops = new int[][] {
                new int[] { 2,2 },
                new int[] { 3,3 }
            };
            int maxCountValue = maxCount(m, n, ops);
            Console.WriteLine($"Количество максимальных значений после преобразований в массиве равно {maxCountValue}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxCount(int m, int n, int[][] ops)
        {
            if (ops.Length == 0)
            {
                return m * n;
            }
            int minRow = Int32.MaxValue;
            int minColumn = Int32.MaxValue;
            for (int i = 0; i < ops.Length; i++)
            {
                if (ops[i][0] < minRow)
                {
                    minRow = ops[i][0];
                }
                if (ops[i][1] < minColumn)
                {
                    minColumn = ops[i][1];
                }
            }
            return minRow*minColumn;
        }
    }
}
