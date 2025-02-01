using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task160
{
    public class Task160 : InfoBasicTask
    {
        /*
         160. Пересечение двух связанных списков
        Учитывая заголовки двух односвязных списков headA и headB, верните узел, в котором пересекаются два списка. Если два связанных списка вообще не пересекаются, верните null.
        https://leetcode.com/problems/intersection-of-two-linked-lists/description/
         */
        public Task160(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode intersect = new ListNode(8, new ListNode(4, new ListNode(5)));
            ListNode head1 = new ListNode(4, new ListNode(1, intersect));
            Console.WriteLine("Первый связанный список");
            printValuesFromListNode(head1, 0);
            ListNode head2 = new ListNode(5, new ListNode(6, new ListNode(1, intersect)));
            Console.WriteLine("Второй связанный список");
            printValuesFromListNode(head2, 0);
            ListNode resultListNode = getIntersectionNode(head1, head2);
            Console.WriteLine(resultListNode == null ? "Связанные списки head1 и head2 не имеют пересечения" : $"Связанные списки head1 и head2 пересекаются в узле со значением = {resultListNode.val}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode getIntersectionNode(ListNode headA, ListNode headB)
        {
            Stack<ListNode> firstList = new Stack<ListNode>();
            Stack<ListNode> secondList = new Stack<ListNode>();
            ListNode returnedNode = null;
            while (true)
            {
                if (headA != null)
                {
                    firstList.Push(headA);
                    headA = headA.next;
                }
                if (headB != null)
                {
                    secondList.Push(headB);
                    headB = headB.next;
                }
                if (headA == null && headB == null)
                {
                    break;
                }
            }
            while (secondList.Count > 0 && firstList.Count > 0)
            {
                ListNode popedNodeFromB = secondList.Pop();
                ListNode popedNodeFromA = firstList.Pop();
                if (popedNodeFromB == popedNodeFromA)
                {
                    returnedNode = popedNodeFromA;
                }
            }
            return returnedNode;
        }
    }
}
