using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2383
{
    /*
     2383. Минимальное количество часов тренировок для победы в соревновании
    Вы участвуете в соревновании, и вам даны два положительных целых числа initialEnergy и initialExperience, обозначающие вашу начальную энергию и начальный опыт соответственно.
    Вам также даны два нумерованных от 0 целочисленных массива energy и experience длиной n.
    Вы будете сражаться с n противниками по очереди. Энергия и опыт ith противника обозначаются energy[i] и experience[i] соответственно. Чтобы победить противника и перейти к следующему, если он доступен, вам нужно иметь строго больше опыта и энергии.
    Победа над противником ith увеличивает ваш опыт на experience[i], но уменьшает вашу энергию на energy[i].
    Перед началом соревнований вы можете тренироваться в течение нескольких часов. После каждого часа тренировки вы можете либо увеличить свой начальный опыт на единицу, либо увеличить свою начальную энергию на единицу.
    Верните минимальное количество часов обучения, необходимых для победы над всеми n противниками.
        n == energy.length == experience.length
        1 <= n <= 100
        1 <= initialEnergy, initialExperience, energy[i], experience[i] <= 100
    https://leetcode.com/problems/minimum-hours-of-training-to-win-a-competition/description/
     */
    public class Task2383 : InfoBasicTask
    {
        public Task2383(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int initialEnergy = 5;
            int initialExperience = 3;
            int[] energy = new int[] { 1, 4, 3, 2 };
            int[] experience = new int[] { 2, 6, 3, 1 };
            Console.WriteLine($"Начальная энергия = {initialEnergy}");
            Console.WriteLine($"Начальный опыт = {initialExperience}");
            printArray(energy, "Энергия врагов: ");
            printArray(experience, "Опыт врагов: ");
            if (isValid(initialEnergy, initialExperience, energy, experience))
            {
                int countH = minNumberOfHours(initialEnergy, initialExperience, energy, experience);
                Console.WriteLine($"Минимальное количество чассов тренировки для победы на всеми врагами = {countH}");
            }
            else
            {
                Console.WriteLine($"Исходный данные не валидны!");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(int initialEnergy, int initialExperience, int[] energy, int[] experience)
        {
            if (energy.Length != experience.Length)
            {
                return false;
            }
            int n = energy.Length;
            if (n < 1 || n > 100)
            {
                return false;
            }
            if (initialEnergy < 1 || initialEnergy > 100)
            {
                return false;
            }
            if (initialExperience < 1 || initialExperience > 100)
            {
                return false;
            }
            foreach (var item in energy)
            {
                if (item < 1 || item > 100)
                {
                    return false;
                }
            }
            foreach (var item in experience)
            {
                if (item < 1 || item > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int minNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
        {
            int minCountHours = 0;
            int index = 0;
            while (index<energy.Length)
            {
                if (initialEnergy > energy[index] && initialExperience > experience[index])
                {
                    initialExperience += experience[index];
                    initialEnergy -= energy[index];
                    index++;
                }
                else
                {
                    if (initialEnergy <= energy[index])
                    {
                        int diff = energy[index] - initialEnergy + 1;
                        minCountHours += diff;
                        initialEnergy += diff;
                    }
                    if (initialExperience <= experience[index])
                    {
                        int diff = experience[index] - initialExperience + 1;
                        minCountHours += diff;
                        initialExperience += diff;
                    }
                }
            }
            return minCountHours;
        }
    }
}
