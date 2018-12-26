using IdeoTreeStructure.Domain.Abstract;
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

        public ActionResult RemoveNode(int id)
        {
            var removeResult = repository.RemoveNode(id);
            if (removeResult == true)
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
    }
}