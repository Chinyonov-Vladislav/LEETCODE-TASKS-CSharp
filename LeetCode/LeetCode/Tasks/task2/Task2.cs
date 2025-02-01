using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task2
{
    public class Task2 : InfoBasicTask
    {
        private ListNode l1;
        private ListNode l2;
        public Task2(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))));
            l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
        }

        public override void execute()
        {
            ListNode resultListNode = addTwoNumbers(l1,l2);
            printListNode(resultListNode, 0);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode addTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode resultListNode = new ListNode();
            recursiveAdding(resultListNode, l1, l2, false);
            return resultListNode;
        }
        private void recursiveAdding(ListNode currentNode, ListNode l1, ListNode l2, bool hasOverflow)
        {
            int newNumber = 0;
            if (l1 != null && l2 != null)
            {
                newNumber = l1.val + l2.val;
            }
            else if (l1 == null && l2 != null)
            {
                newNumber = l2.val;
            }
            else if (l2 == null && l1 != null)
            {
                newNumber = l1.val;
            }
            if (hasOverflow)
            {
                newNumber += 1;
                hasOverflow = false;
            }
            if (newNumber >= 10)
            {
                newNumber -= 10;
                hasOverflow = true;
            }
            currentNode.val = newNumber;
            if ((l1 != null && l1.next != null) || (l2 != null && l2.next != null) || hasOverflow)
            {
                currentNode.next = new ListNode();
                recursiveAdding(currentNode.next, l1 == null ? null : l1.next, l2 == null ? null : l2.next, hasOverflow);
            }
        }
        private void printListNode(ListNode listNode, int number)
        {
            if (listNode != null)
            {
                Console.WriteLine($"Номер узла = {number}, Значение = {listNode.val}");
                number += 1;
                printListNode(listNode.next, number);
            }
        }

    }
}
