using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task441
{
    public class Task441 : InfoBasicTask
    {
        /*
         441. Расположение монет
        У вас есть n монет, и вы хотите построить лестницу из этих монет. Лестница состоит из k рядов, в каждом ith ряду ровно i монет. Последний ряд лестницы может быть неполным.
        Учитывая целое число n, верните количество полных строк лестницы, которую вы построите.
         */
        public Task441(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int countCoins = 5;
            Console.WriteLine($"Количество строки лестницы из {countCoins} монет = {arrangeCoins(countCoins)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int arrangeCoins(int n)
        {
            int numberRow = 0;
            while (n - (numberRow + 1) >= 0)
            {
                numberRow++;
                n -= numberRow;
            }
            return numberRow;
        }
        private int bestSolution(int n)
        {
            var low = 1;
            var high = n;

            while (low <= high)
            {
                var middle = low + (high - low) / 2;
                var total = 1L * (1 + middle) * middle / 2;

                if (total <= n)
                {
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }

            return high;
        }
    }
}
