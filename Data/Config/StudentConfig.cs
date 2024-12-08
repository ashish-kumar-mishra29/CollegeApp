using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CollegeApp.Data.Config;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students"); // this is the table
        builder.HasKey(x => x.Id); // this is the primary key
        builder.Property(x => x.Id).UseIdentityColumn();
        
        builder.Property(n =>n.StudentName).HasMaxLength(50).IsRequired();
        builder.Property(n =>n.Address).IsRequired(false).HasMaxLength(100);
        builder.Property(n => n.Email).IsRequired().HasMaxLength(100);
        
        builder.HasData(new List<Student>()
        {
            new Student
            {
                Id = 1, 
                StudentName = "Ashish", 
                Address = "India", 
                Email = "ashish@gmail.com",
                DOB = new DateTime(2001,1,2),
            },
            new Student
            {
                Id = 2, 
                StudentName = "James", 
                Address = "London", 
                Email = "james@gmail.com",
                DOB = new DateTime(1997,4,21),
            },
        });
        
        //Foreign key configurations
        builder.HasOne( n=> n.Department).WithMany(n=>n.Students).HasForeignKey(n=>n.DepartmentId)
            .HasConstraintName("FK_Students_Departments");
    }
}