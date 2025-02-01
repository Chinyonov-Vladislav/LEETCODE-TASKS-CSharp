using LeetCode.Basic;
using System;
using System.Text;

namespace LeetCode.Tasks.task541
{
    /*
     541. Инвертировать строку II
    Даны строка s и целое число k. Обработайте первые k символов для каждых 2k символов, начиная с начала строки.
    Если осталось меньше k символов, переверните их все. Если осталось меньше 2k символов, но больше или равно k символов, переверните первые k символов, а остальные оставьте как есть.
     */
    public class Task541 : InfoBasicTask
    {
        public Task541(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "abcdefg";
            int k = 2;
            Console.WriteLine($"Оригинальная строка = \"{str}\"\nСтрока с перевернутыми перевернутыми каждыми {k} символами через {k} символов ={reverseStr(str, k)}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string reverseStr(string s, int k)
        {
            StringBuilder sb = new StringBuilder(s);
            for (int i = 0; i < sb.Length; i += k * 2)
            {
                int remainSymbols = sb.Length - 1 - i;
                int left = i;
                int right = remainSymbols < k ? sb.Length - 1 : i + k - 1;
                while (left < right)
                {
                    char temp = s[left];
                    sb.Replace(s[left], s[right], left, 1);
                    sb.Replace(s[right], temp, right, 1);
                    left++;
                    right--;
                }
            }
            return sb.ToString();
        }
    }
}
