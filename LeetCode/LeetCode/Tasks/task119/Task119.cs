using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task119
{
    /*
     119. Треугольник Паскаля II
    Для заданного целого числа rowIndex верните строку треугольника Паскаля.
    В треугольнике Паскаля каждое число является суммой двух чисел, расположенных непосредственно над ним, как показано на рисунке:
     */
    public class Task119 : InfoBasicTask
    {
        public Task119(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int rowIndex = 3;
            IList<int> rowByIndex = getRow(rowIndex);
            printIListInt(rowByIndex, $"Строка под номером {rowIndex} из треугольника Паскаля");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> getRow(int rowIndex)
        {
            IList<int> previousRow = new List<int>();
            IList<int> currentRow = new List<int>();
            if (rowIndex == 0)
            {
                currentRow = new List<int>() { 1 };
            }
            else if (rowIndex == 1)
            {
                currentRow = new List<int>() { 1, 1 };
            }
            else
            {
                previousRow = new List<int>() { 1, 1 };
                for (int i = 2; i <= rowIndex; i++)
                {
                    currentRow.Clear();
                    for (int j = 0; j <= i; j++)
                    {
                        if (j == 0 || j == i)
                        {
                            currentRow.Add(1);
                        }
                        else
                        {
                            currentRow.Add(previousRow[j - 1] + previousRow[j]);
                        }
                    }
                    previousRow = new List<int>(currentRow);
                }
            }
            return currentRow;
        }
        public IList<int> bestSolution(int rowIndex) // скопировано с leetCode
        {
            List<int> res = new List<int> { 1 };
            long prev = 1;
            for (int k = 1; k <= rowIndex; k++)
            {
                long next_val = prev * (rowIndex - k + 1) / k;
                res.Add((int)next_val);
                prev = next_val;
            }
            return res;
        }
    }
}
