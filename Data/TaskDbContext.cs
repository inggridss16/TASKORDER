using Microsoft.EntityFrameworkCore;
using TASKORDER.Models;

namespace TASKORDER.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
