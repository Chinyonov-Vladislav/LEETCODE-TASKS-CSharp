using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1736
{
    /*
     1736. Последнее время путем замены скрытых цифр
    Вам дана строка time в виде  hh:mm, где некоторые цифры в строке скрыты (обозначены ?).
    Действительным временем является время включительно между 00:00 и 23:59.
    Верните последнее действительное время, которое вы можете получить, timeзаменив скрытые цифры.
    https://leetcode.com/problems/latest-time-by-replacing-hidden-digits/description/
     */
    public class Task1736 : InfoBasicTask
    {
        public Task1736(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string hiddenTime = "2?:?0";
            Console.WriteLine($"Скрытое время: \"{hiddenTime}\"");
            string time = maximumTime(hiddenTime);
            Console.WriteLine($"Максимальное время из скрытого: \"{time}\"");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string maximumTime(string time)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < time.Length;)
            {
                if (time[i] == '?')
                {
                    if (i == 0)
                    {
                        if (time[i + 1] == '?')
                        {
                            sb.Append('2');
                            sb.Append('3');
                        }
                        else if (time[i + 1] - '0' > 3)
                        {
                            sb.Append('1');
                            sb.Append(time[i + 1]);
                        }
                        else
                        {
                            sb.Append('2');
                            sb.Append(time[i + 1]);
                        }
                        i += 2;
                    }
                    else if (i == 1)
                    {
                        if (time[i - 1] == '1' || time[i - 1] == '0')
                        {
                            sb.Append('9');
                        }
                        else
                        {
                            sb.Append('3');
                        }
                        i++;
                    }
                    else if (i == 3)
                    {
                        sb.Append('5');
                        i++;
                    }
                    else if (i == 4)
                    {
                        sb.Append('9');
                        i++;
                    }
                }
                else
                {
                    sb.Append(time[i]);
                    i++;
                }
            }
            return sb.ToString();
        }
    }
}
