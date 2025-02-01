using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task997
{
    /*
     997. Найдите городского судью
    В городе есть n человек с номерами от 1 до n. Ходят слухи, что один из этих людей тайно является городским судьёй.
    Если городской судья существует, то:
        Городской судья никому не доверяет.
        Все (за исключением городского судьи) доверяют городскому судье.
        Существует ровно один человек, который удовлетворяет свойствам 1 и 2.
    Вам выдается массив, trust где trust[i] = [ai, bi] это означает, что помеченный человек ai доверяет помеченному человеку bi. Если доверительная связь не существует в trust массиве, то такая доверительная связь не существует.
    Верните этикетку городского судьи, если городской судья существует и его можно идентифицировать, или верните -1 иначе.
    https://leetcode.com/problems/find-the-town-judge/description/
     */
    public class Task997 : InfoBasicTask
    {
        public Task997(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[][] array = new int[][] {
                new int[] {1,2 },
                new int[] {3,3 }
            };
            int n = 3;
            int numberJudge = findJudge(n, array);
            Console.WriteLine(numberJudge == -1 ? $"Номер судьи = {numberJudge}" : "Невозможно определить судью");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findJudge(int n, int[][] trust)
        {
            List<int> candidates = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                candidates.Add(i);
            }
            for (int i = 0; i < trust.Length; i++) // отсеиваем из кандидатов жителей
            {
                if (candidates.Contains(trust[i][0]))
                {
                    candidates.Remove(trust[i][0]);
                }
            }
            // проверяем все ли жители доверяют одному из кандидатов
            Dictionary<int,int> keyValuePairs = new Dictionary<int,int>();
            foreach (int i in candidates) {
                keyValuePairs.Add(i, 0);
            }
            for (int i = 0; i < trust.Length; i++)
            {
                if (keyValuePairs.ContainsKey(trust[i][1]))
                {
                    keyValuePairs[trust[i][1]]++;
                }
            }
            foreach (var pair in keyValuePairs)
            {
                if (pair.Value == n - 1)
                {
                    return pair.Key;
                }
            }
            return  -1;
        }
        private int bestSolution(int n, int[][] trust)
        {
            if (n == 1) return 1;

            int[] trustCount = new int[n + 1];

            for (int i = 0; i < trust.Length; i++)
            {
                trustCount[trust[i][0]]--;
                trustCount[trust[i][1]]++;
            }

            for (int i = 0; i < trustCount.Length; i++)
            {
                if (trustCount[i] == n - 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
