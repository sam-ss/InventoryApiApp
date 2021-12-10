using InventoryApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApiApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Inventory> Inventorys { get; set; }
    }
}
