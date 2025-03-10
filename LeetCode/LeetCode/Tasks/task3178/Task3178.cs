using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3178
{
    /*
     3178. Найдите ребёнка, у которого через K секунд окажется мяч
    Вам даны два положительных целых числа n и k. nДети, пронумерованные от 0 до n - 1, стоят в очереди в порядке слева направо.
    Изначально ребёнок 0 держит мяч, и направление передачи мяча — вправо. Каждую секунду ребёнок, у которого мяч, передаёт его ребёнку, стоящему рядом с ним. Как только мяч достигает любого конца линии, то есть ребёнка 0 или ребёнка n - 1, направление передачи меняется на противоположное.
    Верните номер ребенка, который получит мяч через k секунд.
    Ограничения:
        2 <= n <= 50
        1 <= k <= 50
    https://leetcode.com/problems/find-the-child-who-has-the-ball-after-k-seconds/description/
     */
    public class Task3178 : InfoBasicTask
    {
        public Task3178(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 3;
            int k = 5;
            Console.WriteLine($"Количество детей = {n}\nКоличество секунд = {k}");
            if (isValid(n, k))
            {
                int currentIndex = numberOfChild(n, k);
                Console.WriteLine($"Индекс ребенка с мячом после {k} секунд = {currentIndex}");
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
        private bool isValid(int n, int k)
        {
            if (!(n >= 2 && n <= 50))
            {
                return false;
            }
            if (!(k >= 1 && k <= 50))
            {
                return false;
            }
            return true;
        }
        private int numberOfChild(int n, int k)
        {
            int currentIndexChild = 0;
            bool positiveDirection = true;
            int countSeconds = 0;
            while (countSeconds < k) {
                if (positiveDirection)
                {
                    currentIndexChild++;
                }
                else
                {
                    currentIndexChild--;
                }
                if (currentIndexChild == n - 1)
                {
                    positiveDirection = false;
                }
                else if (currentIndexChild == 0)
                {
                    positiveDirection = true;
                }
                countSeconds++;
            }
            return currentIndexChild;
        }
    }
}
