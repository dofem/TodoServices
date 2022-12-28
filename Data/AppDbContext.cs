using Microsoft.EntityFrameworkCore;

using TodoServices.Model;

namespace TodoServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        { 

        }

        public  DbSet<User>Users { get; set; }
        public DbSet<Tasks>Taskss { get; set; }


       
    }
}
