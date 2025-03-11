using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3270
{
    /*
     3270. Найди ключ к цифрам
    Вам даны три положительных целых числа num1, num2 и num3.
    key из num1, num2, и num3 определяется как четырёхзначное число, такое что:
        Изначально, если в каком-либо числе меньше четырёх цифр, оно дополняется начальными нулями.
        Цифра ith (1 <= i <= 4) в key получается путём взятия наименьшей цифры среди ith цифр num1, num2, и num3.
    Верните key из трёх чисел без ведущих нулей (если они есть).
    Ограничения:
        1 <= num1, num2, num3 <= 9999
    https://leetcode.com/problems/find-the-key-of-the-numbers/description/
     */
    public class Task3270 : InfoBasicTask
    {
        public Task3270(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int num1 = 987;
            int num2 = 879;
            int num3 = 798;
            Console.WriteLine($"Первое число = {num1}\nВторое число = {num2}\nТретье число = {num3}");
            if (isValid(num1, num2, num3))
            {
                int res = generateKey(num1, num2, num3);
                Console.WriteLine($"Ключ, полученный путём взятия наименьшей цифры из каждого числа для каждой позиции = {res}");
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
        private bool isValid(int num1, int num2, int num3)
        {
            List<int> values = new List<int>() { num1, num2, num3 };
            foreach (int val in values)
            {
                if (val < 1 || val > 9999)
                {
                    return false;
                }
            }
            return true;
        }
        private int generateKey(int num1, int num2, int num3)
        {
            string[] arrStr = new string[] { Convert.ToString(num1), Convert.ToString(num2), Convert.ToString(num3) };
            for (int i = 0; i < arrStr.Length; i++)
            {
                if (arrStr[i].Length < 4)
                {
                    int count = 4 - arrStr[i].Length;
                    StringBuilder sb = new StringBuilder();
                    sb.Append('0', count);
                    sb.Append(arrStr[i]);
                    arrStr[i] = sb.ToString();
                }
            }
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                int min = Math.Min(arrStr[0][i] - '0', Math.Min(arrStr[1][i] - '0', arrStr[2][i] - '0'));
                result += min * (int)Math.Pow(10, 4 - i - 1);
            }
            return result;
        }
    }
}
