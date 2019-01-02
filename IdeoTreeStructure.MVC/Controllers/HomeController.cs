using IdeoTreeStructure.Domain.Abstract;
using IdeoTreeStructure.Domain.Entities;
using IdeoTreeStructure.MVC.Models;
using IdeoTreeStructure.MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IdeoTreeStructure.MVC.Controllers
{
    public class HomeController : Controller
    {
        private ITreeNodeRepository repository;

        public HomeController(ITreeNodeRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index(string sortParam = "id")
        {
            var treeRoot = new TreeElement().CreateTreeFromFlatNodes(repository.TreeNodes.ToList());

            switch (sortParam)
            {
                case "alp":
                    treeRoot.SortTreeNodes(e => e.Content);
                    break;
                case "id":
                    treeRoot.SortTreeNodes(e => e.Id.ToString());
                    break;
                case "childam":
                    treeRoot.SortTreeNodes(e => e.Children.Count.ToString());
                    break;
            }

            return View(treeRoot);
        }

        public ActionResult AddView()
        {
            return View();
        }

        public ActionResult EditView(int idToEdit)
        {
            var editNode = repository.TreeNodes.SingleOrDefault(m => m.NodeID == idToEdit);
            if(editNode == null)
            {
                return View("Error", new ErrorModel { Message = "Node with id " + idToEdit + " not found" });
            }

            var update = new TreeUpdateElement()
            {
                IdToUpdate = idToEdit,
                NewContent = editNode.Content,
                NewParentID = editNode.ParentID
            };

            return View(update);
        }  
    }
}