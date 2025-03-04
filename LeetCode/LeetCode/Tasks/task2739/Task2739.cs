using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2739
{
    /*
     2739. Общее пройденное расстояние
    У грузовика есть два топливных бака. Вам даны два целых числа, mainTank обозначающих количество топлива в основном баке в литрах и additionalTank обозначающих количество топлива в дополнительном баке в литрах.
    Грузовик расходует 10 км на литр. Всякий раз, когда в основном баке расходуется 5 литров топлива, если в дополнительном баке есть не менее 1 литров топлива, 1 литров топлива будет перетекать из дополнительного бака в основной.
    Вернитесь на максимальное расстояние, которое можно преодолеть.
    Примечание: впрыск из дополнительного бака не является непрерывным. Он происходит внезапно и сразу после каждых 5 литров израсходованного топлива.
    Ограничения:
        1 <= mainTank, additionalTank <= 100
    https://leetcode.com/problems/total-distance-traveled/description/
     */
    public class Task2739 : InfoBasicTask
    {
        public Task2739(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int mainTank = 5;
            int additionalTank = 10;
            Console.WriteLine($"Главный бак = {mainTank} л.");
            Console.WriteLine($"Дополнительный бак = {additionalTank} л.");
            if (isValid(mainTank, additionalTank))
            {
                int dist = distanceTraveled(mainTank, additionalTank);
                Console.WriteLine($"Расстояние = {dist} км.");
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
        private bool isValid(int mainTank, int additionalTank)
        {
            if (mainTank < 1 || mainTank > 100 || additionalTank < 1 || additionalTank > 100)
            {
                return false;
            }
            return true;
        }
        private int distanceTraveled(int mainTank, int additionalTank)
        {
            int expenditure = 0;
            int distance = 0;
            while (mainTank != 0)
            {
                mainTank--;
                distance += 10;
                expenditure++;
                if (expenditure == 5 && additionalTank>0)
                {
                    additionalTank--;
                    expenditure = 0;
                    mainTank++;
                }
            }
            return distance;
        }
        // скопировано с leetcode
        private int bestSolution(int mainTank, int additionalTank)
        {
            int result = 0;

            while (mainTank >= 5)
            {
                mainTank -= 5;
                result += 50;
                mainTank += additionalTank > 0 ? 1 : 0;
                additionalTank--;
            }

            result += mainTank * 10;

            return result;
        }
    }
}
