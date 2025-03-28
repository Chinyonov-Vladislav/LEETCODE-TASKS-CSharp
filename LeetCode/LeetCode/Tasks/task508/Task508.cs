using LeetCode.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task508
{
    /*
     508. Наиболее часто встречающаяся сумма поддеревьев
    Учитывая root двоичного дерева, верните наиболее часто встречающуюся сумму поддеревьев. Если есть несколько вариантов, верните все значения с наибольшей частотой в любом порядке.
    Сумма поддерева узла определяется как сумма значений всех узлов поддерева с корнем в этом узле (включая сам узел).
    Ограничения:
        Количество узлов в дереве находится в диапазоне [1, 10^4].
        -10^5 <= Node.val <= 10^5
    https://leetcode.com/problems/most-frequent-subtree-sum/description/
     */
    public class Task508 : InfoBasicTask
    {
        public Task508(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            TreeNode root = new TreeNode(5, new TreeNode(2), new TreeNode(-5));
            Console.WriteLine("Исходное бинарное дерево");
            printTreeNode(root);
            if (isValid(root))
            {
                int[] res = findFrequentTreeSum(root);
                printArray(res, "Наиболее часто встречающиеся суммы поддеревьев: ");
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
        private bool isValid(TreeNode root)
        {
            int lowLimitCountNodes = 1;
            int highLimitCountNodes = (int)Math.Pow(10,4);
            int lowLimitValueNode = -1 * (int)Math.Pow(10, 5);
            int highLimitValueNode = (int)Math.Pow(10, 5);
            int countNodes = 0;
            List<TreeNode> nodesOfNextLevel = new List<TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root != null)
            {
                queue.Enqueue(root);
            }
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                countNodes++;
                if (currentNode.val < lowLimitValueNode || currentNode.val > highLimitValueNode)
                {
                    return false;
                }
                if (currentNode.left != null)
                {
                    nodesOfNextLevel.Add(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    nodesOfNextLevel.Add(currentNode.right);
                }
                if (queue.Count == 0)
                {
                    for (int i = 0; i < nodesOfNextLevel.Count; i++)
                    {
                        queue.Enqueue(nodesOfNextLevel[i]);
                    }
                    nodesOfNextLevel.Clear();
                }
            }
            if (countNodes < lowLimitCountNodes || countNodes > highLimitCountNodes)
            {
                return false;
            }
            return true;
        }
        private int[] findFrequentTreeSum(TreeNode root)
        {
            if (root == null)
            {
                return new int[0];
            }
            Dictionary<int, int> freq = new Dictionary<int, int>();
            List<TreeNode> visitedNodes = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode treeNode = stack.Pop();
                if (!visitedNodes.Contains(treeNode))
                {
                    visitedNodes.Add(treeNode);
                }
                if (treeNode.left == null && treeNode.right == null)
                {
                    if (freq.ContainsKey(treeNode.val))
                    {
                        freq[treeNode.val]++;
                    }
                    else
                    {
                        freq.Add(treeNode.val, 1);
                    }
                }
                else if (treeNode.left != null && treeNode.right == null && visitedNodes.Contains(treeNode.left))
                {
                    treeNode.val += treeNode.left.val;
                    if (freq.ContainsKey(treeNode.val))
                    {
                        freq[treeNode.val]++;
                    }
                    else
                    {
                        freq.Add(treeNode.val, 1);
                    }
                }
                else if (treeNode.right != null && treeNode.left == null && visitedNodes.Contains(treeNode.right))
                {
                    treeNode.val += treeNode.right.val;
                    if (freq.ContainsKey(treeNode.val))
                    {
                        freq[treeNode.val]++;
                    }
                    else
                    {
                        freq.Add(treeNode.val, 1);
                    }
                }
                else if(treeNode.left != null && treeNode.right != null && visitedNodes.Contains(treeNode.left) && visitedNodes.Contains(treeNode.right))
                {
                    treeNode.val += treeNode.left.val;
                    treeNode.val += treeNode.right.val;
                    if (freq.ContainsKey(treeNode.val))
                    {
                        freq[treeNode.val]++;
                    }
                    else
                    {
                        freq.Add(treeNode.val, 1);
                    }
                }
                if (treeNode.left != null && !visitedNodes.Contains(treeNode.left))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.left);
                }
                else if (treeNode.right != null && !visitedNodes.Contains(treeNode.right))
                {
                    stack.Push(treeNode);
                    stack.Push(treeNode.right);
                }
            }
            List<int> res = new List<int>();
            
            Dictionary<int,int> orderedDict =freq.OrderByDescending(item => item.Value).ToDictionary(item => item.Key, item => item.Value);
            int max = orderedDict.First().Value;
            foreach (var pair in orderedDict)
            {
                if (pair.Value == max)
                {
                    res.Add(pair.Key);
                }
            }
            res.Sort();
            return res.ToArray();
        }
    }
}
