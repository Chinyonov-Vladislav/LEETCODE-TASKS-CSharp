using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task733
{
    /*
     733. Заливка флудом
    Вам дано изображение, представленное в виде m x n сетки из целых чисел image, где image[i][j] обозначает значение пикселя изображения. Вам также даны три целых числа sr, sc, и color. 
    Ваша задача — выполнить заливку изображения, начиная с пикселя image[sr][sc].
    Для выполнения заливки потоком:
        Начните с начального пикселя и измените его цвет на color.
        Выполните ту же операцию для каждого пикселя, который непосредственно примыкает (пиксели, которые имеют общую сторону с исходным пикселем по горизонтали или вертикали) и имеет тот же цвет, что и исходный пиксель.
        Продолжайте повторять этот процесс, проверяя соседние пиксели обновлённых пикселей и изменяя их цвет, если он совпадает с исходным цветом начального пикселя.
        Процесс завершается, когда больше нет соседних пикселей исходного цвета для обновления.
    Верните измененное изображение после выполнения заливки заливкой.
    https://leetcode.com/problems/flood-fill/description/
     */
    public class Task733 : InfoBasicTask
    {
        public Task733(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] image = new int[3][] {
                new int[] { 1,1,1 },
                new int[] { 1,1,0 },
                new int[] { 1,0,1 },
            };
            printTwoDimensionalArray(image, "Оригинальное изображение");
            int row = 1;
            int column = 1;
            int color = 2;
            int[][] finalImage = floodFill(image, row, column, color);
            printTwoDimensionalArray(finalImage, "Изображение после преобразований");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[][] floodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color)
            {
                return image;
            }
            int colorOfOriginalPixel = image[sr][sc];
            image[sr][sc] = color;
            recursiveColor(image, sr, sc, color, colorOfOriginalPixel);
            return image;
        }
        private void recursiveColor(int[][] image, int row, int column, int color, int originalColor)
        {
            if (row - 1 >= 0 && row - 1 <= image.Length-1 && image[row - 1][column] == originalColor) // влево
            {
                image[row - 1][column] = color;
                recursiveColor(image, row - 1, column, color, originalColor);
            }
            if (row + 1 >= 0 && row + 1 <= image.Length-1 && image[row + 1][column] == originalColor) // вправо
            {
                image[row + 1][column] = color;
                recursiveColor(image, row + 1, column, color, originalColor);
            }
            if (column-1 >= 0 && column - 1 <= image[row].Length-1 && image[row][column -1] == originalColor) // вверх
            {
                image[row][column -1] = color;
                recursiveColor(image, row, column - 1, color, originalColor);
            }
            if (column + 1 >= 0 && column + 1 <= image[row].Length - 1 && image[row][column + 1] == originalColor) // вниз
            {
                image[row][column + 1] = color;
                recursiveColor(image, row, column + 1, color, originalColor);
            }
        }
    }
}
