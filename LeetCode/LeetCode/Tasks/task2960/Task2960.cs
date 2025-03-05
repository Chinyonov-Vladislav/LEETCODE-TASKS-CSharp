using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2960
{
    /*
     2960. Подсчет протестированных устройств после тестовых операций
    Вам дан нумерованный от 0 целочисленный массив batteryPercentages длиной n, обозначающий процент заряда батареи n нумерованных от 0 устройств.
    Ваша задача — протестировать каждое устройство i по порядку от 0 до n - 1, выполнив следующие тестовые операции:
    Если batteryPercentages[i] больше , чем 0:
        Увеличьте количество протестированных устройств.
        Уменьшите процент заряда батареи всех устройств с индексами j в диапазоне [i + 1, n - 1] на 1, чтобы процент заряда их батареи никогда не опускался ниже 0, то есть batteryPercentages[j] = max(0, batteryPercentages[j] - 1).
        Перейдите к следующему устройству.
    В противном случае перейдите к следующему устройству без проведения каких-либо тестов.
    Верните целое число, обозначающее количество устройств, которые будут протестированы после выполнения тестовых операций в указанном порядке.
    Ограничения:
        1 <= n == batteryPercentages.length <= 100 
        0 <= batteryPercentages[i] <= 100
    https://leetcode.com/problems/count-tested-devices-after-test-operations/description/
     */
    public class Task2960 : InfoBasicTask
    {
        public Task2960(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] batteryPercentages = new int[] { 1, 1, 2, 1, 3 };
            printArray(batteryPercentages, "Массив уровня зарядки устройств: ");
            if (isValid(batteryPercentages))
            {
                int res = countTestedDevices(batteryPercentages);
                Console.WriteLine($"Количество протестированных устройств = {res}");
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
        private bool isValid(int[] batteryPercentages)
        {
            if (batteryPercentages.Length < 1 || batteryPercentages.Length > 100)
            {
                return false;
            }
            foreach (int batteryPercentage in batteryPercentages) {
                if (batteryPercentage < 0 || batteryPercentage > 100)
                {
                    return false;
                }
            }
            return true;
        }
        private int countTestedDevices(int[] batteryPercentages)
        {
            int countTestedDevices = 0;
            for(int i=0;i<batteryPercentages.Length;i++)
            {
                if (batteryPercentages[i] > 0)
                {
                    countTestedDevices++;
                    for (int j = i + 1; j < batteryPercentages.Length; j++)
                    {
                        batteryPercentages[j] = Math.Max(0, batteryPercentages[j] - 1);
                    }
                }
            }
            return countTestedDevices;
        }
    }
}
