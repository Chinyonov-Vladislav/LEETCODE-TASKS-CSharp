using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task832
{
    /*
     832. Переворачивание изображения
    Дано n x n двоичное изображение image, переверните его по горизонтали, затем инвертируйте и верните полученное изображение.
    Переворачивание изображения по горизонтали означает, что каждая строка изображения перевернута.
        Например, переворачивание [1,1,0] по горизонтали приводит к [0,1,1].
    Инвертировать изображение означает заменить каждый 0 на 1, а каждый 1 на 0.
        Например, инвертирование [0,1,1] приводит к [1,0,0].
    https://leetcode.com/problems/flipping-an-image/description/
     */
    public class Task832 : InfoBasicTask
    {
        public Task832(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] nums = new int[][] {
                new int[] { 1,1,0 },
                new int[] { 1,0,1 },
                new int[] { 0,0,0 },
            };
            printTwoDimensionalArray(nums, "Оригинальный массив");
            nums = flipAndInvertImage(nums);
            printTwoDimensionalArray(nums, "Массив после преобразования");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[][] flipAndInvertImage(int[][] image)
        {
            for (int row = 0; row < image.Length; row++)
            {
                int left = 0;
                int right = image[row].Length - 1;
                while (left < right)
                {
                    (image[row][left], image[row][right]) = (image[row][right], image[row][left]);
                    image[row][left] = image[row][left] == 0 ? 1 : 0;
                    image[row][right] = image[row][right] == 0 ? 1 : 0;
                    left++;
                    right--;
                }
                if (image.Length % 2 != 0)
                {
                    int mid = image.Length / 2;
                    image[row][mid] = image[row][mid] == 0 ? 1 : 0;
                }
            }
            return image;
        }
    }
}
