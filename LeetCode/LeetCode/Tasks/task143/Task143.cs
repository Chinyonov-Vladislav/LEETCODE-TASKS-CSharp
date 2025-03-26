using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task143
{
    /*
     143. Изменить порядок следования списка
    Вам дана голова односвязного списка. Список можно представить в виде:
    L0 → L1 → … → Ln - 1 → Ln
    Измените порядок отображения списка в следующей форме:
    L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
    Вы не можете изменять значения в узлах списка. Можно изменять только сами узлы.
    Ограничения:
        Количество узлов в списке находится в диапазоне [1, 5 * 10^4].
        1 <= Node.val <= 1000
    https://leetcode.com/problems/reorder-list/description/
     */
    public class Task143 : InfoBasicTask
    {
        public Task143(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(head);
            if (isValid(head))
            {
                reorderList(head);
                Console.WriteLine("Связанный список после изменения порядка следования");
                printValuesFromListNode(head);
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
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = 5* (int)Math.Pow(10,4);
            int lowLimitValueNode = 1;
            int highLimitValueNode = 1000;
            int countNodes = 0;
            while (head != null)
            {
                if (head.val < lowLimitValueNode || head.val > highLimitValueNode)
                {
                    return false;
                }
                countNodes++;
                head = head.next;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private void reorderList(ListNode head)
        {
            List<ListNode> listNodes = new List<ListNode>();
            while (head != null)
            {
                listNodes.Add(head);
                head = head.next;
            }
            List<ListNode> orderedListNodes = new List<ListNode>();
            int left = 0;
            int right = listNodes.Count - 1;
            while (left <= right)
            {
                orderedListNodes.Add(listNodes[left]);
                if (left != right)
                {
                    orderedListNodes.Add(listNodes[right]);
                }
                left++;
                right--;
            }
            for (int i = 0; i < orderedListNodes.Count; i++)
            {
                orderedListNodes[i].next = i != orderedListNodes.Count - 1 ? orderedListNodes[i + 1] : null;
            }
        }
    }
}
