using System.Xml.Linq;
using AutoMapper;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.Dto;
using CollegeApp.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public StudentController(CollegeDBContext dbContext, IMapper mapper, IStudentRepository studentRepository) 
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        
        [HttpGet("All")]
        //[AllowAnonymous] //This indicates that this api is accessible by everyone.
        public async Task<ActionResult<IEnumerable<studentDto>>> GetStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentDtoData = _mapper.Map<List<studentDto>>(students);//In map always pass the destination object
            return Ok(studentDtoData);
        }

        
        [HttpGet("{Id:int}", Name = "GetStudentById")]
        public async Task<ActionResult<studentDto>> GetStudentById(int Id)
        {
            if(Id<=0)
                return BadRequest("Id is less than zero");
            var student = await _studentRepository.GetByIdAsync(student => student.Id == Id);
            if (student == null)
            {
                return NotFound($"The student with id {Id} was not found.");
            }
            var studentDTO = _mapper.Map<studentDto>(student);
            return Ok(studentDTO);
        }

        
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<studentDto>> CreateStudent([FromBody]studentDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            //This I have done by using custom validator.
  //          if (model.AdmissionDate < DateTime.Now)
  //          {
  //              ModelState.AddModelError("AdmissionDate Error", "Admission Date Must be greater than or equal to the current date");
  //              return BadRequest(ModelState);
   //         }
            Student student = _mapper.Map<Student>(model);
            var newStudent = await _studentRepository.CreateAsync(student);
            model.Id = newStudent.Id;
            return CreatedAtRoute("GetStudentById", new {id = model.Id},model);
            
        }

        
        [HttpGet("by-name/{name:alpha}", Name = "GetStudentByName")]
        public async Task<ActionResult<studentDto>> GetStudentByName(string name)
        {
            var student = await _studentRepository.GetByNameAsync(student => student.StudentName.ToLower().Contains(name.ToLower()));
            if (student == null) { return NotFound("Name of student is not available"); }
            var studentDTO = _mapper.Map<studentDto>(student);
            return Ok(studentDTO);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdateStudent([FromBody] studentDto model)
        {
            if(model == null || model.Id <=0)
            {
                return NotFound();
            }

            var existingStudent = await _studentRepository.GetByIdAsync(n => n.Id == model.Id);
            if(existingStudent == null){
                return NotFound();
            }
            var newStudent = _mapper.Map<Student>(model);
            await _studentRepository.UpdateAsync(newStudent);
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeleteStudentById(int Id)
        {
            var student =await _studentRepository.GetByIdAsync(student => student.Id == Id);
            if(student == null)
            {
                return NotFound();
            }
            await _studentRepository.DeleteAsync(student);
    
            return NoContent();
        }
    }
}
