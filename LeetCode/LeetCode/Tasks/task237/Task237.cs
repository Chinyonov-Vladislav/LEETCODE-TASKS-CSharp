using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task237
{
    /*
     237. Удалить узел из связанного списка
    У нас есть односвязный список head, и мы хотим удалить из него узел node.
    Вам предоставлен удаляемый узел node. Вам не будет предоставлен доступ к первому узлу head.
    Все значения связанного списка уникальны, и гарантируется, что заданный узел node не является последним узлом в связанном списке.
    Удалите данный узел. Обратите внимание, что под удалением узла мы подразумеваем не удаление его из памяти. Мы имеем в виду:
        Значение данного узла не должно существовать в связанном списке.
        Количество узлов в связанном списке должно уменьшиться на единицу.
        Все значения перед node должны быть в одном порядке.
        Все значения после node должны быть в том же порядке.
    Индивидуальное тестирование:
        В качестве входных данных вы должны предоставить весь связанный список head и заданный узел node. node не должен быть последним узлом списка и должен быть реальным узлом в списке.
        Мы создадим связанный список и передадим узел вашей функции.
        Результатом будет весь список после вызова вашей функции.
    Ограничения:
        Количество узлов в данном списке находится в диапазоне [2, 1000].
        -1000 <= Node.val <= 1000
        Значение каждого узла в списке уникально.
        Удаляемый node находится в списке и не является хвостовым узлом.
    https://leetcode.com/problems/delete-node-in-a-linked-list/description/
     */
    public class Task237 : InfoBasicTask
    {
        public Task237(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            ListNode deletedNode = new ListNode(5);
            List<ListNode> listNodes = new List<ListNode>() { new ListNode(4), deletedNode, new ListNode(1), new ListNode(9) };
            for (int i = 0; i < listNodes.Count; i++)
            {
                listNodes[i].next = i != listNodes.Count - 1 ? listNodes[i + 1] : null;
            }
            Console.WriteLine("Исходный связанный список");
            printValuesFromListNode(listNodes[0]);
            if (isValid(listNodes[0], deletedNode))
            {
                for (int i = 0; i < listNodes.Count; i++)
                {
                    if (listNodes[i] == deletedNode)
                    {
                        Console.WriteLine($"Номер узла для удаления = {i}. Значение в узле для удаления = {listNodes[i].val}");
                        break;
                    }
                }
                deleteNode(deletedNode);
                Console.WriteLine("Связанный список после удаления узла");
                printValuesFromListNode(listNodes[0]);
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
        private bool isValid(ListNode head, ListNode deletedNode)
        {
            int lowLimit = -1000;
            int highLimit = 1000;
            List<int> values = new List<int>();
            int countNodes = 0;
            bool isExistDeletedNode = false;
            while (head != null)
            {
                if (head == deletedNode)
                {
                    isExistDeletedNode = true;
                }
                if (head == deletedNode && head.next == null)
                {
                    return false;
                }
                countNodes++;
                if (head.val < lowLimit || head.val > highLimit)
                {
                    return false;
                }
                values.Add(head.val);
                head = head.next;
            }
            if (!isExistDeletedNode)
            {
                return false;
            }
            if (countNodes < lowLimit || countNodes > highLimit)
            {
                return false;
            }
            HashSet<int> set = new HashSet<int>(values);
            if(set.Count != values.Count)
            {
                return false;
            }
            return true;
        }
        private void deleteNode(ListNode node)
        {
            while (true)
            {
                node.val = node.next.val;
                if (node.next.next == null)
                {
                    node.next = null;
                    break;
                }
                else
                {
                    node = node.next;
                }
            }
        }
    }
}
