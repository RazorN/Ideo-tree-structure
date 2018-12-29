using IdeoTreeStructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeoTreeStructure.Domain.Abstract
{
    public interface ITreeNodeRepository
    {
        IEnumerable<TreeNode> TreeNodes { get; }
        TreeNode RemoveNode(int id);
        TreeNode AddNode(TreeNode node);
        TreeNode EditNode(TreeNode modfiedNode);
    }
}
