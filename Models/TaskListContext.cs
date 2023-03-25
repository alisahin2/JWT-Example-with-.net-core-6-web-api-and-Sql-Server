using Microsoft.EntityFrameworkCore;

namespace JwtExample.Models
{
    public class TaskListContext : DbContext 
    {
        public TaskListContext(DbContextOptions options) : base(options)
        { }

        public DbSet<TaskLists> TaskLists { get; set; }
    }
}
