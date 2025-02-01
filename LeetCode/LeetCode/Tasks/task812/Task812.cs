using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task812
{
    /*
     812. Наибольшая площадь треугольника
    Учитывая массив точек на плоскости X-Y points с координатами points[i] = [xi, yi], верните площадь наибольшего треугольника, который можно образовать из любых трёх разных точек. 
    Будут приняты ответы в пределах 10-5 от фактического ответа.
    https://leetcode.com/problems/largest-triangle-area/description/
     */
    public class Task812 : InfoBasicTask
    {
        public Task812(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] points = new int[5][] {
                new int[] { 0,0 },
                new int[] { 0,1  },
                new int[] { 1,0 },
                new int[] { 0,2 },
                new int[] { 2,0 }
            }; 
            double maxArea = largestTriangleArea(points);
            Console.WriteLine($"Максимальная площадь треугольника = {maxArea}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private double largestTriangleArea(int[][] points)
        {
            double maxArea = 0;
            for (int indexFirstPoint = 0; indexFirstPoint <= points.Length-3; indexFirstPoint++)
            {
                for (int indexSecondPoint = 0; indexSecondPoint < points.Length; indexSecondPoint++)
                {
                    if (indexSecondPoint == indexFirstPoint)
                    {
                        continue;
                    }
                    for (int indexThirdPoint = 0; indexThirdPoint < points.Length; indexThirdPoint++)
                    {
                        if (indexSecondPoint == indexThirdPoint || indexThirdPoint == indexFirstPoint)
                        {
                            continue;
                        }
                        int[] firstPoint = points[indexFirstPoint]; // A
                        int[] secondPoint = points[indexSecondPoint]; // B
                        int[] thirdPoint = points[indexThirdPoint]; // C
                        double lengthOfFirstSide = Math.Sqrt(Math.Pow(secondPoint[0] - firstPoint[0],2)+Math.Pow(secondPoint[1] - firstPoint[1], 2));//AB
                        double lengthOfSecondSide = Math.Sqrt(Math.Pow(secondPoint[0] - thirdPoint[0], 2) + Math.Pow(secondPoint[1] - thirdPoint[1], 2)); //BC
                        double lengthOfThirdSide = Math.Sqrt(Math.Pow(thirdPoint[0] - firstPoint[0], 2) + Math.Pow(thirdPoint[1] - firstPoint[1], 2));//CA
                        double halfPerimeter = (lengthOfFirstSide + lengthOfSecondSide + lengthOfThirdSide)/2;
                        double area = Math.Sqrt(halfPerimeter * (halfPerimeter - lengthOfFirstSide) * (halfPerimeter - lengthOfSecondSide) * (halfPerimeter - lengthOfThirdSide));
                        if (area > maxArea)
                        {
                            maxArea = area;
                        }
                    }
                }
            }
            return maxArea;
        }
        // скопировано с leetcode

        private double bestSolution(int[][] points)
        {
            double maxArea = 0;
            int n = points.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        maxArea = Math.Max(maxArea, CalculateArea(points[i], points[j], points[k]));
                    }
                }
            }

            return maxArea;
        }

        private double CalculateArea(int[] p1, int[] p2, int[] p3)
        {
            // calculate Area with determinant formula 1/2 * ( x1(y2-y3) + x2(y3-y1) + x3(y1-y2) )
            return Math.Abs(.5 * (p1[0] * (p2[1] - p3[1]) + p2[0] * (p3[1] - p1[1]) + p3[0] * (p1[1] - p2[1])));
        }

    }
}
