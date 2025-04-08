using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task848
{
    /*
     848. Смещение букв
    Вам дана строка s из строчных букв английского алфавита и целочисленный массив shifts той же длины.
    Вызовите shift() буквы, следующей за ней в алфавите, (перевернув её так, чтобы 'z' стала 'a').
        Например, shift('a') = 'b', shift('t') = 'u' и shift('z') = 'a'.
    Теперь для каждого shifts[i] = x мы хотим сдвинуть первые i + 1 букв s на x раз.
    Верните последнюю строку после применения всех таких сдвигов на s.
    Ограничения:
        1 <= s.length <= 10^5
        s состоит из строчных английских букв.
        shifts.length == s.length
        0 <= shifts[i] <= 10^9
    https://leetcode.com/problems/shifting-letters/description/
     */
    public class Task848 : InfoBasicTask
    {
        public Task848(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string initialString = "abc";
            int[] shifts = new int[] { 3, 5, 9 };
            Console.WriteLine($"Исходная строка: \"{initialString}\"");
            printArray(shifts, "Массив сдвигов: ");
            if (isValid(initialString, shifts))
            {
                string res = shiftingLetters(initialString, shifts);
                Console.WriteLine($"Конечная строка после сдвигов: \"{res}\"");
            }
            else
            {
                printInfoNotValidData();
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isValid(string s, int[] shifts)
        {
            int lowLimitLengthInitialString = 1;
            int highLimitLengthInitialString = (int)Math.Pow(10, 5);
            int lowLimitValueShift = 0;
            int highLimitValueShift = (int)Math.Pow(10, 9);
            if (s.Length < lowLimitLengthInitialString || s.Length > highLimitLengthInitialString)
            {
                return false;
            }
            foreach (char c in s)
            {
                if (!(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            if (shifts.Length != s.Length)
            {
                return false;
            }
            foreach (int valueShift in shifts)
            {
                if (valueShift < lowLimitValueShift || valueShift > highLimitValueShift)
                {
                    return false;
                }
            }
            return true;
        }
        private string shiftingLetters(string s, int[] shifts)
        {
            long[] totalShifts = new long[shifts.Length];
            for (int i = shifts.Length - 1; i >= 0; i--)
            {
                if (i == shifts.Length - 1)
                {
                    totalShifts[i] = shifts[i];
                }
                else
                {
                    totalShifts[i] = shifts[i] + totalShifts[i + 1];
                }
            }
            char[] chars = s.ToCharArray();
            for (int i = 0; i < totalShifts.Length; i++)
            {
                long valueCurrentValue = chars[i] - 'a';
                long valueCharAfterShift = (valueCurrentValue + totalShifts[i]) % 26;
                chars[i] = (char)(valueCharAfterShift + 'a');
            }
            return new string(chars);
        }
    }
}
