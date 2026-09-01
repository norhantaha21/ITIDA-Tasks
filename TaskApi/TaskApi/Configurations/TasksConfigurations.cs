using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApi.Models;

namespace TaskApi.Configurations
{
    public class TasksConfigurations : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
           builder.HasKey(t => t.Id);
            builder.Property(t=>t.Title).IsRequired().HasMaxLength(50);
            builder.Property(d=>d.Description).IsRequired().HasMaxLength(200);

            //relation
            builder.HasOne(u => u.User).WithMany(t => t.Tasks).HasForeignKey(t=>t.UserId);
        }
    }
}
