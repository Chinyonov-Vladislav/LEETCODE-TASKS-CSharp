using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2094
{
    /*
     2094. Поиск 3-значных четных чисел
    Вам дан целочисленный массив digits, где каждый элемент является цифрой. Массив может содержать дубликаты.
    Вам нужно найти все уникальные целые числа, которые соответствуют заданным требованиям:
        Целое число состоит из последовательноститрёх элементов из digits в любом произвольном порядке.
        Целое число не имеет начальных нулей.
        Целое число является четным.
    Например, если заданные digits были [1, 2, 3], то целые числа 132 и 312 соответствуют требованиям.
    Возвращает отсортированный массив уникальных целых чисел.
    https://leetcode.com/problems/finding-3-digit-even-numbers/description/
     */
    public class Task2094 : InfoBasicTask
    {
        public Task2094(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] numbers = new int[] { 2, 2, 8, 8, 2 };
            printArray(numbers, "Исходный массив цифр: ");
            int[] result = findEvenNumbers(numbers);
            printArray(result, "Массив четных чисел, составленных из массива цифр: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int[] findEvenNumbers(int[] digits)
        {
            int[] digitFreq = new int[10];
            foreach (var digit in digits)
            {
                digitFreq[digit]++;
            }
            List<int> numbers = new List<int>();
            for (int number = 100; number <= 999; number+=2)
            {
                int[] digitFreqCurrentNumber = new int[10];
                int currentNumber = number;
                while (currentNumber != 0)
                {
                    int digit = currentNumber % 10;
                    digitFreqCurrentNumber[digit]++;
                    currentNumber /= 10;
                }
                bool isCorrect = true;
                for (int i = 0; i < 10; i++)
                {
                    if (digitFreqCurrentNumber[i] > digitFreq[i])
                    {
                        isCorrect = false;
                        break;
                    }
                }
                if (isCorrect)
                {
                    numbers.Add(number);
                }
            }
            return numbers.ToArray();
        }
    }
}
