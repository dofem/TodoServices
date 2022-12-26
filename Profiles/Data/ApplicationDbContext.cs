using Microsoft.EntityFrameworkCore;

using TodoServices.Model;

namespace TodoServices.Profiles.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }



    }
}
