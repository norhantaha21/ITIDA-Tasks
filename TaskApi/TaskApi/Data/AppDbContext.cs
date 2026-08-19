using Microsoft.EntityFrameworkCore;
using TaskApi.Configurations;
using TaskApi.Models;

namespace TaskApi.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Users> Users {  get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Users>(entity =>
            //{
            //    entity.HasKey(t => t.Id);
            //    entity.Property(t => t.Name).IsRequired().HasMaxLength(50);
            //});
            //modelBuilder.Entity<Tasks>(entity =>
            //{
            //    entity.HasKey(t => t.Id);
            //    entity.Property(t=>t.Title).IsRequired().HasMaxLength(50);
            //    entity.Property(t => t.Description).IsRequired().HasMaxLength(200);

            //    entity.HasOne(u => u.User).WithMany(t => t.Task).HasForeignKey(t => t.UserId);
            //});
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TasksConfigurations());
        }

    }
}
