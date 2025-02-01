using System;
using System.Collections.Generic;
using LeetCode.Basic;

namespace LeetCode.Tasks.Task23
{
    public class Task23 : InfoBasicTask
    {
        public Task23(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
            
        }

        public override void execute()
        {
            ListNode[]  listNodes = new ListNode[] {
                new ListNode(1, new ListNode(4, new ListNode(5))),
                new ListNode(1, new ListNode(3, new ListNode(4))),
                new ListNode(2, new ListNode(6))
            };
            ListNode finalListNode = mergeKLists(listNodes);
            printListNode(finalListNode, 0);
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }

        private ListNode mergeKLists(ListNode[] lists)
        {
            List<int> intValues = new List<int>();
            for (int i = 0; i < lists.Length; i++)
            {
                ListNode currentListNode = lists[i];
                if (currentListNode != null)
                {
                    while (true)
                    {
                        intValues.Add(currentListNode.val);
                        currentListNode = currentListNode.next;
                        if (currentListNode == null)
                        {
                            break;
                        }
                    }
                }
            }
            intValues.Sort();
            if (intValues.Count == 0)
            {
                return null;
                
            }
            ListNode returnedListNode = new ListNode();
            settingListNode(returnedListNode, intValues, 0);
            return returnedListNode;
        }
        private void settingListNode(ListNode currentListNode, List<int> values, int index)
        {
            currentListNode.val = values[index];
            index += 1;
            if (index < values.Count)
            {
                ListNode nextListNode = new ListNode();
                currentListNode.next = nextListNode;
                settingListNode(nextListNode, values, index);
            }
            else
            {
                currentListNode.next = null;
            }
            
        }
        private void printListNode(ListNode listNode, int number)
        {
            if (listNode != null)
            {
                Console.WriteLine($"Номер узла = {number}, Значение = {listNode.val}");
                number += 1;
                printListNode(listNode.next, number);
            }
        }
    }
}
