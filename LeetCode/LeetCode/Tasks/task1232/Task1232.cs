using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1232
{
    /*
     1232. Проверьте, является ли это прямой линией
    Вам дан массив coordinates, coordinates[i] = [x, y], где [x, y] обозначает координаты точки. Проверьте, образуют ли эти точки прямую линию на плоскости XY.
    https://leetcode.com/problems/check-if-it-is-a-straight-line/description/
     */
    public class Task1232 : InfoBasicTask
    {
        public Task1232(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] points = new int[][] {
                new int[] {1,1},
                new int[] {2 ,2},
                new int[] { 3,4},
                new int[] { 4,5},
                new int[] { 5,6},
                new int[] { 7,7}
            };
            Console.WriteLine("Координаты точек");
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine($"Точка №{i + 1}: x = {points[i][0]} y = {points[i][1]}");
            }
            Console.WriteLine(checkStraightLine(points) ? "Точки лежат на одной линии" : "Точки не лежат на одной линии");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool checkStraightLine(int[][] coordinates)
        {
            if (coordinates.Length == 2)
            {
                return true;
            }
            for (int i = 2; i < coordinates.Length; i++)
            {
                int x1 = coordinates[i-2][0];
                int x2 = coordinates[i - 1][0];
                int x3 = coordinates[i][0];
                int y1 = coordinates[i - 2][1];
                int y2 = coordinates[i - 1][1];
                int y3 = coordinates[i][1];
                double area = 0.5 * Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
                if (area != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
