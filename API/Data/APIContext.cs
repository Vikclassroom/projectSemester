using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<AccountModel> AccountModel { get; set; }

        public DbSet<ListModel> ListModel { get; set; }

        public DbSet<DeleteModel> DeleteModel { get; set; }
    }
}
