using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task423
{
    /*
     423. Восстановите исходные цифры с английского
    Учитывая строку s , содержащую неправильное английское представление цифр 0-9, верните цифры в порядке возрастания.
    Ограничения:
        1 <= s.length <= 10^5
        s[i] является одним из персонажей ["e","g","f","i","h","o","n","s","r","u","t","w","v","x","z"].
        s является гарантированно действительным.
    https://leetcode.com/problems/reconstruct-original-digits-from-english/description/
     */
    public class Task423 : InfoBasicTask
    {
        public Task423(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "owoztneoerevsennesev";
            Console.WriteLine($"Строка, содержащая неправильное английское представление цифр 0-9: \"{str}\"");
            if (isValid(str))
            {
                string res = originalDigits(str);
                Console.WriteLine($"Цифры в порядке возрастания из оригинальной строки: {res}");
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
            int lowLimit = 1;
            int highLimit = (int)Math.Pow(10, 5);
            if (s.Length < lowLimit || s.Length > highLimit)
            {
                return false;
            }
            List<char> acceptedChars = new List<char>() { 'e', 'g', 'f', 'i', 'h', 'o', 'n', 's', 'r', 'u', 't', 'w', 'v', 'x', 'z' };
            foreach (char c in s)
            {
                if (!acceptedChars.Contains(c))
                {
                    return false;
                }
            }
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }
            Dictionary<char, int> dict = new Dictionary<char, int>()
            {
                { 'z', 0 },
                { 'w', 2 },
                { 'u', 4 },
                { 'x', 6 },
                { 'g', 8 },
                { 'o', 1 },
                { 't', 3 },
                { 'f', 5 },
                { 's', 7 },
                 { 'i', 9 }
            };
            foreach (var pair in dict)
            {
                string str = String.Empty;
                switch (pair.Key)
                {
                    case 'z':
                        str = "zero";
                        break;
                    case 'w':
                        str = "two";
                        break;
                    case 'u':
                        str = "four";
                        break;
                    case 'x':
                        str = "six";
                        break;
                    case 'g':
                        str = "eight";
                        break;
                    case 'o':
                        str = "one";
                        break;
                    case 't':
                        str = "three";
                        break;
                    case 'f':
                        str = "five";
                        break;
                    case 's':
                        str = "seven";
                        break;
                    case 'i':
                        str = "nine";
                        break;
                }
                int count = freq[pair.Key - 'a'];
                foreach (char c in str)
                {
                    freq[c - 'a'] -= count;
                }
            }
            foreach (int val in freq)
            {
                if (val != 0)
                {
                    return false;
                }
            }
            return true;
        }
        private string originalDigits(string s)
        {
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }
            int[] freqValue = new int[10];
            Dictionary<char, int> dict = new Dictionary<char, int>()
            {
                { 'z', 0 },
                { 'w', 2 },
                { 'u', 4 },
                { 'x', 6 },
                { 'g', 8 },
                { 'o', 1 },
                { 't', 3 },
                { 'f', 5 },
                { 's', 7 },
                { 'i', 9 }
            };
            foreach (var pair in dict)
            {
                string str = String.Empty;
                switch (pair.Key)
                {
                    case 'z':
                        str = "zero";
                        break;
                    case 'w':
                        str = "two";
                        break;
                    case 'u':
                        str = "four";
                        break;
                    case 'x':
                        str = "six";
                        break;
                    case 'g':
                        str = "eight";
                        break;
                    case 'o':
                        str = "one";
                        break;
                    case 't':
                        str = "three";
                        break;
                    case 'f':
                        str = "five";
                        break;
                    case 's':
                        str = "seven";
                        break;
                    case 'i':
                        str = "nine";
                        break;
                }
                int count = freq[pair.Key - 'a'];
                freqValue[pair.Value] = count;
                foreach (char c in str)
                {
                    freq[c - 'a'] -= count;
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < freqValue.Length; i++)
            {
                sb.Append((char)(i + 48), freqValue[i]);
            }
            return sb.ToString();
        }
    }
}
