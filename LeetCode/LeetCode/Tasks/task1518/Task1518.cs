using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1518
{
    /*
     1518. Бутылки с водой
    Есть numBottles бутылки для воды, которые изначально наполнены водой. Вы можете обменять numExchange пустые бутылки для воды с рынка на одну полную бутылку.
    Операция по выпиванию полной бутылки воды превращает ее в пустую бутылку.
    Учитывая два целых числа numBottles и numExchange, верните максимальноеколичествобутылок воды, которые вы можете выпить. 
    https://leetcode.com/problems/water-bottles/description/
     */
    public class Task1518 : InfoBasicTask
    {
        public Task1518(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int numBottles = 9;
            int countBottlesForExchange = 3;
            Console.WriteLine($"Количество бутылок, наполненных водой = {numBottles}");
            Console.WriteLine($"Количество пустых бутылок для обмена = {countBottlesForExchange}");
            int totalCountBottles = numWaterBottles(numBottles, countBottlesForExchange);
            Console.WriteLine($"Общее количество бутылок, наполненных водой = {totalCountBottles}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int numWaterBottles(int numBottles, int numExchange)
        {
            int totalCountBootles = numBottles;
            while (numBottles >= numExchange)
            {
                int countNewBottles = numBottles / numExchange;
                totalCountBootles += countNewBottles;
                numBottles = numBottles - numExchange * countNewBottles + countNewBottles;
            }
            return totalCountBootles;
        }
    }
}
