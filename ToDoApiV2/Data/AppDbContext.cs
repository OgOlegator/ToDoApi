using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ToDoApiV2.Models;

namespace ToDoApiV2.Data
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
