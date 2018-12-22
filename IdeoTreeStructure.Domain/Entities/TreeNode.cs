using System;
using System.Collections.Generic;
using System.Text;

namespace IdeoTreeStructure.Domain.Entities
{
    public class TreeNode
    {
        public int NodeID { get; set; }
        public String Content { get; set; }
        public int? ParentID { get; set; }
    }
}
