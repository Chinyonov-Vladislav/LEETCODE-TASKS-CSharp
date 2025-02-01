using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task118
{
    /*
     118. Треугольник Паскаля

    Учитывая целое число numRows, верните первые numСтрок треугольника Паскаля.
    В треугольнике Паскаля каждое число является суммой двух чисел, расположенных непосредственно над ним
    https://leetcode.com/problems/pascals-triangle/
     */
    public class Task118 : InfoBasicTask
    {
        public Task118(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int numRows = 5;
            IList<IList<int>> result = generate(numRows);
            printPascalTriangle(result);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public IList<IList<int>> generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>(); 
            for (int i = 0; i < numRows; i++)
            {
                result.Add(new List<int>());
                if (i <= 1)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        result[i].Add(1);
                    }
                }
                else
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (j == 0 || j == i)
                        {
                            result[i].Add(1);
                        }
                        else
                        {
                            result[i].Add(result[i - 1][j - 1] + result[i - 1][j]);
                        }
                    }
                }
            }
            return result;
        }
        private void printPascalTriangle(IList<IList<int>> triangle)
        {
            for (int i = 0; i < triangle.Count; i++)
            {
                Console.Write($"Номер строки в треугольнике - {i + 1}: ");
                for(int j=0; j< triangle[i].Count;j++)
                {
                    if (j == triangle[i].Count - 1)
                    {
                        Console.Write($"{triangle[i][j]}\n");
                    }
                    else
                    {
                        Console.Write($"{triangle[i][j]}, ");
                    }
                }
            }
        }
    }
}
