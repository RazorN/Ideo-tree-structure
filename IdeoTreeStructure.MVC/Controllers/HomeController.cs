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
            var update = new TreeUpdateElement();

            update.IdToUpdate = idToEdit;
            update.NewContent = editNode.Content;
            update.NewParentID = editNode.ParentID;
            return View(update);
        }

        public ActionResult RemoveNode(int id)
        {
            var removeResult = repository.RemoveNode(id);
            if (!removeResult.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        public ActionResult AddNode(TreeNode newNode)
        {
            var addedNode = repository.AddNode(newNode);
            return Redirect("Index");
        }

        public ActionResult EditNode(TreeUpdateElement modfiedNode)
        {
            var editedNode = repository.TreeNodes.FirstOrDefault(m => m.NodeID == modfiedNode.IdToUpdate);
            if (!editedNode.Equals(null))
            {
                editedNode.Content = modfiedNode.NewContent;
                editedNode.ParentID = modfiedNode.NewParentID;
                repository.EditNode(editedNode);
                return Redirect("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}