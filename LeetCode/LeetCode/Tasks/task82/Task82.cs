using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task82
{
    /*
     82. Удалите дубликаты из отсортированного списка II
    Учитывая head отсортированного связанного списка, удалите все узлы с повторяющимися номерами, оставив только уникальные номера из исходного списка. 
    Верните связанный список,также отсортированный
    Ограничения:
        Количество узлов в списке находится в диапазоне [0, 300].
        -100 <= Node.val <= 100
        Список гарантированно будет отсортирован в порядке возрастания.
    https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/description/
     */
    public class Task82 : InfoBasicTask
    {
        public Task82(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode listNode = new ListNode(1, new ListNode(1,new ListNode(1, new ListNode(2, new ListNode(3)))));
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(listNode);
            if (isValid(listNode))
            {
                ListNode res = deleteDuplicates(listNode);
                Console.WriteLine("Связанный список с удалёнными повторяющимися элементам");
                printValuesFromListNode(res);
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
            List<int> valuesFromNodes = new List<int>();
            int countNodes = 0;
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = 300;
            int lowLimitValueNode = -100;
            int highLimitValueNode = 100;
            while (head != null)
            {
                valuesFromNodes.Add(head.val);
                countNodes++;
                if (head.val < lowLimitValueNode || head.val > highLimitValueNode)
                {
                    return false;
                }
                head = head.next;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            for (int i = 1; i < valuesFromNodes.Count; i++)
            {
                if (valuesFromNodes[i] < valuesFromNodes[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        private ListNode deleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            Dictionary<int, int> dict = new Dictionary<int, int>();
            ListNode newListNode = null;
            ListNode newHead = null;
            while (head != null)
            {
                if (dict.ContainsKey(head.val))
                {
                    dict[head.val]++;
                }
                else
                {
                    dict.Add(head.val, 1);
                }
                head = head.next;
            }
            List<int> uniqueValues = dict.Where(item => item.Value == 1).OrderBy(item => item.Value).ToDictionary(item => item.Key, item => item.Value).Keys.ToList();
            for (int i = 0; i < uniqueValues.Count; i++)
            {
                if (i == 0)
                {
                    newListNode = new ListNode(uniqueValues[i]);
                    newHead = newListNode;
                }
                else
                {
                    newListNode.next = new ListNode(uniqueValues[i]);
                    newListNode = newListNode.next;
                }
            }
            return newHead;
        }
        // скопировано с leetcode
        private ListNode bestSolution(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode dummy = new ListNode(0, head);
            ListNode prev = dummy;
            while (head != null)
            {
                if (head.next != null && head.val == head.next.val)
                {
                    while (head.next != null && head.val == head.next.val)
                    {
                        head = head.next;
                    }
                    prev.next = head.next;
                }
                else
                {
                    prev = prev.next;
                }
                head = head.next;
            }
            return dummy.next;
        }
    }
}
