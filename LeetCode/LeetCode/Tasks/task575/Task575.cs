using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task575
{
    /*
     575. Раздача конфет
    У Алисы есть n конфет, где ith конфета относится к типу candyType[i]. Алиса заметила, что начала набирать вес, поэтому она обратилась к врачу.
    Врач посоветовал Алисе есть только n / 2 имеющихся у неё конфет (n всегда чётное число). Алисе очень нравятся её конфеты, и она хочет съесть максимальное количество разных видов конфет, следуя совету врача.
    Учитывая целочисленный массив candyType длиной n, верните максимальноеколичестворазных видов конфет, которые она может съесть, если будет есть толькоn / 2из них.
     */
    public class Task575 : InfoBasicTask
    {
        public Task575(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            
        }

        public override void execute()
        {
            int[] candies = new int[] { 6, 6, 6, 6 };
            int countTypesCandiesForEating = distributeCandies(candies);
            Console.WriteLine($"Алиса может съесть {countTypesCandiesForEating} типов конфет");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int distributeCandies(int[] candyType)
        {
            int countCandiesForEat = candyType.Length / 2;
            HashSet<int> uniqueTypeCandies = new HashSet<int>(candyType);
            return uniqueTypeCandies.Count >= countCandiesForEat ? countCandiesForEat : uniqueTypeCandies.Count;
        }
    }
}
