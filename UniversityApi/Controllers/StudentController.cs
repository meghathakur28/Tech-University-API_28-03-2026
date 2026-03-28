using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using UniversityApi.Repositories;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(StudentRepository studentRepository) : ControllerBase
    {
        // Implement your code here
        [HttpDelete("DeleteStudent/{studentId}")]
        public IActionResult Delete(int id)
        {
            var res = studentRepository.DeleteStudent(id);
            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("ByCourseTitle/{courseTitle}")]
        public IActionResult Get(string courseTitle)
        {
            var result = studentRepository.GetStudentsByCourseTitle(courseTitle);
            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NotFound();

        }

    }
}