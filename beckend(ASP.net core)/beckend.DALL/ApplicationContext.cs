using beckend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace beckend.DALL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> UsersContext { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=fitnesDB;Username=postgres;Password=123");
        }


    }
}
