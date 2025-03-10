using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3184
{
    /*
     3184. Подсчитайте пары, которые образуют полный день
    Учитывая целочисленный массив hours со временем в часах, верните целое число, обозначающее количество пар i, j где i < j и hours[i] + hours[j] образуют полный день.
    Полный день определяется как промежуток времени, точно кратный 24 часам.
    Например, 1 день — это 24 часа, 2 дня — это 48 часов, 3 дня — это 72 часа и так далее.
    Ограничения:
        1 <= hours.length <= 100
        1 <= hours[i] <= 10^9
    https://leetcode.com/problems/count-pairs-that-form-a-complete-day-i/description/
     */
    public class Task3184 : InfoBasicTask
    {
        public Task3184(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] hours = new int[] { 12, 12, 30, 24, 24 };
            printArray(hours, "Массив значения часов компоненты времени: ");
            if (isValid(hours))
            {
                int count = countCompleteDayPairs(hours);
                Console.WriteLine($"Количество пар часов, образующих полный день = {count}");
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
        private bool isValid(int[] hours)
        {
            if (hours.Length < 1 || hours.Length > 100)
            {
                return false;
            }
            int highLimit = (int)Math.Pow(10, 9);
            foreach (int hour in hours) {
                if (hour < 1 || hour > highLimit)
                {
                    return false;
                }
            }
            return true;
        }
        private int countCompleteDayPairs(int[] hours)
        {
            int count = 0;
            for (int i = 0; i < hours.Length - 1; i++)
            {
                for (int j = i + 1; j < hours.Length; j++)
                {
                    if ((hours[i] + hours[j]) % 24 == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
