using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2566
{
    /*
     2566. Максимальная разница при переназначении цифры
    Вам дано целое число num. Вы знаете, что Боб тайно переназначит одну из 10 возможных цифр (0 на 9) на другую цифру.
    Верните разницу между максимальным и минимальным значениями, которые Боб может получить, изменив ровно однуцифру в num.
    Примечания:
        Когда Боб переназначает цифру d1 к другой цифре d2, Боб заменяет все вхождения d1 in num на d2.
        Боб может переназначить цифру самой себе, и в этом случае num не изменится.
        Боб может переназначать разные цифры для получения минимального и максимального значений соответственно.
    Результирующее число после переназначения может содержать начальные нули.
    Ограничения:
        1 <= num <= 10^8
    https://leetcode.com/problems/maximum-difference-by-remapping-a-digit/description/
     */
    public class Task2566 : InfoBasicTask
    {
        public Task2566(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int number = 11891;
            Console.WriteLine($"Исходное число = {number}");
            if (isValid(number))
            {
                int result = minMaxDifference(number);
                Console.WriteLine($"Результат = {result}");
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
        private bool isValid(int num)
        {
            int upperLimit = (int)Math.Pow(10, 8);
            if (num < 1 || num > upperLimit)
            {
                return false;
            }
            return true;
        }
        private int minMaxDifference(int num)
        {
            List<int> minValueList = new List<int>();
            List<int> maxValueList = new List<int>();
            int copyNum = num;
            while (copyNum != 0) {
                int digit = copyNum % 10;
                minValueList.Add(digit);
                maxValueList.Add(digit);
                copyNum /= 10;
            }
            minValueList.Reverse();
            maxValueList.Reverse();
            int digitForReplaceMax = 9;
            int digitForReplaceMin = 0;
            for (int i = 0; i < minValueList.Count; i++)
            {
                if (minValueList[i] != 0)
                {
                    digitForReplaceMin = minValueList[i];
                    break;
                }
            }
            for (int i = 0; i < maxValueList.Count; i++)
            {
                if (maxValueList[i] != 9)
                {
                    digitForReplaceMax = maxValueList[i];
                    break;
                }
            }
            for (int i = 0; i < minValueList.Count; i++)
            {
                if (minValueList[i] == digitForReplaceMin)
                {
                    minValueList[i] = 0;
                }
                if (maxValueList[i] == digitForReplaceMax)
                {
                    maxValueList[i] = 9;
                }
            }
            int minValue = 0;
            int maxValue = 0;
            for (int i = 0; i < minValueList.Count; i++)
            {
                minValue += minValueList[i] * (int)Math.Pow(10, minValueList.Count - i - 1);
                maxValue += maxValueList[i] * (int)Math.Pow(10, maxValueList.Count - i - 1);
            }
            
            minValue = num < minValue ? num : minValue;
            maxValue = maxValue < num ? num : maxValue;
            return maxValue - minValue;
        }
    }
}
