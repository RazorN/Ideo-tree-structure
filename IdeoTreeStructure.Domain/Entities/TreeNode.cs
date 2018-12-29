using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdeoTreeStructure.Domain.Entities
{
    public class TreeNode
    {
        [Key]
        public int NodeID { get; set; }
        public String Content { get; set; }
        public int? ParentID { get; set; }
    }
}
