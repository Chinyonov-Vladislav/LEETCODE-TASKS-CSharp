using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task304
{
    /*
     304. Запрос суммы диапазона 2D - неизменяемый
    Учитывая 2D-матрицу matrix, обработайте несколько запросов следующего типа:
        Вычислите сумму элементов matrix внутри прямоугольника, ограниченного верхним левым (row1, col1) и нижним правым (row2, col2) углами.
    Реализовать класс NumMatrix:
        NumMatrix(int[][] matrix) Инициализирует объект с помощью целочисленной матрицы matrix.
        int sumRegion(int row1, int col1, int row2, int col2) Возвращает сумму элементов matrix внутри прямоугольника, ограниченного верхним левым (row1, col1) и нижним правым (row2, col2) углами.
    Вы должны разработать алгоритм, который sumRegion работает с O(1) временной сложностью.
    Ограничения:
        m == matrix.length
        n == matrix[i].length
        1 <= m, n <= 200
        -10^4 <= matrix[i][j] <= 10^4
        0 <= row1 <= row2 < m
        0 <= col1 <= col2 < n
        Не более 104 звонков будет сделано по адресу sumRegion.
    https://leetcode.com/problems/range-sum-query-2d-immutable/description/
     */
    public class Task304 : InfoBasicTask
    {
        public Task304(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] {3,0,1,4,2 },
                new int[] {5,6,3,2,1},
                new int[] {1,2,0,1,5 },
                new int[] {4,1,0,1,7 },
                new int[] {1,0,3,0,5 },
            };
            printTwoDimensionalArray(matrix, "Исходная двумерная матрица");
            int[][] coordinates = new int[][] {
                new int[] {2,1,4,3 },
                 new int[] {1,1,2,2 },
                  new int[] { 1, 2, 2, 4 }
            };
            printTwoDimensionalArray(matrix, "Двумерный массив координат областей");
            if (isValid(matrix, coordinates))
            {
                NumMatrix numMatrix = new NumMatrix(matrix);
                foreach (int[] coordinate in coordinates)
                {
                    int row1 = coordinate[0];
                    int col1 = coordinate[1];
                    int row2 = coordinate[2];
                    int col2 = coordinate[3];
                    int sumInRegion = numMatrix.SumRegion(row1,col1,row2, col2);
                    Console.WriteLine($"Сумма региона с координатами левого верхнего угла ({row1},{col1}) и правого нижнего угла ({row2},{col2}) = {sumInRegion}");
                }
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
        private bool isValid(int[][] matrix, int[][] coordinates)
        {
            int lowLimitDimensionMatrix = 1;
            int highLimitDimensionMatrix = 200;
            int lowLimitValueInMatrix = -1* (int)Math.Pow(10, 4);
            int highLimitValueInMatrix = (int)Math.Pow(10, 4);
            int countRows = matrix.Length;
            if (countRows < lowLimitDimensionMatrix || countRows > highLimitDimensionMatrix)
            {
                return false;
            }
            int countCols = matrix[0].Length;
            foreach (int[] row in matrix)
            {
                if (row.Length < lowLimitDimensionMatrix || row.Length > highLimitDimensionMatrix || row.Length != countCols)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < lowLimitValueInMatrix || item > highLimitValueInMatrix)
                    {
                        return false;
                    }
                }
            }
            int lowLimitCountCoordinates = 1;
            int highLimitCountCoordinates = (int)Math.Pow(10, 4);
            if (coordinates.Length < lowLimitCountCoordinates || coordinates.Length > highLimitCountCoordinates)
            {
                return false;
            }
            foreach (int[] coordinate in coordinates)
            {
                if (coordinate.Length != 4)
                {
                    return false;
                }
                int row1 = coordinate[0];
                int col1 = coordinate[1];
                int row2 = coordinate[2];
                int col2 = coordinate[3];
                if (!(0<=row1 && row1<=row2 && row2< countRows))
                {
                    return false;
                }
                if (!(0 <= col1 && col1 <= col2 && col2 < countCols))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
