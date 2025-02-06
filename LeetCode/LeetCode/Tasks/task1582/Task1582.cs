using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1582
{
    /*
     1582. Особые позиции в двоичной матрице
    Учитывая m x n двоичную матрицу mat, верните количество особых позиций в mat.
    Позиция (i, j) называется специальной, если mat[i][j] == 1 и все остальные элементы в строке i и столбце j являются 0 (строки и столбцы имеют нулевую индексацию).
    https://leetcode.com/problems/special-positions-in-a-binary-matrix/description/
     */
    public class Task1582 : InfoBasicTask
    {
        public Task1582(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] mat = new int[][] {
                new int[] {1,0,0 },
                 new int[] {0,1,0 },
                  new int[] {0,0,1 },
            };
            
            printTwoDimensionalArray(mat, "Исходная матрица");
            if (correctMatrix(mat))
            {
                int count = numSpecial(mat);
                Console.WriteLine($"Количество специальных позиций в матрице = {count}");
            }
            else
            {
                Console.WriteLine("Исходная матрица не корректна. Матрица должна состоять только из 0 и 1");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool correctMatrix(int[][] mat)
        {
            for (int row = 0; row < mat.Length; row++)
            {
                for (int column = 0; column < mat[row].Length; column++)
                {
                    if (mat[row][column] != 0 && mat[row][column] != 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int numSpecial(int[][] mat)
        {
            int count = 0;
            for (int i = 0; i < mat.Length; i++) // индекс по строкам
            {
                for (int j = 0; j < mat[i].Length; j++) // индекс по столбцам
                {
                    if (mat[i][j] == 1)
                    {
                        int countOfOnes = 0;
                        for (int indexRow = 0; indexRow < mat.Length; indexRow++) // проверка элементов по столбцу
                        {
                            if (indexRow != i && mat[indexRow][j] == 1)
                            {
                                countOfOnes++;
                            }
                        }
                        for (int indexColumn = 0; indexColumn < mat[i].Length; indexColumn++) // проверка элементов по строке
                        {
                            if (indexColumn != j && mat[i][indexColumn] == 1)
                            {
                                countOfOnes++;
                            }
                        }
                        if (countOfOnes == 0)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        //скопировано с leetcode
        private int bestSolution(int[][] mat)
        {
            int m = mat.Length, n = mat[0].Length;
            int[] row = new int[m];
            int[] col = new int[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        row[i]++;
                        col[j]++;
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] == 1 && row[i] == 1 && col[j] == 1) count++;
                }
            }

            return count;
        }
    }
}
