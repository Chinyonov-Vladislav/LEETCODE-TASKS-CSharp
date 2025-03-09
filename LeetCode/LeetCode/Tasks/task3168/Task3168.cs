using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3168
{
    /*
     3168. Минимальное количество стульев в комнате ожидания
    Вам дана строка s. Моделируйте события каждую секунду i:
        Если s[i] == 'E' человек входит в комнату ожидания и садится на один из стульев.
        Если s[i] == 'L', человек покидает зал ожидания, освобождая стул.
    Верните минимальное количество стульев, необходимое для того, чтобы у каждого вошедшего в комнату ожидания человека был стул, учитывая, что изначально она пуста.
    Ограничения:
        1 <= s.length <= 50
        s состоит только из букв 'E' и 'L'.
        s представляет допустимую последовательность входов и выходов.
    https://leetcode.com/problems/minimum-number-of-chairs-in-a-waiting-room/description/
     */
    public class Task3168 : InfoBasicTask
    {
        public Task3168(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "ELEELEELLL";
            Console.WriteLine($"Исходная строка прихода и ухода людей: \"{s}\" (E - человек входит в комнату ожидания и садится на один из стульев, L - человек покидает зал ожидания, освобождая стул)");
            if (isValid(s))
            {
                int min = minimumChairs(s);
                Console.WriteLine($"Минимальное количество стульев для размещения всех людей = {min}");
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
        private bool isValid(string s)
        {
            if (s.Length < 1 || s.Length > 50)
            {
                return false;
            }
            int countPeople = 0;
            List<char> acceptedChars = new List<char>() { 'E', 'L' };
            foreach (char c in s)
            {
                if (!acceptedChars.Contains(c))
                {
                    return false;
                }
                if (c == 'E')
                {
                    countPeople++;
                }
                else
                {
                    countPeople--;
                    if (countPeople < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private int minimumChairs(string s)
        {
            int countPeople = 0;
            int max = 0;
            foreach (char c in s)
            {
                if (c == 'E')
                {
                    countPeople++;
                    if (countPeople > max)
                    {
                        max = countPeople;
                    }
                }
                else
                {
                    countPeople--;
                }
            }
            return max;
        }
    }
}
