using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1945
{
    /*
     1945. Сумма цифр строки после преобразования
    Вам дана строка s, состоящая из строчных букв английского алфавита, и целое число k. Ваша задача — преобразовать строку в целое число с помощью специального процесса, а затем преобразовать его, многократно суммируя его цифры k раз. В частности, выполните следующие действия:
    Преобразуйте s в целое число, заменив каждую букву на её порядковый номер в алфавите (т. е. замените 'a' на 1, 'b' на 2, ..., 'z' на 26).
    Преобразуйте T целое число, заменив его суммой его цифр.
    Повторите операцию преобразования k несколько раз
        Например, если s = "zbax" и k = 2, то в результате следующих операций получится целое число 8:
        Преобразовать: "zbax" ➝ "(26)(2)(1)(24)" ➝ "262124" ➝ 262124
        Преобразование №1: 262124 ➝ 2 + 6 + 2 + 1 + 2 + 4 ➝ 17
        Преобразование №2: 17 ➝ 1 + 7 ➝ 8
    Верните результат в виде целого числа после выполнения операций, описанных выше.
    https://leetcode.com/problems/sum-of-digits-of-string-after-convert/description/
     */
    public class Task1945 : InfoBasicTask
    {
        public Task1945(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "zbax";
            Console.WriteLine($"Исходная строка: \"{str}\"");
            int k = 2;
            Console.WriteLine($"Количество трансформаций = {k}");
            int result = getLucky(str, k);
            Console.WriteLine($"Результат = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int getLucky(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                int currentNumber = s[i] - 'a' + 1;
                sb.Append(currentNumber);
            }
            for (int i = 0; i < k; i++)
            {
                int localNumber = 0;
                for (int j = 0; j < sb.Length; j++)
                {
                    localNumber += sb[j] - '0';
                }
                sb.Clear();
                sb.Append(localNumber);
            }
            return Convert.ToInt32(sb.ToString());

        }
    }
}
