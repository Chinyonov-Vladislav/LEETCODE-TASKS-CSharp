using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task382
{
    public class Solution
    {
        private List<int> list;
        private Random rnd;
        public Solution(ListNode head)
        {
            rnd = new Random();
            list = new List<int>();
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }
        }

        public int GetRandom()
        {
            return list[rnd.Next(0, list.Count)];
        }
    }
}
