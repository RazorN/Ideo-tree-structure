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

        // GET: Home
        public ActionResult Index()
        {
            //This is how new Tree model works
            var treeRoot = new TreeElement().CreateTreeFromFlatNodes(repository.TreeNodes.ToList());

            return View(treeRoot);
        }

        public ActionResult EditView()
        {
            return View();
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
            if (!addedNode.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        public ActionResult EditNode(TreeNode modfiedNode)
        {
            var editedNode = repository.EditNode(modfiedNode);
            if (!editedNode.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}