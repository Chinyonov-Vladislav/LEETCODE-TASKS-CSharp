using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1812
{
    /*
     1812. Определите цвет квадрата шахматной доски
    Вам дана строка coordinates, которая представляет собой координаты квадрата на шахматной доске. Ниже приведена шахматная доска для наглядности.
    Верните true если квадрат белый, и false если квадрат чёрный.
    Координаты всегда будут соответствовать квадрату на шахматной доске. В координатах сначала всегда будет буква, а затем число.
    https://leetcode.com/problems/determine-color-of-a-chessboard-square/description/
     */
    public class Task1812 : InfoBasicTask
    {
        public Task1812(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string coord = "h3";
            Console.WriteLine($"Координаты на шахматной доске: \"{coord}\"");
            if (isValid(coord))
            {
                Console.WriteLine(squareIsWhite(coord) ? $"Квадрат с координатами \"{coord}\" имеет белый цвет" : $"Квадрат с координатами \"{coord}\" имеет черный цвет");
            }
            else
            {
                Console.WriteLine("Координаты не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string coordinate)
        {
            if (coordinate.Length != 2)
            {
                return false;
            }
            char firstCoord = coordinate[0];
            char secondCoord = coordinate[1];
            if (firstCoord < 'a' || firstCoord > 'h' || secondCoord < '1' || secondCoord > '8')
            {
                return false;
            }
            return true;
        }
        private bool squareIsWhite(string coordinates)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>() {
                {'a',1 },
                {'b',2 },
                {'c',3 },
                {'d',4 },
                {'e',5 },
                {'f',6 },
                {'g',7 },
                {'h',8 },
            };
            int numberRow = coordinates[1] - '0';
            int numberColumn = dict[coordinates[0]];
            if (numberRow % 2 == 0) // четная строка
            {
                if (numberColumn % 2 == 0) // четный столбец в четной строке
                {
                    return false;
                }
                else // нечетный столбец в четной строке
                {
                    return true;
                }
            }
            else // нечетная строка
            {
                if (numberColumn % 2 == 0) // четный столбец в нечетной строке
                {
                    return true;
                }
                else // нечетный столбец в нечетной строке
                {
                    return false;
                }
            }
        }
    }
}
