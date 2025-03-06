using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3000
{
    /*
     3000. Максимальная площадь прямоугольника с самой длинной диагональю
    Вам дан двумерный нумерованный с 0 целочисленный массив dimensions.
    Для всех индексов i 0 <= i < dimensions.length dimensions[i][0] обозначает длину, а dimensions[i][1] обозначает ширину прямоугольника i.
    Верните площадь прямоугольника с самой длинной диагональю. Если таких прямоугольников несколько, верните площадь прямоугольника с самой большой площадью.
    Ограничения:
        1 <= dimensions.length <= 100
        dimensions[i].length == 2
        1 <= dimensions[i][0], dimensions[i][1] <= 100
    https://leetcode.com/problems/maximum-area-of-longest-diagonal-rectangle/description/
     */
    public class Task3000 : InfoBasicTask
    {
        public Task3000(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] dimensions = new int[][] {
                new int[] { 9, 3 },
                new int[] { 8, 6 },
            };
            printTwoDimensionalArray(dimensions, "Двумерный массив");
            if (isValid(dimensions))
            {
                int area = areaOfMaxDiagonal(dimensions);
                Console.WriteLine($"Площадь прямоугольника с самой длинной диагональю = {area}");
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
        private bool isValid(int[][] dimensions)
        {
            if (dimensions.Length < 1 || dimensions.Length > 100)
            {
                return false;
            }
            foreach (int[] arr in dimensions)
            {
                if (arr.Length != 2)
                {
                    return false;
                }
                if (arr[0] < 1 || arr[0] > 100 || arr[1] < 1 || arr[1] > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int areaOfMaxDiagonal(int[][] dimensions)
        {
            Dictionary<double, List<int[]>> dict = new Dictionary<double, List<int[]>>();
            for (int i = 0; i < dimensions.Length; i++)
            {
                double localDiagonal = Math.Sqrt(dimensions[i][0] * dimensions[i][0] + dimensions[i][1] * dimensions[i][1]);
                if (!dict.ContainsKey(localDiagonal))
                {
                    dict.Add(localDiagonal, new List<int[]>() { dimensions[i] });
                }
                else
                {
                    dict[localDiagonal].Add(dimensions[i]);
                }
            }
            List<int[]> dimensionsWithMaxDiagonal = dict.OrderByDescending(x => x.Key).First().Value;
            int maxArea = dimensionsWithMaxDiagonal[0][0] * dimensionsWithMaxDiagonal[0][1];
            for (int i = 1; i < dimensionsWithMaxDiagonal.Count; i++)
            {
                int localArea = dimensionsWithMaxDiagonal[i][0] * dimensionsWithMaxDiagonal[i][1];
                if (localArea > maxArea)
                {
                    maxArea = localArea;
                }
            }
            return maxArea;
        }
    }
}
