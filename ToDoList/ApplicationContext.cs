using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ToDoList
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; } = null!;
        public ApplicationContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoTask>()
                .Property(x => x.Id)
                .IsRequired();          
        }
    }
}
