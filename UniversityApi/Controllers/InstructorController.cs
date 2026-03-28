using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using UniversityApi.Repositories;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController(InstructorRepository instructorRepository) : ControllerBase
    {
        // Implement your code here
        [HttpPost("AddInstructor")]
        public IActionResult AddInstructor([FromBody] Instructor instructor)
        {
            var res = instructorRepository.AddInstructor(instructor);

            if (!res)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("WithCourseCountAbove/{count}")]
        public IActionResult WithCourseCountAbove(int courseCount)
        {
            var result = instructorRepository.GetInstructorsWithCourseCountAbove(courseCount);

            if (result != null && result.Any())
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("WithMostEnrollments")]
        public IActionResult WithMostEnrollments()
        {
            var result = instructorRepository.GetInstructorsWithMostEnrollments();

            if (result != null && result.Any())
            {
                return Ok();
            }

            return NotFound();

        }



    }


}
