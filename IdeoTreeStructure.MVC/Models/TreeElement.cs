using IdeoTreeStructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeoTreeStructure.MVC.Models
{
    public class TreeElement
    {
        public int? Id { get; set; }
        public string Content { get; set; }
        public int? ParentId { get; set; }
        public List<TreeElement> Children { get; set; }

        public TreeElement()
        {
            Children = new List<TreeElement>();
        }

        public TreeElement(TreeNode node)
        {
            this.Id = node.NodeID;
            this.Content = node.Content;
            this.ParentId = node.ParentID;
            this.Children = new List<TreeElement>();
        }
    }
}