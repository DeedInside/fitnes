using Microsoft.EntityFrameworkCore;
using beckend.Domain.Models;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace beckend.DALL.Repositories
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> UsersContext { get; set; } = null!;

        public ApplicationContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=fitnesDB;Username=postgres;Password=123");
        }

    }
}
