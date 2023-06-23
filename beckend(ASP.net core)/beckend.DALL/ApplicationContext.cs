using beckend.Domain.Models;
using beckend.Domain.Models.Exercises;
using Microsoft.EntityFrameworkCore;

namespace beckend.DALL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> UsersContext { get; set; }
        /// <summary>
        /// таблица упражнений
        /// </summary>
        public DbSet<Exercise> ExercisesDb { get; set; }
        /// <summary>
        /// таблица упражнений с нагрузкой
        /// </summary>
        public DbSet<PersonalExercise> PersonalExercisesDb { get; set; }
        /// <summary>
        /// тренировочный день
        /// </summary>
        public DbSet<Workout> workoutsDb { get; set; }
        /// <summary>
        /// комплекс тренировок
        /// </summary>
        public DbSet<SetWorckout> setWorckoutsDb { get; set; }

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
