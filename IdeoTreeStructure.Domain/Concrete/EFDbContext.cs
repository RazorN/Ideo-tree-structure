using IdeoTreeStructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeoTreeStructure.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<TreeNode> Nodes { get; set; }
    }
}
