using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApi.models.Entities;

namespace RestApi.Data
{
    public class RestApiContext : DbContext
    {
        public RestApiContext (DbContextOptions<RestApiContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Product2> Product2 { get; set; } = default!;
        
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .UseTptMappingStrategy();

            base.OnModelCreating(modelBuilder);
        }*/
    }
}
