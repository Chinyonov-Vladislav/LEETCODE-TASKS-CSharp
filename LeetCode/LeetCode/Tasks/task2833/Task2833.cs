using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2833
{
    /*
     2833. Самая удаленная точка от источника
    Вам дана строка moves длиной n, состоящая только из символов 'L', 'R', и '_'. 
    Строка представляет ваше движение по числовой прямой, начинающейся с начала координат 0.
    В ith перемещении вы можете выбрать одно из следующих направлений:
        переместитесь влево, если moves[i] = 'L' или moves[i] = '_'
        переместитесь вправо, если moves[i] = 'R' или moves[i] = '_'
    Верните значение расстояния от начала координат до самой дальней точки, до которой вы можете добраться после n ходов.
    Ограничения:
        1 <= moves.length == n <= 50
        moves состоит только из символов 'L', 'R' и '_'.
    https://leetcode.com/problems/furthest-point-from-origin/description/
     */
    public class Task2833 : InfoBasicTask
    {
        public Task2833(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string moves = "L_RL__R";
            Console.WriteLine($"Исходная строка: \"{moves}\"");
            if (isValid(moves))
            {
                int point = furthestDistanceFromOrigin(moves);
                Console.WriteLine($"значение расстояния от начала координат до самой дальней точки = {point}");
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
        private bool isValid(string moves)
        {
            if (moves.Length < 1 || moves.Length > 50)
            {
                return false;
            }
            foreach (char move in moves)
            {
                if (move != 'L' && move != 'R' && move != '_')
                {
                    return false;
                }
            }
            return true;
        }
        private int furthestDistanceFromOrigin(string moves)
        {
            int countLeft = 0;
            int countRight = 0;
            int countUnderLine = 0;
            foreach (var move in moves) {
                if (move == 'L')
                {
                    countLeft++;
                }
                else if (move == 'R')
                {
                    countRight++;
                }
                else
                {
                    countUnderLine++;
                }
            }
            return countLeft > countRight ? countLeft+countUnderLine-countRight : countRight + countUnderLine-countLeft;
        }
    }
}
