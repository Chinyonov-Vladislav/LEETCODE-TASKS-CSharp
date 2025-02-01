using LeetCode.Basic;
using System;

namespace LeetCode.Tasks.task66
{
    /*
     66. Плюс Один
     Вам дано большое целое число, представленное в виде массива целых чисел digits, где каждое digits[i] является ith цифрой целого числа. Цифры упорядочены от старших к младшим слева направо. Большое целое число не содержит ведущих 0's.
     Увеличьте большое целое число на единицу и верните полученный массив цифр.
     */
    public class Task66 : InfoBasicTask
    {
        public Task66(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] digits = new int[] { 1,2,3 };
            printArray(digits, "Исходный массив");
            int[] resultArray = plusOne(digits);
            printArray(resultArray, "Конечный массив");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int[] plusOne(int[] digits)
        {
            bool allNumbersIsNine = true;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != 9)
                {
                    allNumbersIsNine = false;
                    break;
                }
            }
            int[] resultArray = new int[allNumbersIsNine ? digits.Length+1 : digits.Length];
            if (allNumbersIsNine)
            {
                for (int i = 0; i < resultArray.Length; i++)
                {
                    if (i == 0)
                    {
                        resultArray[i] = 1;
                    }
                    else
                    {
                        resultArray[i] = 0;
                    }
                }
            }
            else
            {
                bool hasOverflow = false;
                for (int i = resultArray.Length - 1; i >= 0; i--)
                {
                    if (i == resultArray.Length - 1)
                    {
                        int currentDigit = digits[i] + 1;
                        if (currentDigit >= 10)
                        {
                            resultArray[i] = 0;
                            hasOverflow = true;
                        }
                        else
                        {
                            resultArray[i] = currentDigit;
                            hasOverflow = false;
                        }
                    }
                    else
                    {
                        if (hasOverflow)
                        {
                            int currentDigit = digits[i] + 1;
                            if (currentDigit >= 10)
                            {
                                resultArray[i] = 0;
                                hasOverflow = true;
                            }
                            else
                            {
                                resultArray[i] = currentDigit;
                                hasOverflow = false;
                            }
                        }
                        else
                        {
                            resultArray[i] = digits[i];
                            hasOverflow = false;
                        }
                    }
                }
            }
            return resultArray;
        }
    }
}
