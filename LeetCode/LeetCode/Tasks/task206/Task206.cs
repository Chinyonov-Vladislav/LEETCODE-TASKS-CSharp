using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task206
{
    /*
     206. Список с обратными ссылками
    Учитывая head односвязного списка, переверните его и верните перевёрнутый список.
     */
    public class Task206 : InfoBasicTask
    {
        public Task206(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode root = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            Console.WriteLine("Исходный односвязный список");
            printValuesFromListNode(root);
            ListNode result = reverseList(root);
            Console.WriteLine("Перевернутый односвязный список");
            printValuesFromListNode(result);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private ListNode reverseList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            List<int> listNodesValues = new List<int>();
            while (head != null) {
                listNodesValues.Add(head.val);
                head = head.next;
            }
            return getInvertedListNode(listNodesValues, listNodesValues.Count - 1);
        }
        private ListNode getInvertedListNode(List<int> nums, int currentIndex)
        {
            if (currentIndex == -1)
            {
                return null;
            }
            ListNode result = new ListNode();
            result.val = nums[currentIndex];
            result.next = getInvertedListNode(nums, --currentIndex);
            return result;
        }
    }
}
