using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D06
{
    public class TreeNode
    {
        public TreeNode(string value, TreeNode parent)
        {
            Value = value;
            Parent = parent;
            Depth = parent?.Depth != null ? parent.Depth + 1 : 0;
            Children = new List<TreeNode>();
        }

        public TreeNode Parent { get; }

        public string Value { get; }

        public int Depth { get; }

        public List<TreeNode> Children { get; }
    }
}
