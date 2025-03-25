using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Basic
{
    public class NodeWithRandomPointer
    {
        public int val;
        public NodeWithRandomPointer next;
        public NodeWithRandomPointer random;

        public NodeWithRandomPointer(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
