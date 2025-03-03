using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2678
{
    /*
     2678. Количество пожилых граждан
    Вам дан нумерованный от 0 массив строк details. Каждый элемент details содержит информацию о конкретном пассажире, сжатую в строку длиной 15. Система устроена таким образом, что:
        Первые десять символов состоят из номера телефона пассажира.
        Следующий символ обозначает пол человека.
        Следующие два символа используются для обозначения возраста человека.
        Последние два символа определяют место, отведенное этому человеку.
    Верните количество пассажиров, которым строго больше 60 лет.
    Ограничения:
        1 <= details.length <= 100
        details[i].length == 15
        details[i] consists of digits from '0' to '9'.
        details[i][10] is either 'M' or 'F' or 'O'.
        Номера телефонов и номера мест пассажиров различны.
    https://leetcode.com/problems/number-of-senior-citizens/description/
     */
    public class Task2678 : InfoBasicTask
    {
        public Task2678(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] details = new string[] { "7868190130M7522", "5303914400F9211", "9273338290F4010" };
            printArray(details, "Массив информации: ");
            if (isValid(details))
            {
                int count = countSeniors(details);
                Console.WriteLine($"Количество людей, строго старше 60 лет = {count}");
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
        private bool isValid(string[] details)
        {
            if (details.Length < 1 || details.Length > 100)
            {
                return false;
            }
            List<char> accepetedCharInTenIndex = new List<char>() { 'M', 'F', 'O' };
            HashSet<string> numberPhones = new HashSet<string>();
            HashSet<string> numberPlaces = new HashSet<string>();
            foreach (var str in details)
            {
                if (str.Length != 15)
                {
                    return false;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 10)
                    {
                        if (!accepetedCharInTenIndex.Contains(str[i]))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!char.IsDigit(str[i]))
                        {
                            return false;
                        }
                    }
                }
                string numberPhone = str.Substring(0, 10);
                string numberPlace = str.Substring(13);
                numberPhones.Add(numberPhone);
                numberPlaces.Add(numberPlace);
            }
            if (numberPhones.Count != details.Length)
            {
                return false;
            }
            if (numberPlaces.Count != details.Length)
            {
                return false;
            }
            return true;
        }
        private int countSeniors(string[] details)
        {
            int count = 0;
            foreach (string s in details) {
                int number = Convert.ToInt32(s.Substring(11,2));
                if (number > 60)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
