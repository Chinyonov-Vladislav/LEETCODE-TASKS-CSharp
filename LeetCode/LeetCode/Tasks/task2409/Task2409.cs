using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2409
{
    /*
     2409. Количество дней, проведенные вместе
    Алиса и Боб едут в Рим на отдельные деловые встречи.
    Вам даны 4 строки arriveAlice, leaveAlice, arriveBob, и leaveBob. 
    Элис будет в городе с arriveAlice по leaveAlice (включительно), а Боб будет в городе с arriveBob по leaveBob (включительно). 
    Каждая из них будет представлять собой 5-значную строку в формате "MM-DD", соответствующем месяцу и дню недели.
    Верните общее количество дней, которые Алиса и Боб провели в Риме вместе.
    Вы можете предположить, что все даты относятся к одному и тому же календарному году, который не является високосным. Обратите внимание, что количество дней в месяце можно представить в виде: [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31].
    Ограничения:
        Все даты указаны в следующем формате "MM-DD".
        Даты прибытия Алисы и Бобараньше или равныдатам их отъезда.
        Указанные даты являются действительными датами не високосного года.
    https://leetcode.com/problems/count-days-spent-together/description/
     */
    public class Task2409 : InfoBasicTask
    {
        public Task2409(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string arriveAlice = "09-01";
            string leaveAlice = "10-19";
            string arriveBob = "06-19";
            string leaveBob = "10-20";
            Console.WriteLine($"Дата прибытия Алисы = \"{arriveAlice}\". Дата убытия Алисы = \"{leaveAlice}\"\nДата прибытия Боба = \"{arriveBob}\". Дата убытия Боба = \"{leaveBob}\"");
            int result = countDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob);
            Console.WriteLine($"Количество дней, пробытых вместе = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int countDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
        {
            int count = 0;
            int[] days = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            HashSet<string> set = new HashSet<string>();
            string[] partArriveAlice = arriveAlice.Split('-');
            int monthArriveAlice = Convert.ToInt32(partArriveAlice[0]);
            int dateArriveAlice = Convert.ToInt32(partArriveAlice[1]);

            string[] partLeaveAlice = leaveAlice.Split('-');
            int monthLeaveAlice = Convert.ToInt32(partLeaveAlice[0]);
            int dateLeaveAlice = Convert.ToInt32(partLeaveAlice[1]);

            string[] partArriveBob = arriveBob.Split('-');
            int monthArriveBob = Convert.ToInt32(partArriveBob[0]);
            int dateArriveBob = Convert.ToInt32(partArriveBob[1]);
            string[] partLeaveBob = leaveBob.Split('-');
            int monthLeaveBob = Convert.ToInt32(partLeaveBob[0]);
            int dateLeaveBob = Convert.ToInt32(partLeaveBob[1]);
            if (monthArriveAlice == monthLeaveAlice)
            {
                for (int startDate = dateArriveAlice; startDate <= dateLeaveAlice; startDate++)
                {
                    string date = $"{monthArriveAlice}-{startDate}";
                    set.Add(date);
                }
            }
            else
            {
                for (int startMonth = monthArriveAlice; startMonth <= monthLeaveAlice; startMonth++)
                {
                    int startDate = 0;
                    int limit = 0;
                    if (startMonth == monthArriveAlice)
                    {
                        startDate = dateArriveAlice;
                        limit = days[startMonth - 1];

                    }
                    else if (startMonth != monthLeaveAlice)
                    {
                        startDate = 1;
                        limit = days[startMonth - 1];
                    }
                    else
                    {
                        startDate = 1;
                        limit = dateLeaveAlice;
                    }
                    for (; startDate <= limit; startDate++)
                    {
                        string date = $"{startMonth}-{startDate}";
                        set.Add(date);
                    }
                }
            }
            if (monthArriveBob == monthLeaveBob)
            {
                for (int startDate = dateArriveBob; startDate <= dateLeaveBob; startDate++)
                {
                    string date = $"{monthArriveBob}-{startDate}";
                    if (set.Contains(date))
                    {
                        count++;
                    }
                }
            }
            else
            {
                for (int startMonth = monthArriveBob; startMonth <= monthLeaveBob; startMonth++)
                {
                    int startDate = 0;
                    int limit = 0;
                    if (startMonth == monthArriveBob)
                    {
                        startDate = dateArriveBob;
                        limit = days[startMonth - 1];

                    }
                    else if (startMonth != monthLeaveBob)
                    {
                        startDate = 1;
                        limit = days[startMonth - 1];
                    }
                    else
                    {
                        startDate = 1;
                        limit = dateLeaveBob;
                    }
                    for (; startDate <= limit; startDate++)
                    {
                        string date = $"{startMonth}-{startDate}";
                        if (set.Contains(date))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
