using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3222
{
    /*
     3222. Найдите победителя в игре с монетами
    Вам даны два положительных целых числа x и y, обозначающие количество монет достоинством 75 и 10 соответственно.
    Алиса и Боб играют в игру. Каждый ход, начиная с Алисы, игрок должен собрать монеты общей стоимостью 115. Если игрок не может этого сделать, он проигрывает.
    Верните имя игрока, который выиграет игру, если оба игрока будут играть оптимально.
    Ограничения:
        1 <= x, y <= 100
    https://leetcode.com/problems/find-the-winning-player-in-coin-game/description/
     */
    public class Task3222 : InfoBasicTask
    {
        public Task3222(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int x = 2;
            int y = 7;
            Console.WriteLine($"Количество монет номиналом 75 = {x}\nКоличество монет номиналом 10 = {y}");
            if (isValid(x, y))
            {
                Console.WriteLine($"Победитель - {winningPlayer(x,y)}");
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
        private bool isValid(int x, int y)
        {
            if (x < 1 || x > 100 || y < 1 || y > 100)
            {
                return false;
            }
            return true;
        }
        private string winningPlayer(int x, int y)
        {
            int numberRound = 0;
            while (x > 0 && y >= 4)
            {
                x -= 1;
                y -= 4;
                numberRound++;
            }
            if (numberRound % 2 == 0)
            {
                return "Bob";
            }
            return "Alice";
        }
    }
}
