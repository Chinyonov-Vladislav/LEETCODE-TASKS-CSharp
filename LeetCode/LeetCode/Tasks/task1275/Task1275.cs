using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1275
{
    /*
     1275. Найдите победителя в игре «Крестики-нолики»
    В крестики-нолики играют два игрока A и B на 3 x 3 сетке. Правила игры в крестики-нолики таковы:
        Игроки по очереди расставляют персонажей по пустым квадратам ' '.
        Первый игрок A всегда расставляет 'X' персонажей, а второй игрок B всегда расставляет 'O' персонажей.
        'X' и 'O' символы всегда помещаются в пустые квадраты, никогда в заполненные.
        Игра заканчивается, когда три одинаковых (непустых) символа заполняют любую строку, столбец или диагональ.
        Игра также заканчивается, если все квадраты непустые.
        Если игра окончена, больше никаких ходов быть не может.
    Учитывая двумерный целочисленный массив moves где moves[i] = [rowi, coli] указывает, что ход ith будет сыгран на grid[rowi][coli]. верните победителя игры, если он есть (A или B). Если игра заканчивается вничью, верните "Draw". Если ещё есть ходы, которые можно сделать, верните "Pending".
    Вы можете предположить, что moves является допустимым (то есть соответствует правилам крестиков-ноликов), сетка изначально пуста, и A будет играть первым.
    Ограничения:
        1 <= moves.length <= 9
        moves[i].length == 2
        0 <= rowi, coli <= 2
        На moves нет повторяющихся элементов.
        moves следуйте правилам игры в крестики-нолики.
    https://leetcode.com/problems/find-winner-on-a-tic-tac-toe-game/description/
     */
    public class Task1275 : InfoBasicTask
    {
        public Task1275(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] moves = new int[][] {
                new int[] { 2,2 },
                new int[] { 1,2 },
                new int[] {2,1 },
                new int[] { 1,1 },
                new int[] { 2, 0 }
            };
            printTwoDimensionalArray(moves, "Массив ходов");
            if (isValid(moves))
            {
                string result = tictactoe(moves);
                switch (result)
                {
                    case "A":
                        Console.WriteLine("Победитель - игрок А");
                        break;
                    case "B":
                        Console.WriteLine("Победитель - игрок B");
                        break;
                    case "Pending":
                        Console.WriteLine("Еще остались возмодные ходы!");
                        break;
                    case "Draw":
                        Console.WriteLine("Ничья!");
                        break;
                }
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
        private bool isValid(int[][] moves)
        {
            if (moves.Length < 1 || moves.Length > 9)
            {
                return false;
            }
            char[][] grid = new char[][] {
                new char[] { ' ',' ',' ' },
                new char[] { ' ',' ',' ' },
                new char[] { ' ',' ',' ' },
            };
            HashSet<string> movesSet = new HashSet<string>();
            foreach (int[] move in moves)
            {
                if (move.Length != 2)
                {
                    return false;
                }
                foreach (int item in move)
                {
                    if (item < 0 || item > 2)
                    {
                        return false;
                    }
                }
                movesSet.Add($"{move[0]}{move[1]}");
            }
            if (movesSet.Count != moves.Length)
            {
                return false;
            }
            for (int i = 0; i < moves.Length; i++)
            {
                if (grid[moves[i][0]][moves[i][1]] != ' ')
                {
                    return false;
                }
                if (i % 2 == 0)
                {
                    grid[moves[i][0]][moves[i][1]] = 'X';
                }
                else
                {
                    grid[moves[i][0]][moves[i][1]] = '0';
                }
            }
            return true;
        }
        private string tictactoe(int[][] moves)
        {
            char[][] grid = new char[][] {
                new char[] { ' ',' ',' ' },
                new char[] { ' ',' ',' ' },
                new char[] { ' ',' ',' ' },
            };
            bool isTik = true;
            foreach (int[] move in moves)
            {
                if (isTik)
                {
                    grid[move[0]][move[1]] = 'X';
                }
                else
                {
                    grid[move[0]][move[1]] = '0';
                }
                isTik = !isTik;
            }
            if (isWinnerFind(grid))
            {
                if (!isTik)
                {
                    return "A";
                }
                return "B";
            }
            bool isExistMove = false;
            foreach (var row in grid)
            {
                foreach (var item in row)
                {
                    if (item == ' ')
                    {
                        isExistMove = true;
                        break;
                    }
                }
                if (isExistMove)
                {
                    break;
                }
            }
            if (isExistMove)
            {
                return "Pending";
            }
            return "Draw";
        }
        private bool isWinnerFind(char[][] grid)
        {
            List<char> list = new List<char>();
            int countRows = grid.Length;
            int countColumns = grid[0].Length;
            for (int indexRow = 0; indexRow < countRows; indexRow++)
            {
                list.Clear();
                for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
                {
                    if (!list.Contains(grid[indexRow][indexColumn]))
                    {
                        list.Add(grid[indexRow][indexColumn]);
                    }
                }
                if (list.Count == 1 && list[0] != ' ')
                {
                    return true;
                }
            }
            for (int indexColumn = 0; indexColumn < countColumns; indexColumn++)
            {
                list.Clear();
                for (int indexRow = 0; indexRow < countRows; indexRow++)
                {
                    if (!list.Contains(grid[indexRow][indexColumn]))
                    {
                        list.Add(grid[indexRow][indexColumn]);
                    }
                }
                if (list.Count == 1 && list[0] != ' ')
                {
                    return true;
                }
            }
            list.Clear();
            for (int index = 0; index < countRows; index++)
            {
                if (!list.Contains(grid[index][index]))
                {
                    list.Add(grid[index][index]);
                }
            }
            if (list.Count == 1 && list[0] != ' ')
            {
                return true;
            }
            list.Clear();
            for (int i = 0; i < countRows; i++)
            {
                int j = countRows - 1 - i;
                if (!list.Contains(grid[i][j]))
                {
                    list.Add(grid[i][j]);
                }
            }
            if (list.Count == 1 && list[0] != ' ')
            {
                return true;
            }
            return false;
        }
    }
}
