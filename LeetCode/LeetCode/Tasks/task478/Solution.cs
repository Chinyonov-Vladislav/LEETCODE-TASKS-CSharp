using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task478
{
    public class Solution
    {
        private Random rnd;
        private double radius;
        private double x_center;
        private double y_center;
        public Solution(double radius, double x_center, double y_center)
        {
            rnd = new Random();
            this.radius = radius;
            this.x_center = x_center;
            this.y_center = y_center;
        }

        public double[] randPoint()
        {
            double theta = rnd.NextDouble() * 2 * Math.PI;
            double r = radius * Math.Sqrt(rnd.NextDouble());
            return new double[] { x_center + r * Math.Cos(theta), y_center + r * Math.Sin(theta) };
        }
    }
}
