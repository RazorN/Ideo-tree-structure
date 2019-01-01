using IdeoTreeStructure.Domain.Entities;
using IdeoTreeStructure.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeoTreeStructure.MVC.Utils
{
    public static class TreeUtils
    {
        public static void SortTreeNodes(this TreeElement root, Func<TreeElement,string> keySelector)
        {
            root.Children = root.Children.OrderBy(keySelector).ToList();
            foreach(var node in root.Children)
            {
                node.SortTreeNodes(keySelector);
            }
        }

        public static TreeElement CreateTreeFromFlatNodes(this TreeElement root, List<TreeNode> flatNodes)
        {
            var treeElements = new List<TreeElement>();

            foreach (var node in flatNodes)
            {
                treeElements.Add(new TreeElement(node));
            }

            root.BuildTree(treeElements);

            return root;
        }

        private static TreeElement BuildTree(this TreeElement root, List<TreeElement> elements)
        {
            if(elements.Count == 0)
            {
                return root;
            }

            var children = root.FetchChildren(elements).ToList();
            root.Children.AddRange(children);
            root.RemoveChildren(elements);

            for(int i = 0; i < children.Count; i++)
            {
                children[i] = children[i].BuildTree(elements);
                if(elements.Count == 0)
                {
                    break;
                }
            }

            return root;
        }

        private static IEnumerable<TreeElement> FetchChildren(this TreeElement root, List<TreeElement> elements)
        {
            return elements.Where(n => n.ParentId == root.Id);
        }

        private static void RemoveChildren(this TreeElement root, List<TreeElement> elements)
        {
            foreach(var el in root.Children)
            {
                elements.Remove(el);
            }
        }
    }
}