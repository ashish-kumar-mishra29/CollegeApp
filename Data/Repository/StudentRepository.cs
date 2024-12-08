using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository;
// If user want to add other functionality other than common functionality we can do like this.
public class StudentRepository : CollegeRepository<Student>, IStudentRepository
{
    private readonly CollegeDBContext _context;
  
    public StudentRepository( CollegeDBContext context) : base(context) // By using base we can pass parameter from child to parent
    {
        _context = context;
       
    }
}