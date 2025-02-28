using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2500
{
    /*
     2500. Удалить наибольшее значение в каждой строке
    Вам дана m x n матрица grid, состоящая из натуральных чисел.
    Выполняйте следующую операцию до тех пор, пока grid не станет пустым:
        Удалите элемент с наибольшим значением из каждой строки. Если таких элементов несколько, удалите любой из них.
        Добавьте в ответ максимальное количество удаленных элементов.
    Обратите внимание, что количество столбцов уменьшается на единицу после каждой операции.
    Верните ответ после выполнения описанных выше операций.
    Ограничения:
        m == grid.length
        n == grid[i].length
        1 <= m, n <= 50
        1 <= grid[i][j] <= 100
    https://leetcode.com/problems/delete-greatest-value-in-each-row/description/
     */
    public class Task2500 : InfoBasicTask
    {
        public Task2500(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] { 
                new int[] {1,2,4 },
                new int[] {3,3,1 },
            };
            printTwoDimensionalArray(grid, "Исходная матрица");
            if (isValid(grid))
            {
                int result = deleteGreatestValue(grid);
                Console.WriteLine($"Результат = {result}");
            }
            else
            {
                Console.WriteLine("Невалидные исходные данные!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[][] grid)
        {
            int m = grid.Length;
            if (m <0 || m>50)
            {
                return false;
            }
            int n = grid[0].Length;
            if (n < 0 || n > 50)
            {
                return false;
            }
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] < 1 || grid[i][j] > 100)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int deleteGreatestValue(int[][] grid)
        {
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                Array.Sort(grid[i]);
            }
            int countColumns = grid[0].Length;
            for (int indexColumn = countColumns - 1; indexColumn >= 0; indexColumn--)
            {
                int max = grid[0][indexColumn];
                for (int indexRow = 1; indexRow < grid.Length; indexRow++)
                {
                    if (grid[indexRow][indexColumn] > max)
                    {
                        max = grid[indexRow][indexColumn];
                    }
                }
                result += max;
            }
            return result;
        }
    }
}
