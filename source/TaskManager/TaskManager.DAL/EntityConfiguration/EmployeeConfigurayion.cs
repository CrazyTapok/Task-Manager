using TaskManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace TaskManager.DAL.EntityConfiguration
{
    public class EmployeeConfigurayion : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees").HasKey(k => k.Id);

            builder.Property(p => p.Name).IsRequired();

            builder.HasIndex(p => p.Email).IsUnique();

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany(p => p.Projects)
                .WithMany(e => e.Employees)
                .UsingEntity<Dictionary<string, object>>("Employees_Projects",
                    x => x.HasOne<Project>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    y => y.HasOne<Employee>().WithMany().OnDelete(DeleteBehavior.NoAction));

            builder.HasMany(p => p.Tasks)
                .WithOne(t => t.CreateEmployee)
                .HasForeignKey(t => t.CreateEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
