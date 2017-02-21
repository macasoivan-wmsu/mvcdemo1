using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo.dal
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
     {
   
    }
      public DbSet <User> Users { get; set; }
    }
}
