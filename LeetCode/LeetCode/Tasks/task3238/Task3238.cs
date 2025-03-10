using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3238
{
    /*
     3238. Найдите количество выигравших игроков
    Вам дано целое число n, обозначающее количество игроков в игре, и двумерный массив pick, где pick[i] = [xi, yi] обозначает, что игрок xi выбрал шар цвета yi.
    Игрок i выигрывает игру, если он выберет строго больше, чем i шаров одного цвета. Другими словами,
        Игрок 0 выигрывает, если он выберет любой мяч.
        Игрок 1 побеждает, если он выберет хотя бы два шарика одного цвета.
        ...
        Игрок i побеждает, если он выберет не менее i + 1 шаров одного цвета.
    Возвращает количество игроков, которые выиграли игру.
    Обратите внимание, что в игре могут выиграть несколько игроков.
    Ограничения:
        2 <= n <= 10
        1 <= pick.length <= 100
        pick[i].length == 2
        0 <= pick[i][0] <= n - 1 
        0 <= pick[i][1] <= 10
    https://leetcode.com/problems/find-the-number-of-winning-players/description/
     */
    public class Task3238 : InfoBasicTask
    {
        public Task3238(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int n = 4;
            int[][] pick = new int[][] {
                new int[] { 0,0 },
                new int[] { 1,0 },
                new int[] { 1,0 },
                new int[] { 2,1 },
                new int[] { 2,1 },
                new int[] { 2,0 },
            };
            Console.WriteLine($"Количество игроков = {n}");
            printTwoDimensionalArray(pick, "Ход игры");
            if (isValid(n, pick))
            {
                int count = winningPlayerCount(n, pick);
                Console.WriteLine($"Количество игроков - победителей = {count}");
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
        private bool isValid(int n, int[][] pick)
        {
            if (n<2||n>10)
            {
                return false;
            }
            if (pick.Length < 1 || pick.Length > 100)
            {
                return false;
            }
            foreach (int[] arr in pick)
            {
                if (arr.Length != 2)
                {
                    return false;
                }
                if (arr[0] < 0 || arr[0] >= n)
                {
                    return false;
                }
                if (arr[1] < 0 || arr[1] > 10)
                {
                    return false;
                }
            }
            return true;
        }
        private int winningPlayerCount(int n, int[][] pick)
        {
            int count = 0;
            Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();
            foreach (int[] arr in pick)
            {
                if (dict.ContainsKey(arr[0]))
                {
                    if (dict[arr[0]].ContainsKey(arr[1]))
                    {
                        dict[arr[0]][arr[1]]++;
                    }
                    else
                    {
                        dict[arr[0]].Add(arr[1], 1);
                    }
                }
                else
                {
                    dict.Add(arr[0], new Dictionary<int, int>());
                    dict[arr[0]].Add(arr[1], 1);
                }
            }
            foreach (var pair in dict)
            {
                int numberPlayer = pair.Key;
                foreach (var balls in pair.Value)
                {
                    if (balls.Value > numberPlayer)
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }
    }
}
