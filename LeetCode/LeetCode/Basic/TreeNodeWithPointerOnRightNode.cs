using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Basic
{
    public class TreeNodeWithPointerOnRightNode
    {
        public int val;
        public TreeNodeWithPointerOnRightNode left;
        public TreeNodeWithPointerOnRightNode right;
        public TreeNodeWithPointerOnRightNode next;

        public TreeNodeWithPointerOnRightNode() { }

        public TreeNodeWithPointerOnRightNode(int _val)
        {
            val = _val;
        }

        public TreeNodeWithPointerOnRightNode(int _val, TreeNodeWithPointerOnRightNode _left, TreeNodeWithPointerOnRightNode _right, TreeNodeWithPointerOnRightNode _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
