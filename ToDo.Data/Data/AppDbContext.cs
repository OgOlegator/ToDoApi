using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Hosting;
using ToDos.Core.Models;

namespace ToDos.Persistence.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDo>().HasData(new ToDo
            {
                Id = "1",
                Name = "Test 1"
            });

            modelBuilder.Entity<ToDo>().HasData(new ToDo
            {
                Id = "2",
                Name = "Test 2"
            });

            modelBuilder.Entity<ToDo>().HasData(new ToDo
            {
                Id = "3",
                Name = "Test 3"
            });
        }

    }
}
