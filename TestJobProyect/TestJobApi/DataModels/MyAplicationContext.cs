using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestJobApi.DataModels
{
    public class MyAplicationContext:DbContext
    {
        public MyAplicationContext(DbContextOptions<MyAplicationContext> options)
       : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<UserApp> User { get; set; }
    }
}
