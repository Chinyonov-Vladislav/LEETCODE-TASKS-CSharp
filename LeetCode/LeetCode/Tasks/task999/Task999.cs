using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task999
{
    /*
     999. Доступные ходы для ладьи для атаки пешки
    Вам дана 8 x 8 матрица, представляющая шахматную доску. Существует ровно одна белая ладья, представленная 'R', некоторым количеством белых слонов 'B' и некоторым количеством черных пешек 'p'. Пустые квадраты обозначаются символом '.'.
    Ладья может перемещаться на любое количество клеток по горизонтали или вертикали (вверх, вниз, влево, вправо) до тех пор, пока не достигнет другой фигуры или края доски. Ладья атакует пешку, если может переместиться на клетку пешки за один ход.
    Примечание: ладья не может проходить через другие фигуры, например, через слонов или пешки. Это означает, что ладья не может атаковать пешку, если путь ей преграждает другая фигура.
    Верните количество пешек, на которые нападает белая ладья.
    https://leetcode.com/problems/available-captures-for-rook/description/
     */
    public class Task999 : InfoBasicTask
    {
        public Task999(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            char[][] board = new char[][] {
                new char[] { '.','.','.','.','.','.','.','.' },
                new char[] { '.','p','p','p','p','p','.','.' },
                new char[] {'.','p','p','B','p','p','.','.' },
                new char[] {'.','p','B','R','B','p','.','.' },
                new char[] {'.','p','p','B','p','p','.','.' },
                new char[] {'.','p','p','p','p','p','.','.' },
                new char[] { '.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.' },
            };
            Console.WriteLine("Шахматное поле");
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write($"{board[i][j]}\t");
                }
                Console.WriteLine();
            }
            int count = numRookCaptures(board);
            Console.WriteLine($"Количество пешек, которое может уничтожить ладья: {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int numRookCaptures(char[][] board)
        {
            char rock = 'R';
            char elephant = 'B';
            char pawn = 'p';
            int count = 0;
            bool isRockFound = false;
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    if (board[row][column] == rock)
                    {
                        isRockFound = true;
                        // пройтись по клеткам вверх
                        for (int up = row-1; up >= 0; up--)
                        {
                            if (board[up][column] == elephant)
                            {
                                break;
                            }
                            if (board[up][column] == pawn)
                            {
                                count++;
                                break;
                            }
                        }
                        // пройтись по клеткам вниз
                        for (int down = row + 1; down < board.Length; down++)
                        {
                            if (board[down][column] == elephant)
                            {
                                break;
                            }
                            if (board[down][column] == pawn)
                            {
                                count++;
                                break;
                            }
                        }
                        // пройтись по клеткам влево
                        for (int left = column - 1; left >=0; left--)
                        {
                            if (board[row][left] == elephant)
                            {
                                break;
                            }
                            if (board[row][left] == pawn)
                            {
                                count++;
                                break;
                            }
                        }
                        // пройтись по клеткам вправо
                        for (int right = column + 1; right < board[row].Length; right++)
                        {
                            if (board[row][right] == elephant)
                            {
                                break;
                            }
                            if (board[row][right] == pawn)
                            {
                                count++;
                                break;
                            }
                        }
                        break;
                    }
                }
                if (isRockFound)
                {
                    break;
                }
            }
            return count;
        }
    }
}
