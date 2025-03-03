using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2651
{
    /*
     2651. Рассчитать время прибытия с задержкой
    Вам дано положительное целое число arrivalTime, обозначающее время прибытия поезда в часах, и другое положительное целое число delayedTime, обозначающее время задержки в часах.
    Верните то время, к которому поезд прибудет на станцию.
    Обратите внимание, что время в этой задаче указано в 24-часовом формате.
    Ограничения:
        1 <= arrivaltime < 24
        1 <= delayedTime <= 24
    https://leetcode.com/problems/calculate-delayed-arrival-time/description/
     */
    public class Task2651 : InfoBasicTask
    {
        public Task2651(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int arrivalTime = 13;
            int delayedTime = 11;
            Console.WriteLine($"Время прибытия = {arrivalTime}:00");
            Console.WriteLine($"Время задержки = {delayedTime}:00");
            if (isValid(arrivalTime, delayedTime))
            {
                int newTimeArrival = findDelayedArrivalTime(arrivalTime, delayedTime);
                Console.WriteLine($"Время прибытия с задержкой = {newTimeArrival}:00");
            }
            else {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int arrivalTime, int delayedTime)
        {
            if (!(arrivalTime >= 1 && arrivalTime < 24) || !(delayedTime >= 1 && arrivalTime <= 24))
            {
                return false;
            }
            return true;
        }
        private int findDelayedArrivalTime(int arrivalTime, int delayedTime)
        {
            int newTime = arrivalTime + delayedTime;
            if (newTime >= 24)
            {
                return newTime - 24;
            }
            return newTime;
        }
    }
}
