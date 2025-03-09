using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2946
{
    /*
     2946. Подобие матрицы после циклических сдвигов
    Вам дана m x n целочисленная матрица mat и целое число k. Строки матрицы нумеруются с 0.
    Следующий процесс происходит k раз:
        Строки с чётными индексами (0, 2, 4, ...) циклически сдвигаются влево.
        Строки с нечётными индексами (1, 3, 5, ...) циклически сдвигаются вправо.
    Вернуть true если окончательная изменённая матрица после k шагов идентична исходной матрице, и false в противном случае.
    Ограничения:
        1 <= mat.length <= 25
        1 <= mat[i].length <= 25
        1 <= mat[i][j] <= 25
        1 <= k <= 50
    https://leetcode.com/problems/matrix-similarity-after-cyclic-shifts/description/
     */
    public class Task2946 : InfoBasicTask
    {
        public Task2946(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] mat = new int[][] {
                new int[] { 1,2,1,2 },
                new int[] { 5,5,5,5 },
                new int[] { 6,3,6,3 },
            };
            printTwoDimensionalArray(mat, "Исходный двумерный массив");
            int k = 2;
            Console.WriteLine($"Значение переменной количества циклических сдвигов = {k}");
            if (isValid(mat,k))
            {
                Console.WriteLine(areSimilar(mat, k) ? $"Полученная матрица после {k} циклических сдвигов идентична исходной матрице" : $"Полученная матрица после {k} циклических сдвигов не идентична исходной матрице");
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
        private bool isValid(int[][] mat, int k)
        {
            if (mat.Length < 1 || mat.Length > 25)
            {
                return false;
            }
            foreach (int[] row in mat)
            {
                if (row.Length < 1 || row.Length>25)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < 1 || item > 25)
                    {
                        return false;
                    }
                }
            }
            if (k < 1 || k > 50)
            {
                return false;
            }
            return true;
        }
        private bool areSimilar(int[][] mat, int k)
        {
            int[][] copyMatrix = new int[mat.Length][];
            for (int indexRow = 0; indexRow < copyMatrix.Length; indexRow++)
            {
                copyMatrix[indexRow] = new int[mat[indexRow].Length];
                for (int indexColumn = 0; indexColumn < copyMatrix[indexRow].Length; indexColumn++)
                {
                    copyMatrix[indexRow][indexColumn] = mat[indexRow][indexColumn];
                }
            }
            for (int indexRow = 0; indexRow < copyMatrix.Length; indexRow++)
            {
                int n = copyMatrix[indexRow].Length;
                k = k % n; // Убедимся, что k не превышает длину массива
                if (indexRow % 2 == 0)
                {
                    // Перевернем весь массив
                    reverse(copyMatrix[indexRow], 0, n - 1);
                    // Перевернем первую часть (первые k элементов)
                    reverse(copyMatrix[indexRow], 0, k - 1);
                    // Перевернем вторую часть (оставшиеся элементы)
                    reverse(copyMatrix[indexRow], k, n - 1);
                }
                else
                {
                    // Перевернем весь массив
                    reverse(copyMatrix[indexRow], 0, n - 1);
                    // Перевернем последнюю часть (последние n - k элементов)
                    reverse(copyMatrix[indexRow], 0, n - k - 1);
                    // Перевернем первую часть (первые k элементов)
                    reverse(copyMatrix[indexRow], n - k, n - 1);
                }
                for (int indexColumn = 0; indexColumn < copyMatrix[indexRow].Length; indexColumn++)
                {
                    if (copyMatrix[indexRow][indexColumn] != mat[indexRow][indexColumn])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void reverse(int[] array, int start, int end)
        {
            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }
    }
}
