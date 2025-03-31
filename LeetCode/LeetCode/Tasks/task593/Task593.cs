using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task593
{
    /*
     593. Действительный квадрат
    Учитывая координаты четырёх точек в двумерном пространстве p1, p2, p3 и p4, верните true если эти четыре точки образуют квадрат.
    Координата точки pi представлена в виде [xi, yi]. Входные данные не вводятся в каком-либо порядке.
    Правильный квадрат имеет четыре равные стороны положительной длины и четыре равных угла (по 90 градусов).
    Ограничения:
        p1.length == p2.length == p3.length == p4.length == 2
        -10^4 <= xi, yi <= 10^4
    https://leetcode.com/problems/valid-square/description/
     */
    public class Task593 : InfoBasicTask
    {
        public Task593(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] p1 = new int[] { 0, 0 };
            Console.WriteLine($"Координаты первой точки = ({p1[0]},{p1[1]})");
            int[] p2 = new int[] { 1, 1 };
            Console.WriteLine($"Координаты второй точки = ({p2[0]},{p2[1]})");
            int[] p3 = new int[] { 1, 0 };
            Console.WriteLine($"Координаты третьей точки = ({p3[0]},{p3[1]})");
            int[] p4 = new int[] { 0, 1 };
            Console.WriteLine($"Координаты четвертой точки = ({p4[0]},{p4[1]})");
            if (isValid(p1, p2, p3, p4))
            {
               Console.WriteLine(validSquare(p1, p2, p3, p4) ? "По заданным координатам возможно построить квадрат" : "По заданным координатам невозможно построить квадрат") ;
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
        private bool isValid(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            List<int[]> arrays = new List<int[]>() { p1, p2, p3, p4 };
            int lowLimitValue = -1 * (int)Math.Pow(10, 4);
            int highLimitValue = (int)Math.Pow(10, 4);
            int limitLength = 2;
            foreach (int[] array in arrays) {
                if (array.Length != limitLength)
                {
                    return false;
                }
                foreach (int val in array)
                {
                    if (val < lowLimitValue || val > highLimitValue)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool validSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            List<double> lengths = new List<double>() { };
            List<int[]> arrays = new List<int[]>() { p1, p2, p3, p4 };
            for (int i = 0; i < arrays.Count - 1; i++)
            {
                for (int j = i + 1; j < arrays.Count; j++)
                {
                    double length = Math.Sqrt(Math.Pow(arrays[j][0] - arrays[i][0], 2) + Math.Pow(arrays[j][1] - arrays[i][1], 2));
                    lengths.Add(length);
                }
            }
            lengths.Sort();
            for (int i = 5; i >= 0; i--)
            {
                lengths[i] /= lengths[0];
            }
            if ((Math.Abs(lengths[0] - 1) < 1E-8) &&
                 (Math.Abs(lengths[1] - 1) < 1E-8) &&
                 (Math.Abs(lengths[2] - 1) < 1E-8) &&
                 (Math.Abs(lengths[3] - 1) < 1E-8) &&
                 (Math.Abs(lengths[4] - Math.Sqrt(2)) < 1E-8) &&
                 (Math.Abs(lengths[5] - Math.Sqrt(2)) < 1E-8)
               )
            {
                return true;
            }
            return false;
        }
    }
}
