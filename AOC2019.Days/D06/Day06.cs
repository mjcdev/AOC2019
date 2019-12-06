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

        public int NumberOfOrbitalJumpsBetween(string start, string end, IEnumerable<InputModel> inputModels)
        {
            var treeNode = CreateTree(inputModels);

            var flattened = FlattenTree(treeNode, new List<TreeNode>());

            var startNode = flattened.First(f => f.Value == start);

            var endNode = flattened.First(f => f.Value == end);

            var startParents = GetPathToCentreOfMassFromNode(startNode).ToArray();
            var endParents = GetPathToCentreOfMassFromNode(endNode).ToArray();

            for (var startIndex = 0; startIndex < startParents.Length; startIndex++)
            {
                for (var endIndex = 0; endIndex < endParents.Length; endIndex++)
                {
                    if (startParents[startIndex] == endParents[endIndex])
                    {
                        return startIndex + endIndex;
                    }
                }
            }

            return 0;
        }

        public IEnumerable<string> GetPathToCentreOfMassFromNode(TreeNode node)
        {
            var parents = new List<string>();

            var currentNode = node;

            while(currentNode.Parent != null)
            {
                parents.Add(currentNode.Parent.Value);
                currentNode = currentNode.Parent;
            }

            return parents;
        }

    }
}
