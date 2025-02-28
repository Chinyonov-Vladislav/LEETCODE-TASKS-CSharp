using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2469
{
    /*
     2469. Преобразуйте температуру
    Вам дано неотрицательное число с плавающей запятой, округлённое до двух знаков после запятой celsius, которое обозначает температуру в градусах Цельсия.
    Вам нужно преобразовать градусы Цельсия в кельвины и градусы Фаренгейта и вернуть результат в виде массива ans = [kelvin, fahrenheit].
    Верните массив ans. Ответы в пределах 10-5 от фактического ответа будут приняты.
    Обратите внимание , что:
        Kelvin = Celsius + 273.15
        Fahrenheit = Celsius * 1.80 + 32.00
    Ограничения:
        0 <= celsius <= 1000
    https://leetcode.com/problems/convert-the-temperature/description/
     */
    public class Task2469 : InfoBasicTask
    {
        public Task2469(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            double celsius = 36.50;
            Console.WriteLine($"Температура по Цельсию = {celsius}");
            if (isValid(celsius))
            {
                double[] res = convertTemperature(celsius);
                Console.WriteLine($"Температура по Кельвину = {res[0]}");
                Console.WriteLine($"Температура по Фаренгейту = {res[1]}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(double c)
        {
            if (c < 0 || c > 1000)
            {
                return false;
            }
            return true;
        }
        private double[] convertTemperature(double celsius)
        {
            return new double[2] { celsius + 273.15, celsius * 1.80 + 32.00 };
        }
    }
}
