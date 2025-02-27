using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2299
{
    /*
     2299. Проверка надежного пароля II
    Пароль считается надёжным, если он соответствует всем следующим критериям:
        В нем есть, по крайней мере, 8 символов.
        Он содержит по крайней мере одну строчную букву.
        Он содержит по крайней мере одну заглавную букву.
        Он содержит по крайней мере одну цифру.
        Он содержит по крайней мере один специальный символ. Специальные символы — это символы в следующей строке: "!@#$%^&*()-+".
        Он не содержит 2 одинаковых символов в соседних позициях (то есть "aab" нарушает это условие, а "aba" — нет).
    Учитывая строку password, верните true если это надежный пароль. В противном случае верните false.
    https://leetcode.com/problems/strong-password-checker-ii/description/
     */
    public class Task2299 : InfoBasicTask
    {
        public Task2299(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string password = "IloveLe3tcode!";
            Console.WriteLine($"Пароль: \"{password}\"");
            Console.WriteLine(strongPasswordCheckerII(password) ? "Пароль является надежным" : "Пароль не является надежным");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool strongPasswordCheckerII(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            string specialChars = "!@#$%^&*()-+";
            bool isContainUpperCaseLetter = false;
            bool isContainLowerCaseLetter = false;
            bool isContainDigit = false;
            bool isContainSpecialChar = false;
            bool isContainTwoIdenticalSymbolsInAdjacentPositions = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (i > 0)
                {
                    if (password[i] == password[i - 1] && !isContainTwoIdenticalSymbolsInAdjacentPositions)
                    {
                        isContainTwoIdenticalSymbolsInAdjacentPositions = true;
                    }
                }
                if (char.IsUpper(password[i]))
                {
                    isContainUpperCaseLetter = true;
                }
                if (char.IsLower(password[i]))
                {
                    isContainLowerCaseLetter= true;
                }
                if (specialChars.Contains(password[i]))
                {
                    isContainSpecialChar = true;
                }
                if (char.IsDigit(password[i]))
                {
                    isContainDigit = true;
                }
            }
            if (!isContainUpperCaseLetter || !isContainLowerCaseLetter || !isContainDigit || !isContainSpecialChar || isContainTwoIdenticalSymbolsInAdjacentPositions)
            {
                return false;
            }
            return true;
        }
    }
}
