using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ToDoApiV3.Models;

namespace ToDoApiV3.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

    }
}
