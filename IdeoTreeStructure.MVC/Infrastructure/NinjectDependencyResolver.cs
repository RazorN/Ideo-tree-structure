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
                new TreeNode {NodeID = 2, Content = "Node2", ParentID = null},
                new TreeNode {NodeID = 3, Content = "Node1", ParentID = 0},
                new TreeNode {NodeID = 4, Content = "Node1", ParentID = 0},
                new TreeNode {NodeID = 5, Content = "Node1", ParentID = 0},
                new TreeNode {NodeID = 6, Content = "Node1", ParentID = 3},
                new TreeNode {NodeID = 7, Content = "Node1", ParentID = 3},
            });
            kernel.Bind<ITreeNodeRepository>().ToConstant(mock.Object);
        }
    }
}