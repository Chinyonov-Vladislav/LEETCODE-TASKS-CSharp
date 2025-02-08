using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1688
{
    /*
     1688. Количество матчей в турнире
    Вам дано целое число n — количество команд в турнире со странными правилами:
        Если текущее количество команд чётное, каждая команда объединяется в пару с другой командой. Всего проводится n / 2 матчей, и n / 2 команд переходят в следующий раунд
        Если текущее количество команд нечётное, одна команда случайным образом проходит в следующий раунд, а остальные разбиваются на пары. Всего проводится (n - 1) / 2 матчей, и (n - 1) / 2 + 1 команд проходят в следующий раунд.
    Верните количество матчей, сыгранных в турнире, до определения победителя.
    https://leetcode.com/problems/count-of-matches-in-tournament/description/
     */
    public class Task1688 : InfoBasicTask
    {
        public Task1688(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int countCommands = 14;
            Console.WriteLine($"Количество команд = {countCommands}");
            int countMatches = numberOfMatches(countCommands);
            Console.WriteLine($"Количество проведенных матчей = {countMatches}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numberOfMatches(int n)
        {
            int countMatches = 0;
            while (n != 1)
            {
                countMatches += n / 2;
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = n / 2 + 1;
                }
            }
            return countMatches;
        }
    }
}
