using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.Task1886
{
    /*
     1886. Определите, можно ли получить матрицу путём поворота
    Учитывая две n x n двоичные матрицы mat и target, верните true, если их можно сделать mat равной target путем последовательного поворота mat на 90 градусов или false иначе.
    https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/description/
     */
    public class Task1886 : InfoBasicTask
    {
        public Task1886(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] initialMatrix = new int[][] {
                new int[] { 0,0,0},
                new int[] { 0,1,0 },
                new int[] { 1,1,1},
            };
            int[][] targetMatrix = new int[][] {
                 new int[] { 1,1,1},
                 new int[] { 0,1,0 },
                 new int[] { 0,0,0},
            };
            printTwoDimensionalArray(initialMatrix, "Исходная матрица");
            printTwoDimensionalArray(targetMatrix, "Целевая матрица");
            bool isInitialMatrixCorrect = isCorrectMatrix(initialMatrix);
            bool isTargetMatrixCorrect = isCorrectMatrix(targetMatrix);
            if (!isInitialMatrixCorrect)
            {
                Console.WriteLine("Исходная матрица не корректна для задания");
            }
            if (!isTargetMatrixCorrect)
            {
                Console.WriteLine("Целевая матрица не корректна для задания");
            }
            Console.WriteLine(findRotation(initialMatrix, targetMatrix) ?
                "Целевую матрицу можно получить из исходной путём поворотов на 90 градусов по часовой стрелке" :
                "Целевую матрицу невозможно получить из исходной путём поворотов на 90 градусов по часовой стрелке");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isCorrectMatrix(int[][] mat)
        {
            int countRows = mat.Length;
            for (int i = 0; i < mat.Length; i++)
            {
                if (mat[i].Length!= countRows)
                {
                    return false;
                }
            }
            return true;
        }
        private bool findRotation(int[][] mat, int[][] target)
        {
            if (isIdenticMatrix(mat, target))
            {
                return true;
            }
            for (int numberCycle = 0; numberCycle <= 2; numberCycle++)
            {
                int countRowsAndColumns = mat.Length;
                int[][] result = new int[countRowsAndColumns][];
                for (int i = 0; i < countRowsAndColumns; i++)
                {
                    result[i] = new int[countRowsAndColumns];
                }
                for (int i = 0; i < countRowsAndColumns; i++)
                {
                    for (int j = 0; j < countRowsAndColumns; j++)
                    {
                        result[countRowsAndColumns - 1 - j][i] = mat[i][j];
                    }
                }
                if (isIdenticMatrix(result, target))
                {
                    return true;
                }
                else
                {
                    mat = result;
                }
            }
            return false;
        }
        private bool isIdenticMatrix(int[][] mat, int[][] target)
        {
            if (mat.Length != target.Length)
            {
                return false;
                
            }
            for (int i = 0; i < mat.Length; i++)
            {
                if (mat[i].Length != target[i].Length)
                {
                    return false;
                }
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] != target[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
