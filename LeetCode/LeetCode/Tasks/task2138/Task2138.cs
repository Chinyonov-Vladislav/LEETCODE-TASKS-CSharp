using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2138
{
    /*
     2138. Разделите строку на группы по k символов
    Строку s можно разделить на группы размером k с помощью следующей процедуры:
        Первая группа состоит из первых k символов строки, вторая группа состоит из следующих k символов строки и так далее. Каждый символ может входить только в одну группу.
        Для последней группы, если в строке не осталось k символов, для завершения группы используется символ fill.
    Обратите внимание, что разбиение выполняется таким образом, чтобы после удаления символа fill из последней группы (если он есть) и объединения всех групп по порядку результирующая строка была равна s.
    Учитывая строку s, размер каждой группы k и символ fill, верните массив строк, обозначающийсостав каждой группы, на которую sбыла разделена строка с помощью описанной выше процедуры.
     */
    public class Task2138 : InfoBasicTask
    {
        public Task2138(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string str = "abcdefghij";
            int k = 3;
            char fill = 'x';
            Console.WriteLine($"Исходная строка: \"{str}\"");
            Console.WriteLine($"Размер группы = {k}");
            Console.WriteLine($"Символ для дополнения группы: \'{fill}\'");
            string[] result = divideString(str, k, fill);
            printArray(result, "Результирующий массив: ");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private string[] divideString(string s, int k, char fill)
        {
            int size = 0;
            if (s.Length % k == 0)
            {
                size = s.Length / k;
            }
            else
            {
                size = s.Length / k + 1;
            }
            string[] result = new string[size];
            int index = 0;
            for (int i = 0; i < s.Length; i += k)
            {
                string part = String.Empty;
                if (i + k < s.Length)
                {
                    part = s.Substring(i, k);
                }
                else
                {
                    part = s.Substring(i);
                }
                if (part.Length != k)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(part);
                    stringBuilder.Append(fill, k - part.Length);
                    part = stringBuilder.ToString();
                    
                }
                result[index] = part;
                index++;
            }
            return result;
        }
    }
}
