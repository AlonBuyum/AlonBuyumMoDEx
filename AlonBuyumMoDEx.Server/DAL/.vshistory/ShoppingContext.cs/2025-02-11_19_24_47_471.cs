using AlonBuyumMoDEx.Server.Models;

using Microsoft.EntityFrameworkCore;

using SQLitePCL;

namespace AlonBuyumMoDEx.Server.DAL
{
    public class ShoppingContext: DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            Batteries.Init();
            optionsBuilder.UseSqlite("Data Source=shopping.db");
        }
    }
}
