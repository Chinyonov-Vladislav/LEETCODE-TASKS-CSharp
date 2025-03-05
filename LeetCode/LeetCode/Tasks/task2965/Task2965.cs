using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2965
{
    /*
     2965. Поиск отсутствующих и повторяющихся значений
    Вам дана двумерная целочисленная матрица с индексацией 0 grid размером n * n со значениями в диапазоне [1, n^2]. 
    Каждое целое число встречается ровно один раз, кроме a, которое встречается дважды, и b, которое отсутствует. 
    Задача состоит в том, чтобы найти повторяющиеся и отсутствующие числа a и b.
    Возвращает целочисленный массивansпроиндексированный с 0, где элемент под индексом 0 - повторяющийся, а под индексом 1 -пропущенный
    Ограничения:
        2 <= n == grid.length == grid[i].length <= 50
        1 <= grid[i][j] <= n * n
        Для всего x этого 1 <= x <= n * n существует ровно один x, который не равен ни одному из элементов сетки.
        Для всего x этого 1 <= x <= n * n существует ровно один x, который равен ровно двум элементам сетки.
        Для всех x этих 1 <= x <= n * n слов, кроме двух, существует ровно одна пара i, j этих 0 <= i, j <= n - 1 и grid[i][j] == x.
    https://leetcode.com/problems/find-missing-and-repeated-values/description/
     */
    public class Task2965 : InfoBasicTask
    {
        public Task2965(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] { 9, 1, 7 },
                new int[] {8,9,2 },
                new int[] {3,4,6 },
            };
            printTwoDimensionalArray(grid, "Двумерная матрица");
            if (isValid(grid))
            {
                int[] res = findMissingAndRepeatedValues(grid);
                Console.WriteLine($"Повторяющееся дважды значение = {res[0]}\nПропущенное значение = {res[1]}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[][] grid)
        {
            int n = grid.Length;
            if (n < 2 || n > 50)
            {
                return false;
            }
            int[] freq = new int[n * n];
            for (int indexRow = 0; indexRow < grid.Length; indexRow++)
            {
                if (n != grid[indexRow].Length)
                {
                    return false;
                }
                if (grid[indexRow].Length < 2 || grid[indexRow].Length > 50)
                {
                    return false;
                }
                for (int indexColumn = 0; indexColumn < grid[indexRow].Length; indexColumn++)
                {
                    if (grid[indexRow][indexColumn] < 1 || grid[indexRow][indexColumn] > n * n)
                    {
                        return false;
                    }
                    freq[grid[indexRow][indexColumn] - 1]++;
                }
            }
            int countZeroFreq = 0;
            int countTwoFreq = 0;
            int countOthers = 0;
            foreach (int num in freq)
            {
                if (num == 0)
                {
                    countZeroFreq++;
                }
                if (num == 2)
                {
                    countTwoFreq++;
                }
                if (num == 1)
                {
                    countOthers++;
                }
            }
            if (countZeroFreq != 1 || countTwoFreq != 1 || countOthers != n * n - 2)
            {
                return false;
            }
            return true;
        }
        private int[] findMissingAndRepeatedValues(int[][] grid)
        {
            int n = grid.Length;
            int[] freq = new int[n*n];
            for (int indexRow = 0; indexRow < grid.Length; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < grid.Length; indexColumn++)
                {
                    freq[grid[indexRow][indexColumn] - 1]++;
                }
            }
            int[] res = new int[] { 0, 0 };
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] == 0)
                {
                    res[1] = i + 1;
                }
                else if (freq[i] == 2)
                {
                    res[0] = i + 1;
                }
            }
            return res;
        }
    }
}
