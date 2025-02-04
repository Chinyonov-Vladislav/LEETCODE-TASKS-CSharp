using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1252
{
    /*
     1252. Ячейки с нечетными значениями в матрице
    Существует матрица m x n с инициализированными значениями 0's. Также существует двумерный массив indices с каждым indices[i] = [ri, ci] элементом, представляющим позицию с индексом 0 для выполнения некоторых операций с матрицей.
    Для каждого местоположения indices[i] выполните оба из следующих действий:
        Увеличьте все ячейки в строке ri.
        Увеличьте все ячейки в столбце ci.
       Учитывая m, n, и indices, верните количество нечётных ячеекв матрице после применения приращения ко всем ячейкам в indices.
     */
    public class Task1252 : InfoBasicTask
    {
        public Task1252(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] indices = new int[][] {
                new int[] { 0,1},
                new int[] { 1,1},
            };
            Console.WriteLine("Индексы ячейки для изменения строки и столбца");
            for (int i = 0; i < indices.Length; i++)
            {
                Console.WriteLine($"[{indices[i][0]},{indices[i][0]}]");
            }
            int m = 2;
            int n = 3;
            Console.WriteLine($"Размеры нулевой матрицы: {m}x{n}");
            int countOddCells = oddCells(m, n, indices);
            Console.WriteLine($"Количество ячеек с нечетным значением после преобразований = {countOddCells}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int oddCells(int m, int n, int[][] indices)
        {
            int countOddCells = 0;
            int[][] zeroMatrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                zeroMatrix[i] = new int[n];
            }
            for (int i = 0; i < indices.Length; i++)
            {
                int indexRowFromArray = indices[i][0];
                int indexColummnFromArray = indices[i][1];
                for (int indexColumn = 0; indexColumn < zeroMatrix[indexRowFromArray].Length; indexColumn++)
                {
                    zeroMatrix[indexRowFromArray][indexColumn]++;
                }
                for (int indexRow = 0; indexRow < zeroMatrix.Length; indexRow++)
                {
                     zeroMatrix[indexRow][indexColummnFromArray]++;
                }
            }
            for (int indexRow = 0; indexRow < zeroMatrix.Length; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < zeroMatrix[indexRow].Length; indexColumn++)
                {
                    if (zeroMatrix[indexRow][indexColumn] % 2 != 0)
                    {
                        countOddCells++;
                    }
                }
            }
            return countOddCells;
        }
        //скопировано с leetcode
        private int bestSolution(int m, int n, int[][] indices)
        {
            int[] row = new int[m];
            int[] col = new int[n];
            for (int i = 0; i < indices.Length; i++)
            {
                row[indices[i][0]]++;
                col[indices[i][1]]++;
            }
            int res = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res += (row[i] + col[j]) % 2 == 1 ? 1 : 0;
                }
            }
            return res;
        }
    }
}
