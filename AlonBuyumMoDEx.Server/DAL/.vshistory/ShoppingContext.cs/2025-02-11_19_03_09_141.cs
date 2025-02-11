using AlonBuyumMoDEx.Server.Models;

using Microsoft.EntityFrameworkCore;

namespace AlonBuyumMoDEx.Server.DAL
{
    public class ShoppingContext: DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
