using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task121
{
    public class Task121 : InfoBasicTask
    {
        /*
         121. Лучшее время для покупки и продажи акций
        Вам дан массив prices с ценами prices[i] на акции в день ith
        Вы хотите максимизировать свою прибыль, выбрав один день для покупки акций и другой день в будущем для их продажи
        Верните максимальную прибыль, которую вы можете получить от этой сделки. Если вы не можете получить никакой прибыли, верните 0.
         */
        public Task121(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] cost = new int[] { 1,2 };
            Console.WriteLine($"Максимальный профит = {maxProfit(cost)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxProfit(int[] prices)
        {
            if (prices.Length <= 1)
            {
                return 0;
            }
            int maxProfit = 0;
            int costBuy = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < costBuy)
                {
                    costBuy = prices[i];
                    continue;
                }
                if (prices[i] - costBuy > maxProfit)
                {
                    maxProfit = prices[i] - costBuy;
                }
            }
            return maxProfit;
        }
    }
}
