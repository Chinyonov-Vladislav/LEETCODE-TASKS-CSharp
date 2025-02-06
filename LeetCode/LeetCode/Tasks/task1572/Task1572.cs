using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1572
{
    /*
     1572. Диагональная сумма матрицы
    Учитывая квадратную матрицу mat, верните сумму диагоналей матрицы.
    Учитывайте только сумму всех элементов на главной диагонали и всех элементов на побочной диагонали, которые не являются частью главной диагонали.
     https://leetcode.com/problems/matrix-diagonal-sum/description/
     */
    public class Task1572 : InfoBasicTask
    {
        public Task1572(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] mat = new int[][] {
                new int[] {1,2,3 },
                new int[] {4,5,6 },
                new int[] {7,8,9 },
            };
            if (checkIsMatrixSquare(mat))
            {
                printTwoDimensionalArray(mat, "Квадратная матрица: ");
                int sum = diagonalSum(mat);
                Console.WriteLine($"Сумма элементов на главной и побочной диагонали = {sum}");
            }
            else
            {
                printTwoDimensionalArray(mat, "Матрица: ");
                Console.WriteLine("Исходная матрица не является квадратной");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkIsMatrixSquare(int[][] mat)
        {
            int countRowsMatrix = mat.Length;
            for (int i = 0; i < mat.Length; i++)
            {
                if (mat[i].Length != countRowsMatrix)
                {
                    return false;
                }
            }
            return true;
        }
        private int diagonalSum(int[][] mat)
        {
            int countRowsAndColumnInSquareMatrix = mat.Length;
            int sum = 0;
            for (int i = 0; i < countRowsAndColumnInSquareMatrix; i++)
            {
                sum += mat[i][i];
            }
            int indexRow = 0;
            for (int indexColumn = countRowsAndColumnInSquareMatrix - 1; indexColumn >= 0; indexColumn--)
            {
                sum += mat[indexRow][indexColumn];
                if (countRowsAndColumnInSquareMatrix % 2 != 0 && countRowsAndColumnInSquareMatrix / 2 == indexColumn && countRowsAndColumnInSquareMatrix / 2 == indexRow)
                {
                    sum -= mat[indexRow][indexColumn];
                }
                indexRow++;
            }
            return sum;
        }
    }
}
