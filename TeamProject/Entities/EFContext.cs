using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DefaultConnection")
        { }
        public DbSet<User> Users { get; set; }
    }
}
