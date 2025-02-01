using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task8
{
    public class Task8 : InfoBasicTask
    {
        public Task8(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "-2147483647";
            int number = myAtoi(str);
            Console.WriteLine($"Cтрока: \"{str}\". Число из строки: {number}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int myAtoi(string s)
        {
            s = s.Trim();
            if (s.Length == 0)
            {
                return 0;
            }
            bool isNegative = s[0] == '-';
            string resultNumberStr = "";
            for (int i = 0; i < s.Length; i++)
            {
                if ((i == 0 && s[i] == '-') || (resultNumberStr.Length == 0 && s[i] == '0') || (i==0 && s[i]=='+'))
                {
                    continue;
                }
                if (!char.IsDigit(s[i]))
                {
                    break;
                }
                resultNumberStr += s[i];
            }
            int resultNumber = 0;
            for (int i = 0; i < resultNumberStr.Length; i++)
            {
                char currentDigit = resultNumberStr[i];
                if (!isNegative && ( resultNumber > int.MaxValue / 10 || (resultNumber == int.MaxValue / 10 && Int32.Parse(currentDigit.ToString()) > 7)))
                {
                    return int.MaxValue;
                }
                if (isNegative)
                {
                    int copyNegativeNumber = resultNumber * -1;
                    if (copyNegativeNumber < int.MinValue / 10 || (copyNegativeNumber == int.MinValue / 10 && Int32.Parse(currentDigit.ToString()) > 8))
                    {
                        return int.MinValue;
                    }
                }
                resultNumber = resultNumber*10+Int32.Parse(resultNumberStr[i].ToString());
            }
            return isNegative ? resultNumber * (-1) : resultNumber;
        }
    }
}
