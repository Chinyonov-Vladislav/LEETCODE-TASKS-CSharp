using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task2011
{
    /*
     2011. Конечное значение переменной после выполнения операций
    Существует язык программирования, в котором есть только четыре операции и одна переменная X:
        ++X и X++ увеличивает значение переменной X на 1.
        --X и X-- уменьшает значение переменной X на 1.
    Изначально значение X равно 0.
    Учитывая массив строк, operations содержащий список операций, верните окончательное значение X после выполнения всех операций.
    https://leetcode.com/problems/final-value-of-variable-after-performing-operations/description/
     */
    public class Task2011 : InfoBasicTask
    {
        public Task2011(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            string[] operations = new string[] { "++X", "++X", "X++" };
            printArray(operations, "Массив операций: ");
            int value = finalValueAfterOperations(operations);
            Console.WriteLine($"Финальное значение после выполнения операций = {value}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int finalValueAfterOperations(string[] operations)
        {
            int x = 0;
            foreach (string operation in operations) {
                if (operation == "X++")
                {
                    x++;
                }
                else if (operation == "++X")
                {
                    ++x;
                }
                else if (operation == "--X")
                {
                    --x;
                }
                else
                {
                    x--;
                }
            }
            return x;
        }
    }
}
