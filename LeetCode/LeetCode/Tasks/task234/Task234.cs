using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task234
{
    /*
     234. Связанный список палиндромов
    Учитывая head односвязного списка, верните true если это палиндром иначе false.
     */
    public class Task234 : InfoBasicTask
    {
        public Task234(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode root = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            Console.WriteLine(isPalindrome(root) ? "Связанный список является палиндромом" : "Связанный список не является палиндромом");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private bool isPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }
            List<int> numbers= new List<int>();
            Stack<ListNode> listNodes= new Stack<ListNode>();
            listNodes.Push(head);
            while (listNodes.Count > 0)
            {
                ListNode node= listNodes.Pop();
                numbers.Add(node.val);
                if (node.next != null)
                {
                    listNodes.Push(node.next);
                }
            }
            int left = 0;
            int right = numbers.Count-1;
            while (left <= right)
            {
                if (numbers[left] != numbers[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
