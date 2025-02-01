using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task455
{
    public class Task455 : InfoBasicTask
    {
        /*
         455. Назначение печенья для детей
        Предположим, вы замечательный родитель и хотите угостить своих детей печеньем. Но вы должны дать каждому ребёнку не больше одного печенья.
        У каждого ребенка i есть фактор жадности g[i], который представляет собой минимальный размер печенья, которым ребенок будет доволен; 
        и у каждого печенья j есть размер s[j]. 
        Если s[j] >= g[i], мы можем назначить файл cookie j дочернему элементу i, и дочерний элемент i будет доволен. Ваша цель - увеличить количество дочерних элементов вашего контента и вывести максимальное их количество.
         */
        public Task455(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] g = new int[] { 1, 2 };
            int[] s = new int[] { 1, 2, 3 };
            Console.WriteLine($"Количество удовлетворенных детей = {findContentChildren(g,s)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int findContentChildren(int[] g, int[] s)
        {
            bool[] bools = new bool[s.Length];
            for (int i = 0; i < bools.Length; i++)
            {
                bools[i] = false;
            }
            int countSatisfiedChildren = 0;
            for (int indexForG=0; indexForG < g.Length; indexForG++) // итерация по факторам жадности
            {
                int indexCookieForStatisfaction = -1;
                int minSizeCookieForSatisfaction = int.MaxValue;
                for (int indexForS=0; indexForS < s.Length; indexForS++) // итерация по печеньям
                {
                    if (!bools[indexForS] && s[indexForS] >= g[indexForG])
                    {
                        if (s[indexForS] <= minSizeCookieForSatisfaction)
                        {
                            indexCookieForStatisfaction = indexForS;
                            minSizeCookieForSatisfaction = s[indexForS];
                        }
                        
                    }
                }
                if (indexCookieForStatisfaction >= 0)
                {
                    countSatisfiedChildren++;
                    bools[indexCookieForStatisfaction] = true;
                }
            }
            return countSatisfiedChildren;
        }
        private int bestSolution(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int n = g.Length;
            int m = s.Length;
            int greed = 0;
            int cookie = 0;
            while (cookie < m && greed < n)
            {
                if (g[greed] <= s[cookie])
                {
                    greed++;
                    cookie++;
                }
                else
                {
                    cookie++;
                }
            }
            return greed;
        }
    }
}
