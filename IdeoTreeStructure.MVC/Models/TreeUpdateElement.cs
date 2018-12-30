using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdeoTreeStructure.MVC.Models
{
    public class TreeUpdateElement
    {
        public int IdToUpdate { get; set; }
        public string NewContent { get; set; }
        public int? NewParentID { get; set; }
    }
}