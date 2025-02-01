using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task292
{
    /*
     292. Ним Игра
    Вы играете в следующую Nim-игру со своим другом:
        Вначале на столе лежит груда камней.
        Вы и ваш друг будете чередоваться по очереди, и вы пойдете первым.
        На каждом ходу игрок, чья очередь наступила, убирает из стопки от 1 до 3 камней.
        Тот, кто уберет последний камень, становится победителем.
    Учитывая n, количество камней в куче, верните trueесли вы можете выиграть игру, предполагая, что и вы, и ваш друг играете оптимально, в противном случае верните false.
     https://leetcode.com/problems/nim-game/description/
     */
    public class Task292 : InfoBasicTask
    {
        public Task292(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int countStones = 8;
            Console.WriteLine(canWinNim(8) ? $"Вы сможете выиграть при количестве камней = {countStones}" : $"Вы не сможете выиграть при количестве камней = {countStones}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool canWinNim(int n)
        {
            return n % 4 != 0;
        }
    }
}
