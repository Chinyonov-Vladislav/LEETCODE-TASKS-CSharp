using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task147
{
    /*
    147. Сортировка связанного списка алгоритмом сортировки вставками
     Учитывая head односвязного списка, отсортируйте его с помощью сортировки вставками и верните начало отсортированного списка.
    Этапы алгоритма сортировки по вставке:
        При сортировке вставками каждый раз используется один элемент из входного списка и формируется отсортированный выходной список.
        На каждой итерации сортировка вставками удаляет один элемент из входных данных, находит его место в отсортированном списке и вставляет его туда.
        Это повторяется до тех пор, пока не останется ни одного элемента ввода.
    Ниже приведён графический пример алгоритма сортировки вставками. Частично отсортированный список (чёрный) изначально содержит только первый элемент списка. С каждой итерацией из входных данных удаляется один элемент (красный) и вставляется в отсортированный список на место.
    Ограничения:
        Количество узлов в списке находится в диапазоне [1, 5000].
        -5000 <= Node.val <= 5000
     https://leetcode.com/problems/insertion-sort-list/description/
     */
    public class Task147 : InfoBasicTask
    {
        public Task147(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode listNode = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(listNode);
            if (isValid(listNode))
            {
                ListNode res = insertionSortList(listNode);
                Console.WriteLine("Отсортированный связанный список с помощью алгоритма сортировки вставками");
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
        private bool isValid(ListNode listNode)
        {
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = 5000;
            int lowLimitValueNode = -5000;
            int highLimitValueNode =5000;
            int countNodes = 0;
            while (listNode != null)
            {
                if (listNode.val < lowLimitValueNode || listNode.val > highLimitValueNode)
                {
                    return false;
                }
                countNodes++;
                listNode = listNode.next;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private ListNode insertionSortList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            List<ListNode> listNodes = new List<ListNode>();
            while (head != null)
            {
                listNodes.Add(head);
                head = head.next;
            }
            for (int i = 1; i < listNodes.Count; ++i)
            {
                ListNode key = listNodes[i];
                int j = i - 1;
                while (j >= 0 && listNodes[j].val > key.val)
                {
                    listNodes[j + 1] = listNodes[j];
                    j = j - 1;
                }
                listNodes[j + 1] = key;
            }
            for (int i = 0; i < listNodes.Count; i++)
            {
                if (i == listNodes.Count - 1)
                {
                    listNodes[i].next = null;
                }
                else
                {
                    listNodes[i].next = listNodes[i + 1];
                }
            }
            return listNodes[0];
        }
        // скопировано с leetcode
        private ListNode optimalAlgorithm(ListNode head)
        {
            if (head.next == null)
                return head;

            ListNode emptFirst = new ListNode(-1, head);
            ListNode prev = head;
            ListNode curr = head.next;
            while (curr != null)
            {
                if (curr.val >= prev.val)
                {
                    prev = curr;
                    curr = curr.next;
                    continue;
                }
                var tmp = emptFirst;
                while (curr.val > tmp.next.val)
                {
                    tmp = tmp.next;
                }
                prev.next = curr.next;
                curr.next = tmp.next;
                tmp.next = curr;
                curr = prev.next;
            }
            return emptFirst.next;
        }
    }
}
