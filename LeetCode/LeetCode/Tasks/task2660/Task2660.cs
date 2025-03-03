using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2660
{
    /*
     2660. Определите победителя в игре в боулинг
    Вам даны два нумерованных от 0 целочисленных массива player1 и player2, представляющие количество кеглей, которые сбил игрок 1 и игрок 2 в игре в боулинг соответственно.
    Игра в боулинг состоит из n раундов, и в каждом раунде нужно сбить ровно 10 кеглей.
    Предположим, что игрок выбивает xi кегли на iм ходу. Значение iго хода для игрока равно:
        2xi если игрок выбивает 10 кеглей на (i - 1)-м или (i - 2)-м ходу.
        В противном случае, так оно и есть xi.
        Очки игрока — это сумма значений его n ходов.
    Возврат
        1, если счёт игрока 1 больше, чем счёт игрока 2,
        2, если счёт игрока 2 больше, чем счёт игрока 1, и
        0 в случае ничьей.
     */
    public class Task2660 : InfoBasicTask
    {
        public Task2660(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] scorePlayer1 = new int[] { 5, 10, 3, 2 };
            int[] scorePlayer2 = new int[] { 6, 5, 7, 3 };
            printArray(scorePlayer1, "Счёт игрока №1: ");
            printArray(scorePlayer2, "Счёт игрока №2: ");
            if (isValid(scorePlayer1, scorePlayer2))
            {
                int res = isWinner(scorePlayer1, scorePlayer2);
                Console.WriteLine(res == 0 ? "Результат матча - ничья" : $"Победитель игрок №{res}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] player1, int[] player2)
        {
            if (player1.Length != player2.Length)
            {
                return false;
            }
            int n = player1.Length;
            if (n < 1 || n > 1000)
            {
                return false;
            }
            for (int i = 0; i < n; i++)
            {
                if (player1[i] < 0 || player1[i] > 10 || player2[i] < 0 || player2[i] > 10)
                {
                    return false;
                }
            }
            return true;
        }
        private int isWinner(int[] player1, int[] player2)
        {
            int sumFirstPlayer = 0;
            int sumSecondPlayer = 0;
            for (int i = 0; i < player1.Length; i++)
            {
                if (i == 0)
                {
                    sumFirstPlayer += player1[i];
                    sumSecondPlayer += player2[i];
                    continue;
                }
                bool isTen = false;
                if (i == 1)
                {
                    isTen = player1[i - 1] == 10;
                }
                else
                {
                    isTen = player1[i - 1] == 10 || player1[i - 2] == 10;
                }
                if (isTen)
                {
                    sumFirstPlayer += player1[i] * 2;
                }
                else
                {
                    sumFirstPlayer += player1[i];
                }
                if (i == 1)
                {
                    isTen = player2[i - 1] == 10;
                }
                else
                {
                    isTen = player2[i - 1] == 10 || player2[i - 2] == 10;
                }
                if (isTen)
                {
                    sumSecondPlayer += player2[i] * 2;
                }
                else
                {
                    sumSecondPlayer += player2[i];
                }
            }
            return sumFirstPlayer == sumSecondPlayer ? 0 : sumFirstPlayer > sumSecondPlayer ? 1 : 2;
        }
    }
}
