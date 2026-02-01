using Community.core.Models;
using Microsoft.EntityFrameworkCore;

namespace Community.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Courses> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=Community");


        }
    }
}

