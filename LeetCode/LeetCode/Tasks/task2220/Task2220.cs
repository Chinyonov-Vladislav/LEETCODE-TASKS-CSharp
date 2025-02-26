using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2220
{
    /*
     2220. Минимальное изменение бита для преобразования числа
    Перестановка бита в числе x — это выбор бита в двоичном представлении x и перестановка его из 0 в 1 или из 1 в 0.
        Например, для x = 7 двоичное представление выглядит так: 111 и мы можем выбрать любой бит (включая ведущие нули, которые не показаны) и перевернуть его. Мы можем перевернуть первый бит справа, чтобы получить 110, перевернуть второй бит справа, чтобы получить 101, перевернуть пятый бит справа (ведущий ноль), чтобы получить 10111, и т. д.
    Учитывая два целых числа start и goal, верните минимальное количество битовых переворотов для преобразования start в goal.
    https://leetcode.com/problems/minimum-bit-flips-to-convert-number/description/
     */
    public class Task2220 : InfoBasicTask
    {
        public Task2220(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int start = 10;
            int goal = 7;
            Console.WriteLine($"Стартовое значение = {start}\nЦелевое значение = {goal}");
            int result = minBitFlips(start, goal);
            Console.WriteLine($"Количество смен битов для получения из числа {start} числа {goal} = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int minBitFlips(int start, int goal)
        {
            int countDifferentBits = 0;
            while (start > 0 || goal > 0)
            {
                int bitOfX = start > 0 ? start & 1 : 0;
                int bitOfY = goal > 0 ? goal & 1 : 0;
                if (bitOfX != bitOfY)
                {
                    countDifferentBits++;
                }
                start = start > 0 ? start >>= 1 : start;
                goal = goal > 0 ? goal >>= 1 : goal;
            }
            return countDifferentBits;
        }
    }
}
