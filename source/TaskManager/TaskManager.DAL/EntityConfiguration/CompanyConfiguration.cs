using TaskManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.DAL.EntityConfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies").HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired();

            builder.HasMany(p => p.Projects)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            builder.HasMany(e => e.Employees)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
