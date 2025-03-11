using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3340
{
    /*
     3340. Проверьте сбалансированную строку
    Вам дана строка num, состоящая только из цифр. Строка из цифр называется сбалансированной, если сумма цифр в чётных позициях равна сумме цифр в нечётных позициях.
    Вернуть, true если num он сбалансирован, в противном случае вернуть false.
    Ограничения:
        2 <= num.length <= 100
        num состоит только из цифр
    https://leetcode.com/problems/check-balanced-string/description/
     */
    public class Task3340 : InfoBasicTask
    {
        public Task3340(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string num = "24123";
            Console.WriteLine($"Исходное число в строковом формате: \"{num}\"");
            if (isValid(num))
            {
                Console.WriteLine(isBalanced(num) ? "Исходная строка сбалансированна: сумма цифр в четных индексах равна сумме цифр в нечетных индексах" : "Исходная строка не сбалансированна: сумма цифр в четных индексах не равна сумме цифр в нечетных индексах");
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
        private bool isValid(string num)
        {
            if (num.Length < 2 || num.Length>100)
            {
                return false;
            }
            foreach (char c in num)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool isBalanced(string num)
        {
            int sumOdd = 0;
            int sumEven = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sumEven += num[i] - '0';
                }
                else
                {
                    sumOdd += num[i] - '0';
                }
            }
            return sumOdd == sumEven;
        }
    }
}
