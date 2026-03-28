using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Interfaces;
using UniversityApi.Models;
using UniversityApi.Repositories;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(CourseRepository courseRepository) : ControllerBase
    {
        // Implement your code here
        [HttpPut("/UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] Course course)
        {
            var result = courseRepository.UpdateCourse(course);

            if (!result)
            {
                return BadRequest();
            }
            return Ok("Course Updated Successfully");
        }

        [HttpGet("WithEnrollmentsAboveGrade/{grade}")]
        public IActionResult WithEnrollmentsAboveGrade(int grade)
        {
            var result = courseRepository.GetCoursesWithEnrollmentsAboveGrade(grade);

            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NotFound("No Records Found");
        }

        [HttpGet("ByInstructorName/{instructorName}")]
        public IActionResult ByInstructorName(string instructorName)
        {

            var courses = courseRepository.GetCoursesByInstructorName(instructorName);

            if (courses != null && courses.Any())
            {
                return Ok(courses);
            }

            return NotFound();

        }

    }
}