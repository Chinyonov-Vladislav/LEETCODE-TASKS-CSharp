using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3360
{
    /*
     3360. Игра по удалению камней
    Алиса и Боб играют в игру, в которой они по очереди убирают камни из кучи, причём Алиса ходит первой.
        Алиса начинает с того, что убирает ровно 10 камней в свой первый ход.
        За каждый последующий ход каждый игрок убирает ровно на 1 камень меньше, чем предыдущий противник.
    Игрок, который не может сделать ход, проигрывает игру.
    Для заданного положительного целого числа n верните true если Алиса выиграет игру, и false в противном случае.
    Ограничения:
        1 <= n <= 50
    https://leetcode.com/problems/stone-removal-game/description/
     */
    public class Task3360 : InfoBasicTask
    {
        public Task3360(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int countStones = 12;
            Console.WriteLine($"Количество камней в игре = {countStones}");
            if (isValid(countStones))
            {
                Console.WriteLine(canAliceWin(countStones) ? "Алиса может выиграть" : "Алиса не может выиграть");
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
        private bool isValid(int n)
        {
            if (n < 1 || n > 50)
            {
                return false;
            }
            return true;
        }
        private bool canAliceWin(int n)
        {
            bool isAliceTurn = true;
            int countStoneThisTurn = 10;
            while (countStoneThisTurn <= n)
            {
                n -= countStoneThisTurn;
                countStoneThisTurn--;
                isAliceTurn = !isAliceTurn;
            }
            return !isAliceTurn;
        }
    }
}
