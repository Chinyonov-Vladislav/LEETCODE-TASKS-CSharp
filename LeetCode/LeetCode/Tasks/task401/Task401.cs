using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task401
{
    public class Task401 : InfoBasicTask
    {
        public Task401(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int turnedOn = 1;
            IList<string> results = readBinaryWatch(turnedOn);
            printIListString(results, $"Количество включенных светодиодов = {turnedOn}. Результаты : ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<string> readBinaryWatch(int turnedOn)
        {
            IList<string> strings = new List<string>();
            List<int> minutesAndHours = new List<int>() { 8, 4, 2, 1, 32, 16, 8, 4, 2, 1 };
            for (int i = 0; i <= 1023; i++)
            {
                string current = Convert.ToString(i, 2);
                int countZeros = 10 - current.Length;
                StringBuilder sb = new StringBuilder();
                sb.Insert(0, "0", countZeros);
                sb.Append(current);
                current = sb.ToString();
                int currentOneSymbolsInCurrent = 0;
                int start = 0;
                int finish = current.Length - 1;
                while (start < finish)
                {
                    if (current[start] == '1')
                    {
                        currentOneSymbolsInCurrent++;
                    }
                    if (current[finish] == '1')
                    {
                        currentOneSymbolsInCurrent++;
                    }
                    start++;
                    finish--;
                }
                if (currentOneSymbolsInCurrent == turnedOn)
                {
                    int minutesByClock = 0;
                    int hoursByClock = 0;
                    for(int indexNumber = 0; indexNumber<current.Length;indexNumber++)
                    {
                        if (indexNumber >= 0 && indexNumber <= 3 && current[indexNumber] == '1')
                        {
                            hoursByClock += minutesAndHours[indexNumber];
                        }
                        if (indexNumber >= 4 && indexNumber <= current.Length-1 && current[indexNumber] == '1')
                        {
                            minutesByClock += minutesAndHours[indexNumber];
                        }
                    }
                    if (minutesByClock > 59)
                    {
                        continue;
                    }
                    hoursByClock += minutesByClock / 60;
                    minutesByClock = minutesByClock % 60;
                    if (hoursByClock >= 0 && hoursByClock <= 11 && minutesByClock >= 0 && minutesByClock <= 59)
                    {
                        StringBuilder sb2 = new StringBuilder();
                        sb2.Append(hoursByClock.ToString());
                        sb2.Append(":");
                        if (minutesByClock < 10)
                        {
                            sb2.Append($"0{minutesByClock}");
                        }
                        else
                        {
                            sb2.Append($"{minutesByClock}");
                        }
                        strings.Add(sb2.ToString());
                    }
                }
            }
            return strings;
        }
        // copy from leetcode
        private IList<string> bestSolution(int turnedOn)
        {
            var ans = new List<string>();

            for (int h = 0; h < 12; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    if (getOneBitCount(h) + getOneBitCount(m) == turnedOn)
                    {
                        ans.Add(h.ToString() + ":" + getMinuteString(m));
                    }
                }
            }

            return ans;
        }

        private int getOneBitCount(int n)
        {
            int ans = 0;
            while (n != 0)
            {
                ans++;
                n = n & (n - 1);
            }

            return ans;
        }

        private string getMinuteString(int m)
        {
            if (m < 10)
            {
                return "0" + m.ToString();
            }

            return m.ToString();
        }
    }
}
