using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task764
{
    /*
     764. Самый большой знак плюс
    Вам дано целое число n. У вас есть n x n двоичная сетка grid со всеми исходными значениями 1's, за исключением некоторых индексов, указанных в массиве mines. ith Элемент массива mines определяется как mines[i] = [xi, yi] где grid[xi][yi] == 0.
    Возврат порядок наибольшего значения выровнено по оси знак плюс 1содержится в grid. Если thздесь нет ни одного, верните 0.
    Знак «плюс», ориентированный по оси, из 1's порядка k имеет центр grid[r][c] == 1 и четыре стороны длиной k - 1 вверх, вниз, влево и вправо, состоящие из 1's. Обратите внимание, что за пределами сторон знака «плюс» могут быть 0's или 1's, проверяется только соответствующая область знака «плюс» на наличие 1's.
    Ограничения:
        1 <= n <= 500
        1 <= mines.length <= 5000
        0 <= xi, yi < n
        Все пары (xi, yi) являются уникальными.
    https://leetcode.com/problems/largest-plus-sign/description/
     */
    public class Task764 : InfoBasicTask
    {
        public Task764(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 5;
            int[][] mines = new int[][] { new int[] { 4, 2 } };
            Console.WriteLine($"Размер поля: {n}x{n}");
            printTwoDimensionalArray(mines, "Координаты мин");
            if (isValid(n, mines))
            {
                int res = orderOfLargestPlusSign(n, mines);
                Console.WriteLine($"Наибольший порядок возможного креста = {res}");
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
        private bool isValid(int n, int[][] mines)
        {
            int lowLimitN = 1;
            int highLimitN = 500;
            int lowLimitMinesLength = 1;
            int highLimitMinesLength = 5000;
            if (n < lowLimitN || n > highLimitN || mines.Length < lowLimitMinesLength || mines.Length > highLimitMinesLength)
            {
                return false;
            }
            foreach (int[] mine in mines)
            {
                if (mine.Length != 2)
                {
                    return false;
                }
                if (mine[0] < 0 || mine[0] >= n || mine[1] < 0 || mine[1] >= n)
                {
                    return false;
                }
            }
            for (int i = 0; i < mines.Length; i++)
            {
                for (int j = 0; j < mines.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (mines[i][0] == mines[j][0] && mines[i][1] == mines[j][1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int orderOfLargestPlusSign(int n, int[][] mines)
        {
            int[,] matrix = new int[n, n];
            for (int indexRow = 0; indexRow < n; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < n; indexColumn++)
                {
                    matrix[indexRow, indexColumn] = 1;
                }
            }
            for (int index = 0; index < mines.Length; index++)
            {
                int currentIndexRowMine = mines[index][0];
                int currentIndexColumnMine = mines[index][1];
                matrix[currentIndexRowMine, currentIndexColumnMine] = 0;
            }
            int[,] upMatrix = new int[n, n];
            int[,] downMatrix = new int[n, n];
            int[,] leftMatrix = new int[n, n];
            int[,] rightMatrix = new int[n, n];
            // заполнение матрицы вверх
            for (int indexRow = 0; indexRow < n; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < n; indexColumn++)
                {
                    if (matrix[indexRow, indexColumn] == 1)
                    {
                        int upRow = indexRow - 1;
                        int upColumn = indexColumn;
                        if (upRow >= 0 && upRow < n && upColumn >= 0 && upColumn < n)
                        {
                            upMatrix[indexRow, indexColumn] = upMatrix[upRow, upColumn] + 1;
                        }
                        else
                        {
                            upMatrix[indexRow, indexColumn] = 1;
                        }
                    }
                }
            }
            // заполнение матрицы влево
            for (int indexColumn = 0; indexColumn < n; indexColumn++)
            {
                for (int indexRow = 0; indexRow < n; indexRow++)
                {
                    if (matrix[indexRow, indexColumn] == 1)
                    {
                        int leftRow = indexRow;
                        int leftColumn = indexColumn - 1;
                        if (leftRow >= 0 && leftRow < n && leftColumn >= 0 && leftColumn < n)
                        {
                            leftMatrix[indexRow, indexColumn] = leftMatrix[leftRow, leftColumn] + 1;
                        }
                        else
                        {
                            leftMatrix[indexRow, indexColumn] = 1;
                        }
                    }
                }
            }
            // заполнение матрицы вниз
            for (int indexRow = n - 1; indexRow >= 0; indexRow--)
            {
                for (int indexColumn = n - 1; indexColumn >= 0; indexColumn--)
                {
                    if (matrix[indexRow, indexColumn] == 1)
                    {
                        int downRow = indexRow + 1;
                        int downColumn = indexColumn;
                        if (downRow >= 0 && downRow < n && downColumn >= 0 && downColumn < n)
                        {
                            downMatrix[indexRow, indexColumn] = downMatrix[downRow, downColumn] + 1;
                        }
                        else
                        {
                            downMatrix[indexRow, indexColumn] = 1;
                        }
                    }
                }
            }
            // заполнение матрицы вправо
            for (int indexColumn = n - 1; indexColumn >= 0; indexColumn--)
            {
                for (int indexRow = n - 1; indexRow >= 0; indexRow--)
                {
                    if (matrix[indexRow, indexColumn] == 1)
                    {
                        int rightRow = indexRow;
                        int rightColumn = indexColumn + 1;
                        if (rightRow >= 0 && rightRow < n && rightColumn >= 0 && rightColumn < n)
                        {
                            rightMatrix[indexRow, indexColumn] = rightMatrix[rightRow, rightColumn] + 1;
                        }
                        else
                        {
                            rightMatrix[indexRow, indexColumn] = 1;
                        }
                    }
                }
            }
            int maxOrder = 0;
            for (int indexRow = 0; indexRow < n; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < n; indexColumn++)
                {
                    int currentOrder = Math.Min(upMatrix[indexRow, indexColumn], Math.Min(downMatrix[indexRow, indexColumn], Math.Min(leftMatrix[indexRow, indexColumn], rightMatrix[indexRow, indexColumn])));
                    if (currentOrder > maxOrder)
                    {
                        maxOrder = currentOrder;
                    }
                }
            }
            return maxOrder;
        }
    }
}
