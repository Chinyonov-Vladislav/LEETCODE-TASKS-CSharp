using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task1290
{
    /*
     1290. Преобразуйте двоичное число в связанном списке в целое число
    Дано head — ссылочный узел односвязного списка. Значение каждого узла в связанном списке равно 0 или 1. Связанный список содержит двоичное представление числа. 
    Возвращает десятичное значение числа в связанном списке.
    Самый значимый бит находится в начале связанного списка.
    https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/description/
     */
    public class Task1290 : InfoBasicTask
    {
        public Task1290(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode listNode = new ListNode(1, new ListNode(0, new ListNode(1, new ListNode(1))));
            printValuesFromListNode(listNode);
            int value = getDecimalValue(listNode);
            Console.WriteLine($"Число в десятичном представлении = {value}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int getDecimalValue(ListNode head)
        {
            List<int> bits = new List<int>();
            while (head != null)
            {
                bits.Add(head.val);
                head = head.next;
            }
            int result = 0;
            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i] == 1)
                {
                    result += (int)Math.Pow(2, bits.Count - i - 1);
                }
            }
            return result;
        }
        // скопировано с leetcode
        private int bestSolution(ListNode head)
        {
            int ans = 0;
            while (head != null)
            {
                if (head.val == 0)
                {
                    ans = ans * 2;
                }
                else
                {
                    ans = ans * 2 + 1;
                }
                head = head.next;
            }
            return ans;
        }
    }
}
