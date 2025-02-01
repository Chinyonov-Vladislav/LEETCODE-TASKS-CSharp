using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task766
{
    /*
     766. Матрица Теплица
    Учитывая m x n matrix, верните true, если матрица является матрицей Тёплица. В противном случае верните false.
    Матрица является матрицей Тёплица, если все диагонали от верхней левой до нижней правой имеют одинаковые элементы.
     */
    public class Task766 : InfoBasicTask
    {
        public Task766(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] matrix = new int[][] {
                new int[] { 1,2,3,4 },
                new int[] { 5,1,2,3 },
                new int[] { 9,5,1,2 },
            };
            int[][] matrix1 = new int[][] {
                new int[] { 1,2 },
                new int[] { 2,2,},
            };
            Console.WriteLine(isToeplitzMatrix(matrix1) ? "Матрица имеет на своих диагоналях одинаковые элементы" : "Матрица имеет на своих диагоналях не одинаковые элементы");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isToeplitzMatrix(int[][] matrix)
        {
            if (matrix.Length == 1 && matrix[0].Length == 1)
            {
                return true;
            }
            List<List<int>> diagonals = new List<List<int>>();
            bool firstIteration = true;
            List<int> indexForCell1 = new List<int>() { matrix.Length - 1, 0 };
            List<int> indexForCell2 = new List<int>() { matrix.Length - 1, 0 };
            while (true)
            {
                int cell1Row = indexForCell1[0];
                int cell1Column = indexForCell1[1];
                int cell2Row = indexForCell2[0];
                int cell2Column = indexForCell2[1];
                diagonals.Add(new List<int>());
                while (cell1Row <= cell2Row && cell1Column <= cell2Column)
                {
                    diagonals[diagonals.Count - 1].Add(matrix[cell1Row][cell1Column]);
                    cell1Row++;
                    cell1Column++;
                }
                if (!firstIteration && indexForCell1[0] == indexForCell2[0] && indexForCell1[1] == indexForCell2[1])
                {
                    break;
                }
                if (indexForCell1[0] > 0)
                {
                    indexForCell1[0]--;
                }
                else
                {
                    indexForCell1[1]++;
                }
                if (indexForCell2[1] < matrix[0].Length - 1)
                {
                    indexForCell2[1]++;
                }
                else
                {
                    indexForCell2[0]--;
                }
                if (firstIteration)
                {
                    firstIteration = false;
                }
            }
            foreach (var listDiagonal in diagonals)
            {
                HashSet<int> uniqueValuesDiagonal = new HashSet<int>(listDiagonal);
                if (uniqueValuesDiagonal.Count != 1)
                {
                    return false;
                }
            }
            return true;
        }
        private bool bestSolution(int[][] matrix)
        {
            for (int row = 1; row < matrix.Length; row++)
            {
                for (int col = 1; col < matrix[row].Length; col++)
                {
                    if (matrix[row - 1][col - 1] != matrix[row][col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
