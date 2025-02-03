using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1037
{
    /*
     1037. Действительный Бумеранг
    Учитывая массив points, где points[i] = [xi, yi] представляет собой точку на плоскости X-Y, верните true если эти точки являютсябумерангом.
    Бумеранг — это набор из трёх точек, которые все различны и не лежат на прямой.
    https://leetcode.com/problems/valid-boomerang/description/
     */
    public class Task1037 : InfoBasicTask
    {
        public Task1037(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] points = new int[][] {
                new int[] { 1,1},
                new int[] { 2,3},
                new int[] { 3,2}
            };
            printTwoDimensionalArray(points, "Координаты точек");
            Console.WriteLine(isBoomerang(points) ? "Все точки различны и не лежат на одной одной" : "Не все точки различны и лежат на одной одной");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isBoomerang(int[][] points)
        {
            int x1 = points[0][0];
            int x2 = points[1][0];
            int x3 = points[2][0];
            int y1 = points[0][1];
            int y2 = points[1][1];
            int y3 = points[2][1];
            double areaRectange = 0.5 * Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
            return !(areaRectange == 0);
        }
    }
}
