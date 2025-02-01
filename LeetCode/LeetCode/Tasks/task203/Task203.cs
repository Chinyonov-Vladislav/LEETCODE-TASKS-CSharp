using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task203
{
    /*
     203. Удаление связанных элементов списка
    Учитывая head связанного списка и целое число val, удалите все узлы связанного списка, в которых есть Node.val == val, и верните новый заголовок.
     */
    public class Task203 : InfoBasicTask
    {
        public Task203(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(6, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6)))))));
            int valRemove = 6;
            ListNode result = removeElements(head, valRemove);
            printValuesFromListNode(result, 0);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode removeElements(ListNode head, int val)
        {
            if (head == null || (head.next == null && head.val == val))
            {
                return null;
            }
            List<int> numbersFromListNode=new List<int>();
            Stack<ListNode> stack = new Stack<ListNode>();
            stack.Push(head);
            while (stack.Count > 0) { 
                ListNode node = stack.Pop();
                if (node.val != val)
                {
                    numbersFromListNode.Add(node.val);
                }
                if (node.next != null)
                {
                    stack.Push(node.next);
                }
            }
            if (numbersFromListNode.Count > 0)
            {
                ListNode result = new ListNode();
                setResult(result, numbersFromListNode, 0);
                return result;
            }
            else
            {
                return null;
            }
        }
        private void setResult(ListNode result, List<int> numbers, int index)
        {
            if (index >=0 && index < numbers.Count)
            {
                result.val = numbers[index];
                index++;
                if (index <= numbers.Count - 1)
                {
                    result.next = new ListNode();
                    setResult(result.next, numbers, index);
                }
            }
        }
        private ListNode bestSolution(ListNode head, int val)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode current = dummy;
            while (current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return dummy.next;
        }
    }
}
