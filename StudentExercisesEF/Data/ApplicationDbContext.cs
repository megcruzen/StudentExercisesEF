using Microsoft.EntityFrameworkCore;
using StudentExercisesEF.Models;

namespace StudentExercisesEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Student> Student { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Cohort> Cohort { get; set; }
        public DbSet<StudentExercise> StudentExercise { get; set; }
    }
};
