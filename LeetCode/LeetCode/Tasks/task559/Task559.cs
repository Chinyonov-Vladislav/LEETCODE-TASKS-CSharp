using LeetCode.Basic;
using System;
using System.Collections.Generic;

namespace LeetCode.Tasks.task559
{
    public class Task559 : InfoBasicTask
    {
        public Task559(int number, string name, string description, Difficult difficult) : base(number, name, description, difficult)
        {
        }

        public override void execute()
        {
            Node root = new Node(1, new List<Node>() { new Node(3, new List<Node>() { new Node(5), new Node(6) }), new Node(2), new Node(4) });
            int maxDepthOfTree = maxDepth(root);
            Console.WriteLine($"Максимальная глубина дерева = {maxDepthOfTree}");
        }

        public override void testing()
        {
            throw new NotImplementedException();
        }
        private int maxDepth(Node root)
        { 
            if (root == null)
            {
                return 0;
            }
            int maxDepth = 0;
            travel(root, 0, ref maxDepth);
            return maxDepth;
        }
        private void travel(Node root, int currentDepth, ref int maxDepth)
        {
            
            currentDepth++;
            Console.WriteLine($"Текущее значение узла = {root.val} | Текущий уровень = {currentDepth}");
            if (currentDepth > maxDepth)
            {
                maxDepth = currentDepth;
            }
            if (root.children == null)
            {
                return;
            }
            for (int i = 0; i < root.children.Count; i++)
            {
                travel(root.children[i], currentDepth, ref maxDepth);
            }
        }
    }
}
