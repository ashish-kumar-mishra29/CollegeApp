using CollegeApp.Models;

namespace CollegeApp.Repository
{
    public class collegeRepository
    {
        public static List<Student> Students { get; set; } = new List<Student>()
        {
             new Student
                {
                    Id = 1,
                    StudentName = "Ashish",
                    Email = "ashish1@gmail.com",
                    Address = "Guj, INDIA"
                },
                new Student
                {
                    Id = 2,
                    StudentName = "Ankit",
                    Email = "ankit1@gmail.com",
                    Address = "UP, INDIA"
                }
        };
    }
}
