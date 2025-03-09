using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3114
{
    /*
     3114. Последнее время, которое вы можете получить после замены символов
    Вам дана строка s с указанием времени в 12-часовом формате, в которой некоторые цифры (возможно, ни одной) заменены на "?".
    12-часовое время отображается в формате "HH:MM", где HH находится между 00 и 11, а MM находится между 00 и 59. Самое раннее 12-часовое время — 00:00, а самое позднее — 11:59.
    Вам нужно заменить все символы "?" в s на цифры таким образом, чтобы время, которое мы получим в результате, было действительным временем в 12-часовом формате и было самым поздним из возможных.
    Верните результирующую строку.
    Ограничения:
        s.length == 5
        s[2] равен символу ":".
        Все символы, кроме s[2], являются цифрами или "?" символами.
        Входные данные генерируются таким образом, чтобы между и было "00:00"по крайней мере"11:59" одно время, которое вы можете получить после замены "?" символов.
    https://leetcode.com/problems/latest-time-you-can-obtain-after-replacing-characters/description/
     */
    public class Task3114 : InfoBasicTask
    {
        public Task3114(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string time = "0?:5?";
            Console.WriteLine($"Исходная строка с временем: \"{time}\"");
            if (isValid(time))
            { 
                string maxTime = findLatestTime(time);
                Console.WriteLine($"Максимальное допустимое время: \"{maxTime}\"");
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
        private bool isValid(string s)
        {
            if (s.Length != 5)
            {
                return false;
            }
            if (s[2] != ':')
            {
                return false;
            }
            if (s[0] != '?'  && (s[0] < '0' || s[0]>'1'))
            {
                return false;
            }
            if (s[1] != '?' && (s[1] < '0' || s[1] > '1'))
            {
                return false;
            }
            if (s[3] != '?' && (s[3] < '0' || s[3] > '5'))
            {
                return false;
            }
            if (s[4] != '?' && (s[4] < '0' || s[4] > '9'))
            {
                return false;
            }
            return true;
        }
        private string findLatestTime(string s)
        {
            char[] massChar = s.ToCharArray();
            if (massChar[0] == '?' && massChar[1] == '?')
            {
                massChar[0] = '1';
                massChar[1] = '1';
            }
            else if (massChar[0] != '?' && massChar[1] == '?')
            {
                if (massChar[0] == '0')
                {
                    massChar[1] = '9';
                }
                else
                {
                    massChar[1] = '1';
                }
            }
            else if (massChar[0] == '?' && massChar[1] != '?')
            {
                if (massChar[1] >= 0 && massChar[1] <= '1')
                {
                    massChar[0] = '1';
                }
                else
                {
                    massChar[0] = '0';
                }
            }
            if (massChar[3] == '?')
            {
                massChar[3] = '5';
            }
            if (massChar[4] == '?')
            {
                massChar[4] = '9';
            }
            return new string(massChar);
        }
    }
}
