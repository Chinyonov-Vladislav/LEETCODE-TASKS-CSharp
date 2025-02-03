using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1184
{
    /*
     1184. Расстояние между автобусными остановками
    У автобуса n остановок, пронумерованных от 0 до n - 1, которые образуют круг. Мы знаем расстояние между всеми парами соседних остановок, где distance[i] — расстояние между остановками с номерами i и (i + 1) % n.
    Автобус движется в обоих направлениях, то есть по часовой стрелке и против часовой стрелки.
    Возвращает кратчайшее расстояние между заданными start и destination остановками.
    https://leetcode.com/problems/distance-between-bus-stops/description/
     */
    public class Task1184 : InfoBasicTask
    {
        public Task1184(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] distance = new int[] { 7, 10, 1, 12, 11, 14, 5, 0 };
            int start = 7;
            int end = 2;
            printArray(distance, "Расстояние между остановками: ");
            Console.WriteLine($"Стартовая остановка = {start}");
            Console.WriteLine($"Конечная остановка = {end}");
            int minDistance = distanceBetweenBusStops(distance, start, end);
            Console.WriteLine($"Минимальное расстояние между остановками {start} и {end} = {minDistance}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int distanceBetweenBusStops(int[] distance, int start, int destination)
        {
            int distByClockWise = 0;
            int distByСounterClockWise = 0;
            if (start == destination)
            {
                return 0;
            }
            if (start > destination)
            {
                for (int i = start; i < distance.Length; i++)
                {
                    distByClockWise += distance[i];
                }
                for (int i = 0; i < destination; i++)
                {
                    distByClockWise += distance[i];
                }
                for (int i = destination; i < start; i++)
                {
                    distByСounterClockWise += distance[i];
                }
            }
            else
            {
                for (int i = destination; i < distance.Length; i++)
                {
                    distByClockWise += distance[i];
                }
                for (int i = 0; i < start; i++)
                {
                    distByClockWise += distance[i];
                }
                for (int i = start; i < destination; i++)
                {
                    distByСounterClockWise += distance[i];
                }
            }
            return distByClockWise < distByСounterClockWise ? distByClockWise : distByСounterClockWise;
        }
    }
}
