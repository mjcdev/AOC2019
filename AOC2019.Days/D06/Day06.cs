using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2019.Days.D06
{
    public class Day06
    {
        private const string CentreOfMass = "COM";

        public int CalculateTotalNumberOfOrbits(IEnumerable<InputModel> inputModels)
        {
            var treeNode = CreateTree(inputModels);

            var flattened = FlattenTree(treeNode, new List<TreeNode>());

            return flattened.Sum(f => f.Depth);
        }

        public TreeNode CreateTree(IEnumerable<InputModel> inputModels)
        {
            var inputModelsList = inputModels.ToList();

            var rootTreeNode = new TreeNode(CentreOfMass, null);

            return PopulateChildrenRecursive(rootTreeNode, inputModelsList);
        }

        public TreeNode PopulateChildrenRecursive(TreeNode node, IEnumerable<InputModel> inputModels)
        {
            var orbits = inputModels.Where(i => i.Centre == node.Value).Select(i => i.Orbit).ToList();

            foreach (var orbit in orbits)
            {
                node.Children.Add(new TreeNode(orbit, node));
            }

            foreach (var child in node.Children)
            {
                PopulateChildrenRecursive(child, inputModels);
            }

            return node;
        }

        public List<TreeNode> FlattenTree(TreeNode node, List<TreeNode> flattened)
        {
            flattened.Add(node);

            foreach (var child in node.Children)
            {
                FlattenTree(child, flattened);
            }
            
            return flattened;
        }

    }
}
