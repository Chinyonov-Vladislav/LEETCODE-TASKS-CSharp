using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2806
{
    /*
     2806. Баланс счета после округленной покупки
    Изначально на вашем банковском счёте 100 долларов.
    Вам дано целое число purchaseAmount — сумма, которую вы потратите на покупку в долларах, другими словами, её цена.
    При совершении покупки сначала purchaseAmount сумма округляется до ближайшего кратного 10 числа. 
    Назовём это значение roundedAmount. Затем с вашего банковского счёта списывается roundedAmount долларов.
    Верните целое число, обозначающее конечный баланс вашего банковского счета после этой покупки.
    Примечания:
        В этой задаче 0 считается кратным 10.
        При округлении 5 округляется в большую сторону (5 округляется до 10, 15 округляется до 20, 25 до 30 и так далее).
    Ограничения:
        0 <= purchaseAmount <= 100
    https://leetcode.com/problems/account-balance-after-rounded-purchase/description/
     */
    public class Task2806 : InfoBasicTask
    {
        public Task2806(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int purchaseAmount = 9;
            Console.WriteLine($"Стоимость покупки = {purchaseAmount}");
            if (isValid(purchaseAmount))
            {
                int res = accountBalanceAfterPurchase(purchaseAmount);
                Console.WriteLine($"Баланс аккаунта после покупки = {res}");
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
        private bool isValid(int purchaseAmount)
        {
            if (purchaseAmount < 0 || purchaseAmount > 100)
            {
                return false;
            }
            return true;
        }
        private int accountBalanceAfterPurchase(int purchaseAmount)
        {
            return 100 - (int)Math.Floor((decimal)((purchaseAmount+5)/10))*10;
        }
    }
}
