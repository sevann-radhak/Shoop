namespace Shoop.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using Shoop.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
                
        }
    }
}
