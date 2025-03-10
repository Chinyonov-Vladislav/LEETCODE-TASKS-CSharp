using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3200
{
    /*
     3200. Максимальная высота треугольника
    Вам даны два целых числа red и blue, обозначающие количество красных и синих шаров. 
    Вы должны расположить эти шары так, чтобы они образовали треугольник, в котором в 1-м ряду будет 1 шар, во 2-м ряду будет 2 шара, в 3-м ряду будет 3 шара и так далее.
    Все шарики в одном ряду должны быть одинакового цвета, а в соседних рядах цвета должны отличаться.
    Верните максимальную высоту треугольника, которая может быть достигнута.
    Ограничения:
        1 <= red, blue <= 100
    https://leetcode.com/problems/maximum-height-of-a-triangle/description/
     */
    public class Task3200 : InfoBasicTask
    {
        public Task3200(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int red = 2;
            int blue = 4;
            Console.WriteLine($"Красных шаров = {red}\nСиних шаров = {blue}");
            if (isValid(red, blue))
            {
                int maxHeight = maxHeightOfTriangle(red, blue);
                Console.WriteLine($"Максимальная высота треугольника, составленного из {red} красных и {blue} синих шаров, " +
                    $"где все шарики в одном ряду должны быть одинакового цвета, а в соседних рядах цвета должны отличаться , а количество шаров равно номеру ряда, " +
                    $"начиная с вершины = {maxHeight}");
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
        private bool isValid(int red, int blue)
        {
            if (red < 1 || red>100 || blue < 1 || blue > 100)
            {
                return false;
            }
            return true;
        }
        private int maxHeightOfTriangle(int red, int blue)
        {
            int heightTriangleRed = 0;
            int heightTriangleBlue = 0;
            int copyRed = red;
            int copyBlue = blue;
            for (int i = 0; ; i++)
            {
                if (i % 2 == 0)
                {
                    copyRed -= (i + 1);
                    if (copyRed < 0)
                    {
                        break;
                    }
                }
                else
                {
                    copyBlue -= (i + 1);
                    if (copyBlue < 0)
                    {
                        break;
                    }
                }
                heightTriangleRed++;
            }
            copyRed = red;
            copyBlue = blue;
            for (int i = 0; ; i++)
            {
                if (i % 2 == 0)
                {
                    copyBlue -= (i + 1);
                    if (copyBlue < 0)
                    {
                        break;
                    }
                }
                else
                {
                    copyRed -= (i + 1);
                    if (copyRed < 0)
                    {
                        break;
                    }
                }
                heightTriangleBlue++;
            }
            return Math.Max(heightTriangleRed, heightTriangleBlue);
        }
    }
}
