using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace LeetCode.Tasks.task1380
{
    /*
     1380. Счастливые числа в матрице
    Учитывая m x n матрицу различных чисел, верните всесчастливые числа в матрице в любомпорядке.
    Счастливое число — это элемент матрицы, который является минимальным элементом в своей строке и максимальным в своём столбце.
    https://leetcode.com/problems/lucky-numbers-in-a-matrix/description/
     */
    public class Task1380 : InfoBasicTask
    {
        public Task1380(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] { 1, 10, 4, 2 },
                new int[] { 9,3,8,7 },
                new int[] { 15,16,17,12 }
            };
            printTwoDimensionalArray(matrix, "Исходная матрица");
            IList<int> result = luckyNumbers(matrix);
            printIListInt(result, "Счастливые числа: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<int> luckyNumbers(int[][] matrix)
        {
            List<int> minElementsInRow = new List<int>();
            List<int> maxElementsInColumns = new List<int>();
            IList<int> results = new List<int>();
            int countRows = matrix.Length;
            if (countRows == 0)
            {
                return results;
            }
            int countColumns = matrix[0].Length;
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                List<int> itemsInRow = new List<int>();
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    itemsInRow.Add(matrix[indexRow][indexColumn]);
                }
                minElementsInRow.Add(itemsInRow.Min());
            }
            for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
            {
                List<int> itemsInColumn = new List<int>();
                for (int indexRow = 0; indexRow < countRows; indexRow++)
                {
                    itemsInColumn.Add(matrix[indexRow][indexColumn]);
                }
                maxElementsInColumns.Add(itemsInColumn.Max());
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            { 
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    int currentItem = matrix[indexRow][indexColumn];
                    if (minElementsInRow[indexRow] == currentItem && maxElementsInColumns[indexColumn] == currentItem)
                    {
                        results.Add(currentItem);
                    }
                }
            }
            return results;
        }
    }
}
