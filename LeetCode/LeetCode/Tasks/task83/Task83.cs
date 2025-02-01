using System;
using LeetCode.Basic;
namespace LeetCode.Tasks.task83
{
    public class Task83 : InfoBasicTask
    {
        public Task83(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode listNodeWithDuplicates = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3)))));
            ListNode resultListNode = deleteDuplicates(listNodeWithDuplicates);
            printValuesFromListNode(resultListNode, 0);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode deleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode resultListNode = new ListNode();
            travelListNode(resultListNode, head, head.val);
            return resultListNode;
        }
        private void travelListNode(ListNode resultListNode, ListNode listNodeWithDuplicates, int currentValue)
        {
            if (listNodeWithDuplicates.val != currentValue)
            {
                resultListNode.val = currentValue;
                currentValue = listNodeWithDuplicates.val;
                if (listNodeWithDuplicates.next != null)
                {
                    resultListNode.next = new ListNode();
                    travelListNode(resultListNode.next, listNodeWithDuplicates.next, currentValue);
                }
                else
                {
                    resultListNode.next = new ListNode(currentValue);
                }
            }
            else
            {
                if (listNodeWithDuplicates.next != null)
                {
                    travelListNode(resultListNode, listNodeWithDuplicates.next, currentValue);
                }
                else
                {
                    resultListNode.val = currentValue;
                }
            }
        }
    }
}
