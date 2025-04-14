using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Basic
{
    public class TwoDirectionalNodeWithChildrens
    {
        public int val;
        public TwoDirectionalNodeWithChildrens prev;
        public TwoDirectionalNodeWithChildrens next;
        public TwoDirectionalNodeWithChildrens child;

        public TwoDirectionalNodeWithChildrens(int val, TwoDirectionalNodeWithChildrens prev = null, TwoDirectionalNodeWithChildrens next = null, TwoDirectionalNodeWithChildrens child = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
            this.child = child;
        }
    }
}
