using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task566
{
    /*
     566. Изменение формы матрицы
    В MATLAB есть удобная функция reshape , которая может преобразовать m x n матрицу в новую с другим размером r x c , сохранив исходные данные.
    Вам дается m x n матрица mat и два целых числа r и c, представляющих количество строк и количество столбцов требуемой измененной матрицы.
    Преобразованная матрица должна быть заполнена всеми элементами исходной матрицы в том же порядке, в котором они располагались в исходной матрице.
    Если операция reshape с заданными параметрами возможна и допустима, выведите новую преобразованную матрицу; в противном случае выведите исходную матрицу.
     https://leetcode.com/problems/reshape-the-matrix/description/
     */
    public class Task566 : InfoBasicTask
    {
        public Task566(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] numbers = new int[][] {
                new int[] { 1,2 },
                new int[] { 3,4 },
            };
            printArray(numbers, "Исходный массив");
            int rows = 1;
            int columns = 4;
            int[][] result = matrixReshape(numbers, rows, columns);
            printArray(result, "Результирующий массив");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[][] matrixReshape(int[][] mat, int r, int c)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    numbers.Add(mat[i][j]);
                }
            }
            long countElementsInResultArray = r * c;
            if (countElementsInResultArray != numbers.Count)
            {
                return mat;
            }
            int index = 0;
            int[][] resultArray = new int[r][];
            for (int i = 0; i < r; i++)
            {
                resultArray[i] = new int[c];
                for (int j = 0; j < resultArray[i].Length; j++)
                {
                    resultArray[i][j] = numbers[index];
                    index++;
                }
            }
            return resultArray;
        }
    }
}
