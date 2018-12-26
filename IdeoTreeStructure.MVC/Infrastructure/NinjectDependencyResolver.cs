using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdeoTreeStructure.Domain.Abstract;
using IdeoTreeStructure.Domain.Entities;

namespace IdeoTreeStructure.MVC.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            // Mock data base
            var mock = new Mock<ITreeNodeRepository>();
            mock.Setup(m => m.TreeNodes).Returns(new List<TreeNode>
            {
                new TreeNode {NodeID = 0, Content = "Node1", ParentID = null},
                new TreeNode {NodeID = 1, Content = "Node2", ParentID = null},
                new TreeNode {NodeID = 2, Content = "Node3", ParentID = null},
                new TreeNode {NodeID = 3, Content = "Node4", ParentID = 0},
                new TreeNode {NodeID = 4, Content = "Node5", ParentID = 0},
                new TreeNode {NodeID = 5, Content = "Node6", ParentID = 0},
                new TreeNode {NodeID = 6, Content = "Node7", ParentID = 3},
                new TreeNode {NodeID = 7, Content = "Node8", ParentID = 3},
                new TreeNode {NodeID = 8, Content = "Node9", ParentID = 7},
                new TreeNode {NodeID = 9, Content = "Node10", ParentID = null}
            });
            mock.Setup(m => m.RemoveNode(It.IsAny<int>())).Returns(true);
            kernel.Bind<ITreeNodeRepository>().ToConstant(mock.Object);
        }
    }
}