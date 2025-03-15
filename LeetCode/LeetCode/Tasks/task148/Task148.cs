using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task148
{
    /*
     148. Сортировка списка
    Учитывая head связанного списка, верните список после его сортировки в порядке возрастания.
    Ограничения:
        Количество узлов в списке находится в диапазоне [0, 5 * 10^4].
        -10^5 <= Node.val <= 10^5
    https://leetcode.com/problems/sort-list/description/
     */
    public class Task148 : InfoBasicTask
    {
        public Task148(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode node = new ListNode(-1, new ListNode(5, new ListNode(3, new ListNode(4, new ListNode(0)))));
            printValuesFromListNode(node);
            if (isValid(node))
            {
                ListNode sortedNode = sortList(node);
                printValuesFromListNode(sortedNode);
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
            int lowLimit = -1*(int)Math.Pow(10, 5);
            int highLimit = (int)Math.Pow(10, 5);
            int countNodes = 0;
            while (head != null)
            {
                Console.WriteLine(head.val);
                if (!(head.val>=lowLimit && head.val<=highLimit))
                {
                    return false;
                }
                countNodes++;
                head = head.next;
            }
            lowLimit = 0;
            highLimit = 5* (int)Math.Pow(10, 4);
            if (countNodes < lowLimit || countNodes > highLimit)
            {
                return false;
            }
            return true;
        }
        private ListNode sortList(ListNode head)
        {
            List<int> values = new List<int>();
            ListNode headDummy = head;
            ListNode returnedHeadPointer = head;
            while (head != null)
            {
                values.Add(head.val);
                head = head.next;
            }
            values.Sort();
            int index = 0;
            while (headDummy != null)
            {
                headDummy.val = values[index];
                headDummy = headDummy.next;
                index++;
            }
            return returnedHeadPointer;
        }
    }
}
