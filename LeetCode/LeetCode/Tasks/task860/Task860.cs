using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task860
{
    /*
     860. Размен денег при продаже лимонада
    В лимонадном киоске каждый лимонад стоит $5. Покупатели стоят в очереди, чтобы купить у вас и заказать по одному (в порядке, указанном в счетах). Каждый клиент покупает только один лимонад и расплачивается либо $5, $10 либо $20 счетом. Вы должны предоставить правильное изменение каждому клиенту, чтобы чистая транзакция была той, которую оплачивает клиент $5.
    Обратите внимание, что поначалу у вас на руках нет никакой мелочи.
    Учитывая целочисленный массив bills где bills[i] — это счёт, который оплачивает ith клиент, верните true если вы можете выдать каждому клиенту сдачу, или false иначе.
     https://leetcode.com/problems/lemonade-change/description/
     */
    public class Task860 : InfoBasicTask
    {
        public Task860(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] bills = new int[] { 5, 5, 10, 10, 20};
            printArray(bills, "Валюты покупателей: ");
            Console.WriteLine(lemonadeChange(bills) ? "Все покупателям возможно будет дать сдачу" : "Невозможно дать сдачу все покупателям");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool lemonadeChange(int[] bills)
        {
            int countFives =  0;
            int countTen =  0;
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 5)
                {
                    countFives++;
                }
                else if (bills[i] == 10)
                {
                    if (countFives >= 1)
                    {
                        countFives--;
                        countTen++;
                    }
                    else
                    {
                        return false;
                    }
                }
                else 
                {
                   
                    if (countFives >= 1 && countTen >= 1)
                    {
                        countFives--;
                        countTen--;
                    }
                    else if(countFives >= 3)
                    {
                        countFives -= 3;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
