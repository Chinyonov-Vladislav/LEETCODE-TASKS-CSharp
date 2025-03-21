using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task328
{
    /*
     328. Нечетный четный связанный список
    Учитывая head односвязного списка, сгруппируйте все узлы с нечётными индексами вместе, а затем узлы с чётными индексами и верните переупорядоченный список.
    Первый узел считается нечётным, второй узел — чётным и так далее.
    Обратите внимание, что относительный порядок внутри чётных и нечётных групп должен оставаться таким же, как и во входных данных.
    Вы должны решить проблему с O(1) дополнительной пространственной сложностью и O(n) временной сложностью.
    Ограничения:
        Количество узлов в связанном списке находится в диапазоне [0, 10^4].
        -10^6 <= Node.val <= 10^6
    https://leetcode.com/problems/odd-even-linked-list/description/
     */
    public class Task328 : InfoBasicTask
    {
        public Task328(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode listNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(listNode);
            if (isValid(listNode))
            {
                ListNode res = oddEvenList(listNode);
                Console.WriteLine("Результирующий связанный список");
                printValuesFromListNode(res);
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
        private bool isValid(ListNode head)
        {
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = (int)Math.Pow(10,4);
            int lowLimitValueNodes = -1* (int)Math.Pow(10,6);
            int highLimitValueNodes = (int)Math.Pow(10, 6);
            int countNodes = 0;
            while (head != null)
            {
                if (head.val < lowLimitValueNodes || head.val > highLimitValueNodes)
                {
                    return false;
                }
                countNodes++;
                head = head.next;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private ListNode oddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode headEven = new ListNode(head.val);
            ListNode headOdd = new ListNode(head.next.val);
            ListNode dummyHeadEven = headEven;
            ListNode dummyHeadOdd = headOdd;
            int index = 0;
            while (head != null)
            {
                if (index >= 2)
                {
                    if (index % 2 == 0)
                    {
                        headEven.next = head;
                        headEven = headEven.next;
                    }
                    else
                    {
                        headOdd.next = head;
                        headOdd = headOdd.next;
                    }
                }
                head = head.next;
                index++;
            }
            headEven.next = dummyHeadOdd;
            headOdd.next = null;
            return dummyHeadEven;
        }
    }
}
