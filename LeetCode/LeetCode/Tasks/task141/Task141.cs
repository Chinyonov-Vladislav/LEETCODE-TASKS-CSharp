using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task141
{
    /*
     141. Цикл связанных списков

    Учитывая, что head, начало связанного списка, определите, есть ли в связанном списке цикл.

    В связанном списке есть цикл, если в списке есть узел, до которого можно снова добраться, непрерывно следуя за next указателем. Внутри программы pos используется для обозначения индекса узла, к которому привязан next указатель хвоста. Обратите внимание, что pos не передаётся в качестве параметра.

    Верните true значение, если в связанном списке есть цикл. В противном случае верните false.

     */
    public class Task141 : InfoBasicTask
    {
        public Task141(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {

            ListNode headNode = new ListNode(3);
            ListNode node1 = new ListNode(2);
            ListNode node2 = new ListNode(0);
            ListNode node3 = new ListNode(-4);
            headNode.next = node1;
            node1.next = node2;
            node2.next = node3;
            node3.next = node1;
            Console.WriteLine(hasCycle(headNode) ? "Связанный список имеет цикличность" : "Связанный список не имеет цикличность");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool hasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            List<ListNode> visitedListNode = new List<ListNode>();
            return travel(head, visitedListNode);
        }
        private bool travel(ListNode listNode, List<ListNode> visitedListNode)
        {
            if (!visitedListNode.Contains(listNode))
            {
                visitedListNode.Add(listNode);
                if (listNode.next != null)
                {
                    return travel(listNode.next, visitedListNode);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
