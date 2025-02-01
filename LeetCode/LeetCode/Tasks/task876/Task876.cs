using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task876
{
    /*
     876. Середина связанного списка
    Учитывая head односвязного списка, верните средний узел связного списка.
    Если есть два средних узла, верните второй средний узел.
    https://leetcode.com/problems/middle-of-the-linked-list/description/
     */
    public class Task876 : InfoBasicTask
    {
        public Task876(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode root = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            ListNode middle = middleNode(root);
            Console.WriteLine($"Значение узла посередине = {middle.val}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode middleNode(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            List<ListNode> listNodes = new List<ListNode>();
            while (head != null) {
                listNodes.Add(head);
                head = head.next;
            }
            return listNodes[listNodes.Count / 2];
        }
    }
}
