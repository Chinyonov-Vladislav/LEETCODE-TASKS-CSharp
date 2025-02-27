using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2319
{
    /*
     2319. Проверьте, является ли матрица X-матрицей
    Квадратная матрица называется X-матрицей, если выполняются оба следующих условия:
        Все элементы на диагоналях матрицы не равны нулю.
        Все остальные элементы равны 0.
    Учитывая двумерный целочисленный массив grid размером n x n, представляющий собой квадратную матрицу, верните true если grid это X-матрица. В противном случае верните false.
     https://leetcode.com/problems/check-if-matrix-is-x-matrix/description/
     */
    public class Task2319 : InfoBasicTask
    {
        public Task2319(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] { 
                new int[] { 2,0,0,1 },
                new int[] { 0,3,1,0 },
                new int[] { 0,5,2,0 },
                new int[] { 4,0,0,2 },
            };
            if (isValid(grid))
            {
                Console.WriteLine(checkXMatrix(grid) ? "Все элементы матрицы на диагоналях равны 0, а на не диагоналях не равны 0" : "Не все элементы матрицы на диагоналях равны 0, а на не диагоналях не равны 0\"");
            }
            else
            {
                Console.WriteLine("Исходная матрица не валидна, так как не является квадратной!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[][] grid)
        {
            int countRows = grid.Length;
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i].Length != countRows)
                {
                    return false;
                }
            }
            return true;
        }
        private bool checkXMatrix(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (i == j || i == grid.Length - 1 - j)
                    {
                        if (grid[i][j] == 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (grid[i][j] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
