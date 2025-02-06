using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1431
{
    /*
     1431. Дети, получившие наибольшее количество конфет
    Есть n детей с конфетами. Вам дан целочисленный массив candies, где каждое candies[i] значение представляет количество конфет у ith ребёнка, и целое число extraCandies, обозначающее количество дополнительных конфет, которые есть у вас.
    Верните булевский массив result длиной n, где result[i] — true если после того, как вы раздадите ith всем детям extraCandies, у них будет наибольшее количество конфет среди всех детей, или false в противном случае.
    Обратите внимание, что несколько детей могут получить наибольшее количество конфет.
    https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/description/
     */
    public class Task1431 : InfoBasicTask
    {
        public Task1431(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] candies = new int[] { 2, 3, 5, 1, 3 };
            printArray(candies, "Количество конфет у детей: ");
            int extraCandies = 3;
            Console.WriteLine($"Количество дополнительных конфет = {extraCandies}");
            IList<bool> res = kidsWithCandies(candies, extraCandies);
            printIListBool(res, "Результат: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private IList<bool> kidsWithCandies(int[] candies, int extraCandies)
        {
            IList<bool> result = new List<bool>();
            int maxCandies = candies.Max();
            for (int i = 0; i < candies.Length; i++)
            {
                result.Add(candies[i] + extraCandies >= maxCandies);
            }
            return result;
        }
    }
}
