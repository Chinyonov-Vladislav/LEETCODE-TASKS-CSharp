using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1030
{
    /*
     1030. Ячейки матрицы в порядке удаления
    Вам даны четыре целых числа row, cols, rCenter, и cCenter. Существует матрица rows x cols, и вы находитесь в ячейке с координатами (rCenter, cCenter).
    Верните координаты всех ячеек в матрице, отсортированные по их расстоянию от (rCenter, cCenter) наименьшего расстояния до наибольшего. Вы можете вернуть ответ в любом порядке, удовлетворяющем этому условию.
    Расстояние между двумя ячейками (r1, c1) и (r2, c2) равно |r1 - r2| + |c1 - c2|.
    Ограничения:
        1 <= rows, cols <= 100
        0 <= rCenter < rows
        0 <= cCenter < cols
    https://leetcode.com/problems/matrix-cells-in-distance-order/description/
     */
    public class Task1030 : InfoBasicTask
    {
        public Task1030(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int rows = 2;
            int cols = 3;
            int rCenter = 1;
            int cCenter = 2;
            Console.WriteLine($"Количество строк = {rows}\nКоличество столбцов = {cols}\nКоордината X выбранной точки = {rCenter}\nКоордината Y выбранной точки = {cCenter}\n");
            if (isValid(rows, cols, rCenter, cCenter))
            {
                int[][] res = allCellsDistOrder(rows, cols, rCenter, cCenter);
                printTwoDimensionalArray(res, "Результирующий двумерный массив");
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
        private bool isValid(int rows, int cols, int rCenter, int cCenter)
        {
            if (rows < 1 || rows > 100 || cols < 1 || cols > 100 || rCenter < 0 || rCenter >= rows || cCenter < 0 || cCenter >= cols)
            {
                return false;
            }
            return true;
        }
        private int[][] allCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>();
            int[][] res = new int[rows * cols][];
            for (int indexRow = 0; indexRow < rows;indexRow++)
            {
                for (int indexCol = 0; indexCol < cols; indexCol++)
                {
                    int distance = Math.Abs(indexRow - rCenter) + Math.Abs(indexCol - cCenter);
                    if (dict.ContainsKey(distance))
                    {
                        dict[distance].Add(new int[] { indexRow, indexCol });
                    }
                    else
                    {
                        dict.Add(distance, new List<int[]>() { new int[] { indexRow, indexCol } });
                    }
                }
            }
            Dictionary<int, List<int[]>> orderedDict = dict.OrderBy(x => x.Key).ToDictionary(item => item.Key, item => item.Value);
            int index = 0;
            foreach (var pair in orderedDict)
            {
                for (int i = 0; i < pair.Value.Count; i++)
                {
                    res[index] = pair.Value[i];
                    index++;
                }
            }
            return res;
        }
    }
}
