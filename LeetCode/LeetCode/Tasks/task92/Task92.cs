using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task92
{
    /*
     92. Список с обратными ссылками II
    Учитывая head односвязного списка и два целых числа left и right где left <= right, переверните узлы списка с позиции left до позиции right и верните перевёрнутый список.
    Ограничения:
        Количество узлов в списке равно n.
        1 <= n <= 500
        -500 <= Node.val <= 500
        1 <= left <= right <= n
    https://leetcode.com/problems/reverse-linked-list-ii/description/
     */
    public class Task92 : InfoBasicTask
    {
        public Task92(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode head = new ListNode(3, new ListNode(5));
            printValuesFromListNode(head);
            int left = 1;
            int right = 2;
            Console.WriteLine($"Интервал переворота узлов (индексация с 1) = [{left},{right}]");
            if (isValid(head, left, right))
            {
                ListNode reversed = reverseBetween(head, left, right);
                printValuesFromListNode(reversed);
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
        private bool isValid(ListNode head, int left, int right)
        {
            int lowLimit = -500;
            int highLimit = 500;
            int countNodes = 0;
            while (head != null)
            {
                if (head.val < lowLimit || head.val > highLimit)
                {
                    return false;
                }
                countNodes++;
            }
            lowLimit = 1;
            if (countNodes < lowLimit || countNodes>highLimit)
            {
                return false;
            }
            if (!(lowLimit <= left && left <= right && right <= countNodes))
            {
                return false;
            }
            return true;
        }
        private ListNode reverseBetween(ListNode head, int left, int right)
        {
            left -= 1;
            right -= 1;
            if (left == right)
            {
                return head;
            }
            List<ListNode> nodes = new List<ListNode>();
            while (head != null)
            {
                nodes.Add(head);
                head = head.next;
            }
            nodes.Add(null);
            for (int i = right; i > left; i--)
            {
                nodes[i].next = nodes[i - 1];
            }
            if (left - 1 >= 0)
            {
                nodes[left - 1].next = nodes[right];
            }
            nodes[left].next = nodes[right + 1];
            if (left == 0)
            {
                return nodes[right];
            }
            return nodes[0];
        }
    }
}
