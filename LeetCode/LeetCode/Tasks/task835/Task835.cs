using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task835
{
    /*
     835. Наложение изображений
    Вам даны два изображения, img1 и img2, представленные в виде двоичных квадратных матриц размером n x n. Двоичная матрица содержит только значения 0 и 1.
    Мы перемещаем одно изображение так, как нам нужно, сдвигая все 1 биты влево, вправо, вверх и/или вниз на любое количество единиц. Затем мы накладываем его на другое изображение. После этого мы можем вычислить пересечение, посчитав количество позиций, в которых 1 есть на обоих изображениях.
    Также обратите внимание, что при переводе не выполняется поворот. Любые 1 биты, которые переводятся за пределы матрицы, стираются.
    Возвращает максимально возможное перекрытие.
    Ограничения:
        n == img1.length == img1[i].length
        n == img2.length == img2[i].length
        1 <= n <= 30
        img1[i][j] является либо 0, либо 1.
        img2[i][j] является либо 0, либо 1.
    https://leetcode.com/problems/image-overlap/description/
     */
    public class Task835 : InfoBasicTask
    {
        public Task835(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] img1 = new int[][] {
                new int[] { 1,1,0 },
                new int[] { 0,1,0 },
                new int[] { 0, 1, 0 }
            };
            int[][] img2 = new int[][] {
                new int[] { 0,0,0 },
                new int[] {0,1,1  },
                new int[] { 0, 0, 1 }
            };
            printTwoDimensionalArray(img1, "Двумерный массив бинарного изображения №1");
            printTwoDimensionalArray(img2, "Двумерный массив бинарного изображения №2");
            if (isValid(img1, img2))
            {
                int res = largestOverlap(img1, img2);
                Console.WriteLine($"Максимальное возможное перекрытие после сдвига = {res}");
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
        private bool isValid(int[][] img1, int[][] img2)
        {
            int lowLimit = 1;
            int highLimit = 30;
            int countItemsInDimension = img1.Length;
            if (countItemsInDimension < lowLimit || countItemsInDimension > highLimit)
            {
                return false;
            }
            foreach (int[] row in img1)
            {
                if (row.Length != countItemsInDimension)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < 0 || item > 1)
                    {
                        return false;
                    }
                }
            }
            if (img2.Length != countItemsInDimension)
            {
                return false;
            }
            foreach (int[] row in img2)
            {
                if (row.Length != countItemsInDimension)
                {
                    return false;
                }
                foreach (int item in row)
                {
                    if (item < 0 || item > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int largestOverlap(int[][] img1, int[][] img2)
        {
            int maxCount = 0;
            List<int[]> coordinatesImg1 = new List<int[]>();
            List<int[]> coordinatesImg2 = new List<int[]>();
            int countItemInDimension = img1.Length;
            for (int indexRow = 0; indexRow < countItemInDimension; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countItemInDimension; indexColumn++)
                {
                    if (img1[indexRow][indexColumn] == 1)
                    {
                        coordinatesImg1.Add(new int[] { indexRow, indexColumn });
                    }
                }
            }
            for (int indexRow = 0; indexRow < countItemInDimension; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countItemInDimension; indexColumn++)
                {
                    if (img2[indexRow][indexColumn] == 1)
                    {
                        coordinatesImg2.Add(new int[] { indexRow, indexColumn });
                    }
                }
            }
            for (int indexCoordinateImg1 = 0; indexCoordinateImg1 < coordinatesImg1.Count; indexCoordinateImg1++)
            {
                for (int indexCoordinateImg2 = 0; indexCoordinateImg2 < coordinatesImg2.Count; indexCoordinateImg2++)
                {
                    int deltaX = coordinatesImg2[indexCoordinateImg2][0] - coordinatesImg1[indexCoordinateImg1][0];
                    int deltaY = coordinatesImg2[indexCoordinateImg2][1] - coordinatesImg1[indexCoordinateImg1][1];
                    int localMax = 0;
                    for (int indexCoordinate = 0; indexCoordinate < coordinatesImg1.Count; indexCoordinate++)
                    {
                        int newCoordinateX = coordinatesImg1[indexCoordinate][0] + deltaX;
                        int newCoordinateY = coordinatesImg1[indexCoordinate][1] + deltaY;
                        if (newCoordinateX >= 0 && newCoordinateX < countItemInDimension && newCoordinateY >= 0 && newCoordinateY < countItemInDimension)
                        {
                            if (img2[newCoordinateX][newCoordinateY] == 1)
                            {
                                localMax++;
                            }
                        }
                    }
                    if (localMax > maxCount)
                    {
                        maxCount = localMax;
                    }
                }
            }
            return maxCount;
        }
    }
}
