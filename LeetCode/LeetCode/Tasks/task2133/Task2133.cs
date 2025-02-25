using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2133
{
    /*
     2133. Проверьте, содержит ли каждая строка и столбец все числа
    Матрица n x n является действительной, если каждая строка и каждый столбец содержат все целые числа от 1 до n (включительно).
    Учитывая n x n целочисленную матрицу matrix, верните true если матрица является корректной. В противном случае верните false.
    https://leetcode.com/problems/check-if-every-row-and-column-contains-all-numbers/description/
     */
    public class Task2133 : InfoBasicTask
    {
        public Task2133(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[3][]
            {
                new int[] { 1,2,3 },
                new int[] { 3,1,2 },
                new int[] { 2,3,1 }
            };
            printTwoDimensionalArray(matrix, "Исходная матрица");
            if (isSquareMatrix(matrix))
            {
                Console.WriteLine(checkValid(matrix) ? "Каждый столбец и строка в квадратной матрице содержит значения от 1 до размера матрицы" : "Не каждый столбец и строка в квадратной матрице содержит значения от 1 до размера матрицы");
            }
            else
            {
                Console.WriteLine("Исходная матрица не является квадратной");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isSquareMatrix(int[][] matrix)
        {
            int countRows = matrix.Length;
            for (int i = 0; i < countRows; i++)
            {
                if (matrix[i].Length != countRows)
                {
                    return false;
                }
            }
            return true;
        }
        private bool checkValid(int[][] matrix)
        {
            int size = matrix.Length;
            for (int indexRow = 0; indexRow < size; indexRow++)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int indexColumn = 0; indexColumn < size; indexColumn++)
                {
                    if (dict.ContainsKey(matrix[indexRow][indexColumn]))
                    {
                        dict[matrix[indexRow][indexColumn]]++;
                    }
                    else
                    {
                        dict.Add(matrix[indexRow][indexColumn], 1);
                    }
                    
                }
                for (int i = 1; i <= size; i++)
                {
                    if (!dict.ContainsKey(i))
                    {
                        return false;
                    }
                }
            }
            for (int indexColumn = 0; indexColumn < size; indexColumn++)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int indexRow = 0; indexRow < size; indexRow++)
                {
                    if (dict.ContainsKey(matrix[indexRow][indexColumn]))
                    {
                        dict[matrix[indexRow][indexColumn]]++;
                    }
                    else
                    {
                        dict.Add(matrix[indexRow][indexColumn], 1);
                    }
                }
                for (int i = 1; i <= size; i++)
                {
                    if (!dict.ContainsKey(i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
