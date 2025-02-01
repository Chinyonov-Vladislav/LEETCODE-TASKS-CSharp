using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task830
{
    /*
     830. Позиции больших групп
    В строке s из строчных букв эти буквы образуют последовательные группы из одинаковых символов.
    Например, в строке s = "abbxxxxzyy" есть группы "a", "bb", "xxxx", "z" и "yy".
    Группа определяется интервалом [start, end], где start и end обозначают начальный и конечный индексы (включительно) группы. В приведённом выше примере "xxxx" имеет интервал [3,6].
    Группа считается большой, если в ней 3 или более персонажей.
    Верните интервалы каждой большой группы, отсортированные в порядке возрастания начального индекса.
    https://leetcode.com/problems/positions-of-large-groups/description/
     */
    public class Task830 : InfoBasicTask
    {
        public Task830(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "abcdddeeeeaabbbcd";
            IList<IList<int>> result = largeGroupPositions(str);
            if (result.Count == 0)
            {
                Console.WriteLine("Нет ни одной большой группы, где количество участников больше 3");
            }
            else
            {
                Console.WriteLine("Большие группы, где количество участников больше 3:");
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine($"[{result[i][0]},{result[i][1]}]");
                }
            }

        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<IList<int>> largeGroupPositions(string s)
        {

            IList<IList<int>> result = new List<IList<int>>();
            int startIndex = 0;
            int endIndex = 0;
            List<int> currentGroup = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (currentGroup.Count == 0)
                {
                    startIndex = i;
                }
                currentGroup.Add(s[i]);
                if (i < s.Length - 1 && s[i+1] != currentGroup[0])
                {
                    endIndex = i;
                    if (currentGroup.Count >= 3)
                    {
                        result.Add(new List<int>() { startIndex, endIndex });
                    }
                    currentGroup.Clear();
                    continue;
                }
                if (i == s.Length-1 && currentGroup.Count >=3)
                {
                    result.Add(new List<int>() { startIndex, i });
                }
            }
            return result;
        }
        // скопировано с leetcode
        private IList<IList<int>> bestSolution(string s)
        {
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < s.Length;)
            {
                char current = s[i];
                int next = i + 1;
                int start = i;
                while (next < s.Length && current == s[next])
                {
                    next++;
                    i++;
                }

                int diff = Math.Abs(next - start);
                if (diff >= 3)
                {
                    IList<int> interval = new List<int>() { start, next - 1 };
                    result.Add(interval);
                }
                i++;
            }
            return result;
        }
    }
}
