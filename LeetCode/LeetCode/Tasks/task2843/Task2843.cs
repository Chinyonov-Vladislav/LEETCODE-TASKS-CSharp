using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2843
{
    /*
     2843. Подсчитывать симметричные целые числа
    Вам даны два натуральных числа low и high.
    Целое число x, состоящее из 2 * n цифр, является симметричным, если сумма первых n цифр x равна сумме последних n цифр x. 
    Числа с нечётным количеством цифр никогда не бывают симметричными.
    Возвращает количество симметричных целых чисел в диапазоне [low, high].
    Ограничения:
        1 <= low <= high <= 10^4
    https://leetcode.com/problems/count-symmetric-integers/description/
     */
    public class Task2843 : InfoBasicTask
    {
        public Task2843(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int low = 1200;
            int high = 1230;
            Console.WriteLine($"Нижняя граница = {low}\nВерхняя граница = {high}");
            if (isValid(low, high))
            {
                int count = countSymmetricIntegers(low, high);
                Console.WriteLine($"Количество симметричных чисел в диапазоне от {low} до {high} = {count}");
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
        private bool isValid(int low, int high)
        {
            int highLimit = (int)Math.Pow(10, 4);
            if (low < 1 || low > highLimit || high < 1 || high > highLimit || high < low)
            {
                return false;
            }
            return true;
        }
        private int countSymmetricIntegers(int low, int high)
        {
            int count = 0;
            for (int i = low; i <= high; i++)
            {
                int currentNumber = i;
                List<int> digits = new List<int>();
                while (currentNumber != 0)
                {
                    digits.Add(currentNumber % 10);
                    currentNumber /= 10;
                }
                if (digits.Count % 2 != 0)
                {
                    continue;
                }
                int sumLeft = 0;
                int sumRight = 0;
                int left = 0;
                int right = digits.Count-1;
                while (left < right)
                {
                    sumLeft += digits[left];
                    sumRight += digits[right];
                    left++;
                    right--;
                }
                if (sumLeft == sumRight)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
