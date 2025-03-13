using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task405
{
    /*
    405. Преобразуйте число в шестнадцатеричное
     Для 32-битного целого числа num верните строку, представляющую его шестнадцатеричное представление. Для отрицательных целых чисел используется метод дополнения до двух.
    Все буквы в строке ответа должны быть строчными, и в ответе не должно быть ведущих нулей, кроме самого нуля.
    Примечание: для непосредственного решения этой задачи нельзя использовать какой-либо встроенный библиотечный метод.
    Ограничения:
        -2^31 <= num <= 2^31 - 1
    https://leetcode.com/problems/convert-a-number-to-hexadecimal/description/
     */
    public class Task405 : InfoBasicTask
    {
        public Task405(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int num = -2147483648;
            Console.WriteLine($"Исходное число = {num}");
            Console.WriteLine($"Число {num} в 16-ричной системе = {toHex(num)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string toHex(int num)
        {
            Dictionary<int, char> dictTenSystemToHexadecimal = new Dictionary<int, char>()
            {
                {0,'0' },
                {1,'1' },
                {2,'2' },
                {3,'3' },
                {4,'4' },
                {5,'5' },
                {6,'6' },
                {7,'7' },
                {8,'8' },
                {9,'9' },
                {10,'a' },
                {11,'b' },
                {12,'c' },
                {13,'d' },
                {14,'e' },
                {15,'f' },
            };
            Dictionary<char, int> dictHexadecimalSystemToTen = new Dictionary<char, int>()
            {
                { '0',0 },
                {'1',1 },
                {'2',2 },
                {'3',3 },
                {'4',4 },
                {'5',5 },
                {'6',6 },
                {'7',7 },
                {'8',8 },
                {'9',9 },
                {'a',10 },
                {'b',11 },
                {'c',12 },
                {'d',13 },
                {'e',14 },
                {'f',15 },
            };
            if (num == 0)
            {
                return "0";
            }
            if (num == Int32.MinValue)
            {
                return "80000000";
            }
            bool isNegative = num < 0;
            StringBuilder stringBuilder = new StringBuilder();
            if (isNegative)
            {
                num *= -1;
            }
            while (num != 0)
            {
                stringBuilder.Append(dictTenSystemToHexadecimal[num % 16]);
                num /= 16;
            }
            char[] chars = stringBuilder.ToString().ToCharArray();
            stringBuilder.Clear();
            int left = 0;
            int right = chars.Length - 1;
            while (left < right)
            {
                (chars[left], chars[right]) = (chars[right], chars[left]);
                left++;
                right--;
            }
            bool isFindFirstNotZeroValue = false;
            foreach (char c in chars)
            {
                if (c != '0')
                {
                    isFindFirstNotZeroValue = true;
                    stringBuilder.Append(c);
                }
                else if (isFindFirstNotZeroValue)
                {
                    stringBuilder.Append(c);
                }
            }
            string hexPositive = stringBuilder.ToString();
            stringBuilder.Clear();
            if (!isNegative)
            {
                return hexPositive;
            }
            else
            {
                int countDigits = 8;
                foreach (char s in hexPositive)
                {
                    int val = 15 - dictHexadecimalSystemToTen[s];
                    char hexVal = dictTenSystemToHexadecimal[val];
                    stringBuilder.Append(hexVal);
                }
                while (stringBuilder.Length != countDigits)
                {
                    stringBuilder.Insert(0, "f");
                }
                char[] charsArr = stringBuilder.ToString().ToCharArray();
                for (int i = charsArr.Length - 1; i >= 0; i--)
                {
                    int val = dictHexadecimalSystemToTen[charsArr[i]] + 1;
                    if (val == 16)
                    {
                        charsArr[i] = '0';
                    }
                    else
                    {
                        charsArr[i] = dictTenSystemToHexadecimal[val];
                        break;
                    }
                }
                return new string(charsArr);
            }
        }
    }
}
