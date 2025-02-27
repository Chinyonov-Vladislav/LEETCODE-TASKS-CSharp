using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2347
{
    /*
     2347. Лучшая покерная комбинация
    Вам дан целочисленный массив ranks и символьный массив suits. У вас есть 5 карт, где ith карта имеет ранг ranks[i] и масть suits[i].
    Ниже приведены типы покерных комбинаций, которые вы можете собрать, от лучших к худшим:
        "Flush": Пять карт одной масти.
        "Three of a Kind": Три карты одного ранга.
        "Pair": Две карты одного ранга.
        "High Card": Любая отдельная карта.
    Верните строку, представляющуюлучший типпокерной комбинации, которую вы можете составить из данных карт.
    Обратите внимание, что возвращаемые значения чувствительны к регистру.
    https://leetcode.com/problems/best-poker-hand/description/
     */
    public class Task2347 : InfoBasicTask
    {
        public Task2347(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] ranks = new int[] { 13, 2, 3, 1, 9 };
            char[] suits = new char[] { 'a', 'a', 'a', 'a', 'a' };
            printArray(ranks, "Массив рангов карт: ");
            printArray(suits, "Массив мастей карт: ");
            if (isValid(ranks, suits))
            {
                string res = bestHand(ranks, suits);
                Console.WriteLine($"Лучшая возможная комбинация = \"{res}\"");
            }
            else
            {
                Console.WriteLine("Массив рангов и/или мастей карт не валиден. Оба массива должны содержить по 5 элементов!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] ranks, char[] suits)
        {
            if (ranks.Length != 5 || suits.Length != 5)
            {
                return false;
            }
            return true;
        }
        private string bestHand(int[] ranks, char[] suits)
        {
            HashSet<char> setSuits = new HashSet<char>(suits);
            if (setSuits.Count == 1)
            {
                return "Flush";
            }
            Dictionary<int, int> dictRanks = new Dictionary<int, int>();
            for (int i = 0; i < ranks.Length; i++)
            {
                if (dictRanks.ContainsKey(ranks[i]))
                {
                    dictRanks[ranks[i]]++;
                }
                else
                {
                    dictRanks.Add(ranks[i], 1);
                }
            }
            int count = dictRanks.OrderByDescending(x => x.Value).First().Value;
            if (count >= 3)
            {
                return "Three of a Kind";
            }
            if (count == 2)
            {
                return "Pair";
            }
            return "High Card";
        }
    }
}
