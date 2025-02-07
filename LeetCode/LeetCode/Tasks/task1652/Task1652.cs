using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1652
{
    /*
     1652. Обезвредить бомбу
    Вам нужно обезвредить бомбу, и время на исходе! Ваш информатор предоставит вам круговой массив code длиной n и ключ k.
    Чтобы расшифровать код, вы должны заменить каждое число. Все числа заменяются одновременно.
        Если k > 0, замените число ith суммой следующих k чисел.
        Если k < 0, замените число ith суммой предыдущих k чисел.
        Если k == 0, замените i th номер на 0.
    Поскольку code является циклом, следующим элементом code[n-1] является code[0], а предыдущим элементом code[0] является code[n-1].
    Учитывая круговой массив code и целочисленный ключ k, верните расшифрованный код для обезвреживания бомбы!
    https://leetcode.com/problems/defuse-the-bomb/description/
     */
    public class Task1652 : InfoBasicTask
    {
        public Task1652(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            int[] code = new int[] { 2,4,9,3 };
            printArray(code, "Закодированный код: ");
            int k = -2;
            Console.WriteLine($"Ключ = {k}");
            int[] result = decrypt(code, k);
            printArray(result, "Декодированный код: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        public int[] decrypt(int[] code, int k)
        {
            int[] result = new int[code.Length];
            if (k == 0)
            {
                return result;
            }
            for (int i = 0; i < code.Length; i++)
            {
                int sum = 0;
                int countShift = 0;
                int index = i;
                while (countShift != k)
                {
                    if (k > 0)
                    {
                        index++;
                        if (index >= code.Length)
                        {
                            index = 0;
                        }
                        countShift++;
                    }
                    else
                    {
                        index--;
                        if (index < 0)
                        {
                            index = code.Length - 1;
                        }
                        countShift--;
                    }
                    sum += code[index];
                }
                result[i] = sum;
            }
            return result;
        }
    }
}
