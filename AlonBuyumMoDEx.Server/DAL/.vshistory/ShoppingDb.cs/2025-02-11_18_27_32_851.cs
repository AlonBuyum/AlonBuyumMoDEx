using Microsoft.EntityFrameworkCore;

namespace AlonBuyumMoDEx.Server.DAL
{
    public class ShoppingDb: DbContext
    {
        public ShoppingDb(DbContextOptions<ShoppingDb> options) : base(options)
        {
        }
        public DbSet<Models.Category> Categories { get; set; }
    }
}
