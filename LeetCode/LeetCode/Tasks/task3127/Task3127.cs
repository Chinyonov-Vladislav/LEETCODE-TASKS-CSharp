using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3127
{
    /*
     3127. Сделайте квадрат того же цвета
    Вам дана двумерная матрица grid размером 3 x 3, состоящая только из символов 'B' и 'W'. Символ 'W' обозначает белый цвет, а символ 'B' — чёрный.
    Ваша задача — изменить цвет не более чем одной ячейки, чтобы в матрице появился 2 x 2 квадрат, в котором все ячейки одного цвета.
    Верните true, если можно создать 2 x 2 квадрат того же цвета, в противном случае верните false.
    Ограничения:
        grid.length == 3
        grid[i].length == 3
        grid[i][j] является либо 'W', либо 'B'.
    https://leetcode.com/problems/make-a-square-with-the-same-color/description/
     */
    public class Task3127 : InfoBasicTask
    {
        public Task3127(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            char[][] grid = new char[][] {
                new char[] { 'B', 'W', 'B' },
                new char[] { 'B', 'W', 'W'},
                new char[] { 'B', 'W', 'B' },
            };
            printTwoDimensionalArray(grid);
            if (isValid(grid))
            {
                Console.WriteLine(canMakeSquare(grid) ? $"Возможно сделать квадрат 2х2 одного цвета, перекрасив всего одну клетку или не перекрасив ни одну клетку вовсе" : "Невозможно сделать квадрат 2х2 одного цвета");
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
        private bool isValid(char[][] grid)
        {
            if (grid.Length != 3)
            {
                return false;
            }
            foreach (char[] row in grid)
            {
                if (row.Length != 3)
                {
                    return false;
                }
                foreach (char item in row)
                {
                    if (item != 'W' && item != 'B')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool canMakeSquare(char[][] grid)
        {
            for (int i = 0; i < grid.Length - 1; i++)
            {
                for (int j = 0; j < grid[i].Length - 1; j++)
                {
                    int countBlack = 0;
                    int countWhite = 0;
                    for (int indexRow = i; indexRow < i + 2; indexRow++)
                    {
                        for (int indexColumn = j; indexColumn < j + 2; indexColumn++)
                        {
                            if (grid[indexRow][indexColumn] == 'W')
                            {
                                countWhite++;
                            }
                            else
                            {
                                countBlack++;
                            }
                        }
                    }
                    if (countBlack >= 3 || countWhite >= 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
