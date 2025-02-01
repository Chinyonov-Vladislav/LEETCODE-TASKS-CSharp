using System;
using System.Collections.Generic;
using LeetCode.Basic;

namespace LeetCode.Tasks.Task13
{
    public class Task13 : InfoBasicTask
    {
        private Dictionary<string, int> romanNumbers;
        public Task13(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            romanNumbers = new Dictionary<string, int>()
            {
                { "I",1 },
                { "II",2 },
                { "III",3 },
                { "IV",4 },
                { "V",5 },
                { "IX",9 },
                { "X",10 },
                { "XL",40 },
                { "L",50 },
                { "XC",90 },
                { "C",100 },
                { "CD",400 },
                { "D", 500},
                { "CM",900 },
                { "M",1000 },
            };
        }

        public override void execute()
        {
            List<string> romans = new List<string>() {
                "III", "LVIII","MCMXCIV"
            };
            foreach (var roman in romans)
            {
                Console.WriteLine($"Римское число: {roman} | Арабское число: {romanToInt(roman)}");
            }
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int romanToInt(string s)
        {
            int resultNumber = 0;
            string currentNumber = "";
            int index = 0;
            while (index < s.Length)
            {
                {
                    currentNumber += s[index];
                    if (index < s.Length - 1)
                    {
                        if (
                            (s[index] == 'I' && (s[index + 1] == 'V' || s[index + 1] == 'X')) ||
                            (s[index] == 'X' && (s[index + 1] == 'L' || s[index + 1] == 'C')) ||
                            (s[index] == 'C' && (s[index + 1] == 'D' || s[index + 1] == 'M')))
                        {
                            currentNumber += s[index + 1];
                            index++;
                        }
                    }
                    resultNumber += romanNumbers[currentNumber];
                    currentNumber = String.Empty;
                    index++;
                }
            }
            return resultNumber;
        }
    }
}
