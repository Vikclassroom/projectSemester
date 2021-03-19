using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Music> Musics { get; set; }
    }
}
