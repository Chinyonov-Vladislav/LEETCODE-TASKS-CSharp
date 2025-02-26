using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2243
{
    /*
     2243. Вычислить сумму цифр строки
    Вам выдается строка, s состоящая из цифр и целого числа k.
    Раунд может быть завершён, если длина s не больше, чем k. В одном раунде выполните следующее:
        Разделите s на последовательные группы размером k так, чтобы первые k символов были в первой группе, следующие k символов — во второй группе и так далее. Обратите внимание, что размер последней группы может быть меньше k.
        Замените каждую группу s на строку, представляющую сумму всех её цифр. Например, "346" заменяется на "13" потому что 3 + 4 + 6 = 13.
        Объедините последовательные группы в новую строку. Если длина строки больше k, повторите с шага 1.
    Вернитесь s после завершения всех раундов.
    https://leetcode.com/problems/calculate-digit-sum-of-a-string/description/
     */
    public class Task2243 : InfoBasicTask
    {
        public Task2243(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string s = "11111222223";
            Console.WriteLine($"Исходная строка: \"{s}\"");
            int size = 3;
            Console.WriteLine($"Размер группы = {size}");
            string result = digitSum(s, size);
            Console.WriteLine($"Финальное число = {result}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string digitSum(string s, int k)
        {
            StringBuilder sb = new StringBuilder(s);
            while (sb.Length > k)
            {
                s = sb.ToString();
                sb.Clear();
                for (int i = 0; i < s.Length; i += k)
                {
                    string currentGroup = String.Empty;
                    if (s.Length - i < k)
                    {
                        currentGroup = s.Substring(i);
                    }
                    else
                    {
                        currentGroup = s.Substring(i, k);
                    }
                    int newNumber = 0;
                    for (int index = 0; index < currentGroup.Length; index++)
                    {
                        newNumber += currentGroup[index] - '0';
                    }
                    sb.Append(newNumber);
                }
            }
            return sb.ToString();
        }
    }
}
