using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task463
{
    /*
     463. Периметр острова
    Вам дана row x col grid карта, на которой grid[i][j] = 1 обозначает сушу, а grid[i][j] = 0 — воду.
    Ячейки сетки соединены по горизонтали/вертикали (не по диагонали).grid полностью окружен водой, и есть ровно один остров (то есть одна или несколько соединенных ячеек суши).
    На острове нет «озёр», то есть вода внутри не соединена с водой вокруг острова. Одна ячейка — это квадрат со стороной 1. Решётка прямоугольная, ширина и высота не превышают 100. Определите периметр острова.
     */
    public class Task463 : InfoBasicTask
    {
        public Task463(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
               new int[] { 0, 1, 0, 0 },
               new int[] {1, 1, 1, 0 },
               new int[] {0, 1, 0, 0 },
               new int[] {1, 1, 0, 0 } };
            Console.WriteLine($"Периметр острова = {islandPerimeter(grid)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int islandPerimeter(int[][] grid)
        {
            int perimeter = 0;
            for (int indexRow = 0; indexRow < grid.Length; indexRow++)
            {
                for (int indexCell = 0; indexCell < grid[indexRow].Length; indexCell++)
                {
                    if (grid[indexRow][indexCell] != 0)
                    {
                        //Проверка слева
                        if (indexCell > 0)
                        {
                            if (grid[indexRow][indexCell-1] != 1)
                            {
                                perimeter++;
                            }
                        }
                        else
                        {
                            perimeter++;
                        }
                        //Проверка справа
                        if (indexCell < grid[indexRow].Length -1)
                        {
                            if (grid[indexRow][indexCell+1] != 1)
                            {
                                perimeter++;
                            }
                        }
                        else
                        {
                            perimeter++;
                        }
                        //Проверка вверху
                        if (indexRow > 0)
                        {
                            if (grid[indexRow-1][indexCell] != 1)
                            {
                                perimeter++;
                            }
                        }
                        else
                        {
                            perimeter++;
                        }
                        //Проверка снизу
                        if (indexRow < grid.Length - 1)
                        {
                            if (grid[indexRow+1][indexCell] != 1)
                            {
                                perimeter++;
                            }
                        }
                        else
                        {
                            perimeter++;
                        }
                    }
                }
            }
            return perimeter;
        }
    }
}
