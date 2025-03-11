using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3274
{
    /*
     3274. Проверьте, совпадают ли цвета двух клеток шахматной доски
    Вам даны две строки, coordinate1 и coordinate2, представляющие координаты клетки на 8 x 8 шахматной доске.
    Верните значение, true если эти два квадрата имеют одинаковый цвет, и false в противном случае.
    Координаты всегда будут соответствовать допустимому квадрату шахматной доски. Координаты всегда будут начинаться с буквы (обозначающей столбец) и заканчиваться цифрой (обозначающей строку).
    Ограничения:
        coordinate1.length == coordinate2.length == 2
        'a' <= coordinate1[0], coordinate2[0] <= 'h'
        '1' <= coordinate1[1], coordinate2[1] <= '8'
    https://leetcode.com/problems/check-if-two-chessboard-squares-have-the-same-color/description/
     */
    public class Task3274 : InfoBasicTask
    {
        public Task3274(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string coordinate1 = "a1";
            string coordinate2 = "c3";
            Console.WriteLine($"Координата на шахматной доске №1 = \"{coordinate1}\"\nКоордината на шахматной доске №2 = \"{coordinate2}\"");
            if (isValid(coordinate1, coordinate2))
            {
                Console.WriteLine(checkTwoChessboards(coordinate1, coordinate2) ? $"Координаты \"{coordinate1}\" \"{coordinate2}\" имеют одинаковый цвет на шахматной доске" : $"Координаты \"{coordinate1}\" \"{coordinate2}\" имеют различные цвета на шахматной доске");
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
        private bool isValid(string coordinate1, string coordinate2)
        {
            if (!(coordinate1.Length == 2 && coordinate2.Length == 2))
            {
                return false;
            }
            if (coordinate1[0] < 'a' || coordinate1[0] > 'h' || coordinate2[0] < 'a' || coordinate2[0] > 'h' || coordinate1[1] < '0' || coordinate1[1] > '8' || coordinate2[1] < '0' || coordinate2[1] > '8')
            {
                return false;
            }
            return true;
        }
        private bool checkTwoChessboards(string coordinate1, string coordinate2)
        {
            int[] values = new int[4] { coordinate1[0] - 'a', coordinate1[1] - '0', coordinate2[0] - 'a', coordinate2[1] - '0' };
            char[] colors = new char[2] { 'W', 'W' };
            int indexColor = 0;
            for (int i = 0; i < values.Length; i += 2)
            {
                if (values[i+1] % 2 != 0 && values[i] % 2 == 0)
                {
                    colors[indexColor] = 'B';
                }
                else if (values[i + 1] % 2 != 0 && values[i] % 2 != 0)
                {
                    colors[indexColor] = 'W';
                }
                else if (values[i + 1] % 2 == 0 && values[i] % 2 == 0)
                {
                    colors[indexColor] = 'W';
                }
                else if (values[i + 1] % 2 == 0 && values[i] % 2 != 0)
                {
                    colors[indexColor] = 'B';
                }
                indexColor++;
            }
            return colors[0] == colors[1];
        }
    }
}
