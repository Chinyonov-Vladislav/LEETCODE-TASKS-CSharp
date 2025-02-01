using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task21
{
    public class Task21 : InfoBasicTask
    {
        public Task21(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {


        }

        public override void execute()
        {
            ListNode firstRootListNode = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode secondRootListNode = new ListNode(1, new ListNode(3, new ListNode(4)));
            ListNode result = mergeTwoLists(firstRootListNode, secondRootListNode);
            printValuesFromListNode(result, 0);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode mergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }
            ListNode resultListNode = new ListNode();
            merge(resultListNode, list1, list2);
            return resultListNode;
        }
        private void merge(ListNode resultListNode, ListNode list1, ListNode list2)
        {
            bool firstNodeValueSeted = false;
            bool secondNodeValueSeted = false;
            if (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    resultListNode.val = list1.val;
                    firstNodeValueSeted = true;
                }
                else
                {
                    resultListNode.val = list2.val;
                    secondNodeValueSeted = true;
                }
            }
            else if (list1 == null && list2 != null)
            {
                resultListNode.val = list2.val;
                secondNodeValueSeted = true;
            }
            else if (list2 == null && list1 != null)
            {
                resultListNode.val = list1.val;
                firstNodeValueSeted = true;
            }
            if (!((list1 == null && list2 != null && list2.next == null) || (list2 == null && list1 != null && list1.next == null)))
            {
                resultListNode.next = new ListNode();
                if (firstNodeValueSeted)
                {
                    merge(resultListNode.next, list1 == null ? null : list1.next, list2);
                }
                if (secondNodeValueSeted)
                {
                    merge(resultListNode.next, list1, list2 == null ? null : list2.next);
                }
            }
        }

        
    }
}
