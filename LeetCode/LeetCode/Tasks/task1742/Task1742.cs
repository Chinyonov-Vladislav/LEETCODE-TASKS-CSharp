using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1742
{
    /*
     1742. Максимальное количество мячей в коробке
    Вы работаете на фабрике по производству мячей, где у вас есть n мячей с номерами от lowLimit до highLimit включительно (то есть n == highLimit - lowLimit + 1), а также бесконечное количество коробок с номерами от 1 до infinity.
    Ваша задача на этой фабрике — положить каждый шарик в коробку с номером, равным сумме цифр номера шарика. Например, шарик с номером 321 будет положен в коробку с номером 3 + 2 + 1 = 6, а шарик с номером 10 будет положен в коробку с номером 1 + 0 = 1.
    Учитывая два целых числа lowLimit и highLimit, верните количество шаров в коробке с наибольшим количеством шаров.
    https://leetcode.com/problems/maximum-number-of-balls-in-a-box/description/
     */
    public class Task1742 : InfoBasicTask
    {
        public Task1742(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int lowLimit = 19;
            int highLimit = 28;
            if (isCorrectInputData(lowLimit, highLimit))
            {
                Console.WriteLine($"Нижний лимит = {lowLimit}\nВерхний лимит = {highLimit}");
                int countMaxBallsInBox = countBalls(lowLimit, highLimit);
                Console.WriteLine($"Максимальное количество шаров в коробке = {countMaxBallsInBox}");
            }
            else
            {
                Console.WriteLine("Неверные исходные данные!");
            }

        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isCorrectInputData(int lowLimit, int highLimit)
        {
            if (lowLimit < 1 || highLimit < lowLimit)
            {
                return false;
            }
            return true;
        }
        private int countBalls(int lowLimit, int highLimit)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = lowLimit; i <= highLimit; i++)
            {
                int sum = 0;
                int currentNumberBall = i;
                while (currentNumberBall != 0)
                {
                    int digit = currentNumberBall % 10;
                    sum += digit;
                    currentNumberBall /= 10;
                }
                if (dict.ContainsKey(sum))
                {
                    dict[sum]++;
                }
                else
                {
                    dict.Add(sum, 1);
                }
            }
            return dict.OrderByDescending(item => item.Value).First().Value;
        }
    }
}
