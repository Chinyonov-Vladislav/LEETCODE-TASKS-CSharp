using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Tasks.task661
{
    /*
     661. Сглаживание изображения
    Сглаживатель изображений — это фильтр размером 3 x 3, который можно применить к каждой ячейке изображения, округлив среднее значение ячейки и восьми соседних ячеек (т. е. среднее значение девяти ячеек в синем сглаживателе). 
    Если одна или несколько соседних ячеек отсутствуют, мы не учитываем их при вычислении среднего значения (т. е. среднее значение четырёх ячеек в красном сглаживателе).
    Учитывая m x n целочисленную матрицу img, представляющую оттенки серого на изображении, верните изображение после применения сглаживания к каждой его ячейке.
     https://leetcode.com/problems/image-smoother/description/
     */
    public class Task661 : InfoBasicTask
    {
        public Task661(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] image = new int[][] {
               new int[] { 100,200,100 },
               new int[] { 200,50,200 },
               new int[] { 100,200,100 }
            };
            int[][] imageSmooth = imageSmoother(image);
            printTwoDimensionalArray(imageSmooth, "Результат в виде двумерного массива");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[][] imageSmoother(int[][] img)
        {
            int countRows = img.GetLength(0);
            int[][] result = new int[countRows][];
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                Console.WriteLine($"Index row = {indexRow}");
                result[indexRow] = new int[img[indexRow].Length];
                for (int indexColumn = 0; indexColumn < img[indexRow].Length; indexColumn++)
                {
                    // indexRow и indexColumn - Центр квадрата
                    List<int> elementsInSquare = new List<int>();
                    for (int i = indexRow - 1; i <= indexRow + 1; i++)
                    {
                        for (int j = indexColumn - 1; j <= indexColumn + 1; j++)
                        {
                            if (i >= 0 && i < countRows && j >= 0 && j < img[indexRow].Length)
                            {
                                elementsInSquare.Add(img[i][j]);
                            }
                        }
                    }
                    result[indexRow][indexColumn] = elementsInSquare.Sum() / elementsInSquare.Count();
                }
            }
            return result;
        }
        private int[][] bestSolution(int[][] img)
        {
            int m = img.Length;
            int n = img[0].Length;

            int[][] result = new int[m][];

            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    int items = 0;
                    int total = 0;
                    for (int i2 = i - 1; i2 <= i + 1; i2++)
                    {
                        if (i2 < 0)
                        {
                            continue;
                        }
                        if (i2 == m)
                        {
                            continue;
                        }
                        for (int j2 = j - 1; j2 <= j + 1; j2++)
                        {
                            if (j2 < 0)
                            {
                                continue;
                            }
                            if (j2 == n)
                            {
                                continue;
                            }
                            total += img[i2][j2];
                            items++;
                        }
                    }
                    result[i][j] = total / items;
                }
            }

            return result;
        }
    }
}
