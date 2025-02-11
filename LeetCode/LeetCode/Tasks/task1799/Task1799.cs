using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1799
{
    /*
     1779. Найдите ближайшую точку с такими же координатами X или Y
    Вам даны два целых числа, x и y, которые представляют ваше текущее местоположение на декартовой сетке: (x, y). Вам также дан массив points, где каждое points[i] = [ai, bi] означает, что точка существует в (ai, bi). Точка действительна, если она имеет ту же координату x или ту же координату y, что и ваше местоположение.
    Верните индекс (с индексом 0) действительной точки с наименьшим расстоянием до Манхэттена от вашего текущего местоположения. Если их несколько, верните допустимую точку с наименьшим индексом. Если действительных баллов нет, вернитесь -1.
    Манхэттенское расстояние между двумя точками (x1, y1) и (x2, y2) равно abs(x1 - x2) + abs(y1 - y2).
    https://leetcode.com/problems/find-nearest-point-that-has-the-same-x-or-y-coordinate/description/
     */
    public class Task1799 : InfoBasicTask
    {
        public Task1799(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] points = new int[][] {
                new int[] {1,2 },
                new int[] {3,1 },
                new int[] {2,4 },
                new int[] {2,3 },
                new int[] {4,4 },
            };
            printTwoDimensionalArray(points, "Массив точек");
            int x = 3;
            int y = 4;
            Console.WriteLine($"Координата X = {x} | Координата Y = {y}");
            int index = nearestValidPoint(x,y,points);
            Console.WriteLine(index == -1 ? "Отсутствует валидная ближайшая точка с такими же координатами X или Y" : $"Индекс ближайшей точки с такими же координатами X или Y = {index}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int nearestValidPoint(int x, int y, int[][] points)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i][0] == x || points[i][1] == y)
                {
                    int distance = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
                    dict.Add(i, distance);
                }
            }
            if (dict.Count == 0)
            {
                return -1;
            }
            return dict.OrderBy(item => item.Value).First().Key;
        }
    }
}
