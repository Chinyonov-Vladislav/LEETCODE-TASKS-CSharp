using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task771
{
    /*
     771. Драгоценности и камешки
    Вам даны строки jewels с описанием типов драгоценных камней и stones с описанием имеющихся у вас камней. Каждый символ в stones — это тип имеющегося у вас камня. Вы хотите узнать, сколько имеющихся у вас камней являются драгоценными.
    Буквы чувствительны к регистру, поэтому "a" считается другим типом камня, нежели "A".
     */
    public class Task771 : InfoBasicTask
    {
        public Task771(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine($"Строка драгоценности = \"{jewels}\"");
            Console.WriteLine($"Строка камни = \"{stones}\"");
            Console.WriteLine($"Количество драгоценностей в камнях = {numJewelsInStones(jewels, stones)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numJewelsInStones(string jewels, string stones)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in jewels)
            {
                dict.Add(c, 0);
            }
            foreach (char c in stones)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
            }
            return dict.Values.Sum();
        }
        private int bestSolution(string jewels, string stones) // скопировано с leetcode
        {
            var jewelsSet = new HashSet<char>();
            var ans = 0;
            for (var i = 0; i < jewels.Length; i++)
            {
                jewelsSet.Add(jewels[i]);
            }

            for (var i = 0; i < stones.Length; i++)
            {
                if (jewelsSet.Contains(stones[i]))
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
