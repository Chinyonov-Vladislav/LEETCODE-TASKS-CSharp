using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task657
{
    /*
     657. Возвращение робота к источнику
    Робот находится в точке (0, 0) на двумерной плоскости. Учитывая последовательность его перемещений, определите, окажется ли этот робот в точке (0, 0) после завершения перемещений.
    Вам дана строка moves, которая представляет собой последовательность перемещений робота, где moves[i] обозначает его ith перемещение. Допустимые перемещения: 'R' (вправо), 'L' (влево), 'U' (вверх) и 'D' (вниз).
    Вернитесь true если робот вернётся в исходную точку после выполнения всех своих действий, или false в противном случае.
    Примечание: направление, в котором «смотрит» робот, не имеет значения. 'R' всегда заставит робота один раз переместиться вправо, 'L' всегда заставит его переместиться влево и т. д. Кроме того, предположим, что величина перемещения робота одинакова для каждого перемещения.
    https://leetcode.com/problems/robot-return-to-origin/description/
     */
    public class Task657 : InfoBasicTask
    {
        public Task657(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string moves = "UD";
            Console.WriteLine(judgeCircle(moves) ? "Робот вернулся в исходную позицию" : "Робот не вернулся в исходную позицию");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool judgeCircle(string moves)
        {
            int upDown = 0;
            int leftRight = 0;
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'R':
                        leftRight++;
                        break;
                    case 'L':
                        leftRight--;
                        break;
                    case 'U':
                        upDown++;
                        break;
                    case 'D':
                        upDown--;
                        break;
                }
            }
            return upDown==0 && leftRight==0;
        }
    }
}
