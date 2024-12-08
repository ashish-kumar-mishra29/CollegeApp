using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeApp.Data.Config;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Department");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        
        builder.Property(n =>n.DepartmentName).HasMaxLength(50).IsRequired();
        builder.Property(n =>n.Description).IsRequired(false).HasMaxLength(100);
       
        
        builder.HasData(new List<Department>()
        {
            new Department
            {
                Id = 1, 
                DepartmentName = "CSE", 
                Description = "Computer Science Engineering",
            },
            new Department
            {
                Id = 2, 
                DepartmentName = "EC", 
                Description = "Electronic Engineering"
            },
        });
    }
}