using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bikeshop.Models
{
    public class AppDbContext : IdentityDbContext<Customer>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Elke table definieëren we als een DbSet property
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShoppingBag> ShoppingBags { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
