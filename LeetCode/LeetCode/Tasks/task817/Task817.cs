using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task817
{
    /*
     817. Компоненты связанного списка
    Вам дан head связанный список, содержащий уникальные целочисленные значения, и целочисленный массив nums, который является подмножеством значений связанного списка.
    Верните количество связанных компонентов в nums где два значения связаны, если они появляются последовательно в связанном списке.
    Ограничения:
        Количество узлов в связанном списке равно n.
        1 <= n <= 10^4
        0 <= Node.val < n
        Все значения Node.val являются уникальными.
        1 <= nums.length <= n
        0 <= nums[i] < n
        Все значения nums являются уникальными.
    https://leetcode.com/problems/linked-list-components/description/
     */
    public class Task817 : InfoBasicTask
    {
        public Task817(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode rootNode = new ListNode(0, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
            int[] nums = new int[] {0,3,1,4 };
            Console.WriteLine($"Исходный связанный список");
            printValuesFromListNode(rootNode);
            printArray(nums, "Подмножество значений связанного списка: ");
            if (isValid(rootNode, nums))
            {
                int res = numComponents(rootNode, nums);
                Console.WriteLine($"Количество связанных компонентов в подмножестве, где два значения связаны, если они появляются последовательно в связанном списке = {res}");
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
        private bool isValid(ListNode head, int[] nums)
        {
            int lowLimitValueNum = 0;
            int lowLimitLengthNums = 1;
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = (int)Math.Pow(10, 4);
            ListNode dummyHead = head;
            int countNodes = 0;
            HashSet<int> uniqueValuesFromNodes = new HashSet<int>();
            HashSet<int> uniqueValuesFromNums = new HashSet<int>();
            while (head != null)
            {
                uniqueValuesFromNodes.Add(head.val);
                countNodes++;
                head = head.next;
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            while (dummyHead != null)
            {
                if (dummyHead.val < 0 || dummyHead.val >= countNodes)
                {
                    return false;
                }
                dummyHead = dummyHead.next;
            }
            if (uniqueValuesFromNodes.Count != countNodes)
            {
                return false;
            }
            if (nums.Length < lowLimitLengthNums || nums.Length > countNodes)
            {
                return false;
            }
            foreach (int val in nums)
            {
                uniqueValuesFromNums.Add(val);
                if (val < lowLimitValueNum || val >= countNodes)
                {
                    return false;
                }
            }
            if (uniqueValuesFromNums.Count != nums.Length)
            {
                return false;
            }
            return true;
        }
        private int numComponents(ListNode head, int[] nums)
        {
            int count = 0;
            int countElementsInGroup = 0;
            while (head != null)
            {
                int currentVal = head.val;
                if (nums.Contains(currentVal))
                {
                    countElementsInGroup++;
                }
                else
                {
                    if (countElementsInGroup > 0)
                    {
                        count++;
                        countElementsInGroup = 0;
                    }
                }
                head = head.next;
            }
            if (countElementsInGroup > 0)
            {
                count++;
            }
            return count;
        }
    }
}
