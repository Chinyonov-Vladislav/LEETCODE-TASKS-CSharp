using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task3304
{
    /*
     3304. Найдите K-й символ в игре «Строка» I
    Алиса и Боб играют в игру. Изначально у Алисы есть строка word = "a".
    Вам дается положительное целое число k.
    Теперь Боб попросит Алису выполнить следующую операцию навсегда:
        Сгенерируйте новую строку, заменив каждый символ в word на следующий символ английского алфавита, и добавьте его к исходной word строке.
    Например, выполнение операции над "c" генерирует "cd", а выполнение операции над "zb" генерирует "zbac".
    Верните значение символа kth в word после выполнения достаточного количества операций, чтобы word содержал не менее k символов.
    Обратите внимание, что символ 'z' можно заменить на 'a' в процессе выполнения операции.
    Ограничения:
        1 <= k <= 500
    https://leetcode.com/problems/find-the-k-th-character-in-string-game-i/description/
     */
    public class Task3304 : InfoBasicTask
    {
        public Task3304(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int k = 5;
            Console.WriteLine($"Значение переменной k = {k}");
            if (isValid(k))
            {
                char c = KthCharacter(k);
                Console.WriteLine($"Результат = {c}");
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
        private bool isValid(int k)
        {
            if (k < 1 || k > 500)
            {
                return false;
            }
            return true;
        }
        private char KthCharacter(int k)
        {
            string initialString = "a";
            while (k >= initialString.Length)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < initialString.Length; i++)
                {
                    if (initialString[i] == 'z')
                    {
                        sb.Append('a');
                    }
                    else
                    {
                        sb.Append((char)(initialString[i] + 1));
                    }
                }
                initialString = initialString + sb.ToString();
            }
            return initialString[k];
        }
    }
}
