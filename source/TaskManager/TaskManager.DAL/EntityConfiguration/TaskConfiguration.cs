using TaskManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.DAL.EntityConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks").HasKey(k => k.Id);

            builder.Property(p => p.Title).IsRequired();

            builder.Property(p => p.Description);

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.CreatedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.UpdatedDate)
                .HasColumnType("datetime");

        }
    }
}
