using IdeoTreeStructure.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(repository.TreeNodes);
        }
    }
}