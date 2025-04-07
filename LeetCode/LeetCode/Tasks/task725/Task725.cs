using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Tasks.task725
{
    /*
     725. Разделить связанный список на части
    Учитывая head односвязного списка и целое число k, разделите связанный список на k последовательных частей.
    Длина каждой части должна быть как можно более одинаковой: размеры двух частей не должны отличаться более чем на единицу. Это может привести к тому, что некоторые части будут нулевыми.
    Части должны располагаться в порядке их появления во входном списке, и части, появляющиеся раньше, всегда должны иметь размер больше или равный частям, появляющимся позже.
    Возвращает массив из k частей.
    Ограничения:
        Количество узлов в списке находится в диапазоне [0, 1000].
        0 <= Node.val <= 1000
        1 <= k <= 50
    https://leetcode.com/problems/split-linked-list-in-parts/description/
     */
    public class Task725 : InfoBasicTask
    {
        public Task725(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode listNode = new ListNode(1, new ListNode(2, new ListNode(3)));
            int k = 5;
            Console.WriteLine($"Исходный связанный список");
            printValuesFromListNode(listNode);
            Console.WriteLine($"Количество частей, на которое необходимо разбить исходный связанный список = {k}");
            if (isValid(listNode, k))
            {
                ListNode[] res = splitListToParts(listNode, k);
                for (int i = 0; i < res.Length; i++)
                {
                    Console.WriteLine($"Связанный список №{i+1}");
                    printValuesFromListNode(res[i]);
                }
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
        private bool isValid(ListNode head, int k)
        {
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = 1000;
            int lowLimitValueNode = 0;
            int highLimitValueNode = 1000;
            int lowLimitValueK = 1;
            int highLimitValueK = 50;
            int countNodes = 0;
            while (head != null)
            {
                if (head.val < lowLimitValueNode || head.val > highLimitValueNode)
                {
                    return false;
                }
                head = head.next;
                countNodes++;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes || k < lowLimitValueK || k > highLimitValueK)
            {
                return false;
            }
            return true;
        }
        private ListNode[] splitListToParts(ListNode head, int k)
        {
            int countElements = 0;
            ListNode dummyHead = head;
            while (head != null) {
                head = head.next;
                countElements++;
            }
            int countElementsInEachPair = countElements / k;
            int countPartWherePlusOne = countElements % k;
            ListNode[] result = new ListNode[k];
            int indexCurrentArr = 0;
            int currentNumberElementInPair = 0;
            ListNode currentHead = null;
            while (dummyHead != null)
            {
                if (currentNumberElementInPair == 0)
                {
                    currentHead = dummyHead;
                }
                currentNumberElementInPair++;
                if (indexCurrentArr < countPartWherePlusOne)
                {
                    if (countElementsInEachPair + 1 == currentNumberElementInPair)
                    {
                        ListNode nextNode = dummyHead.next;
                        dummyHead.next = null;
                        result[indexCurrentArr] = currentHead;
                        indexCurrentArr++;
                        currentNumberElementInPair = 0;
                        dummyHead = nextNode;
                        continue;
                    }
                }
                else
                {
                    if (countElementsInEachPair == currentNumberElementInPair)
                    {
                        ListNode nextNode = dummyHead.next;
                        dummyHead.next = null;
                        result[indexCurrentArr] = currentHead;
                        indexCurrentArr++;
                        currentNumberElementInPair = 0;
                        dummyHead = nextNode;
                        continue;
                    }
                }
                dummyHead = dummyHead.next;
            }
            return result;
        }
    }
}
