using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Tasks.task925
{
    /*
     925. Долго нажатое имя
    Ваш друг набирает свой name текст на клавиатуре. Иногда при вводе символа c клавиша может быть долго нажата, и символ будет набран 1 или более раз.
    Вы просматриваете typed символы на клавиатуре. Вернитесь к True варианту, если возможно, что это было имя вашего друга, при этом некоторые символы (возможно, ни одного) были нажаты и удерживались.
    https://leetcode.com/problems/long-pressed-name/description/
     */
    public class Task925 : InfoBasicTask
    {
        public Task925(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string name = "a";
            string typed = "b";
            Console.WriteLine($"Имя = \"{name}\"");
            Console.WriteLine($"Набранное имя = \"{typed}\"");
            Console.WriteLine(isLongPressedName(name, typed) ? "Имя может быть образованно из набранного имени" : "Имя не может быть образованно из набранного имени");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isLongPressedName(string name, string typed)
        {
            List<Tuple<char, int>> listForName = getCountLetters(name);
            List<Tuple<char, int>> listForTyped = getCountLetters(typed);
            if (listForName.Count != listForTyped.Count)
            {
                return false;
            }
            for (int i = 0; i < listForName.Count; i++)
            {
                if (listForName[i].Item1 != listForTyped[i].Item1 || listForName[i].Item2 > listForTyped[i].Item2)
                {
                    return false;
                }
            }
            return true;
        }
        private List<Tuple<char, int>> getCountLetters(string str)
        {
            List<Tuple<char, int>> values = new List<Tuple<char, int>>();
            char currentChar = ' ';
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    currentChar = str[i];
                    count++;
                    if (str.Length == 1)
                    {
                        values.Add(new Tuple<char, int>(currentChar, count));
                    }
                }
                else if (i == str.Length - 1)
                {
                    if (str[i] == currentChar)
                    {
                        count++;
                        values.Add(new Tuple<char, int>(currentChar, count));
                    }
                    else
                    {
                        values.Add(new Tuple<char, int>(currentChar, count));
                        values.Add(new Tuple<char, int>(str[i], 1));
                    }
                }
                else if (str[i] == currentChar)
                {
                    count++;
                }
                else if (str[i] != currentChar)
                {
                    values.Add(new Tuple<char, int>(currentChar, count));
                    currentChar = str[i];
                    count = 1;
                    if (i == str.Length - 1)
                    {
                        values.Add(new Tuple<char, int>(currentChar, count));
                    }
                }
                
            }
            return values;
        }
        // скопировано с leetcode
        private bool bestSolution(string name, string typed)
        {
            int i = 0, j = 0;

            while (j < typed.Length)
            {
                if (i < name.Length && name[i] == typed[j])
                {
                    i++; // Move in name
                    j++; // Move in typed
                }
                else if (j > 0 && typed[j] == typed[j - 1])
                {
                    j++; // Handle long press
                }
                else
                {
                    return false; // Invalid sequence
                }
            }

            return i == name.Length; // Ensure full name was matched
        }
    }
}
