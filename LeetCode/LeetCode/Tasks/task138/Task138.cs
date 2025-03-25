using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task138
{
    /*
     138. Скопировать список со случайным указателем
    Дан связанный список длиной n, в котором каждый узел содержит дополнительный случайный указатель, который может указывать на любой узел в списке или null.
    Создайте глубокую копию списка. Глубокая копия должна состоять ровно из n совершенно новых узлов, где значение каждого нового узла равно значению соответствующего исходного узла. И next и random указатели новых узлов должны указывать на новые узлы в скопированном списке так, чтобы указатели в исходном списке и скопированном списке представляли одно и то же состояние списка. Ни один из указателей в новом списке не должен указывать на узлы в исходном списке.
        Например, если в исходном списке есть два узла X и Y, где X.random --> Y, то для соответствующих двух узлов x и y в скопированном списке x.random --> y.
    Возврат начало скопированного связанного списка.
    Связанный список представлен на входе/выходе в виде списка из n узлов. Каждый узел представлен в виде пары из [val, random_index] где:
        val: целое число , представляющее Node.val
        random_index: индекс узла (диапазон от 0 до n-1), на который указывает random указатель, или null если он не указывает ни на один узел.
    Ваш код будет только использовать head исходный связанный список.
    Ограничения:
        0 <= n <= 1000
        -10^4 <= Node.val <= 10^4
        Node.random является null или указывает на некоторый узел в связанном списке.
    https://leetcode.com/problems/copy-list-with-random-pointer/description/
     */
    public class Task138 : InfoBasicTask
    {
        public Task138(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            NodeWithRandomPointer node0 = new NodeWithRandomPointer(7);
            NodeWithRandomPointer node1 = new NodeWithRandomPointer(13);
            NodeWithRandomPointer node2 = new NodeWithRandomPointer(11);
            NodeWithRandomPointer node3 = new NodeWithRandomPointer(10);
            NodeWithRandomPointer node4 = new NodeWithRandomPointer(1);
            node0.next = node1;
            node0.random = null;
            node1.next = node2;
            node1.random = node0;
            node2.next = node3;
            node2.random = node4;
            node3.next = node4;
            node3.random = node2;
            node4.next =null;
            node4.random = node1;
            printLinkedListWithRandomPointerNode(node0);
            if (isValid(node0))
            {
                NodeWithRandomPointer res = copyRandomList(node0);
                printLinkedListWithRandomPointerNode(res, "Результирующий связанный список со случайным указателем на узел в каждом узле");
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
        private bool isValid(NodeWithRandomPointer head)
        {
            int lowLimitCountNodes = 0;
            int highLimitCountNodes = 1000;
            int lowLimitValueNode = -1* (int)Math.Pow(10, 4);
            int highLimitValueNode = (int)Math.Pow(10,4);
            NodeWithRandomPointer dummyHead = head;
            HashSet<NodeWithRandomPointer> nodesSet = new HashSet<NodeWithRandomPointer>(); ;
            while (head != null)
            {
                if (head.val < lowLimitValueNode || head.val > highLimitValueNode)
                {
                    return false;
                }
                nodesSet.Add(head);
                head = head.next;
            }
            if (nodesSet.Count < lowLimitCountNodes || nodesSet.Count > highLimitCountNodes)
            {
                return false;
            }
            while (dummyHead != null)
            {
                NodeWithRandomPointer randomPointerNode = dummyHead.random;
                if (!(randomPointerNode == null || nodesSet.Contains(randomPointerNode)))
                {
                    return false;
                }
            }
            return true;
        }
        private NodeWithRandomPointer copyRandomList(NodeWithRandomPointer head)
        {
            Dictionary<NodeWithRandomPointer, NodeWithRandomPointer> dict = new Dictionary<NodeWithRandomPointer, NodeWithRandomPointer>();
            NodeWithRandomPointer dummyOriginalHead = head;
            while (head != null)
            {
                dict.Add(head, new NodeWithRandomPointer(head.val));
                head = head.next;
            }
            NodeWithRandomPointer copyHead = null;
            NodeWithRandomPointer dummyCopyHead = null;
            while (dummyOriginalHead != null)
            {
                if (copyHead == null)
                {
                    copyHead = dict[dummyOriginalHead];
                    dummyCopyHead = copyHead;
                }
                if (dummyOriginalHead.next != null)
                {
                    copyHead.next = dict[dummyOriginalHead.next];
                }
                else
                {
                    copyHead.next = null;
                }
                if (dummyOriginalHead.random != null)
                {
                    copyHead.random = dict[dummyOriginalHead.random];
                }
                else
                {
                    copyHead.random = null;
                }
                dummyOriginalHead = dummyOriginalHead.next;
                copyHead = copyHead.next;
            }
            return dummyCopyHead;
        }
    }
}
