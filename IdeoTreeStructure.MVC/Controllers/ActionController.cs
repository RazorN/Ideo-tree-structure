using IdeoTreeStructure.Domain.Abstract;
using IdeoTreeStructure.Domain.Entities;
using IdeoTreeStructure.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IdeoTreeStructure.MVC.Controllers
{
    public class ActionController : Controller
    {
        private ITreeNodeRepository repository;

        public ActionController(ITreeNodeRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult EditNode(TreeUpdateElement modfiedNode)
        {
            var editedNode = repository.TreeNodes.FirstOrDefault(m => m.NodeID == modfiedNode.IdToUpdate);

            if (modfiedNode.NewParentID != null)
            {
                var parentNode = repository.TreeNodes.FirstOrDefault(m => m.NodeID == modfiedNode.NewParentID);
                if (parentNode == null)
                {
                    return View("Error", new ErrorModel { Message = "Parent node not found" });
                }
            }
            if (editedNode == null)
            {
                return View("Error", new ErrorModel { Message = "Node not found" });
            }
            else
            {
                editedNode.Content = modfiedNode.NewContent;
                editedNode.ParentID = modfiedNode.NewParentID;
                repository.EditNode(editedNode);
                return RedirectToAction("Index","Home",null);
            }
        }

        public ActionResult AddNode(TreeNode newNode)
        {
            if (newNode.ParentID != null)
            {
                var parentNode = repository.TreeNodes.FirstOrDefault(n => n.NodeID == newNode.ParentID);
                if (parentNode == null)
                {
                    return View("Error", new ErrorModel { Message = "Paren not found" });
                }
            }
            var addedNode = repository.AddNode(newNode);
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult RemoveNode(int id)
        {
            var removeResult = repository.RemoveNode(id);
            if (!removeResult.Equals(null))
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
    }
}