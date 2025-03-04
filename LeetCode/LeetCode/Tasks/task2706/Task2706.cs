using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2706
{
    /*
     2706. Купите две шоколадные конфеты
    Вам дан целочисленный массив prices, представляющий цены на различные шоколадки в магазине. Вам также дано одно целое число money, представляющее вашу начальную сумму денег.
    Вы должны купить ровно две шоколадки так, чтобы у вас осталось неотрицательное количество денег. Вы хотите минимизировать сумму цен двух купленных вами шоколадок.
    Верните сумму, которая останется у вас после покупки двух шоколадок. Если вы не можете купить две шоколадки, не влезая в долги, верните money. Обратите внимание, что остаток должен быть неотрицательным.
    Ограничения:
        2 <= prices.length <= 50
        1 <= prices[i] <= 100
        1 <= money <= 100
    https://leetcode.com/problems/buy-two-chocolates/description/
     */
    public class Task2706 : InfoBasicTask
    {
        public Task2706(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] prices = new int[] { 1, 2, 2 };
            int money = 3;
            printArray(prices, "Массив цен: ");
            Console.WriteLine($"Количество денег = {money}");
            if (isValid(prices, money))
            {
                int restMoney = buyChoco(prices, money);
                Console.WriteLine(restMoney == money ? "Невозможно купить две шоколадки на имеющиеся деньги" : $"Остаток денег после покупки двух шоколадок = {restMoney}");
            }
            else
            {
                Console.WriteLine("Исходные данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int[] prices, int money)
        {
            if (prices.Length < 2 || prices.Length > 50)
            {
                return false;
            }
            foreach (int price in prices) {
                if (price < 1 || price > 100)
                {
                    return false;
                }
            }
            if (money < 1 || money > 100)
            {
                return false;
            }
            return true;
        }
        private int buyChoco(int[] prices, int money)
        {
            Array.Sort(prices);
            int sum = prices[0] + prices[1];
            if (sum <= money)
            {
                return money - sum;
            }
            return money;
        }
    }
}
