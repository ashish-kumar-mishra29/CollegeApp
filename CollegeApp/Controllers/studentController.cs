using CollegeApp.Dto;
using CollegeApp.Models;
using CollegeApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        [HttpGet("All")]
        public ActionResult<IEnumerable<studentDto>> GetStudents()
        {
            var student = collegeRepository.Students.Select(n => new studentDto()
            {
                Id = n.Id,
                StudentName= n.StudentName,
                Address= n.Address,
                Email= n.Email,
            });
            return Ok(student);
        }

        [HttpGet("{Id:int}", Name = "GetStudentById")]
        public ActionResult<studentDto> GetStudentById(int Id)
        {
            if(Id<=0)
            {
                return BadRequest("Id is less than zero");
            }
            var student = collegeRepository.Students.Where(n => n.Id == Id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = new studentDto
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                Email = student.Email,
            };
            return Ok(studentDTO);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<studentDto> CreateStudent([FromBody]studentDto model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            int newId = collegeRepository.Students.LastOrDefault().Id + 1;
            Student student = new Student
            {
                Id = newId,
                StudentName = model.StudentName,
                Address = model.Address,
                Email = model.Email,
            };
            collegeRepository.Students.Add(student);
            model.Id = student.Id;
            
            return CreatedAtRoute("GetStudentById", new {id = model.Id},model);
            
        }

        [HttpGet("by-name/{name:alpha}", Name = "GetStudentByName")]
        public ActionResult<studentDto> GetStudentByName(string name)
        {
            var student = collegeRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();
            if (student == null) { return NotFound("Name of student is not available"); }
            var studentDTO = new studentDto
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                Email = student.Email,
            };
            return Ok(studentDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteStudentById(int Id)
        {
            var student = collegeRepository.Students.Where(n => n.Id == Id).FirstOrDefault();
            if(student == null)
            {
                return BadRequest();
            }
            collegeRepository.Students.Remove(student);

            return true;
        }
    }
}
