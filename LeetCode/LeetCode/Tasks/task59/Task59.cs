using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task59
{
    public class Task59 : InfoBasicTask
    {
        public Task59(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 3;
            Console.WriteLine($"Размер исходной матрицы = {n}x{n}");
            if (isValid(n))
            {
                int[][] matrix = generateMatrix(n);
                printTwoDimensionalArray(matrix, "Результирующая спиральная двумерная матрица");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int n)
        {
            int lowLimit = 1;
            int highLimit = 20;
            if (n < lowLimit || n > highLimit)
            {
                return false;
            }
            return true;
        }
        private int[][] generateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                visited[i] = new bool[n];
            }
            int halfCountRows = n / 2;
            int halfCountColumns = n / 2;
            int half = Math.Min(halfCountRows, halfCountColumns);
            int currentValue = 1;
            for (int i = 0; i <= half; i++)
            {
                int currentIndexRow = i;
                int currentIndexColumn = i;
                while (currentIndexColumn < n && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    matrix[currentIndexRow][currentIndexColumn] = currentValue;
                    currentValue++;
                    currentIndexColumn++;
                }
                currentIndexColumn--;
                currentIndexRow++;
                while (currentIndexRow < n && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    matrix[currentIndexRow][currentIndexColumn] = currentValue;
                    currentValue++;
                    currentIndexRow++;
                }
                currentIndexRow--;
                currentIndexColumn--;
                while (currentIndexColumn >= 0 && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    matrix[currentIndexRow][currentIndexColumn] = currentValue;
                    currentValue++;
                    currentIndexColumn--;
                }
                currentIndexColumn++;
                currentIndexRow--;
                while (currentIndexRow >= 0 && !visited[currentIndexRow][currentIndexColumn])
                {
                    visited[currentIndexRow][currentIndexColumn] = true;
                    matrix[currentIndexRow][currentIndexColumn] = currentValue;
                    currentValue++;
                    currentIndexRow--;
                }
            }
            return matrix;
        }
    }
}
