using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task478
{
    /*
     478. Сгенерируйте случайную точку в окружности
    Учитывая радиус и положение центра окружности, реализуйте функцию,randPointкоторая генерирует равномерно распределённую случайную точку внутри окружности.
    Реализации Solution класс:
        Solution(double radius, double x_center, double y_center)инициализирует объект с радиусом окружностиradiusи положением центра(x_center, y_center).
        randPoint()возвращает случайную точку внутри круга. Точка на окружности круга считается находящейся внутри круга. Ответ возвращается в виде массива [x, y].
    Ограничения:
        0 < radius <= 10^8
        -10^7 <= x_center, y_center <= 10^7
        Максимум 3 * 10^4 звонки будут сделаны на randPoint.
    https://leetcode.com/problems/generate-random-point-in-a-circle/description/
     */
    public class Task478 : InfoBasicTask
    {
        public Task478(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            double radius = 1;
            double centerX = 0;
            double centerY = 0;
            Console.WriteLine($"Радиус круга = {radius}\nКоординаты центра ({centerX},{centerY})");
            int countExecuteRandPoint = 3;
            if (isValid(radius, centerX, centerY, countExecuteRandPoint))
            {
                Solution solution = new Solution(radius, centerX, centerY);
                for (int i = 1; i <= countExecuteRandPoint; i++)
                {
                    double[] coord = solution.randPoint();
                    Console.WriteLine($"Точка №{i}: ({coord[0]},{coord[1]})");
                }
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
        private bool isValid(double radius, double centerX, double centerY, int countExecuteRandPoint)
        {
            double lowLimitRadius = 0;
            double highLimitRadius = Math.Pow(10,8);
            double lowLimitCenterCoord = -1* Math.Pow(10, 7);
            double highLimitCenterCoord = Math.Pow(10, 8);
            int lowLimitCountExecuteRandPoint = 1;
            int highLimitCountExecuteRandPoint = 3*(int)Math.Pow(10,4);
            if (radius <= lowLimitRadius || radius > highLimitRadius
                || centerX < lowLimitCenterCoord || centerX > highLimitCenterCoord
                || centerY < lowLimitCenterCoord || centerY > highLimitCenterCoord
                || countExecuteRandPoint < lowLimitCountExecuteRandPoint || countExecuteRandPoint > highLimitCountExecuteRandPoint)
            {
                return false;
            }
            return true;
        }
    }
}
