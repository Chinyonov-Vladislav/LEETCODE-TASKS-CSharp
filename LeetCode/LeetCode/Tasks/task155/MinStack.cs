using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Tasks.task155
{
    public class MinStack
    {
        Stack<int> stack;
        Stack<int> minStack;
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            if (minStack.Count == 0)
            {
                minStack.Push(val);
            }
            else
            {
                int currentMin = minStack.Peek();
                if (currentMin > val)
                {
                    minStack.Push(val);
                }
                else
                {
                    minStack.Push(currentMin);
                }
            }
            stack.Push(val);
        }

        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
