using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1128
{
    /*
     1128. Количество эквивалентных пар домино
    Учитывая список dominoes, dominoes[i] = [a, b] эквивалентно dominoes[j] = [c, d] тогда и только тогда, когда либо (a == c и b == d), либо (a == d и b == c) - то есть одну доминошку можно повернуть так, чтобы она была равна другой доминошке.
    Верните количество пар, (i, j)для которых 0 <= i < j < dominoes.length, и dominoes[i]равно dominoes[j].
     https://leetcode.com/problems/number-of-equivalent-domino-pairs/
     */
    public class Task1128 : InfoBasicTask
    {
        public Task1128(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] dominoes = new int[][] {
                new int[] {1,2 },
                new int[] {2,1 },
                new int[] {3,4 },
                new int[] {5,6 },
            };
            for (int i = 0; i < dominoes.Length; i++)
            {
                Console.WriteLine($"Домино: [{dominoes[i][0]},{dominoes[i][1]}]");
            }
            int count = numEquivDominoPairs(dominoes);
            Console.WriteLine($"Количество эквивалентных пар домино = {count}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numEquivDominoPairs(int[][] dominoes)
        {
            Dictionary<Tuple<int, int>, int> dict = new Dictionary<Tuple<int, int>, int>();
            int count = 0;
            for (int i = 0; i < dominoes.Length; i++)
            {
                Tuple<int, int> currentDomino = new Tuple<int, int>(dominoes[i][0], dominoes[i][1]); // 1,2
                Tuple<int, int> invertDomino = new Tuple<int, int>(dominoes[i][1], dominoes[i][0]); // 2,1
                if (dominoes[i][0] != dominoes[i][1] && dict.ContainsKey(invertDomino))
                {
                    count += dict[invertDomino];
                }
                if (dict.ContainsKey(currentDomino))
                {
                    count += dict[currentDomino];
                    dict[currentDomino]++;
                }
                else
                {
                    dict.Add(currentDomino, 1);
                }
            }
            return count;
        }
        private int firstSolution(int[][] dominoes) // O(n^2)
        {
            int count = 0;
            for (int i = 0; i < dominoes.Length; i++)
            {
                for (int j = i + 1; j < dominoes.Length; j++)
                {
                    if ((dominoes[i][0] == dominoes[j][0] && dominoes[i][1] == dominoes[j][1]) || (dominoes[i][0] == dominoes[j][1] && dominoes[i][1] == dominoes[j][0]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        // скопировано с leetcode
        private int bestSolution(int[][] dominoes)
        {
            int[] dict = new int[100]; // 11 -> 99
            foreach (var d in dominoes)
            {
                int key = Math.Min(d[0], d[1]) * 10 + Math.Max(d[0], d[1]);
                dict[key]++;
            }

            int count = 0;
            foreach (var n in dict)
                count += n * (n - 1) / 2;

            return count;
        }
        
    }
}
