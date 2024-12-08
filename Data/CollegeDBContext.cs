using CollegeApp.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data;

public class CollegeDBContext : DbContext
{
    public CollegeDBContext(DbContextOptions<CollegeDBContext> options) : base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }

    //TO seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Table 1
        modelBuilder.ApplyConfiguration(new StudentConfig()); // Here we are importing data from the studentConfigi

        modelBuilder.ApplyConfiguration(new DepartmentConfig());
        //Table 2: This is the easy way to create table and seed data

    }
}