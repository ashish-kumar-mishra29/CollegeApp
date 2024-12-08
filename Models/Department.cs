namespace CollegeApp.Data;

public class Department
{
    public int Id { get; set; }
    public string DepartmentName { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Student> Students { get; set; } // I have added collection because 1 dep can have multiple students.
}