using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2643
{
    /*
     2643. Строка с максимальным количеством единиц
    Для заданной m x n двоичной матрицы mat найдите нулевую позицию строки, в которой содержится максимальное количество единиц, и количество единиц в этой строке.
    Если есть несколько строк с максимальным количеством единиц, следует выбрать строку с наименьшим номером.
    Верните массив, содержащий индекс строки и количество единиц в ней.
    Ограничения:
        m == mat.length 
        n == mat[i].length 
        1 <= m, n <= 100 
        mat[i][j] является либо 0, либо 1.
    https://leetcode.com/problems/row-with-maximum-ones/description/
     */
    public class Task2643 : InfoBasicTask
    {
        public Task2643(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] grid = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
            };
            printTwoDimensionalArray(grid, "Исходная матрица");
            if (isValid(grid))
            {
                int[] res = rowAndMaximumOnes(grid);
                Console.WriteLine($"Номер строки с максильным количеством единиц = {res[0]}. Количество единиц в строке = {res[1]}");
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
        private bool isValid(int[][] mat)
        {
            List<int> acceptedValues = new List<int>() { 0,1 };
            int m = mat.Length;
            if (m < 1 || m > 100)
            {
                return false;
            }
            for (int indexRow = 0; indexRow < mat.Length; indexRow++)
            {
                int n = mat[indexRow].Length;
                if (n < 1 || n > 100)
                {
                    return false;
                }
                for (int indexColumn = 0; indexColumn < mat[indexRow].Length; indexColumn++)
                {
                    if (!acceptedValues.Contains(mat[indexRow][indexColumn]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int[] rowAndMaximumOnes(int[][] mat)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
            for (int indexRow = 0; indexRow < mat.Length; indexRow++)
            {
                int countOnes = 0;
                for (int indexColumn = 0; indexColumn < mat[indexRow].Length; indexColumn++)
                {
                    if (mat[indexRow][indexColumn] == 1)
                    {
                        countOnes++;
                    }
                }
                dict.Add(indexRow, countOnes);
            }
            int max = dict.OrderByDescending(x => x.Value).First().Value;
            int min = Int32.MaxValue;
            foreach (var pair in dict)
            {
                if (pair.Value == max && min > pair.Key)
                {
                    min = pair.Key;
                }
            }
            return new int[] { min, max };
        }
    }
}
