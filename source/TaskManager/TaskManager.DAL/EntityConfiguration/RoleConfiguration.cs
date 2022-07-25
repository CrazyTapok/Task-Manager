using TaskManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.DAL.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles").HasKey(k => k.Id);

            builder.Property(p => p.Name).IsRequired();

            builder.HasMany(e => e.Employees)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId);
        }
    }
}
