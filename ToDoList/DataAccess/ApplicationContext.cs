using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoTask>()
                .Property(x => x.Id)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .IsRequired();

            modelBuilder.Entity<ToDoTask>()
            .HasOne<User>(s => s.User)
            .WithMany(g => g.Tasks)
            .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<ToDoTask>()
                .Property(x => x.UserId)
                .IsRequired(false);
        }
    }
}
