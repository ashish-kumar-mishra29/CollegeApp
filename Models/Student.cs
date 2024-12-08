using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeApp.Data;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string StudentName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }

    public DateTime DOB { get; set; }
    
    public int? DepartmentId { get; set; }
    public virtual Department? Department { get; set; }
}