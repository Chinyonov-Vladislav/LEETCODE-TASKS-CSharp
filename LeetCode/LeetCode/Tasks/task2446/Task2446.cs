using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2446
{
    /*
     2446. Определите, конфликтуют ли два события
    Вам даны два массива строк, которые представляют собой два события, произошедших в один и тот же день, event1 и event2, где:
        event1 = [startTime1, endTime1] и
        event2 = [startTime2, endTime2].
    Время проведения мероприятия действительно в формате 24 часов в виде HH:MM.
    Конфликт возникает, когда два события имеют некоторое непустое пересечение (то есть какой-то момент является общим для обоих событий).
    Верните true если есть конфликт между двумя событиями. В противном случае верните false.
    Ограничения:
        event1.length == event2.length == 2
        event1[i].length == event2[i].length == 5
        startTime1 <= endTime1
        startTime2 <= endTime2
        Время проведения всех мероприятий соответствует формату HH:MM.

     */
    public class Task2446 : InfoBasicTask
    {
        public Task2446(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] event1 = new string[] { "01:15", "02:00" };
            string[] event2 = new string[] { "02:00", "03:00" };
            Console.WriteLine($"Время первого мероприятия: \"{event1[0]} - {event1[1]}\"");
            Console.WriteLine($"Время второго мероприятия: \"{event2[0]} - {event2[1]}\"");
            if (isValid(event1, event2))
            {
                Console.WriteLine(haveConflict(event1, event2) ? "Существует конфликт времени между двумя мероприятиями" : "Не существует конфликта времени между двумя мероприятиями");
            }
            else
            {
                Console.WriteLine("Исходные данные невалидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string[] event1, string[] event2)
        {
            if (event1.Length != 2 || event2.Length != 2)
            {
                return false;
            }
            List<string[]> events = new List<string[]>() { event1, event2};
            for (int index = 0; index < events.Count; index++)
            {
                string[] currrentEvent = events[index];
                for (int i = 0; i < currrentEvent.Length; i++)
                {
                    if (currrentEvent[i].Length != 5)
                    {
                        return false;
                    }
                    if (currrentEvent[i][2] != ':')
                    {
                        return false;
                    }
                    int firstDigitHour = currrentEvent[i][0] - '0';
                    int secondDigitHour = currrentEvent[i][1] - '0';
                    int firstDigitMinute = currrentEvent[i][3] - '0';
                    int secondDigitMinute = currrentEvent[i][4] - '0';
                    if (firstDigitHour > 2 || firstDigitHour < 0)
                    {
                        return false;
                    }
                    if (firstDigitHour == 2 && (secondDigitHour > 3 || secondDigitHour < 0))
                    {
                        return false;
                    }
                    if (firstDigitHour >= 0 && firstDigitHour <= 1 && (secondDigitHour > 9 || secondDigitHour < 0))
                    {
                        return false;
                    }
                    if (firstDigitMinute > 5 || firstDigitMinute < 0)
                    {
                        return false;
                    }
                    if (secondDigitMinute < 0 || secondDigitMinute > 9)
                    {
                        return false;
                    }

                }
            }
            int startHourEvent1 = Int32.Parse(event1[0].Substring(0, 2));
            int startMinuteEvent1 = Int32.Parse(event1[0].Substring(3));

            int endHourEvent1 = Int32.Parse(event1[1].Substring(0, 2));
            int endMinuteEvent1 = Int32.Parse(event1[1].Substring(3));

            int startHourEvent2 = Int32.Parse(event2[0].Substring(0, 2));
            int startMinuteEvent2 = Int32.Parse(event2[0].Substring(3));

            int endHourEvent2 = Int32.Parse(event2[1].Substring(0, 2));
            int endMinuteEvent2 = Int32.Parse(event2[1].Substring(3));

            int start1 = startHourEvent1 * 60 + startMinuteEvent1;
            int end1 = endHourEvent1 * 60 + endMinuteEvent1;
            int start2 = startHourEvent2 * 60 + startMinuteEvent2;
            int end2 = endHourEvent2 * 60 + endMinuteEvent2;
            if (start1 > end1 || start2 > end2)
            {
                return false;
            }
            return true;
        }
        private bool haveConflict(string[] event1, string[] event2)
        {
            int startHourEvent1 = Int32.Parse(event1[0].Substring(0, 2));
            int startMinuteEvent1 = Int32.Parse(event1[0].Substring(3));

            int endHourEvent1 = Int32.Parse(event1[1].Substring(0, 2));
            int endMinuteEvent1 = Int32.Parse(event1[1].Substring(3));

            int startHourEvent2 = Int32.Parse(event2[0].Substring(0, 2));
            int startMinuteEvent2 = Int32.Parse(event2[0].Substring(3));

            int endHourEvent2 = Int32.Parse(event2[1].Substring(0, 2));
            int endMinuteEvent2 = Int32.Parse(event2[1].Substring(3));

            int start1 = startHourEvent1 * 60 + startMinuteEvent1;
            int end1 = endHourEvent1 * 60 + endMinuteEvent1;
            int start2 = startHourEvent2 * 60 + startMinuteEvent2;
            int end2 = endHourEvent2 * 60 + endMinuteEvent2;
            return start1 <= end2 && start2 <= end1;
        }
    }
}
