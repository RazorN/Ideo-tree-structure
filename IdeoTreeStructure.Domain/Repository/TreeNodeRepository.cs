using IdeoTreeStructure.Domain.Abstract;
using IdeoTreeStructure.Domain.Concrete;
using IdeoTreeStructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeoTreeStructure.Domain.Repository
{
    public class TreeNodeRepository : ITreeNodeRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<TreeNode> TreeNodes
        {
            get { return context.Nodes; }
        }
        

        public TreeNode RemoveNode(int removeId)
        {
            var objToRemove = context.Nodes.SingleOrDefault(nodes => nodes.NodeID == removeId);
            var deleted = context.Nodes.Remove(objToRemove);
            context.SaveChanges();
            return deleted;
        }

        public TreeNode AddNode(TreeNode node)
        {
            var addedNode = context.Nodes.Add(node);
            context.SaveChanges();
            return addedNode;
        }

        public TreeNode EditNode(TreeNode modfiedNode)
        {
            var objToEdit = context.Nodes.SingleOrDefault(nodes => nodes.NodeID == modfiedNode.NodeID);
            objToEdit.Content = modfiedNode.Content;
            objToEdit.ParentID = modfiedNode.ParentID;

            context.SaveChanges();
            return objToEdit;
        }
    }
}
