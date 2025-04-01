using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task794
{
    /*
     794. Допустимое состояние игры в крестики-нолики
    Учитывая, что доска для игры в крестики-нолики представлена в виде массива строк board, верните true только в том случае, если можно достичь этой позиции на доске в ходе корректной игры в крестики-нолики.
    Доска представляет собой массив 3 x 3 символов ' ', 'X', и 'O'. Символ ' ' обозначает пустой квадрат.
    Вот правила игры в крестики-нолики:
        Игроки по очереди расставляют персонажей по пустым квадратам ' '.
        Первый игрок всегда расставляет 'X' символов, а второй игрок всегда расставляет 'O' символов.
        'X' и 'O' символы всегда помещаются в пустые квадраты, а не в заполненные.
        Игра заканчивается, когда в любой строке, столбце или диагонали появляется три одинаковых (непустых) символа.
        Игра также заканчивается, если все квадраты непустые.
        Если игра окончена, больше никаких ходов быть не может.
    Ограничения:
        board.length == 3
        board[i].length == 3
        board[i][j] является либо 'X', 'O', либо ' '.
    https://leetcode.com/problems/valid-tic-tac-toe-state/description/
     */
    public class Task794 : InfoBasicTask
    {
        public Task794(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] board = new string[] {
                "OX ",
                "OO ",
                "OOO"
            };
            printArray(board, "Массив поля игры в крестики-нолики", false);
            if (isValid(board))
            {
               Console.WriteLine(validTicTacToe(board) ? "Игровое поле игры крестики-нолики корректно в текущий момент" : "Игровое поле игры крестики-нолики не корректно в текущий момент");
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
        private bool isValid(string[] board)
        {
            List<char> acceptedChars = new List<char>() { 'X', 'O', ' ' };
            int length = 3;
            if (board.Length != length)
            {
                return false;
            }
            foreach (string row in board)
            {
                if (row.Length != length)
                {
                    return false;
                }
                foreach (char c in row)
                {
                    if (!acceptedChars.Contains(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool validTicTacToe(string[] board)
        {
            int countRows = 3;
            int countCols = 3;
            int countO = 0;
            int countX = 0;
            int countWinnerO = 0;
            int countWinnerX = 0;
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < countCols; indexColumn++)
                {
                    if (board[indexRow][indexColumn] == 'O')
                    {
                        countO++;
                    }
                    else if (board[indexRow][indexColumn] == 'X')
                    {
                        countX++;
                    }
                }
            }
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                HashSet<char> set = new HashSet<char>();
                for (int indexColumn = 0; indexColumn < countCols; indexColumn++)
                {
                    set.Add(board[indexRow][indexColumn]);
                }
                if (set.Count == 1)
                {
                    if (set.Contains('O'))
                    {
                        countWinnerO++;
                    }
                    else if (set.Contains('X'))
                    {
                        countWinnerX++;
                    }
                }
            }
            for (int indexColumn = 0; indexColumn < countCols; indexColumn++)
            {
                HashSet<char> set = new HashSet<char>();
                for (int indexRow = 0; indexRow < countRows; indexRow++)
                {
                    set.Add(board[indexRow][indexColumn]);
                }
                if (set.Count == 1)
                {
                    if (set.Contains('O'))
                    {
                        countWinnerO++;
                    }
                    else if (set.Contains('X'))
                    {
                        countWinnerX++;
                    }
                }
            }
            HashSet<char> setMainDiagonal = new HashSet<char>();
            for (int i = 0; i < countRows; i++)
            {
                setMainDiagonal.Add(board[i][i]);
            }
            if (setMainDiagonal.Count == 1)
            {
                if (setMainDiagonal.Contains('O'))
                {
                    countWinnerO++;
                }
                else if (setMainDiagonal.Contains('X'))
                {
                    countWinnerX++;
                }
            }
            HashSet<char> setSecondaryDiagonal = new HashSet<char>();
            for (int i = 0; i < countRows; i++)
            {
                setSecondaryDiagonal.Add(board[i][countCols - i - 1]);
            }
            if (setSecondaryDiagonal.Count == 1)
            {
                if (setSecondaryDiagonal.Contains('O'))
                {
                    countWinnerO++;
                }
                else if (setSecondaryDiagonal.Contains('X'))
                {
                    countWinnerX++;
                }
            }
            
            if (countWinnerO == 0 && countWinnerX == 0) // если не выиграшных линий у обеих игроков
            {
                if (!(countO == countX || countX == countO + 1))
                {
                    return false;
                }
            }
            else if (countWinnerO >=1 &&  countWinnerO <=3 && countWinnerX == 0) // если есть одна или две выиграшная линия у O
            {
                if (countO != countX)
                {
                    return false;
                }
            }
            else if (countWinnerO == 0 && countWinnerX >= 1 && countWinnerX <= 3) // если есть одна или две выиграшная линия у X
            {
                if (countO + 1 != countX)
                {
                    return false;
                }
            }
            else if (countWinnerO != 0 && countWinnerX != 0) // если победные линии есть у обеих игроков
            {
                return false;
            }
            return true;
        }
    }
}
